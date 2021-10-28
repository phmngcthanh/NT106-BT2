using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace BaiTap2
{
    public partial class TextViewBox : Form
    {
       
        FileStream fs;
        byte[] fileContents;
        AsyncCallback callback;
        public TextViewBox()
        {
            InitializeComponent();
        }

        private void fs_StateChanged(IAsyncResult asyncResult)
        {
            if (asyncResult.IsCompleted)
            {
                try {
                    string s = Encoding.UTF8.GetString
                    (fileContents);
                    tbResults.Text = s;
                    fs.Close(); }
                catch (Exception e)
                {
                    CallErrorBox(e);
                }
            }
        }

        private void btnReadAsync_Click(object sender, EventArgs e)
        { // as NTFS uses 4096 as default alloc unit size 
            //Uses some of Lectuer's code for the reading

                openFileDialog1.ShowDialog();
            if (openFileDialog1.CheckFileExists)
            {
                callback = new AsyncCallback(fs_StateChanged);
                // as NTFS uses 4096 as default alloc unit size 

                try
                {
                    fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate,
FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true);

                    fileContents = new Byte[fs.Length];
                    fs.BeginRead(fileContents, 0, (int)fs.Length, callback, null);
                    this.Text = "Working with " + fs.Name;
                }
                catch (Exception eb)
                {
                    CallErrorBox(eb);
                }
            } //usally this dont happend. But anyway
            else CallErrorBox("File không tồn tại. Vui lòng bấm Save thay vì open nếu bạn muốn tạo file mới");

        }

        private void tbResults_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { //Use 4096 bytes as it is the default NTFS allocation size
            try
            {
                saveFileDialog1.Title = "Save an Text File";
                //if not open before
                if (fs == null)
                {

                    saveFileDialog1.ShowDialog();
                    fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true);
                    callback = new AsyncCallback(fs_StateChanged);
                    this.Text = "Working with " + fs.Name;
                }
                else //save name for convenient
                {
                    
                      saveFileDialog1.FileName = fs.Name;
                      saveFileDialog1.ShowDialog();
                      fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate,
                      FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true);
                      callback = new AsyncCallback(fs_StateChanged);
                }


                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.WriteLine(tbResults.Text);
                    sw.Close();
                }
                catch (Exception err)
                {

                     CallErrorBox(err);
                }
            }
            catch (Exception err)
            { CallErrorBox(err); }
        }

        private void TextViewBox_Load(object sender, EventArgs e)
        {

        }
        //xu ly viec chuyen giua cac form
        private void TextViewBox_FormIsClosed(object sender, FormClosedEventArgs e)
        {
           
            MainBox fm = new MainBox();

            fm.Form_Show();

        }
        // code to deliver user-friendly error instead of exception exit
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
    }
}
