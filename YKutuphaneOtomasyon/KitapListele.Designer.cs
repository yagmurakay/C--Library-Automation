
namespace YKutuphaneOtomasyon
{
    partial class KitapListele
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_KitapArama = new System.Windows.Forms.TextBox();
            this.dataGridView_KitapLİste = new System.Windows.Forms.DataGridView();
            this.button_TeslimAlanlar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KitapLİste)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(58, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kitap Aramak İçin ID Giriniz :";
            // 
            // textBox_KitapArama
            // 
            this.textBox_KitapArama.Location = new System.Drawing.Point(357, 171);
            this.textBox_KitapArama.Name = "textBox_KitapArama";
            this.textBox_KitapArama.Size = new System.Drawing.Size(170, 22);
            this.textBox_KitapArama.TabIndex = 6;
            this.textBox_KitapArama.TextChanged += new System.EventHandler(this.textBox_KitapArama_TextChanged);
            this.textBox_KitapArama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KitapArama_KeyPress);
            // 
            // dataGridView_KitapLİste
            // 
            this.dataGridView_KitapLİste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_KitapLİste.Location = new System.Drawing.Point(83, 238);
            this.dataGridView_KitapLİste.Name = "dataGridView_KitapLİste";
            this.dataGridView_KitapLİste.RowHeadersWidth = 51;
            this.dataGridView_KitapLİste.RowTemplate.Height = 24;
            this.dataGridView_KitapLİste.Size = new System.Drawing.Size(983, 350);
            this.dataGridView_KitapLİste.TabIndex = 5;
            // 
            // button_TeslimAlanlar
            // 
            this.button_TeslimAlanlar.BackColor = System.Drawing.Color.Orange;
            this.button_TeslimAlanlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_TeslimAlanlar.Location = new System.Drawing.Point(627, 150);
            this.button_TeslimAlanlar.Name = "button_TeslimAlanlar";
            this.button_TeslimAlanlar.Size = new System.Drawing.Size(361, 59);
            this.button_TeslimAlanlar.TabIndex = 8;
            this.button_TeslimAlanlar.Text = "Teslim Alanlar";
            this.button_TeslimAlanlar.UseVisualStyleBackColor = false;
            this.button_TeslimAlanlar.Click += new System.EventHandler(this.button_TeslimAlanlar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(73, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 55);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kitap Listele";
            // 
            // KitapListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1136, 614);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_TeslimAlanlar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_KitapArama);
            this.Controls.Add(this.dataGridView_KitapLİste);
            this.Name = "KitapListele";
            this.Text = "Kitap Listele";
            this.Load += new System.EventHandler(this.KitapListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KitapLİste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_KitapArama;
        private System.Windows.Forms.DataGridView dataGridView_KitapLİste;
        private System.Windows.Forms.Button button_TeslimAlanlar;
        private System.Windows.Forms.Label label1;
    }
}