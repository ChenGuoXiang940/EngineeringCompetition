namespace _98_3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.HScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox3.Location = new System.Drawing.Point(318, 367);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(103, 27);
            this.TextBox3.TabIndex = 31;
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox2.Location = new System.Drawing.Point(87, 365);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(103, 27);
            this.TextBox2.TabIndex = 30;
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button1.Location = new System.Drawing.Point(381, 14);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(201, 27);
            this.Button1.TabIndex = 29;
            this.Button1.Text = "開啟檔案並顯示波形";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // HScrollBar1
            // 
            this.HScrollBar1.Location = new System.Drawing.Point(107, 52);
            this.HScrollBar1.Name = "HScrollBar1";
            this.HScrollBar1.Size = new System.Drawing.Size(405, 24);
            this.HScrollBar1.TabIndex = 28;
            this.HScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar1_Scroll);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Black;
            this.PictureBox1.Location = new System.Drawing.Point(2, 85);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(600, 250);
            this.PictureBox1.TabIndex = 27;
            this.PictureBox1.TabStop = false;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox1.Location = new System.Drawing.Point(107, 14);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(271, 27);
            this.TextBox1.TabIndex = 26;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label4.Location = new System.Drawing.Point(243, 365);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 32);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "聲音長度\r\n( 秒 ) ：\r\n";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label3.Location = new System.Drawing.Point(12, 363);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 32);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "目前位置\r\n( 秒 ) ：";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label2.Location = new System.Drawing.Point(11, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 32);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "調整顯示\r\n的位置";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(91, 32);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "欲開啟的\r\nWAV聲音檔";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 450);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.HScrollBar1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.HScrollBar HScrollBar1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

