
namespace YKutuphaneOtomasyon
{
    partial class Ogrenci_islem
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
            this.comboBox_Cinsiyet = new System.Windows.Forms.ComboBox();
            this.dateTimeUyelikTarihi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.textBox_TelNo = new System.Windows.Forms.TextBox();
            this.textBox_AdSoyad = new System.Windows.Forms.TextBox();
            this.textBox_TCNO = new System.Windows.Forms.TextBox();
            this.button_OgrenciEkle = new System.Windows.Forms.Button();
            this.button_OgrenciGuncelle = new System.Windows.Forms.Button();
            this.button_OgrenciSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Cinsiyet
            // 
            this.comboBox_Cinsiyet.FormattingEnabled = true;
            this.comboBox_Cinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.comboBox_Cinsiyet.Location = new System.Drawing.Point(172, 332);
            this.comboBox_Cinsiyet.Name = "comboBox_Cinsiyet";
            this.comboBox_Cinsiyet.Size = new System.Drawing.Size(230, 24);
            this.comboBox_Cinsiyet.TabIndex = 31;
            // 
            // dateTimeUyelikTarihi
            // 
            this.dateTimeUyelikTarihi.Location = new System.Drawing.Point(172, 285);
            this.dateTimeUyelikTarihi.Name = "dateTimeUyelikTarihi";
            this.dateTimeUyelikTarihi.Size = new System.Drawing.Size(230, 22);
            this.dateTimeUyelikTarihi.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Cinsiyet :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Üyelik Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "E-Mail :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefon :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ad Soyad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "TC NO :";
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(172, 222);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(230, 22);
            this.textBox_mail.TabIndex = 23;
            this.textBox_mail.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_mail_Validating);
            // 
            // textBox_TelNo
            // 
            this.textBox_TelNo.Location = new System.Drawing.Point(172, 178);
            this.textBox_TelNo.Name = "textBox_TelNo";
            this.textBox_TelNo.Size = new System.Drawing.Size(230, 22);
            this.textBox_TelNo.TabIndex = 22;
            // 
            // textBox_AdSoyad
            // 
            this.textBox_AdSoyad.Location = new System.Drawing.Point(172, 124);
            this.textBox_AdSoyad.Name = "textBox_AdSoyad";
            this.textBox_AdSoyad.Size = new System.Drawing.Size(230, 22);
            this.textBox_AdSoyad.TabIndex = 21;
            // 
            // textBox_TCNO
            // 
            this.textBox_TCNO.Location = new System.Drawing.Point(172, 81);
            this.textBox_TCNO.Name = "textBox_TCNO";
            this.textBox_TCNO.Size = new System.Drawing.Size(230, 22);
            this.textBox_TCNO.TabIndex = 20;
            this.textBox_TCNO.TextChanged += new System.EventHandler(this.textBox_TCNO_TextChanged);
            this.textBox_TCNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TCNO_KeyPress);
            // 
            // button_OgrenciEkle
            // 
            this.button_OgrenciEkle.BackColor = System.Drawing.Color.Orange;
            this.button_OgrenciEkle.Location = new System.Drawing.Point(456, 74);
            this.button_OgrenciEkle.Name = "button_OgrenciEkle";
            this.button_OgrenciEkle.Size = new System.Drawing.Size(332, 67);
            this.button_OgrenciEkle.TabIndex = 32;
            this.button_OgrenciEkle.Text = "Öğrenci Ekle";
            this.button_OgrenciEkle.UseVisualStyleBackColor = false;
            this.button_OgrenciEkle.Click += new System.EventHandler(this.button_OgrenciEkle_Click);
            // 
            // button_OgrenciGuncelle
            // 
            this.button_OgrenciGuncelle.BackColor = System.Drawing.Color.Orange;
            this.button_OgrenciGuncelle.Location = new System.Drawing.Point(456, 183);
            this.button_OgrenciGuncelle.Name = "button_OgrenciGuncelle";
            this.button_OgrenciGuncelle.Size = new System.Drawing.Size(332, 67);
            this.button_OgrenciGuncelle.TabIndex = 33;
            this.button_OgrenciGuncelle.Text = "Öğrenci Güncelle";
            this.button_OgrenciGuncelle.UseVisualStyleBackColor = false;
            this.button_OgrenciGuncelle.Click += new System.EventHandler(this.button_OgrenciGuncelle_Click);
            // 
            // button_OgrenciSil
            // 
            this.button_OgrenciSil.BackColor = System.Drawing.Color.Orange;
            this.button_OgrenciSil.Location = new System.Drawing.Point(456, 290);
            this.button_OgrenciSil.Name = "button_OgrenciSil";
            this.button_OgrenciSil.Size = new System.Drawing.Size(332, 67);
            this.button_OgrenciSil.TabIndex = 34;
            this.button_OgrenciSil.Text = "Öğrenci Sil";
            this.button_OgrenciSil.UseVisualStyleBackColor = false;
            this.button_OgrenciSil.Click += new System.EventHandler(this.button_OgrenciSil_Click);
            // 
            // Ogrenci_islem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_OgrenciSil);
            this.Controls.Add(this.button_OgrenciGuncelle);
            this.Controls.Add(this.button_OgrenciEkle);
            this.Controls.Add(this.comboBox_Cinsiyet);
            this.Controls.Add(this.dateTimeUyelikTarihi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_mail);
            this.Controls.Add(this.textBox_TelNo);
            this.Controls.Add(this.textBox_AdSoyad);
            this.Controls.Add(this.textBox_TCNO);
            this.Name = "Ogrenci_islem";
            this.Text = "Öğrenci İşlem";
            this.Load += new System.EventHandler(this.Ogrenci_islem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Cinsiyet;
        private System.Windows.Forms.DateTimePicker dateTimeUyelikTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.TextBox textBox_TelNo;
        private System.Windows.Forms.TextBox textBox_AdSoyad;
        private System.Windows.Forms.TextBox textBox_TCNO;
        private System.Windows.Forms.Button button_OgrenciEkle;
        private System.Windows.Forms.Button button_OgrenciGuncelle;
        private System.Windows.Forms.Button button_OgrenciSil;
    }
}