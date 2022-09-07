using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CAN_Simulator
{
    public partial class Form1 : Form
    {
        Can device = new Can(1);
        Params WorkinPartAR = new Params();
        public Form1()
        {
            InitializeComponent();
            device.Open(CanOpenFlag.Can11);
            device.SetBaud(CanBaudRate.BCI_20K);
            device.Start();
            WorkinPartAR.Init(Convert.ToUInt16(trackBar1.Value),(UInt32)1, CheckState(checkBoxStateErr.Checked, checkBoxStateErr2.Checked));
        }
        public StateCode CheckState(bool err, bool errDM)
        {
            if (err && errDM) return StateCode.BothDefect;
            else if (err) return StateCode.Defect;
            else if (errDM) return StateCode.DriveMgmtDefect;
            else return StateCode.Ok;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WorkinPartAR.ChangePositionValue(Convert.ToUInt16(trackBar1.Value));
            textBox1.Text= WorkinPartAR.WorkinPartPosition.ToString();
        }
        

        private void CheckBoxStateManager(object sender, EventArgs e)
        {
            var status = (CheckBox)sender;

            switch (status.Text)
            {
                case "Исправно":
                    checkBoxStateErr.Checked = false;
                    checkBoxStateErr2.Checked = false;
                    checkBoxStateOk.Checked = true;
                    checkBoxStateOk.Enabled = false;
                    break;
                case "Неисправно": case "НеисправноУП":
                    checkBoxStateOk.Enabled = true;
                    checkBoxStateOk.Checked = false;
                    break ;
            }
            if(!(checkBoxStateErr.Checked|| checkBoxStateErr2.Checked|| checkBoxStateOk.Checked))
            {
                checkBoxStateOk.Checked = true;
                checkBoxStateOk.Enabled = false;
            }
            WorkinPartAR.SetState(CheckState(checkBoxStateErr.Checked, checkBoxStateErr2.Checked));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           MessageBox.Show( WorkinPartAR.ShowMessage(WorkinPartAR.CompareFirstMsg()));
        }
    }
}
