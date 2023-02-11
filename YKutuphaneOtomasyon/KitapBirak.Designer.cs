
namespace YKutuphaneOtomasyon
{
    partial class KitapBirak
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
            this.dataGridView_TeslimOnay = new System.Windows.Forms.DataGridView();
            this.button_TeslimOnay = new System.Windows.Forms.Button();
            this.button_EmanetTCKontrol = new System.Windows.Forms.Button();
            this.label_Emanet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_TEslimTarihi = new System.Windows.Forms.DateTimePicker();
            this.textBox_EmanetKitap = new System.Windows.Forms.TextBox();
            this.textBox_TCNO = new System.Windows.Forms.TextBox();
            this.dataGridView_OgrenciBilgileri = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TeslimOnay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OgrenciBilgileri)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_TeslimOnay
            // 
            this.dataGridView_TeslimOnay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TeslimOnay.Location = new System.Drawing.Point(359, 349);
            this.dataGridView_TeslimOnay.Name = "dataGridView_TeslimOnay";
            this.dataGridView_TeslimOnay.RowHeadersWidth = 51;
            this.dataGridView_TeslimOnay.RowTemplate.Height = 24;
            this.dataGridView_TeslimOnay.Size = new System.Drawing.Size(914, 298);
            this.dataGridView_TeslimOnay.TabIndex = 19;
            this.dataGridView_TeslimOnay.Click += new System.EventHandler(this.dataGridView_TeslimOnay_Click);
            // 
            // button_TeslimOnay
            // 
            this.button_TeslimOnay.BackColor = System.Drawing.Color.Orange;
            this.button_TeslimOnay.Location = new System.Drawing.Point(956, 213);
            this.button_TeslimOnay.Name = "button_TeslimOnay";
            this.button_TeslimOnay.Size = new System.Drawing.Size(472, 65);
            this.button_TeslimOnay.TabIndex = 18;
            this.button_TeslimOnay.Text = "Bırak";
            this.button_TeslimOnay.UseVisualStyleBackColor = false;
            this.button_TeslimOnay.Click += new System.EventHandler(this.button_TeslimOnay_Click);
            // 
            // button_EmanetTCKontrol
            // 
            this.button_EmanetTCKontrol.BackColor = System.Drawing.Color.Orange;
            this.button_EmanetTCKontrol.Location = new System.Drawing.Point(956, 96);
            this.button_EmanetTCKontrol.Name = "button_EmanetTCKontrol";
            this.button_EmanetTCKontrol.Size = new System.Drawing.Size(472, 58);
            this.button_EmanetTCKontrol.TabIndex = 17;
            this.button_EmanetTCKontrol.Text = "TC NO Kontrol";
            this.button_EmanetTCKontrol.UseVisualStyleBackColor = false;
            this.button_EmanetTCKontrol.Click += new System.EventHandler(this.button_EmanetTCKontrol_Click);
            // 
            // label_Emanet
            // 
            this.label_Emanet.AutoSize = true;
            this.label_Emanet.Location = new System.Drawing.Point(650, 237);
            this.label_Emanet.Name = "label_Emanet";
            this.label_Emanet.Size = new System.Drawing.Size(40, 17);
            this.label_Emanet.TabIndex = 16;
            this.label_Emanet.Text = "Kitap";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Kitap Teslim Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Öğrenci TC NO:";
            // 
            // dateTimePicker_TEslimTarihi
            // 
            this.dateTimePicker_TEslimTarihi.Location = new System.Drawing.Point(653, 178);
            this.dateTimePicker_TEslimTarihi.Name = "dateTimePicker_TEslimTarihi";
            this.dateTimePicker_TEslimTarihi.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_TEslimTarihi.TabIndex = 13;
            // 
            // textBox_EmanetKitap
            // 
            this.textBox_EmanetKitap.Location = new System.Drawing.Point(653, 269);
            this.textBox_EmanetKitap.Name = "textBox_EmanetKitap";
            this.textBox_EmanetKitap.Size = new System.Drawing.Size(233, 22);
            this.textBox_EmanetKitap.TabIndex = 12;
            // 
            // textBox_TCNO
            // 
            this.textBox_TCNO.Location = new System.Drawing.Point(653, 101);
            this.textBox_TCNO.Name = "textBox_TCNO";
            this.textBox_TCNO.Size = new System.Drawing.Size(185, 22);
            this.textBox_TCNO.TabIndex = 11;
            // 
            // dataGridView_OgrenciBilgileri
            // 
            this.dataGridView_OgrenciBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OgrenciBilgileri.Location = new System.Drawing.Point(54, 59);
            this.dataGridView_OgrenciBilgileri.Name = "dataGridView_OgrenciBilgileri";
            this.dataGridView_OgrenciBilgileri.RowHeadersWidth = 51;
            this.dataGridView_OgrenciBilgileri.RowTemplate.Height = 24;
            this.dataGridView_OgrenciBilgileri.Size = new System.Drawing.Size(559, 239);
            this.dataGridView_OgrenciBilgileri.TabIndex = 28;
            this.dataGridView_OgrenciBilgileri.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_OgrenciBilgileri_CellContentClick);
            this.dataGridView_OgrenciBilgileri.Click += new System.EventHandler(this.dataGridView_OgrenciBilgileri_Click);
            // 
            // KitapBirak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1682, 697);
            this.Controls.Add(this.dataGridView_OgrenciBilgileri);
            this.Controls.Add(this.dataGridView_TeslimOnay);
            this.Controls.Add(this.button_TeslimOnay);
            this.Controls.Add(this.button_EmanetTCKontrol);
            this.Controls.Add(this.label_Emanet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_TEslimTarihi);
            this.Controls.Add(this.textBox_EmanetKitap);
            this.Controls.Add(this.textBox_TCNO);
            this.Name = "KitapBirak";
            this.Text = "Kitap Bırak";
            this.Load += new System.EventHandler(this.KitapBirak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TeslimOnay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OgrenciBilgileri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_TeslimOnay;
        private System.Windows.Forms.Button button_TeslimOnay;
        private System.Windows.Forms.Button button_EmanetTCKontrol;
        private System.Windows.Forms.Label label_Emanet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TEslimTarihi;
        private System.Windows.Forms.TextBox textBox_EmanetKitap;
        private System.Windows.Forms.TextBox textBox_TCNO;
        private System.Windows.Forms.DataGridView dataGridView_OgrenciBilgileri;
    }
}