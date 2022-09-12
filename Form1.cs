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
        //Can device = new Can(1);
        static bool threadCloser = true;
        Params WorkinPartAR = new Params();
        public Form1()
        {
            InitializeComponent();
           /* device.Open(CanOpenFlag.Can11);
            device.SetBaud(CanBaudRate.BCI_20K);
            device.Start();*/
            WorkinPartAR.Init(
                Convert.ToUInt16(ReverseScrollBar(trackBar1.Value, 
                trackBar1.Maximum)),
                1,
                CheckState(checkBoxStateErr1.Checked, checkBoxStateErrDM1.Checked),
                WorkinPartType.AR,
                BitsToByte(WorkinPartAR.BitsArrayBUP)
                );
            Thread thr = new Thread(()=> SendCANMessage(WorkinPartAR));
            thr.Start();
        }
        public int ReverseScrollBar(int value, int maxValue)
        {
            return Math.Abs(value - maxValue);
        }
        public StateCode CheckState(bool err, bool errDM)
        {
            if (err && errDM) return StateCode.BothDefect;
            else if (err) return StateCode.Defect;
            else if (errDM) return StateCode.DriveMgmtDefect;
            else return StateCode.Ok;
        }
        
       public void SendCANMessage(object obj)
        {
            Params obj1 = (Params)obj;
            while (threadCloser)
            {
                label3.Text = obj1.ShowMessage(obj1.CompareFirstMsg(), obj1.CompareSecondMsg());
                Thread.Sleep(100);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = ReverseScrollBar(trackBar1.Value, trackBar1.Maximum).ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WorkinPartAR.ChangePositionValue(Convert.ToUInt16(ReverseScrollBar(trackBar1.Value, trackBar1.Maximum)));
            WorkinPartAR.OutputSignalsBUP();
            WorkinPartAR.SetBUPSignalsValue(BitsToByte(WorkinPartAR.BitsArrayBUP));
            textBox1.Text= WorkinPartAR.WorkinPartPosition.ToString();
        }
        

        private void CheckBoxStateManager(object sender, EventArgs e)
        {
            var status = (CheckBox)sender;

            switch (status.Text)
            {
                case "Исправно":
                    checkBoxStateErr1.Checked = false;
                    checkBoxStateErrDM1.Checked = false;
                    checkBoxStateOk1.Checked = true;
                    checkBoxStateOk1.Enabled = false;
                    break;
                case "Неисправно": case "НеисправноУП":
                    checkBoxStateOk1.Enabled = true;
                    checkBoxStateOk1.Checked = false;
                    break ;
            }
            if(!(checkBoxStateErr1.Checked|| checkBoxStateErrDM1.Checked|| checkBoxStateOk1.Checked))
            {
                checkBoxStateOk1.Checked = true;
                checkBoxStateOk1.Enabled = false;
            }
            WorkinPartAR.SetState(CheckState(checkBoxStateErr1.Checked, checkBoxStateErrDM1.Checked));
            WorkinPartAR.OutputStatusBUP();
            WorkinPartAR.SetBUPSignalsValue(BitsToByte(WorkinPartAR.BitsArrayBUP));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadCloser = false;
        }

        private void KSKUSignalsCheck(object sender, EventArgs e)
        {
            List<byte> signals = new List<byte>(8);
            foreach(CheckBox cb in panel1.Controls)
            {
                signals.Add(cb.Checked ? (byte)1 : (byte)0);
            }
            WorkinPartAR.SetKSKUSignals(BitsToByte(signals));
        }
        public byte BitsToByte(List<byte> arr)
        {
            byte bits = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                bits += (byte)(arr[i] * Math.Pow(2, (arr.Count - 1) - i));
            }
            return bits;
        }
        private void IOSignalsCheck(object sender, EventArgs e)
        {
            if(checkBoxRstAZ1.Checked && checkBoxDeblock1.Checked)
                WorkinPartAR.SetIOSignals((byte)255);
            else if(checkBoxRstAZ1.Checked)
                WorkinPartAR.SetIOSignals((byte)254);
            else if(checkBoxDeblock1.Checked)
                WorkinPartAR.SetIOSignals((byte)1);
            else WorkinPartAR.SetIOSignals(0);
        }
    }
}
