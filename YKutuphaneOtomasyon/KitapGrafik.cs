using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Access veri tabanı için gereken kütüphane
using ZedGraph;//Grafik için gereken kütüphane

namespace YKutuphaneOtomasyon
{
    public partial class KitapGrafik : Form
    {
        public KitapGrafik()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı yapılıyor 

        public void ZedGraph_Olustur(ZedGraphControl zg)
        {
            connection.Open();//Veri tabanı bağlantısı açılıyor


            string GrafikSorgu = "Select count(*) From Kitap";
            //Grafikten aranan değerin kaç tane olduğu çekiliyor(ki bu durumda toplam kitap sayısı)
            OleDbCommand KomutGrafik = new OleDbCommand(GrafikSorgu, connection);
            double KitapSayisi = Convert.ToDouble(KomutGrafik.ExecuteScalar());
            
            string SorguTeslimEdilmeyen = "Select count(*) From Emanet where Durum Like '" + "Teslim Edilmedi" + "'";
            //"Teslim Edlimedi" olan kitapların sayısıı alınıyor
            OleDbCommand KomutTeslimEdilmeyen = new OleDbCommand(SorguTeslimEdilmeyen, connection);

            double TeslimEdilmeyenSayisi = Convert.ToDouble(KomutTeslimEdilmeyen.ExecuteScalar());
           
            string SorguTeslimedilen = "Select count(*) from Emanet where Durum like'" + "Teslim Edildi" + "'";
            OleDbCommand KomutTeslimEdildi = new OleDbCommand(SorguTeslimedilen, connection);
            //"Teslim Edildi" olan kitapların sayısı alınıyor
            double TeslimEdilenSayisi = Convert.ToDouble(KomutTeslimEdildi.ExecuteScalar());

            GraphPane pane = zg.GraphPane;
            pane.Title = "Kütüphane Kitap Sayıları";//Grafik başlığı 
            
            pane.XAxis.Title = "Kitaplar";//X ekseni başlığı
            
            pane.YAxis.Title = "Kitap Sayisi";//Y ekseni başlığı
            
            string[] YIsimler = { "Tüm Kitaplar", "Teslim Edilmeyenler", "Teslim Edilenler" };

            double[] Ciz = { KitapSayisi, 0, 0 };
            //Zedgraph degeri cekiliyor
            double[] Teslimedilmeyen = { 0, TeslimEdilmeyenSayisi, 0 };
            double[] TeslimEdilen = { 0, 0, TeslimEdilenSayisi };

            BarItem bar = pane.AddBar("Tüm Kitaplar", null, Ciz, Color.Orange);
            bar = pane.AddBar("Teslim Edilmeyen", null, Teslimedilmeyen, Color.DeepSkyBlue);
            bar = pane.AddBar("Teslim Edilen", null, TeslimEdilen, Color.Purple);

            pane.Legend.FontSpec.Size = 20;//Grafiğin yazı boyutu
            

            pane.XAxis.IsTicsBetweenLabels = true;//Ayraç komutu
           

            pane.XAxis.TextLabels = YIsimler;//eksen değişkenleri tanımlı değişkene atanıyor
            pane.XAxis.Type = AxisType.Text;//Eksen değerlerinin yazı tipi olması sağlanıyor
            
            

            connection.Close();//Veri tabanı bağlantısı kapatılıyor
            
            zg.AxisChange();

        }



        private void KitapGrafik_Load(object sender, EventArgs e)
        {
            this.ZedGraph_Olustur(zedGraphControl);
            //Grafik oluşturma metodu çağrılıyor form çalışınca grafik ekrana geliyor
        }
    }
}
