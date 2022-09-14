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
        WorkPart AZ2 = new WorkPart();
        WorkPart KR1 = new WorkPart();
        WorkPart KR2 = new WorkPart();
        WorkPart KR3 = new WorkPart();
        WorkPart KR4 = new WorkPart();
        WorkPart KR5 = new WorkPart();
        WorkPart KR6 = new WorkPart();
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
            AZ2.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar3.Value, trackBar3.Maximum)),
                2,
                StateCode.Ok,
                WorkinPartType.AZ
                );
            KR1.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar4.Value, trackBar4.Maximum)),
                3,
                StateCode.Ok,
                WorkinPartType.KR
                );
            KR2.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar5.Value, trackBar5.Maximum)),
                4,
                StateCode.Ok,
                WorkinPartType.KR
                );
            KR3.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar6.Value, trackBar6.Maximum)),
                5,
                StateCode.Ok,
                WorkinPartType.KR
                );
            KR4.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar7.Value, trackBar7.Maximum)),
                6,
                StateCode.Ok,
                WorkinPartType.KR
                );
            KR5.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar8.Value, trackBar8.Maximum)),
                7,
                StateCode.Ok,
                WorkinPartType.KR
                );
            KR6.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar9.Value, trackBar9.Maximum)),
                8,
                StateCode.Ok,
                WorkinPartType.KR
                );

            List<WorkPart> Parts = new List<WorkPart>() { AR, AZ1, AZ2, KR1, KR2, KR3, KR4, KR5, KR6 };

            Thread thr = new Thread(
                () => SendCANMessage(Parts.Cast<object>().ToList()));
            thr.Start();
        }
        public object DefineObject(object tag)
        {
            switch (tag)
            {
                case "AR":
                    return AR;
                case "AZ1":
                    return AZ1;
                case "AZ2":
                    return AZ2;
                case "KR1":
                    return KR1;
                case "KR2":
                    return KR2;
                case "KR3":
                    return KR3;
                case "KR4":
                    return KR4;
                case "KR5":
                    return KR5;
                case "KR6":
                    return KR6;
                default:
                    return null;
            }
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
            var samplesList = obj.Cast<WorkPart>().ToList();
            while (threadCloser)
            {
                this.Text = "CAN Simulator KSKU" + device.WriteStatus;
                foreach (WorkPart part in samplesList)
                {
                    device.Write(part.CompareFirstMsg());
                    device.Write(part.CompareSecondMsg());
                }
                Thread.Sleep(100);
            }
            device.Stop();
            device.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var form = (Form1)sender;
            var panels = form.Controls[0].Controls;
            foreach (Panel panel in panels)
            {
                WorkPart smp = (WorkPart)DefineObject(panel.Tag);
                panel.Controls.OfType<TextBox>().First().Text= smp._WorkinPartPosition.ToString();
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            var trackbar = (TrackBar)sender;
            WorkPart sample= (WorkPart)DefineObject(trackbar.Parent.Tag);
            var textbox = trackbar.Parent.Controls.OfType<TextBox>().First<TextBox>();
            sample.ChangePositionValue(Convert.ToUInt16(ReverseScrollBar(trackbar.Value, trackbar.Maximum)));
            sample.OutputSignalsBUP();
            sample.SetBUPSignalsValue(sample.BitsToByte(sample._BitsArrayBUP));
            textbox.Text= sample._WorkinPartPosition.ToString();
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
            for (int i = 0; i < checkboxList.Count; i++)
            {
                if(i==3 && checkboxList.Count<8)
                {
                    signals.Add((byte)0); signals.Add((byte)0); signals.Add((byte)0);
                }
                signals.Add(checkboxList[i].Checked ? (byte)1 : (byte)0);
            }
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
