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

namespace YKutuphaneOtomasyon
{
    public partial class KitapAl : Form
    {
        public KitapAl()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı
        public void KitapKayit()//Öğrenciye Kitap kaydı yapan metot
        {
            string emanetsayisi = "select EldekiEmanetCount from ogrenci where TCNo like'" + textBox_AliciTC.Text + "%'";
            //5 kitaptan fazla alamayacağı için önce kaç kitabı olduğu öğreniliyor, bununiçin gereken sorgu yazılmıştır
            OleDbCommand emanetkomut = new OleDbCommand(emanetsayisi, connection);
            OleDbDataReader oku = emanetkomut.ExecuteReader();
            while (oku.Read()) //Kayıda kadar okuma işlemi yapılıyor.
            {
                int Okuyucu = Convert.ToInt32(oku[0]);//Elinde bulunan kitap sayısı öğreniliyor
                if (Okuyucu <= 5)//Eğer 5 kitap sayısı aşılmadıysa 
                {
                    string Emanet = "Teslim Edilmedi";//Emanet durumu için kullanılmak üzere yapılan atama

                    string sorgu = "insert into Emanet(AdSoyad,TCNo,KitapID,KitapAdi,AlisTarihi,BitisTarihi,TeslimEdilenTarih,Durum) values (@AdSoyad,@TCNo,@KitapID,@KitapAdi,@AlisTarihi,@BitisTarihi,@TeslimEdilenTarih,@Durum)";
                    //Veri tabanına ekleme için gereken sorgu
                    OleDbCommand Komut = new OleDbCommand(sorgu, connection);
                    
                    Komut.Parameters.AddWithValue("@AdSoyad", textBox_AliciAdSoyad.Text);
                    Komut.Parameters.AddWithValue("@TCNo", textBox_AliciTC.Text);
                    Komut.Parameters.AddWithValue("@KitapID", textBox_AliciKitapID.Text);
                    Komut.Parameters.AddWithValue("@KitapAdi", textBox_AliciKitapAdi.Text);
                    Komut.Parameters.AddWithValue("@AlisTarihi", dateTimePicker_Baslangic.Text);

                    Komut.Parameters.AddWithValue("@BitisTarihi", dateTimePicker_Bitis.Text);
                    Komut.Parameters.AddWithValue("@TeslimEdilenTarih", dateTimePicker_Bitis.Text);
                    Komut.Parameters.AddWithValue("@Durum", Emanet);
                    Komut.ExecuteNonQuery();
                    //Alınan kitabı başkası almasın diye durumu "0" yapılıyor
                    string SorguKitapDurumu1 = "update Kitap set KitapDurum=@KitapDurum where KitapID like '" + textBox_AliciKitapID.Text + "%'";
                    OleDbCommand KomutKitapDurumu1 = new OleDbCommand(SorguKitapDurumu1, connection);
                    KomutKitapDurumu1.Parameters.AddWithValue("@KitapDurum", 0);
                    KomutKitapDurumu1.ExecuteNonQuery();
                    //TCNo ya göre öğrencinin toplam aldığı kitap ve eldeki emanet kitap sayısı getiriliyor
                    string SorguOkuyucuKitapSayisi = "select ToplamKitap,EldekiEmanetCount from ogrenci where TCNo like '" + textBox_AliciTC.Text + "%'";
                    OleDbCommand KomutOkuyucuKitapSayisi = new OleDbCommand(SorguOkuyucuKitapSayisi, connection);
                    OleDbDataReader OkuyucuKitapSayisi = KomutOkuyucuKitapSayisi.ExecuteReader();


                    while (OkuyucuKitapSayisi.Read()) // Okuma işlemi yapılıyr
                    {
                        int KitapSayisi = Convert.ToInt32(OkuyucuKitapSayisi[0]); //Veritabanından gelen değerler ilgili değişkene aktarılıyor
                        int EmanetSayisi = Convert.ToInt32(OkuyucuKitapSayisi[1]);//Veritabanından gelen değerler ilgili değişkene aktarılıyor

                        KitapSayisi = KitapSayisi + 1; //Kitap sayısı 1 arttırılıyor
                        EmanetSayisi = EmanetSayisi + 1; //Emanet sayısı 1 arttırılıyor
                        MessageBox.Show("Toplamda Alınan Kitap Sayisi " + KitapSayisi.ToString());
                        //İlgili öğrencinin toplamda kaç kitap aldığı kullanıcıya bildirillyor

                        //Toplam kitap sayısı ve Eldeki emanet sayısının yeni değerleri veri tabanına UPDATE ile yazılır 
                        string SorguOkuyucuKSayi = "update ogrenci set ToplamKitap=@ToplamKitap, EldekiEmanetCount=@EldekiEmanetCOunt where TCNo like '" + textBox_AliciTC.Text + "%'";
                        OleDbCommand KomutOkuyucuDurumu = new OleDbCommand(SorguOkuyucuKSayi, connection);
                        KomutOkuyucuDurumu.Parameters.AddWithValue("@ToplamKitap", KitapSayisi);
                        KomutOkuyucuDurumu.Parameters.AddWithValue("@EldekiEmanetCount", EmanetSayisi);
                        KomutOkuyucuDurumu.ExecuteNonQuery();
                    }

                    //Kitap kaydı yapıldıktan sonra veri tabanındaki güncel durum ekrana getiriliyor
                    string SorguOgr = "select TCNo,adSoyad,EldekiEmanetCount from ogrenci";
                    OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, connection);
                    OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
                    DataTable TableOgr = new DataTable(); // TAble olusturuluyor
                    AdaptorOgr.Fill(TableOgr); //Tablela veritabanındaki bilgiler ekleniyor.
                    dataGridView_OgrenciBilgileri.DataSource = TableOgr;
                    //Datagride Sütun headerlar veriliyor.
                    dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "TC NO";
                    dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
                    dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Kitap Sayısı";

                    //DataGrid sütun uzunlukları ayarlanıyor.
                    dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
                    dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
                    dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
                    dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Tıklanınca satırın tamamı seçiliyor           

                    label_BitisTarihi.Visible = false;//İşlemin bitiminde tekrar gizleniyorlar 
                    dateTimePicker_Bitis.Visible = false;//İşlemin bitiminde tekrar gizleniyorlar 

                    MessageBox.Show("Kitap Teslimi Kullanıcı Üzerine Yapıldı", "Sonuç");
                    //Kullanıcı bilgilendiriliyor
                }
                else
                {
                    MessageBox.Show(" Emanet Sayısı 5 Kitabı Aşamaz. Bu Kitabı Alamazsınız", "Uyarı");
                }
            }

        }

        private void KitapAl_Load(object sender, EventArgs e)
        {
            //Datagridview deki verilere tıklandığında değiştirilmemesi için değerlerini true yapıyoruz.
            dataGridView_KitapBilgileri.ReadOnly = true;
            dataGridView_OgrenciBilgileri.ReadOnly = true;
            //textboxlara dışarıdan girişler engelleniyor.
            textBox_AliciTC.ReadOnly = true;
            textBox_AliciAdSoyad.ReadOnly = true;
            textBox_AliciEmanet.ReadOnly = true;
            textBox_AliciKitapID.ReadOnly = true;
            textBox_AliciKitapAdi.ReadOnly = true;
            dateTimePicker_Baslangic.Enabled = false;//Alan otomatik doluyor
            dateTimePicker_Bitis.Visible = false;//Kitap seçildiğinde aktif olacak
            label_BitisTarihi.Visible = false;//Kitap seçildiğinde aktif olacak


            textBox_TcOgrBul.Focus();

            connection.Open(); //veri tabanı bağlantısı açılıyor
            //Sorgu ile Öğrenciler listeleniyor.
            string SorguOgr = "select TCNo,adSoyad,EldekiEmanetCount from ogrenci";
            OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, connection);
            OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
            DataTable TableOgr = new DataTable();
            AdaptorOgr.Fill(TableOgr);
            dataGridView_OgrenciBilgileri.DataSource = TableOgr;
            //Sütun isimleri veriliyor
            dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "Tc Kimlik No";
            dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Sayısı";

            //Sütun genişlikleri veriliyor
            dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
            dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
            dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
            dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView e tıklandığında tüm satırın seçilmesi sağlanıyor
            
            //connection.Close();//İşlem sonu  bağlantı kapatılıyor

            //connection.Open();//Bağlantı açılıyor

            //Veri tabanındaki kitaplar ekrana yazdırılıyor
            string SorguKtp = "select KitapID,KitapAd,Tur,Yazar from Kitap";
            OleDbCommand KomutKtp = new OleDbCommand(SorguKtp, connection);
            OleDbDataAdapter AdaptorKtp = new OleDbDataAdapter(KomutKtp);
            DataTable TableKtp = new DataTable();
            AdaptorKtp.Fill(TableKtp);
            dataGridView_KitapBilgileri.DataSource = TableKtp;

            //dataGridKitapBilgileri sütu başlıkları ayarlanyor.
            dataGridView_KitapBilgileri.Columns[0].HeaderText = "KitapID";
            dataGridView_KitapBilgileri.Columns[1].HeaderText = "Ktap Adı";
            dataGridView_KitapBilgileri.Columns[2].HeaderText = "Kitap Türü";
            dataGridView_KitapBilgileri.Columns[3].HeaderText = "Kitap Yazarı";

            //dataGridKitapBilgileri sütun genişlikleri ayarlanıyor.
            dataGridView_KitapBilgileri.Columns[0].Width = 100;
            dataGridView_KitapBilgileri.Columns[1].Width = 130;
            dataGridView_KitapBilgileri.Columns[2].Width = 113;
            dataGridView_KitapBilgileri.Columns[3].Width = 115;
            dataGridView_KitapBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tıklandığında tüm satırın seçilmesi sağlanıyor
            connection.Close();//Veri tabanı bağlantısı kapatılıyor
        }

        private void textBox_TcOgrBul_TextChanged(object sender, EventArgs e)
        {
            //Öğrenci Arama yapılırken çalışan kodlar
            
            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Her bir Tuşlamada çalışan kod TCno ile girilen rakamları içeren tc no değerlerini ekrana getirir
                //bunu sağlayan sorgu 
                string Sorgu = "select TCNo,adSoyad,EldekiEmanetCount from ogrenci where TCNo like '" + textBox_TcOgrBul.Text + "%'";
               
                OleDbCommand Komut = new OleDbCommand(Sorgu, connection);//Sorgu bağlantı ile ilişkilendirilip komutoluşturuuluyor
                OleDbDataAdapter Adaptor = new OleDbDataAdapter(Komut);
                DataTable Table = new DataTable();//Data table oluşturuluyor
                Adaptor.Fill(Table);//Data Tablosuna veri tabanından gelen veriler dolduruluyor
                dataGridView_OgrenciBilgileri.DataSource = Table;//dataGridView için veriler Tablodan alınıyor
                //Alanların Sütün isimleri veriliyor
                dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "TC NO";
                dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
                dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Kitap Sayısı";

                //ALanların genişlikleri belirleniyor
                dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
                dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
                dataGridView_OgrenciBilgileri.Columns[2].Width = 83;

                dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //Tıklandığında Satırın tamamının seçilmesi sağlanıyor
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
            catch(Exception ex)//Hata oluşusa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//KUllanıcıya Hata mesajı veriliyor
                connection.Close();
                //Veri tabanı bağlantısı kesiiyor
            }

        }

        private void textBox_KitapAd_TextChanged(object sender, EventArgs e)//KitapID
        {
            //Kitap ID yazılmaya başlandığı anda arama başlayacak

            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //TCNo için girili değer ile arama yapılıyor
                string SorguKtp = "select KitapID,KitapAd,Tur,Yazar from Kitap where KitapID like '" + textBox_KitapAd.Text + "%'";
                OleDbCommand KomutKtp = new OleDbCommand(SorguKtp, connection);//sorgu bağlantı ile ilişkilendirilip komut oluşturuluyor
                OleDbDataAdapter AdaptorKtp = new OleDbDataAdapter(KomutKtp);//bağlantı için köprü görevi görüyor
                DataTable TableKtp = new DataTable();//data tablosu oluşturuluyor
                AdaptorKtp.Fill(TableKtp);//tablo veri tabanından gelen değerler ile doluyor
                dataGridView_KitapBilgileri.DataSource = TableKtp;//tablodaki değerler ekrana yazdırılmak üzere atanıyor

                //Sütunlara  isim veriliyor
                dataGridView_KitapBilgileri.Columns[0].HeaderText = "KitapId";
                dataGridView_KitapBilgileri.Columns[1].HeaderText = "Ktap Adı";
                dataGridView_KitapBilgileri.Columns[2].HeaderText = "Kitap Türü";
                dataGridView_KitapBilgileri.Columns[3].HeaderText = "Kitap Yazarı";

                //Sutun botutları belirleniyor
                dataGridView_KitapBilgileri.Columns[0].Width = 100;
                dataGridView_KitapBilgileri.Columns[1].Width = 130;
                dataGridView_KitapBilgileri.Columns[2].Width = 113;
                dataGridView_KitapBilgileri.Columns[3].Width = 115;


                dataGridView_KitapBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
                //Tıklandığında tüm satırların seçilmesi sağlanıyor

                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
            catch(Exception ex)//Hata oluşursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu");//Kullanıcı bilgilendiriliyor
                connection.Close();
                //Veri tabanı bağlantısı kesiliyor
            }
        }

        private void dataGridView_OgrenciBilgileri_Click(object sender, EventArgs e)
        {   //Öğrenci Ekranda seçilmesi için
            try
            {   //Herhangi bir yere tıklandığında hata almamak için try-catch kullanıldı.
                textBox_AliciTC.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[0].Value.ToString();
                textBox_AliciAdSoyad.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[1].Value.ToString();
                textBox_AliciEmanet.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception)//Hata olursa
            {

                MessageBox.Show("Lütfen Emanet Almak için istenilen Alanı Seçiniz.", "HATA!!");
            }
        }

        private void dataGridView_KitapBilgileri_Click(object sender, EventArgs e)
        {   //Ekrandan kitap seçimi yapılması iççin
            try
            {
                dateTimePicker_Bitis.Visible = true; 
                //Kitap seçildiğinde görünür yapılıyorlar
                label_BitisTarihi.Visible = true;

                textBox_AliciKitapID.Text = dataGridView_KitapBilgileri.SelectedRows[0].Cells[0].Value.ToString();
                textBox_AliciKitapAdi.Text = dataGridView_KitapBilgileri.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (Exception)//Hata olursa
            {

                MessageBox.Show("Lütfen Emanet Almak için istenilen Alanı Seçiniz.", "HATA");
            }
        }

        private void button_KitapAl_Click(object sender, EventArgs e)
        {
            if (textBox_AliciKitapID.Text != "" && textBox_AliciKitapAdi.Text != "" && textBox_AliciTC.Text != "" && textBox_AliciAdSoyad.Text != "" && textBox_AliciEmanet.Text != "")
            {//Gerekli ALanlar doluysa
                if (connection.State == ConnectionState.Closed)//Veri tabanı bağlantısı kapalıysa
                {
                    connection.Open();//Veri tabanı bağlantısı açılıyor
             
                    //Id değeri ile emanet durumu getiriliyor
                    string SorguKontrolKitapID = "select KitapID,Durum from Emanet where KitapID like '" + textBox_AliciKitapID.Text + "%' ";
                    OleDbCommand KomutKontrolKitapID = new OleDbCommand(SorguKontrolKitapID, connection);
                    OleDbDataReader OkuKontrolKitapID = KomutKontrolKitapID.ExecuteReader();



                    if (OkuKontrolKitapID.HasRows == false) 
                    {//Veri tabanında kayıt yoksa kayıt yapılıyor
                        KitapKayit();//Öğrenciye Kitap kaydı yapan metot
                    }
                    else//Kayıt varsa
                    {
                        //Kitabın durumu kontrol ediliyor
                        string KitapDurumu = "select KitapDurum from Kitap where KitapID like '" + textBox_AliciKitapID.Text + "%'";
                        OleDbCommand KomutKitapDurumu = new OleDbCommand(KitapDurumu, connection);
                        OleDbDataReader OkuKitapDurumu = KomutKitapDurumu.ExecuteReader();

                        int Durum = 0;//Durum kontrolü için yazılan değişken ve değeri

                        while (OkuKitapDurumu.Read())
                        {
                            if (Durum == Convert.ToInt32(OkuKitapDurumu["KitapDurum"]))//Kitap durumu 0 ise birisi almıştır ve başkasına verilemez
                            {
                                MessageBox.Show("Bu Kitap Başka Kullanıcı Üzerinde Bulunmaktadır. Kitap Teslim Verilemez ", "UYARI");
                                //Kullanıcı bilgilendiriliyor
                            }
                            else//kitap uygunsa Öğrenci üzerine kitap kaydediliyor
                            {
                                KitapKayit(); //Öğrenci üzerine kitap kaydeden metot

                            }
                        }
                    }
                    connection.Close();//Veri tabanı bağlantısı kapatılıyor

                }
            }
            else//Gerekli alanlarda eksik varsa
            {
                MessageBox.Show("Bilgileri eksik doldurdunuz");
            }
            
        }

        private void dataGridView_OgrenciBilgileri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
