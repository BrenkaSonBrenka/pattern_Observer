using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Publisher pub = new Publisher();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var matching = Assembly.GetAssembly(typeof(ISub)).GetTypes()
              .Where(type => typeof(ISub)
              .IsAssignableFrom(type) && !type.IsInterface);

            foreach (var name in matching)
            {
                subList.Items.Add(name.Name);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (subList.SelectedIndex != -1)
            {
                var form = Activator.CreateInstance(Type.GetType("WindowsFormsApp1." + subList.Items[subList.SelectedIndex].ToString()), pub) as Form;

                form.Show();
            }
        }

        private void turnOnButton_Click(object sender, EventArgs e)
        {
            pub.IsBroadcasting = true;
            turnOnButton.Enabled = false;
            turnOffButton.Enabled = true;

            pub.Notify();
        }

        private void turnOffButton_Click(object sender, EventArgs e)
        {
            pub.IsBroadcasting = false;
            turnOnButton.Enabled = true;
            turnOffButton.Enabled = false;
        }
    }
}
