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
    }
}
