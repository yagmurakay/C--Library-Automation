using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;//Veri tabanı için gereken Access Kütüphanesi

namespace YKutuphaneOtomasyon
{
    public partial class EmanetSorgula : Form
    {
        public EmanetSorgula()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı oluşturuluyor
        public void Goster()//Veri tabanında Emanet alınmış kitaplar gösteriliyor Teslim edilme bilgileriyle beraber
        {
            connection.Open();
            string Sorgu = "Select AdSoyad,TCNo,KitapAdi,Durum,BitisTarihi,TeslimEdilenTarih From Emanet";
            //Emanet tablosundan verileri çekmek için gereken SQLsorgusu
            OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
            //Sorgumuzu bağlantı ile ilişkilendirip komutu oluşturduk
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            //Veri kaynağı ile bağlantı için adapter oluşturduk
            DataTable Table = new DataTable();
            //çektiğimiz verileri yazmak için DataTable tipinde bir nesne ürettik
            Adapter.Fill(Table);
            //DataTable'ın içini veri tabanından gelen verilerle doldurduk

            dataGridView_EmanetListesi.DataSource = Table;//dataGridview için verileri DataTable'den çekiyoruz
            dataGridView_EmanetListesi.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_EmanetListesi.Columns[1].HeaderText = "TC NO";

            dataGridView_EmanetListesi.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_EmanetListesi.Columns[3].HeaderText = "Durumu";
            dataGridView_EmanetListesi.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_EmanetListesi.Columns[5].HeaderText = "Teslim Tarihi";
            //yukarıda Sutunlara isim veriliyor

            // Sutunlarımızın boyutları belirleniyor.
            dataGridView_EmanetListesi.Columns[0].Width = 110;
            dataGridView_EmanetListesi.Columns[1].Width = 100;
            dataGridView_EmanetListesi.Columns[2].Width = 100;
            dataGridView_EmanetListesi.Columns[3].Width = 100;
            dataGridView_EmanetListesi.Columns[4].Width = 120;
            dataGridView_EmanetListesi.Columns[5].Width = 120;
            


            for (int i = 0; i < dataGridView_EmanetListesi.Rows.Count - 1; i++) //dataGridView in satır sayısı kadar işlem yapacağımızı söylüyoruz
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle(); //Renklendirme yapılıyor


                DateTime Tarih;//Tarih değişkenimiz oluşturuluyor
                Tarih = Convert.ToDateTime(dataGridView_EmanetListesi.Rows[i].Cells[4].Value); 
                //DataGrid'deki Tarih değişkenini Tarih değişkenimize aktarıyoruz.

                DateTime zaman = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                //Şu anda bulunduğumuz zamanı zaman değişkenine aktarıyoruz


                TimeSpan GunFarki = zaman.Subtract(Tarih); 
                //Renklendirme yapmak için şuanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyoruz
                
                
                int Fark = int.Parse(GunFarki.Days.ToString());//Tarih tipinden olan gün farkını işlem yapabilmek için integer'a çeciriyoruz
                
                if ((dataGridView_EmanetListesi.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi")) //Eğer İşlem yapılan veri Teslim Edilmedi ise
                { 
                    if (Fark < - 2)//Teslim tarihine 2 günden fazla varsa
                    { //Yeşil olarak ekrrana geliyor
                        CellColor.BackColor = Color.Green;//Arkaplan yeşil
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                    }
                    else if (Fark <= 2)//eğer iki gün ve daha az kaldıysa
                    { 
                        CellColor.BackColor = Color.Yellow; //Arka plana sarı renk atanıyor
                        CellColor.ForeColor = Color.Black;//Yazı rengi siyah yapılıyor
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//renk değerleri ilgili satıra yazılıyor
                    }
                    if (Fark > 0)
                    {

                        //Eğer günü geçmişse 
                        CellColor.BackColor = Color.Red;//Arka plan kırmızı yapılıyor
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz yapılıyor
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor

                    }
                }
                else
                {
                    //Teslim Edildi ise
                    CellColor.BackColor = Color.Green;//Arka plan rengi yeşil yapılıyor
                    CellColor.ForeColor = Color.White;//Yazı rengi beyaz yapılıyor
                    dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                }
            }

            connection.Close();
        }

        public void TcNoileGoster()
        {
            connection.Open();
            string Sorgu = "Select AdSoyad,TCNo,KitapAdi,BitisTarihi,TeslimEdilenTarih,Durum From Emanet Where TCNo LIKE '" + textBox_tcnoilearama.Text + "%'";
            //TC No ile yapılacak aramanın SQL sorgusu
            OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
            //Sorgu ile veri tabanı bağlantısının ilişkilendirlmesiyle oluşan komut
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
            //Komut nesneşi işleniyor
            DataTable Table = new DataTable();
            //Data Tablosu oluşturuluyor
            Adapter.Fill(Table);
            //Tablo veri tabanından gelen değerlerle doluyor

            dataGridView_EmanetListesi.DataSource = Table;//dataGridView için veri kaynağı belirleniyor
            //Alanlara / Sutunlara isim veriliyor
            dataGridView_EmanetListesi.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_EmanetListesi.Columns[1].HeaderText = "TC NO";
            dataGridView_EmanetListesi.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_EmanetListesi.Columns[3].HeaderText = "Bitiş Tarihi";
            dataGridView_EmanetListesi.Columns[4].HeaderText = "Teslim Tarihi";
            dataGridView_EmanetListesi.Columns[5].HeaderText = "Durumu";

            //Alanların boyutları belirleniyor
            dataGridView_EmanetListesi.Columns[0].Width = 110;
            dataGridView_EmanetListesi.Columns[1].Width = 100;
            dataGridView_EmanetListesi.Columns[2].Width = 100;
            dataGridView_EmanetListesi.Columns[3].Width = 100;
            dataGridView_EmanetListesi.Columns[4].Width = 120;
            dataGridView_EmanetListesi.Columns[5].Width = 120;



            for (int i = 0; i < dataGridView_EmanetListesi.Rows.Count - 1; i++)//Satır sayısı kadar işlem yapılıyor
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; //Tarih değişkeni oluşturruluyor
                Tarih = Convert.ToDateTime(dataGridView_EmanetListesi.Rows[i].Cells[4].Value); //Veri tabanındaki tarih Tarih değişkenine atanıyor

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                //Şuanki zaman değeri alınıyor ki teslim tarihi ile karşılaştırılsın

                TimeSpan GunFarki = Suan.Subtract(Tarih); //Veri tabanındaki tarih ile Şuanki zaman karşılaştırılıyor
                
                //Karşılaştırılınca elde edilen fark integera çevriliyor
                int Fark = int.Parse(GunFarki.Days.ToString());
                
                if ((dataGridView_EmanetListesi.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))//Eğer "Teslim Edilmedi" ise
                {
                    if (Fark < -2)
                    { //2 günden fazla varsa
                        CellColor.BackColor = Color.Green;//Arka plan yeşil
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                    }
                    else if (Fark <= 2)
                    {   //Teslime 2 gün veya daha az kaldıysa
                        CellColor.BackColor = Color.Yellow;//Arka plan sarı
                        CellColor.ForeColor = Color.Black;//Yazırengi siyah
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//renkler ilgili satıra atanıyor
                    }
                    if (Fark > 0)//Günü geçmişse
                    {

                        CellColor.BackColor = Color.Red;//Arkaplan kırmızı
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renkler ilgili satıra atanıyor

                    }
                }
                else //"Teslim Edildi" ise
                {
                    
                    CellColor.BackColor = Color.Green;//Arka plan yeşil
                    CellColor.ForeColor = Color.White;//Yazı rengi beyaz
                    dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renkler ilgili satıra atanıyor
                }
            }

            connection.Close();
        }

        public void TeselimetmeyenlerGoster()//Sadece Teslim Edilmeyen kitapları gösteren metot
        {
            connection.Open();
            string Sorgu = "Select AdSoyad,TCNo,KitapAdi,Durum,BitisTarihi,TeslimEdilenTarih From Emanet Where Durum Like '" + "Teslim Edilmedi" + "'";
            //Durumu "Teslim Edilmedi" olan kitapların emanet listesindeki verilerini çekmek için gereken sorgu
            OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
            //Sorgu bağlantı ile ilişkilendirilip komut oluşturuluyor
            OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);//Komut Adapter nesnesine gönderilerek işlem yapılıyor
            DataTable Table = new DataTable();//DataTable tipinden nesne üretiliyor
            Adapter.Fill(Table);//ÜÜretilen Tablonun içi verilerle dolduruluyır

            dataGridView_EmanetListesi.DataSource = Table;//dataGridView için Tablodaki veriler atanıyor
            //dataGridView alanlarına Header isimleri veriliyor
            dataGridView_EmanetListesi.Columns[0].HeaderText = "Ad Soyad";
            dataGridView_EmanetListesi.Columns[1].HeaderText = "TC NO";
            dataGridView_EmanetListesi.Columns[2].HeaderText = "Kitap Adı";
            dataGridView_EmanetListesi.Columns[3].HeaderText = "Durum";
            dataGridView_EmanetListesi.Columns[4].HeaderText = "Bitiş Tarihi";
            dataGridView_EmanetListesi.Columns[5].HeaderText = "Teslim Tarihi";

            //Alanların boyutları belirleniyor
            dataGridView_EmanetListesi.Columns[0].Width = 110;
            dataGridView_EmanetListesi.Columns[1].Width = 100;
            dataGridView_EmanetListesi.Columns[2].Width = 100;
            dataGridView_EmanetListesi.Columns[3].Width = 100;
            dataGridView_EmanetListesi.Columns[4].Width = 120;
            dataGridView_EmanetListesi.Columns[5].Width = 120;



            for (int i = 0; i < dataGridView_EmanetListesi.Rows.Count - 1; i++)//Toplam satır sayısı kadar işlem yapılıyor
            {
                DataGridViewCellStyle CellColor = new DataGridViewCellStyle();


                DateTime Tarih; // Tarih değişkeni oluşturduk.
                Tarih = Convert.ToDateTime(dataGridView_EmanetListesi.Rows[i].Cells[4].Value); //Veri tabanındaki tarihi tarih değişkenine atıyoruz

                DateTime Suan = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                //Şuanki zaman değeri çekiliyor

                TimeSpan GunFarki = Suan.Subtract(Tarih); //Şuanki zaman ile veritabanındaki kayıt zamanı karşılaştırılıyor
                //Renklendirme için Fark alınıyor
                
                int Fark = int.Parse(GunFarki.Days.ToString());//GunFarki integer tipine dönüştürülüyor
               
                if ((dataGridView_EmanetListesi.Rows[i].Cells[3].Value.ToString() == "Teslim Edilmedi"))//Eğer ilgili değer "Teslim Edilmedi" ise
                {
                    if (Fark < -2)//Teslim tarihine 2 günden fazla varsa
                    { 
                        CellColor.BackColor = Color.Green;//Arkaplan rengi yeşil yapılıyor
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz yapılıyor
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra aktarılıyor
                    }
                    else if (Fark <= 2)//Teslim tarihine 2 gün ve da az kaldıysa
                    { 
                        CellColor.BackColor = Color.Yellow;//Arkaplan  rengi Sarı yapılıyor
                        CellColor.ForeColor = Color.Black;// Yazı rengi siyah yapılıyor
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                    }
                    if (Fark > 0)//Eğer günü geçmişse
                    {

                        CellColor.BackColor = Color.Red;//Arka plan rengi kırmızı yapılıyor
                        CellColor.ForeColor = Color.White;//Yazı rengi beyaz yapılıyor
                        dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra yazılıyor

                    }
                }
                else//Eğer "Teslim Edildi" ise
                {
                   
                    CellColor.BackColor = Color.Green;//Arka plan rengi yeşil yapılıyor
                    CellColor.ForeColor = Color.White;//Yazı rengi beyaz yapılıyor 
                    dataGridView_EmanetListesi.Rows[i].DefaultCellStyle = CellColor;//Renk değerleri ilgili satıra atanıyor
                }
            }
            connection.Close();

        }

        private void EmanetSorgula_Load(object sender, EventArgs e)
        {
            dataGridView_EmanetListesi.ReadOnly = true; //Üstüne tıklanarak içeriği değiştirilmemesi sağlanıyor
           
            Goster();//İlgili metot sayesinde Veri tabanındaki Emanet listesi ekrana getiriliyor
            
        }

        private void dataGridView_EmanetListesi_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   //Ekranda sorgulama işlemi yapılırken Header tıklanınca veriler taze şekilde veri tabanından tekrar gösteriliyor
           
            Goster();//İlgili metotla veri tabanındaki veriler ekrana yazılıyor
            
        }

        private void textBox_tcnoilearama_TextChanged(object sender, EventArgs e)
        {
            TcNoileGoster();
            //Txt e yazılan TC ile arama yapılacak

        }

        private void button_TeslimEdilmeyenler_Click(object sender, EventArgs e)
        {
            TeselimetmeyenlerGoster();
            //Butona basılınca ilgili metotla Veri tabanındaki durumu "Teslim Edilmedi" olan veriler çekiliyor
        }

        private void button_Tumu_Click(object sender, EventArgs e)
        {
            Goster();
            //Butona basılınca veri tabanındaki Bütün Emanet verileri çekiliyor
        }
    }
}
