
namespace YKutuphaneOtomasyon
{
    partial class KitapGrafik
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
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.BackColor = System.Drawing.SystemColors.Control;
            this.zedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl.IsShowPointValues = false;
            this.zedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.PointValueFormat = "G";
            this.zedGraphControl.Size = new System.Drawing.Size(800, 450);
            this.zedGraphControl.TabIndex = 10;
            // 
            // KitapGrafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "KitapGrafik";
            this.Text = "Kitap Grafik";
            this.Load += new System.EventHandler(this.KitapGrafik_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ZedGraph.ZedGraphControl zedGraphControl;
    }
}