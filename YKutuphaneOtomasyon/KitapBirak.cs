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
    public partial class KitapBirak : Form
    {
        public KitapBirak()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı
        private void KitapBirak_Load(object sender, EventArgs e)
        {   //Form yüklenince çalışacak kod
            dateTimePicker_TEslimTarihi.Enabled = false;//Alanın elle değişmesi engelleniyor
            textBox_EmanetKitap.Visible = false;//Alan gizleniyor
            textBox_EmanetKitap.Enabled = false;//Alanın elle değişmesi engelleniyor
            label_Emanet.Visible = false;//Alan gizleniyor
            dataGridView_TeslimOnay.ReadOnly = true;//Elle değiştirilmesi engelleniyor
            dataGridView_OgrenciBilgileri.ReadOnly = true;//Elle değiştirilmesi engelleniyor

            connection.Open(); //veri tabanı bağlantısı açılıyor
            //Öğrenciler Listeleniyor
            string SorguOgr = "select TCNo,adSoyad,EldekiEmanetCount from ogrenci";//Sorgu
            OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, connection);
            OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
            DataTable TableOgr = new DataTable();
            AdaptorOgr.Fill(TableOgr);
            dataGridView_OgrenciBilgileri.DataSource = TableOgr;//Data kaynağı belirtiliyor
            //Alanlara / Sütunlara isim veriliyor
            dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "Tc Kimlik No";
            dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Sayısı";

            //Alanların genişlikleri veriliyor
            dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
            dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
            dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
            dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tıklandığında tüm satırın seçilmesi sağlanıyor
            connection.Close();//Veri tabanı bağlantısı kapatılıyor

        }

        public void Goster()//seçilen kişi ile ilgili tabloya veriler çekiliyor
        {
            //Sorguda join işlemi yapılarak iki tablodan veriler çekiliyor.
            string Sorgu = "Select E.AdSoyad,E.TCNo,E.KitapAdi,E.Durum,E.BitisTarihi,E.KitapID,O.Ceza from Emanet E,ogrenci O where O.TCNo=E.TCNo and E.TCNo like '" +
                textBox_TCNO.Text + "%' and E.Durum like '" + "Teslim Edilmedi" + "'";
            OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            OleDbDataReader Oku = Komut.ExecuteReader();


            dataGridView_TeslimOnay.DataSource = Table;//Veri kaynağı atanıyor
            //Alanların isimleri belirtiliyor
            dataGridView_TeslimOnay.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_TeslimOnay.Columns[1].HeaderText = "TC NO";
            dataGridView_TeslimOnay.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_TeslimOnay.Columns[3].HeaderText = "Emanet Durumu";
            dataGridView_TeslimOnay.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_TeslimOnay.Columns[5].HeaderText = "KitapID";
            dataGridView_TeslimOnay.Columns[6].HeaderText = "Ceza";

            //Alanların genişliği belirleniyor
            dataGridView_TeslimOnay.Columns[0].Width = 115;
            dataGridView_TeslimOnay.Columns[1].Width = 100;
            dataGridView_TeslimOnay.Columns[2].Width = 100;
            dataGridView_TeslimOnay.Columns[3].Width = 100;
            dataGridView_TeslimOnay.Columns[4].Width = 140;
            dataGridView_TeslimOnay.Columns[5].Width = 70;
            dataGridView_TeslimOnay.Columns[6].Width = 70;



            for (int i = 0; i < dataGridView_TeslimOnay.Rows.Count - 1; i++) //Sütun sayısı kadar işlem yapan döngü
            {   //Renklendirmek için cellstyle kullanılıyor
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; //Tarih değişkeni
                Tarih = Convert.ToDateTime(dataGridView_TeslimOnay.Rows[i].Cells[4].Value);
                //Veri tabanından gelen tarih DateTime tipine çevrilip bu değişkene atanıyor

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                //Suanki zaman değeri alınıyor

                TimeSpan GunFarki = Suan.Subtract(Tarih);
                //Şuanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                                                          
                //Bu karşılaştırma sonucuna görede renklendirme işlemi yapılıyor.

                int Fark = int.Parse(GunFarki.Days.ToString());//Aradaki fark integere çevrilip değişkene atanıyor

                if ((dataGridView_TeslimOnay.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))
                {
                    //Teslim edilmeyen değerler üzerinde işlem yapılıyor
                    if (Fark < -2)//2 günden fazla süre varsa teslime
                    { 
                        CellColor.BackColor = Color.Green;//Arka plan yeşil
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//renk değerleri ilgili satıra aktarılıyor
                    }
                    else if (Fark <= 2)//Teslim tarihine 2 gün veya daha az kaldıysa
                    { 
                        CellColor.BackColor = Color.Yellow;//Arka plan sarı
                        CellColor.ForeColor = Color.Black;//Yazı rengi siyah
                        dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//İlgili satıra renk değerleri atanıyor
                    }
                    if (Fark > 0)//Teslim tarihi geçmişse
                    {

                        CellColor.BackColor = Color.Red;//Arka plan kırmızı
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor

                    }
                }
                else//Teslim Edildi ise
                {
                    
                    CellColor.BackColor = Color.Green;//Arka plan yeşil
                    CellColor.ForeColor = Color.White;//yazı rengi beyaz
                    dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//renk değerleri ilgili satıra atanıyor
                }
            }
            dataGridView_TeslimOnay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tıklandığında satırı tamamen seçiyor
        }

        private void button_EmanetTCKontrol_Click(object sender, EventArgs e)
        {
            if (textBox_TCNO.Text != "")//Tc no alanı boş değilse
            {


                try
                {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Sorguda ikitablodanda veriler çekiliyor.
                string Sorgu = "select E.AdSoyad,E.TCNo,E.KitapAdi,E.Durum,E.BitisTarihi,E.KitapID,O.Ceza from Emanet E,ogrenci O where O.TCNo=E.TCNo and E.TCNo like '" + textBox_TCNO.Text + "%' and E.Durum like '" + "Teslim Edilmedi" + "'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
                OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
                DataTable Table = new DataTable();
                Adapter.Fill(Table);
                OleDbDataReader Oku = Komut.ExecuteReader();

                dataGridView_TeslimOnay.DataSource = Table;//Veri kaynağı atanıyor
                    //Alanların isimleri veriliyor
                dataGridView_TeslimOnay.Columns[0].HeaderText = "Ad Soyad";
                dataGridView_TeslimOnay.Columns[1].HeaderText = "Tc Kimlik No";
                dataGridView_TeslimOnay.Columns[2].HeaderText = "Kitap Adı";
                dataGridView_TeslimOnay.Columns[3].HeaderText = "Emanet Durumu";
                dataGridView_TeslimOnay.Columns[4].HeaderText = "Bitiş Tarihi";
                dataGridView_TeslimOnay.Columns[5].HeaderText = "Kitap ID";
                dataGridView_TeslimOnay.Columns[6].HeaderText = "Ceza";


                 //Alanların genişlikleri belirleniyor
                dataGridView_TeslimOnay.Columns[0].Width = 115;
                dataGridView_TeslimOnay.Columns[1].Width = 100;
                dataGridView_TeslimOnay.Columns[2].Width = 100;
                dataGridView_TeslimOnay.Columns[3].Width = 100;
                dataGridView_TeslimOnay.Columns[4].Width = 140;
                dataGridView_TeslimOnay.Columns[5].Width = 70;
                dataGridView_TeslimOnay.Columns[6].Width = 70;



                for (int i = 0; i < dataGridView_TeslimOnay.Rows.Count - 1; i++)//Satır sayısı kadar işlem yapılıyor
                {
                    DataGridViewCellStyle CellColor = new DataGridViewCellStyle();//Renklendirme için!



                    DateTime Tarih;//Tarih değişkeni oluşturuluyor
                    Tarih = Convert.ToDateTime(dataGridView_TeslimOnay.Rows[i].Cells[4].Value);
                        //Veri tabanından çekilen tarih değişkeni DateTime tipine dönüştürülüp Değişkene atanıyor

                    DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                        //Şuandaki zaman değeri çekiliyor

                    TimeSpan GunFarki = Suan.Subtract(Tarih);//Veri tabanındaki tarih ile şuanki tarih arasındaki fark alınıyor
                    int Fark = int.Parse(GunFarki.Days.ToString());
                        //Alınan fark integer tipine değiştirilip değişken atanıyor
                   
                    if ((dataGridView_TeslimOnay.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))//Veri tabanının ilgili alanındaki değer "Teslim Edilmedi" ise
                    {
                        if (Fark < -2)//2 günden fazla varsa teslim tarihine
                        { 
                            CellColor.BackColor = Color.Green;//Arka plan rengi yeşil
                            CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                            dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                        }
                        else if (Fark <= 2)//Teslime 2 gün veya daha az kalmışsa
                        { 
                            CellColor.BackColor = Color.Yellow;//Arka plan rengi
                            CellColor.ForeColor = Color.Black;//Yazı rengi
                            dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                        }
                        if (Fark > 0)//Teslim tarihi geçmişse
                        {

                            CellColor.BackColor = Color.Red;//Arka plan kırmızı
                            CellColor.ForeColor = Color.White;//yazı rengi beyaz
                            dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                        }
                    }
                    else//Teslim Edildi ise
                    {
                        
                        CellColor.BackColor = Color.Green;//Arka plan yeşil
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_TeslimOnay.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                    }
                }
                dataGridView_TeslimOnay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //Tıklandığında tüm satır seçiliyor
                    
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
                }
                catch(Exception ex)//Hata oluşursa
                {
                    MessageBox.Show(ex.Message, "Bir Şey Oldu");//Kullanıcı bilgilendiriliyor
                    connection.Close();//Veri tabanı bağlantısı kesiliyor
                }
            }
            else//TC No alanı boş bırakıldıysa
            {
                MessageBox.Show("Lütfen TcKimlik Numarası Giriniz", "TC NO Eksik");
                //Bilgilendirme mesajı
            }
        }

        private void dataGridView_TeslimOnay_Click(object sender, EventArgs e)
        {
            try
            {   //Tıklandığında bilgiler textboxa aktarılıyor.
                textBox_EmanetKitap.Text = dataGridView_TeslimOnay.SelectedRows[0].Cells[5].Value.ToString();
                textBox_EmanetKitap.Visible = true;
                label_Emanet.Visible = true;

            }
            catch (Exception)
            {

                MessageBox.Show("Hata Lütfen Tekrar Deneyiniz", "Hata");
                //Hata mesajı
            }
        }

        private void button_TeslimOnay_Click(object sender, EventArgs e)
        {
            if (textBox_EmanetKitap.Text != "")//ALan boş değilse
            {
                try
                {

                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Emanet durumunu güncelleyen veri tabanı sorgusu
                string TeslimTarihiYaz = "update Emanet set TeslimEdilenTarih=@TeslimEdilenTarih where KitapID like '" + textBox_EmanetKitap.Text + "%' and Durum like '" + "Teslim Edilmedi" + "%'";
                OleDbCommand KomutTeslimTarihi = new OleDbCommand(TeslimTarihiYaz, connection);
                KomutTeslimTarihi.Parameters.AddWithValue("@TeslimEdilenTarih", dateTimePicker_TEslimTarihi.Text);
                KomutTeslimTarihi.ExecuteNonQuery();

                    //Kitap Durumunu güncelleyen veri tabaın sorgusu
                string Sorgu = "update Kitap set KitapDurum=@KitapDurum where KitapID like '" + textBox_EmanetKitap.Text + "%'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
                Komut.Parameters.AddWithValue("@KitapDurumu", 1);
                Komut.ExecuteNonQuery();

                //Durum bilgisini güncelleyen veri tabanı sorgusu
                string SorguOkuyucu = "update Emanet set Durum=@Durum where KitapID like '" + textBox_EmanetKitap.Text + "%'";
                OleDbCommand KomutOkuyucu = new OleDbCommand(SorguOkuyucu, connection);
                KomutOkuyucu.Parameters.AddWithValue("@Durum", "Teslim Edildi");
                KomutOkuyucu.ExecuteNonQuery();


                //Öğrencinin Elinde bulunan kitap sayısını alıyoruz
                string EmanetCek = "select EldekiEmanetCount from ogrenci where TCNo like '" + textBox_TCNO.Text + "%'";
                OleDbCommand KomutEmanetCek = new OleDbCommand(EmanetCek, connection);
                OleDbDataReader OkuyucuEmanetSayisi = KomutEmanetCek.ExecuteReader();
                while (OkuyucuEmanetSayisi.Read())
                {

                    int EmanetSayisi = Convert.ToInt32(OkuyucuEmanetSayisi[0].ToString());
                    EmanetSayisi = EmanetSayisi - 1;

                    //Eldeki kitap sayısında güncelleme yapılıyor
                    string SorguEmanet = "update ogrenci set EldekiEmanetCount=@EldekiEmanetCount Where TCNo Like '" + textBox_TCNO.Text + "%'";

                    OleDbCommand KomutEmanet = new OleDbCommand(SorguEmanet, connection);
                    KomutEmanet.Parameters.AddWithValue("@EldekiEmanetCount", EmanetSayisi);
                    KomutEmanet.ExecuteNonQuery();
                }


                DateTime Tarih;//Tarih değişkeni
                Tarih = Convert.ToDateTime(dataGridView_TeslimOnay.SelectedRows[0].Cells[4].Value.ToString());
                    //Veri tabanından çekilen tarih tip dönüşümü yapılıp Tarih değişkenine atanıyor
                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    //Anlık zaman bilgisi çekiliyor


                TimeSpan GunFarki = Suan.Subtract(Tarih);
                    //Veri tabanındaki tarih ile Anlık zamanın farkı alınıyor
                int Fark = int.Parse(GunFarki.Days.ToString());
                    //Fark değeri integere çevrilip ilgili değere atanıyor

                //Girilen TC NO ya göre Ceza değeri alınıyor
                string CezaGetir = "select Ceza from ogrenci where TCNo like '" + textBox_TCNO.Text + "%'";
                OleDbCommand KomutCezaGetir = new OleDbCommand(CezaGetir, connection);
                OleDbDataReader CezaOku = KomutCezaGetir.ExecuteReader();
                if (CezaOku.Read()) // Ceza okunuyor
                {

                    if (Fark > 0) //Fark değerine göre
                    {
                        int CezaDegeri = Convert.ToInt32(CezaOku["Ceza"]);
                        int CezaPuanı = 0;
                        //Ceza ve fark değerleriyle belirleniyor
                        CezaPuanı = (Fark + CezaDegeri);
                        //Ceza durumu güncelleniyor
                        string SorguCeza = "update ogrenci set Ceza=@Ceza where TCNo like '" + textBox_TCNO.Text + "%'";
                        OleDbCommand KomutCeza = new OleDbCommand(SorguCeza, connection);
                        KomutCeza.Parameters.AddWithValue("@Ceza", CezaPuanı);
                        KomutCeza.ExecuteNonQuery();
                        MessageBox.Show("Okuyucunun Para Cezası" + CezaPuanı.ToString() + " TL'Dir");
                    }
                }


                Goster();//Kişi ile ilgili veriler tabloya çekiliyor
                connection.Close();//Veri tabanı bağlantısı kapatılıyor 

                textBox_EmanetKitap.Text = "";//Alan temizleniyor
                textBox_EmanetKitap.Visible = false;//ALan gizleniyor
                label_Emanet.Visible = false;//ALan gizleniyor

                }
                catch(Exception ex)//Hata olursa
                {
                    MessageBox.Show(ex.Message, "Birşey Oldu!!!");//Kullanıcı bilgilendiriliyor
                    connection.Close();//Veri tabanı bağlantısı kesiliyor
                }
            }
            else//Kitap seçimi yapılmadıysa
            {
                MessageBox.Show("Lütfen Kitap Seçimini Yapınız");
                //Kullanıcıya mesaj
            }

            connection.Open(); //veri tabanı bağlantısı açılıyor
            //Öğrencileri listeleyen sorgu
            string SorguOgr = "select TCNo,adSoyad,EldekiEmanetCount from ogrenci";
            OleDbCommand KomutOgr = new OleDbCommand(SorguOgr, connection);
            OleDbDataAdapter AdaptorOgr = new OleDbDataAdapter(KomutOgr);
            DataTable TableOgr = new DataTable();
            AdaptorOgr.Fill(TableOgr);
            dataGridView_OgrenciBilgileri.DataSource = TableOgr;//Data kaynağı atanıyor
            
            //Alanların işimleri veriliyor
            dataGridView_OgrenciBilgileri.Columns[0].HeaderText = "Tc Kimlik No";
            dataGridView_OgrenciBilgileri.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView_OgrenciBilgileri.Columns[2].HeaderText = "Emanet Sayısı";

            //ALanların genişliği belirleniyor
            dataGridView_OgrenciBilgileri.Columns[0].Width = 100;
            dataGridView_OgrenciBilgileri.Columns[1].Width = 135;
            dataGridView_OgrenciBilgileri.Columns[2].Width = 83;
            dataGridView_OgrenciBilgileri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tıklandığında tamamının seçilmesi sağlanıyor
            connection.Close();//VEri tabanı bağlantısı Kesiliyor

        }

        private void dataGridView_OgrenciBilgileri_Click(object sender, EventArgs e)
        {
            textBox_TCNO.Text = dataGridView_OgrenciBilgileri.SelectedRows[0].Cells[0].Value.ToString();
            //Tıklanınca TC no textBox a atanıyor
        }

        private void dataGridView_OgrenciBilgileri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
