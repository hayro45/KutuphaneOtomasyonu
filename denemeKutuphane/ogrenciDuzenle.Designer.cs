namespace denemeKutuphane
{
    partial class ogrenciDuzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTc = new System.Windows.Forms.MaskedTextBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblcinsiyet = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.richAdres = new System.Windows.Forms.RichTextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(319, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 34);
            this.button2.TabIndex = 23;
            this.button2.Text = "Yeni";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(319, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "Duzenle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtTc
            // 
            this.txtTc.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTc.Location = new System.Drawing.Point(116, 25);
            this.txtTc.Mask = "00000000000";
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(165, 31);
            this.txtTc.TabIndex = 25;
            this.txtTc.ValidatingType = typeof(int);
            this.txtTc.TextChanged += new System.EventHandler(this.txtTc_Text_Changed);
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTel.Location = new System.Drawing.Point(116, 136);
            this.txtTel.Mask = "(999) 000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(165, 31);
            this.txtTel.TabIndex = 31;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton2.Location = new System.Drawing.Point(205, 249);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 26);
            this.radioButton2.TabIndex = 35;
            this.radioButton2.Text = "Erkek";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(114, 249);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 26);
            this.radioButton1.TabIndex = 34;
            this.radioButton1.Text = "Kadın";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblcinsiyet
            // 
            this.lblcinsiyet.AutoSize = true;
            this.lblcinsiyet.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblcinsiyet.Location = new System.Drawing.Point(23, 251);
            this.lblcinsiyet.Name = "lblcinsiyet";
            this.lblcinsiyet.Size = new System.Drawing.Size(85, 22);
            this.lblcinsiyet.TabIndex = 38;
            this.lblcinsiyet.Text = "Cinsiyet:";
            // 
            // txtEposta
            // 
            this.txtEposta.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.Location = new System.Drawing.Point(116, 173);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(165, 31);
            this.txtEposta.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(25, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 37;
            this.label6.Text = "E-posta:";
            // 
            // richAdres
            // 
            this.richAdres.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richAdres.Location = new System.Drawing.Point(116, 306);
            this.richAdres.Name = "richAdres";
            this.richAdres.Size = new System.Drawing.Size(304, 115);
            this.richAdres.TabIndex = 36;
            this.richAdres.Text = "";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyad.Location = new System.Drawing.Point(116, 99);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(165, 31);
            this.txtSoyad.TabIndex = 29;
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.Location = new System.Drawing.Point(116, 62);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(165, 31);
            this.txtAd.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(40, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 22);
            this.label5.TabIndex = 32;
            this.label5.Text = "Adres:";
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(28, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "Telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(32, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Soyadı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(62, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "TC No:";
            // 
            // ogrenciDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 454);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lblcinsiyet);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richAdres);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ogrenciDuzenle";
            this.Text = "Öğrenci Düzenle";
            this.Load += new System.EventHandler(this.OgrenciDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox txtTc;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lblcinsiyet;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richAdres;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}