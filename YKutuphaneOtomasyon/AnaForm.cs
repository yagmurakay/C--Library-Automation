using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YKutuphaneOtomasyon
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button_OgrenciEkle_Click(object sender, EventArgs e)
        {
            Ogrenci_islem ogr = new Ogrenci_islem();//Öğrenci İşlem formundan nesne üretiliyor
            ogr.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void button_OgrenciListele_Click(object sender, EventArgs e)
        {
            OgrenciListele ogrList = new OgrenciListele();//Öğrenci Listele formundan nesne üretiliyor
            ogrList.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void button_KitapEklem_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();//Kitap Ekle Formundan nesne üretiliyor
            kitapEkle.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor

        }

        private void button_KitapEkle_Click(object sender, EventArgs e)
        {
            KitapListele kitapList = new KitapListele();//Kitap Listele formundan nesne üretiliyor
            kitapList.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void button_EmanetSorgula_Click(object sender, EventArgs e)
        {
            EmanetSorgula eSorgu = new EmanetSorgula();//EmanetSorgula formundan nesne üretiliyor
            eSorgu.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void button_KitapAl_Click(object sender, EventArgs e)
        {
            KitapAl kitapal = new KitapAl();//Kitap Al formunun nesnesi Üretiliyor
            kitapal.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_KitapBirak_Click(object sender, EventArgs e)
        {
            KitapBirak kbirak = new KitapBirak();//Kitap Bırak formundan nesne üretiliyor
            kbirak.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }

        private void button_KitaplarGrafik_Click(object sender, EventArgs e)
        {
            KitapGrafik grafik = new KitapGrafik();//Kitap Grafik formundan nesne üretiliyor(ZedGraph)
            grafik.Show();//Üretilen nesnenin ekranda gösterilmesi sağlanıyor
        }
    }
}
