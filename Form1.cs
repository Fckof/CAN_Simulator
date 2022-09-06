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
        //Can device = new Can(1);
        Params roAR = new Params();
        public Form1()
        {
            InitializeComponent();

            /*device.Open(CanOpenFlag.Can11);
            device.SetBaud(CanBaudRate.BCI_20K);
            device.Start();*/
            roAR.Init(Convert.ToUInt16(trackBar1.Value), checkBox1.Checked, checkBox2.Checked);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            roAR.ChangePositionValue(Convert.ToUInt16(trackBar1.Value));
            textBox1.Text=trackBar1.Value.ToString();
            var mes = BitConverter.GetBytes(Convert.ToUInt16(trackBar1.Value));
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roAR.ShowParams());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            roAR.ChangeStateValue(checkBox1.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            roAR.ChangePowerValue(checkBox2.Checked);
        }
    }
}
