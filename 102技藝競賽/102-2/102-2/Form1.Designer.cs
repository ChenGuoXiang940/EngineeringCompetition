namespace _102_2
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
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button3.Location = new System.Drawing.Point(561, 193);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(80, 37);
            this.Button3.TabIndex = 19;
            this.Button3.Text = "Exit";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Clicked);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button2.Location = new System.Drawing.Point(561, 107);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(80, 37);
            this.Button2.TabIndex = 18;
            this.Button2.Text = "Convert";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Clicked);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("新細明體", 12F);
            this.Button1.Location = new System.Drawing.Point(561, 64);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(80, 37);
            this.Button1.TabIndex = 17;
            this.Button1.Text = "Random";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Clicked);
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox3.Location = new System.Drawing.Point(163, 189);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(351, 27);
            this.TextBox3.TabIndex = 16;
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox2.Location = new System.Drawing.Point(163, 138);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(351, 27);
            this.TextBox2.TabIndex = 15;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.TextBox1.Location = new System.Drawing.Point(163, 87);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(192, 27);
            this.TextBox1.TabIndex = 14;
            this.TextBox1.Text = "19.561";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 14F);
            this.Label4.Location = new System.Drawing.Point(6, 193);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(163, 19);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Final Binary value：";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 14F);
            this.Label3.Location = new System.Drawing.Point(48, 142);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(121, 19);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Binary value：";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 14F);
            this.Label2.Location = new System.Drawing.Point(50, 91);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(119, 19);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Real　value：";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 16F);
            this.Label1.Location = new System.Drawing.Point(43, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(440, 22);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Conversion of Random Real Value to Binary Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 294);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}

