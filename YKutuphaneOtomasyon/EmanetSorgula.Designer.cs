
namespace YKutuphaneOtomasyon
{
    partial class EmanetSorgula
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
            this.button_TeslimEdilmeyenler = new System.Windows.Forms.Button();
            this.button_Tumu = new System.Windows.Forms.Button();
            this.dataGridView_EmanetListesi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tcnoilearama = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EmanetListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // button_TeslimEdilmeyenler
            // 
            this.button_TeslimEdilmeyenler.BackColor = System.Drawing.Color.Orange;
            this.button_TeslimEdilmeyenler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_TeslimEdilmeyenler.Location = new System.Drawing.Point(212, 51);
            this.button_TeslimEdilmeyenler.Name = "button_TeslimEdilmeyenler";
            this.button_TeslimEdilmeyenler.Size = new System.Drawing.Size(627, 77);
            this.button_TeslimEdilmeyenler.TabIndex = 12;
            this.button_TeslimEdilmeyenler.Text = "Teslim Edilmeyenler";
            this.button_TeslimEdilmeyenler.UseVisualStyleBackColor = false;
            this.button_TeslimEdilmeyenler.Click += new System.EventHandler(this.button_TeslimEdilmeyenler_Click);
            // 
            // button_Tumu
            // 
            this.button_Tumu.BackColor = System.Drawing.Color.Orange;
            this.button_Tumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Tumu.Location = new System.Drawing.Point(212, 144);
            this.button_Tumu.Name = "button_Tumu";
            this.button_Tumu.Size = new System.Drawing.Size(627, 76);
            this.button_Tumu.TabIndex = 11;
            this.button_Tumu.Text = "Tümü";
            this.button_Tumu.UseVisualStyleBackColor = false;
            this.button_Tumu.Click += new System.EventHandler(this.button_Tumu_Click);
            // 
            // dataGridView_EmanetListesi
            // 
            this.dataGridView_EmanetListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_EmanetListesi.Location = new System.Drawing.Point(107, 309);
            this.dataGridView_EmanetListesi.Name = "dataGridView_EmanetListesi";
            this.dataGridView_EmanetListesi.RowHeadersWidth = 51;
            this.dataGridView_EmanetListesi.RowTemplate.Height = 24;
            this.dataGridView_EmanetListesi.Size = new System.Drawing.Size(869, 321);
            this.dataGridView_EmanetListesi.TabIndex = 10;
            this.dataGridView_EmanetListesi.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_EmanetListesi_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(102, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Emanet Kitap Sorgusu İçin TC NO Giriniz :";
            // 
            // textBox_tcnoilearama
            // 
            this.textBox_tcnoilearama.Location = new System.Drawing.Point(549, 263);
            this.textBox_tcnoilearama.Name = "textBox_tcnoilearama";
            this.textBox_tcnoilearama.Size = new System.Drawing.Size(229, 22);
            this.textBox_tcnoilearama.TabIndex = 8;
            this.textBox_tcnoilearama.TextChanged += new System.EventHandler(this.textBox_tcnoilearama_TextChanged);
            // 
            // EmanetSorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1079, 642);
            this.Controls.Add(this.button_TeslimEdilmeyenler);
            this.Controls.Add(this.button_Tumu);
            this.Controls.Add(this.dataGridView_EmanetListesi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_tcnoilearama);
            this.Name = "EmanetSorgula";
            this.Text = "Emanet Sorgula";
            this.Load += new System.EventHandler(this.EmanetSorgula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EmanetListesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_TeslimEdilmeyenler;
        private System.Windows.Forms.Button button_Tumu;
        private System.Windows.Forms.DataGridView dataGridView_EmanetListesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tcnoilearama;
    }
}