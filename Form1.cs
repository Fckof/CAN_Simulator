using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CAN_Simulator
{
    public partial class Form1 : Form
    {
        static bool threadCloser = true;
        Can device = new Can(0);
        WorkPart AR = new WorkPart();
        WorkPart AZ1 = new WorkPart();
        
        public Form1()
        {
            InitializeComponent();
            device.Open(CanOpenFlag.Can11);
            device.SetBaud(CanBaudRate.BCI_125K);
            device.Start();
            
            AR.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar1.Value, trackBar1.Maximum)),
                9,
                StateCode.Ok,
                WorkinPartType.AR
                );
            AZ1.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar2.Value, trackBar2.Maximum)),
                1,
                StateCode.Ok,
                WorkinPartType.AZ
                );
            List<WorkPart> Parts = new List<WorkPart>() { AR, AZ1 };

            Thread thr = new Thread(() => SendCANMessage(Parts.Cast<object>().ToList()));
            thr.Start();
        }
        public int ReverseScrollBar(int value, int maxValue)
        {
            return maxValue-value;
        }
        public StateCode CheckState(bool err, bool errDM)
        {
            if (err && errDM) return StateCode.BothDefect;
            else if (err) return StateCode.Defect;
            else if (errDM) return StateCode.DriveMgmtDefect;
            else return StateCode.Ok;
        }
        
       public void SendCANMessage(List<object> obj)
        {
            var obj1 = (WorkPart)obj[0];
            var obj2 = (WorkPart)obj[1];
            while (threadCloser)
            {
                label3.Text = obj1.ShowMessage(obj1.CompareFirstMsg(), obj1.CompareSecondMsg());
                label14.Text=obj2.ShowMessage(obj2.CompareFirstMsg(), obj2.CompareSecondMsg());
                device.Write(AR.CompareFirstMsg());
                device.Write(AR.CompareSecondMsg());
                Thread.Sleep(100);
            }
            device.Stop();
            device.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = ReverseScrollBar(trackBar1.Value, trackBar1.Maximum).ToString();

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            var trackbar = (TrackBar)sender;
            WorkPart sample= (WorkPart)DefineObject(trackbar.Parent.Tag);
            var textbox = trackbar.Parent.Controls.OfType<TextBox>().First<TextBox>();
            sample.ChangePositionValue(Convert.ToUInt16(ReverseScrollBar(trackbar.Value, trackbar.Maximum)));
            sample.OutputSignalsBUP();
            sample.SetBUPSignalsValue(AR.BitsToByte(sample._BitsArrayBUP));
            textbox.Text= sample._WorkinPartPosition.ToString();
        }
        public object DefineObject(object tag)
        {
            switch (tag)
            {
                case "AR":
                    return AR;
                case "AZ1":
                    return AZ1;
                default:
                    return null;
            }
        }
        

        private void CheckBoxStateManager(object sender, EventArgs e)
        {
            var status = (CheckBox)sender;
            WorkPart sample = (WorkPart)DefineObject(status.Parent.Parent.Tag);
            var checks = status.Parent.Controls.Cast<CheckBox>().ToList();
            sample.SetState(CheckState(checks[1].Checked, checks[0].Checked));
            sample.OutputStatusBUP();
            sample.SetBUPSignalsValue(sample.BitsToByte(sample._BitsArrayBUP));
        }

        private void KSKUSignalsCheck(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            WorkPart sample = (WorkPart)DefineObject(checkbox.Parent.Parent.Tag);
            List<byte> signals = new List<byte>(8);
            var checkboxList = checkbox.Parent.Controls.Cast<CheckBox>().ToList();
            if(checkbox.Parent.Controls.Count<8)
            sample.SetKSKUSignals(sample.BitsToByte(signals));
        }
        
        private void IOSignalsCheck(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            WorkPart sample = (WorkPart)DefineObject(checkbox.Parent.Parent.Tag);
            bool rst=false, deblock = false;
            foreach(CheckBox cb in checkbox.Parent.Controls)
            {
                switch (cb.Tag)
                {
                    case "RstAZ": rst = cb.Checked; break;
                    case "Deblock": deblock = cb.Checked; break;
                }
            }
            if (rst && deblock)
                sample.SetIOSignals((byte)255);
            else if(rst)
                sample.SetIOSignals((byte)127);
            else if(deblock)
                sample.SetIOSignals((byte)128);
            else sample.SetIOSignals(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) { threadCloser = false; }
    }
}
