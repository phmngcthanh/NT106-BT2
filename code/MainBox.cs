using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap2
{
    public partial class MainBox : Form
    {
        public MainBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextViewBox fm = new TextViewBox();
            fm.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImageBox fm = new ImageBox();
            fm.ShowDialog();
            this.Hide();
        }
        public void Form_Show()
        {
            this.Show();
        }
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            
            AboutBox1 fm = new AboutBox1();
            fm.ShowDialog();
            this.Hide();

        }
        private void MainBox_FormIsClosed(object sender, FormClosedEventArgs e)
        {
            /* resolve problem when open other form and application not close when click X on main form*/
            Application.Exit();
            this.Dispose();
        }
    }
}
