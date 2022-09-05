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
        Can device = new Can(0);
        public Form1()
        {
            InitializeComponent();
            
            device.Open(CanOpenFlag.Can11);
            device.SetBaud(CanBaudRate.BCI_20K);
            device.Start();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                CanMessage[] frames = device.ReadAll() ;
                foreach(var mes in frames)
                {
                    string bytes="";
                    foreach(var bt in mes.Data)
                    {
                        bytes+=bt.ToString()+", ";
                    }
                    textBox1.Text += mes.Id + " | " + bytes+"\t\t";
                }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
