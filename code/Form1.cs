using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaiTap2
{
    public partial class ErrBox : Form
    {
        public ErrBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ErrBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
