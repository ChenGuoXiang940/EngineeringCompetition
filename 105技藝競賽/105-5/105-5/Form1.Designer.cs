namespace _105_5
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
            this.Button3 = new System.Windows.Forms.Button();
            this.TextBox11 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.bit2 = new System.Windows.Forms.TextBox();
            this.bit1 = new System.Windows.Forms.TextBox();
            this.TextBox10 = new System.Windows.Forms.TextBox();
            this.TextBox9 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button3.Location = new System.Drawing.Point(432, 216);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(130, 27);
            this.Button3.TabIndex = 43;
            this.Button3.Text = "Exit";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // TextBox11
            // 
            this.TextBox11.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox11.Location = new System.Drawing.Point(135, 216);
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Size = new System.Drawing.Size(100, 27);
            this.TextBox11.TabIndex = 42;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label6.Location = new System.Drawing.Point(0, 222);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(55, 16);
            this.Label6.TabIndex = 41;
            this.Label6.Text = "壓縮比";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button2.Location = new System.Drawing.Point(432, 158);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(130, 33);
            this.Button2.TabIndex = 40;
            this.Button2.Text = "Encoding";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // bit2
            // 
            this.bit2.Enabled = false;
            this.bit2.Font = new System.Drawing.Font("新細明體", 12F);
            this.bit2.Location = new System.Drawing.Point(237, 170);
            this.bit2.Name = "bit2";
            this.bit2.Size = new System.Drawing.Size(63, 27);
            this.bit2.TabIndex = 39;
            this.bit2.Text = "bits";
            this.bit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bit1
            // 
            this.bit1.Enabled = false;
            this.bit1.Font = new System.Drawing.Font("新細明體", 12F);
            this.bit1.Location = new System.Drawing.Point(237, 137);
            this.bit1.Name = "bit1";
            this.bit1.Size = new System.Drawing.Size(63, 27);
            this.bit1.TabIndex = 38;
            this.bit1.Text = "bits";
            this.bit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox10
            // 
            this.TextBox10.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox10.Location = new System.Drawing.Point(135, 170);
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Size = new System.Drawing.Size(102, 27);
            this.TextBox10.TabIndex = 37;
            // 
            // TextBox9
            // 
            this.TextBox9.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox9.Location = new System.Drawing.Point(135, 137);
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Size = new System.Drawing.Size(102, 27);
            this.TextBox9.TabIndex = 36;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label5.Location = new System.Drawing.Point(0, 176);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 16);
            this.Label5.TabIndex = 35;
            this.Label5.Text = "霍夫曼編碼";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label4.Location = new System.Drawing.Point(0, 143);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 16);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "傳統編碼";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 24F);
            this.Label3.Location = new System.Drawing.Point(61, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(430, 32);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "簡易霍夫曼編碼資料壓縮系統";
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button1.Location = new System.Drawing.Point(432, 81);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(130, 33);
            this.Button1.TabIndex = 32;
            this.Button1.Text = "Random Set";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label2.Location = new System.Drawing.Point(0, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 31;
            this.Label2.Text = "出現次數";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.Label1.Location = new System.Drawing.Point(0, 66);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 16);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "文字";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(85, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 76);
            this.panel1.TabIndex = 44;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 275);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.TextBox11);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.bit2);
            this.Controls.Add(this.bit1);
            this.Controls.Add(this.TextBox10);
            this.Controls.Add(this.TextBox9);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.TextBox TextBox11;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TextBox bit2;
        internal System.Windows.Forms.TextBox bit1;
        internal System.Windows.Forms.TextBox TextBox10;
        internal System.Windows.Forms.TextBox TextBox9;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
    }
}

