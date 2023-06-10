namespace BookShopManage
{
    partial class Splash
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MyProgress = new System.Windows.Forms.ProgressBar();
            this.LoadLabel = new System.Windows.Forms.Label();
            this.PercentLb1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "BookShop Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(409, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MyProgress
            // 
            this.MyProgress.Location = new System.Drawing.Point(0, 587);
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.Size = new System.Drawing.Size(981, 23);
            this.MyProgress.TabIndex = 2;
            // 
            // LoadLabel
            // 
            this.LoadLabel.AutoSize = true;
            this.LoadLabel.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadLabel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.LoadLabel.Location = new System.Drawing.Point(402, 530);
            this.LoadLabel.Name = "LoadLabel";
            this.LoadLabel.Size = new System.Drawing.Size(140, 37);
            this.LoadLabel.TabIndex = 3;
            this.LoadLabel.Text = "Loading...";
            this.LoadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoadLabel.UseMnemonic = false;
            this.LoadLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // PercentLb1
            // 
            this.PercentLb1.AutoSize = true;
            this.PercentLb1.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentLb1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.PercentLb1.Location = new System.Drawing.Point(535, 530);
            this.PercentLb1.Name = "PercentLb1";
            this.PercentLb1.Size = new System.Drawing.Size(40, 37);
            this.PercentLb1.TabIndex = 4;
            this.PercentLb1.Text = "%";
            this.PercentLb1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PercentLb1.UseMnemonic = false;
            this.PercentLb1.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 611);
            this.Controls.Add(this.PercentLb1);
            this.Controls.Add(this.LoadLabel);
            this.Controls.Add(this.MyProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar MyProgress;
        private System.Windows.Forms.Label LoadLabel;
        private System.Windows.Forms.Label PercentLb1;
        private System.Windows.Forms.Timer timer1;
    }
}

