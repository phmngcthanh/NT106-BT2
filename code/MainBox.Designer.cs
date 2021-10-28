
namespace BaiTap2
{
    partial class MainBox
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BtnText = new System.Windows.Forms.Button();
            this.BtnImage = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bài tập buổi 2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BtnText
            // 
            this.BtnText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnText.Location = new System.Drawing.Point(74, 105);
            this.BtnText.Name = "BtnText";
            this.BtnText.Size = new System.Drawing.Size(159, 32);
            this.BtnText.TabIndex = 1;
            this.BtnText.Text = "Đọc/ Ghi file text";
            this.BtnText.UseVisualStyleBackColor = true;
            this.BtnText.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnImage
            // 
            this.BtnImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnImage.Location = new System.Drawing.Point(74, 221);
            this.BtnImage.Name = "BtnImage";
            this.BtnImage.Size = new System.Drawing.Size(159, 32);
            this.BtnImage.TabIndex = 4;
            this.BtnImage.Text = "Đọc/ Đổi định dạng ảnh";
            this.BtnImage.UseVisualStyleBackColor = true;
            this.BtnImage.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAbout.Location = new System.Drawing.Point(74, 163);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(159, 32);
            this.BtnAbout.TabIndex = 5;
            this.BtnAbout.Text = "Thông tin tác giả";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // MainBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 290);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnImage);
            this.Controls.Add(this.BtnText);
            this.Controls.Add(this.label1);
            this.Name = "MainBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài tập buổi 2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainBox_FormIsClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnText;
        private System.Windows.Forms.Button BtnImage;
        private System.Windows.Forms.Button BtnAbout;
    }
}

