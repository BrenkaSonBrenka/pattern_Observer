using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CurrentDisplay : Form, ISub
    {
        IPub pub;
        public CurrentDisplay()
        {
            InitializeComponent();
        }
        public CurrentDisplay(IPub publisher)
        {
            InitializeComponent();
            pub = publisher;
        }
        private void Subscribe()
        {
            pub.AddSub(this);

        }
        private void Unsubscribe()
        {
            pub.RemoveSub(this);
        }
        public void Update(double temp, double humidity, double pressure)
        {
            label1.Text = "Температура: " + temp;
            label2.Text = "Влажность: " + humidity;
            label3.Text = "Давление: " + pressure;
        }
        private void Screen_1_Load(object sender, EventArgs e)
        {
            this.Text = "CurrentDisplay";
            Subscribe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subscribe();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Unsubscribe();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
