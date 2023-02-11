
namespace YKutuphaneOtomasyon
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OgrenciEkle = new System.Windows.Forms.Button();
            this.button_OgrenciListele = new System.Windows.Forms.Button();
            this.button_KitapEklem = new System.Windows.Forms.Button();
            this.button_KitapEkle = new System.Windows.Forms.Button();
            this.button_KitaplarGrafik = new System.Windows.Forms.Button();
            this.button_KitapBirak = new System.Windows.Forms.Button();
            this.button_KitapAl = new System.Windows.Forms.Button();
            this.button_EmanetSorgula = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OgrenciEkle
            // 
            this.button_OgrenciEkle.BackColor = System.Drawing.Color.Orange;
            this.button_OgrenciEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_OgrenciEkle.Location = new System.Drawing.Point(47, 169);
            this.button_OgrenciEkle.Name = "button_OgrenciEkle";
            this.button_OgrenciEkle.Size = new System.Drawing.Size(393, 76);
            this.button_OgrenciEkle.TabIndex = 0;
            this.button_OgrenciEkle.Text = "Öğrenci Ekle";
            this.button_OgrenciEkle.UseVisualStyleBackColor = false;
            this.button_OgrenciEkle.Click += new System.EventHandler(this.button_OgrenciEkle_Click);
            // 
            // button_OgrenciListele
            // 
            this.button_OgrenciListele.BackColor = System.Drawing.Color.Orange;
            this.button_OgrenciListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_OgrenciListele.Location = new System.Drawing.Point(47, 277);
            this.button_OgrenciListele.Name = "button_OgrenciListele";
            this.button_OgrenciListele.Size = new System.Drawing.Size(393, 76);
            this.button_OgrenciListele.TabIndex = 1;
            this.button_OgrenciListele.Text = "Öğrenci Listele";
            this.button_OgrenciListele.UseVisualStyleBackColor = false;
            this.button_OgrenciListele.Click += new System.EventHandler(this.button_OgrenciListele_Click);
            // 
            // button_KitapEklem
            // 
            this.button_KitapEklem.BackColor = System.Drawing.Color.Orange;
            this.button_KitapEklem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_KitapEklem.Location = new System.Drawing.Point(47, 396);
            this.button_KitapEklem.Name = "button_KitapEklem";
            this.button_KitapEklem.Size = new System.Drawing.Size(393, 76);
            this.button_KitapEklem.TabIndex = 2;
            this.button_KitapEklem.Text = "Kitap Ekleme";
            this.button_KitapEklem.UseVisualStyleBackColor = false;
            this.button_KitapEklem.Click += new System.EventHandler(this.button_KitapEklem_Click);
            // 
            // button_KitapEkle
            // 
            this.button_KitapEkle.BackColor = System.Drawing.Color.Orange;
            this.button_KitapEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_KitapEkle.Location = new System.Drawing.Point(47, 516);
            this.button_KitapEkle.Name = "button_KitapEkle";
            this.button_KitapEkle.Size = new System.Drawing.Size(393, 76);
            this.button_KitapEkle.TabIndex = 3;
            this.button_KitapEkle.Text = "Kitap Listele";
            this.button_KitapEkle.UseVisualStyleBackColor = false;
            this.button_KitapEkle.Click += new System.EventHandler(this.button_KitapEkle_Click);
            // 
            // button_KitaplarGrafik
            // 
            this.button_KitaplarGrafik.BackColor = System.Drawing.Color.Orange;
            this.button_KitaplarGrafik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_KitaplarGrafik.Location = new System.Drawing.Point(676, 516);
            this.button_KitaplarGrafik.Name = "button_KitaplarGrafik";
            this.button_KitaplarGrafik.Size = new System.Drawing.Size(393, 76);
            this.button_KitaplarGrafik.TabIndex = 7;
            this.button_KitaplarGrafik.Text = "Kitaplar(GRAFİK)";
            this.button_KitaplarGrafik.UseVisualStyleBackColor = false;
            this.button_KitaplarGrafik.Click += new System.EventHandler(this.button_KitaplarGrafik_Click);
            // 
            // button_KitapBirak
            // 
            this.button_KitapBirak.BackColor = System.Drawing.Color.Orange;
            this.button_KitapBirak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_KitapBirak.Location = new System.Drawing.Point(676, 396);
            this.button_KitapBirak.Name = "button_KitapBirak";
            this.button_KitapBirak.Size = new System.Drawing.Size(393, 76);
            this.button_KitapBirak.TabIndex = 6;
            this.button_KitapBirak.Text = "Kitap Bırak";
            this.button_KitapBirak.UseVisualStyleBackColor = false;
            this.button_KitapBirak.Click += new System.EventHandler(this.button_KitapBirak_Click);
            // 
            // button_KitapAl
            // 
            this.button_KitapAl.BackColor = System.Drawing.Color.Orange;
            this.button_KitapAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_KitapAl.Location = new System.Drawing.Point(676, 277);
            this.button_KitapAl.Name = "button_KitapAl";
            this.button_KitapAl.Size = new System.Drawing.Size(393, 76);
            this.button_KitapAl.TabIndex = 5;
            this.button_KitapAl.Text = "Kitap Al";
            this.button_KitapAl.UseVisualStyleBackColor = false;
            this.button_KitapAl.Click += new System.EventHandler(this.button_KitapAl_Click);
            // 
            // button_EmanetSorgula
            // 
            this.button_EmanetSorgula.BackColor = System.Drawing.Color.Orange;
            this.button_EmanetSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_EmanetSorgula.Location = new System.Drawing.Point(676, 169);
            this.button_EmanetSorgula.Name = "button_EmanetSorgula";
            this.button_EmanetSorgula.Size = new System.Drawing.Size(393, 76);
            this.button_EmanetSorgula.TabIndex = 4;
            this.button_EmanetSorgula.Text = "Emanet Sorgula";
            this.button_EmanetSorgula.UseVisualStyleBackColor = false;
            this.button_EmanetSorgula.Click += new System.EventHandler(this.button_EmanetSorgula_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 119);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(427, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "İşlem Seçiniz";
            // 
            // AnaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1137, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_KitaplarGrafik);
            this.Controls.Add(this.button_KitapBirak);
            this.Controls.Add(this.button_KitapAl);
            this.Controls.Add(this.button_EmanetSorgula);
            this.Controls.Add(this.button_KitapEkle);
            this.Controls.Add(this.button_KitapEklem);
            this.Controls.Add(this.button_OgrenciListele);
            this.Controls.Add(this.button_OgrenciEkle);
            this.Name = "AnaForm";
            this.Text = "Kütüphane Otomasyonu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_OgrenciEkle;
        private System.Windows.Forms.Button button_OgrenciListele;
        private System.Windows.Forms.Button button_KitapEklem;
        private System.Windows.Forms.Button button_KitapEkle;
        private System.Windows.Forms.Button button_KitaplarGrafik;
        private System.Windows.Forms.Button button_KitapBirak;
        private System.Windows.Forms.Button button_KitapAl;
        private System.Windows.Forms.Button button_EmanetSorgula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

