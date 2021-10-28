using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace BaiTap2
{
    public partial class ImageBox : Form
    {
        public string[] Listfiles;
        int NumOfFiles = 0;
        int OrderOfActingFileInList = 0;
        public ImageBox()
        {
            InitializeComponent();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            BtnLuu.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  
                    pictureBox1.Image = new Bitmap(open.FileName);

                    GetFileInDir(open.FileName);

                    // image file path  
                    //textBox1.Text = open.FileName;
                }
                button1.Show();
                BtnLuu.Show();
                label1.Hide();
                button3.Show();
                button2.Show();
                CheckConDition();
            }
            catch(Exception err)
            { CallErrorBox(err); }
        }


        // lấy cảm hứng từ https://zetcode.com/csharp/listdirectory/ 
        //Triggered when OPEN DIALOG or SAVE 
        //not trigger when next/prev or open in ListView 
        public void GetFileInDir(string filepath)
        {
            try
            {
                string path = System.IO.Path.GetDirectoryName(filepath);
               
                string[] extensions = { ".png", ".bmp", ".jpg", ".jpeg" };

                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => extensions.Any(ext => ext == Path.GetExtension(s)));
                this.NumOfFiles = 0;
                string abc = "";
                foreach (string file in files)
                {
                    this.NumOfFiles++;
                    abc += file + " ";
                }
                listView1.Clear();
                string[] a = new String[this.NumOfFiles];
                Listfiles = a;
                a = null;
                int i = 0;
                foreach (string file in files)
                {

                    this.Listfiles[i] = file;
                    ListViewItem item = new ListViewItem(System.IO.Path.GetFileName(file));
                    item.SubItems.Add(file);
                    listView1.Items.Add(item);
                    if (this.Listfiles[i] == filepath)
                    {
                        OrderOfActingFileInList = i;
                        listView1.Items[i].Selected = true;
                        listView1.EnsureVisible(i);
                    }
                    i++;
                    

                }
               // CallErrorBox(abc);
                //CallErrorBox((OrderOfActingFileInList.ToString()));
            }
            catch (Exception err)
            { CallErrorBox(err); } 
        }
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ImageBox_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Portable Network Graphics|*.png";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            pictureBox1.Image.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            pictureBox1.Image.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            pictureBox1.Image.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    fs.Close();

                }
                GetFileInDir(saveFileDialog1.FileName);
                CheckConDition();
            }
            catch (Exception err)
            { CallErrorBox(err); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ImageBox_FormIsClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            MainBox fm = new MainBox();
            //fm.ShowDialog();
            fm.Form_Show();
            //this.Dispose();
        }
        private void CallErrorBox(string err)
        {
            ErrBox NewForm = new ErrBox();
            NewForm.Text = err;

            NewForm.ShowDialog();
        }
        private void CallErrorBox(Exception err)
        {
            /* deliver user-friendly error 
             */
            const bool on_develop = false;
            ErrBox NewForm = new ErrBox();
            string ErrorMsg;

            if (on_develop)
            {
                ErrorMsg = err.ToString();
                // if you want more friendly-error, turn this on, catch the type and search on
                //https://docs.microsoft.com/en-us/dotnet/api/system.systemexception?view=net-5.0
            }
            else
            {
                if (err.GetType() == typeof(System.IO.IOException))
                    ErrorMsg = "File đang sử dụng bởi ứng dụng khác. Vui lòng tắt ứng dụng đó và thử lại.";
                else
                if (err.GetType() == typeof(InvalidOperationException))
                    ErrorMsg = "Vui lòng chọn file text. Hiện tác giả chưa hỗ trợ các loại file khác.";
                else ErrorMsg = err.Message;

            }
            
            NewForm.Text = ErrorMsg;
            NewForm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FindOrder()
        {

            if (listView1.SelectedItems.Count > 0)
            {
                OrderOfActingFileInList = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }

        }
        private void CheckConDition()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            if (OrderOfActingFileInList == 0)
            {
                button2.Enabled = false;
            }
            if (OrderOfActingFileInList == NumOfFiles - 1)
            {
                button3.Enabled = false;

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(listView1.SelectedItems[0].SubItems[1].Text);
            FindOrder();
            CheckConDition();
            //CallErrorBox(listView1.SelectedItems[1].SubItems.ToString());
            //pictureBox1.Image = new Bitmap(listView1.SelectedItems[0].SubItems.ToString);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(listView1.Items[OrderOfActingFileInList - 1].SubItems[1].Text);
            listView1.Items[OrderOfActingFileInList-1].Selected = true;
            listView1.Items[OrderOfActingFileInList ].Selected = false;
            listView1.EnsureVisible(OrderOfActingFileInList - 1);
            OrderOfActingFileInList--;
            CheckConDition();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = new Bitmap(listView1.Items[OrderOfActingFileInList  +1].SubItems[1].Text);
            listView1.Items[OrderOfActingFileInList + 1].Selected = true;
            listView1.Items[OrderOfActingFileInList].Selected = false;

            listView1.EnsureVisible(OrderOfActingFileInList+  1);
            OrderOfActingFileInList++;
            CheckConDition();
        }
    }
}
