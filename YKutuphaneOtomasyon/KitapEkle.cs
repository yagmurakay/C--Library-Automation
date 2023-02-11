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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //ACcess veri tabanı bağlantısıyapılıyor

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            button_KitapGuncelle.Enabled = false;//Butonun tıklanması engelleniyor KitapId kontrolünden sonra açılacak
            button_KitapSil.Enabled = false;//Buton tıklanması engellneiyor KitapId kontrolünden sonra açılacak
            textBox_KitapID.MaxLength = 6;//KitapId 6 karakterle sınırlandırılıyor
        }

        private void button_KitapEkle_Click(object sender, EventArgs e)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)//Bağlantı kapalıysa
                {
                    if (textBox_KitapID.Text.Length < 6)//Ve KitapID 6 karakterde kısaysa
                    {
                        MessageBox.Show("Lütfen Kitap Id'yi 6 basamaklı giriniz", "Kitap Id Uzunluğu Hatası");
                        //Bilgilendirme
                    }
                    if (textBox_KitapID.Text.Length == 6 && textBox_KitapAdi.Text == "" && textBox_KitapTur.Text == "" && textBox_KitapYazar.Text == "" && textBox_SayfaSayisi.Text == "" && textBox_YayinEvi.Text == "" && dateTimePicker_BasimTarihi.Text == "")
                    {   //ID 6 karakterse
                        MessageBox.Show("Boş alanları doldurunuz", "Hata");
                        //Bilgilendirme
                    }
                    if (textBox_KitapID.Text != "" && textBox_KitapAdi.Text != "" && textBox_KitapTur.Text != "" && textBox_KitapYazar.Text != "" && textBox_SayfaSayisi.Text != "" && textBox_YayinEvi.Text != "" && dateTimePicker_BasimTarihi.Text != "")
                    {   //GErekli alanların hepsi doluysa
                        connection.Open();//Veri tabanı bağlantısı açılıyor
                        //VEri tabanına eklenecek değerler için sorgu yapılıyor
                        string sorgu = "insert into kitap(KitapID,KitapAd,Tur,Yazar,YayinEvi,BasimTarihi,SayfaSayisi,KitapDurum) values(@KitapID,@KitapAd,@Tur,@Yazar,@YayinEvi,@BasimTarihi,@SayfaSayisi,@KitapDurum)";
                        OleDbCommand komut = new OleDbCommand(sorgu, connection);
                        komut.Parameters.AddWithValue("@KitapID", textBox_KitapID.Text);
                        komut.Parameters.AddWithValue("@KitapAd", textBox_KitapAdi.Text);
                        komut.Parameters.AddWithValue("@Tur", textBox_KitapTur.Text);
                        komut.Parameters.AddWithValue("@Yazar", textBox_KitapYazar.Text);
                        komut.Parameters.AddWithValue("@YayinEvi", textBox_YayinEvi.Text);
                        komut.Parameters.AddWithValue("@BasimTarihi", dateTimePicker_BasimTarihi.Text);
                        komut.Parameters.AddWithValue("@SayfaSayisi", textBox_SayfaSayisi.Text);
                        komut.Parameters.AddWithValue("@KitapDurum", 1);
                        komut.ExecuteNonQuery();
                        //Veriler Ekleniyor
                        MessageBox.Show("Kitap Başarılı bir şekilde kaydedildi", "Kitap Kaydı");
                        //Kullanıcı bilgilendiriliyor
                        connection.Close();//Veri tabanı bağlantısı kapatılıyor
                        //Alanlar Temizleniyor
                        textBox_KitapAdi.Text = "";
                        textBox_KitapTur.Text = "";
                        textBox_KitapYazar.Text = "";
                        textBox_YayinEvi.Text = "";
                        dateTimePicker_BasimTarihi.Text = "";
                        textBox_SayfaSayisi.Text = "";
                    }

                }

            }
            catch (Exception ex)//HAta olursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor

                connection.Close();//Veri tabanı bağlantısı kesiliyor

            }
        }

        private void textBox_KitapID_TextChanged(object sender, EventArgs e)
        {   //ID yazılmaya başlandığında işlemler yapılıyor
            textBox_KitapID.Text = textBox_KitapID.Text.ToUpper();//Büyük harfe çevriliyor her girilen
            textBox_KitapID.SelectionStart = textBox_KitapID.Text.Length;

            if (connection.State == ConnectionState.Closed)//Veri tabanı bağlantısı kapalıysa
            {

                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Kitap ID ye göre veriler çekiliyor
                string sorgu = "select kitapID from Kitap";
                OleDbCommand komut = new OleDbCommand(sorgu, connection);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())//Veri olduğu sürece
                {
                    if (textBox_KitapID.Text == oku[0].ToString())
                    {   //Eğer girilen veri veri tabanında varsa
                        button_KitapEkle.Enabled = false;//EKleme alanı pasif
                        button_KitapSil.Enabled = true;//Silme seçeneği aktif ediliyor
                        button_KitapGuncelle.Enabled = true;//Güncelleme alanı aktif ediliyor

                        //İlgili Id için veriler çekiliyor
                        string Sorgu2 = ("select * from Kitap where kitapID like '" + textBox_KitapID.Text + "%'");
                        OleDbCommand Komut2 = new OleDbCommand(Sorgu2, connection);
                        OleDbDataReader Oku2 = Komut2.ExecuteReader();

                        while (Oku2.Read())//Veri okunduğu sürece sürece
                        {

                            if (textBox_KitapID.Text == Oku2[0].ToString())//ID değeri uyuşuyorsa
                            {   //Veriler alanlara atanıyor
                                textBox_KitapID.Text = Oku2[0].ToString();
                                textBox_KitapAdi.Text = Oku2[1].ToString();
                                textBox_KitapTur.Text = Oku2[2].ToString();
                                textBox_KitapYazar.Text = Oku2[3].ToString();
                                textBox_YayinEvi.Text = Oku2[4].ToString();
                                dateTimePicker_BasimTarihi.Text = Oku2[5].ToString();
                                textBox_SayfaSayisi.Text = Oku2[6].ToString();

                            }
                        }
                    }
                }
                connection.Close();//Veri tabanı bağlantısı kapatılıyor

            }
           
                //button_KitapEkle.Enabled = true;//Veri Tabanına ekleme aktif ediliyor
               // button_KitapGuncelle.Enabled = false;//false
                //button_KitapSil.Enabled = false;//false
            
               

            //Alanlar temizleniyor
                //textBox_KitapAdi.Text = "";
                //textBox_KitapTur.Text = "";
                //textBox_KitapYazar.Text = "";
                //textBox_YayinEvi.Text = "";
               // dateTimePicker_BasimTarihi.Text = "";
                //textBox_SayfaSayisi.Text = "";


            
        }

        private void button_KitapGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)//Bağlantı kapalıysa (ki kapalı olması lazım bu noktada)
                {
                    connection.Open();//Veri tabanı bağlantısı açılıyor
                    //Güncellemek için sorgu yazılıyor
                    string sorgu = "update Kitap set KitapAd=@KitapAd,Tur=@Tur,Yazar=@Yazar,YayinEvi=@YayinEvi,BasimTarihi=@BasimTarihi,SayfaSayisi=@SayfaSayisi where kitapID like '" + textBox_KitapID.Text + "%'";
                    OleDbCommand komut = new OleDbCommand(sorgu, connection);
                    komut.Parameters.AddWithValue("@KitapAd", textBox_KitapAdi.Text);
                    komut.Parameters.AddWithValue("@Tur", textBox_KitapTur.Text);
                    komut.Parameters.AddWithValue("@Yazar", textBox_KitapYazar.Text);
                    komut.Parameters.AddWithValue("@YayinEvi", textBox_YayinEvi.Text);
                    komut.Parameters.AddWithValue("@BasimTarihi", dateTimePicker_BasimTarihi.Text);
                    komut.Parameters.AddWithValue("@SayfaSayisi", textBox_SayfaSayisi.Text);
                    komut.ExecuteNonQuery();
                    //Veri tabanı için güncelleme kodları yazılıyor
                    connection.Close();//VEri tabanı bağlantısı kapatılıyor

                    MessageBox.Show("Güncelleme işlemi gerçekleşti", "Güncelleme İşlemi");
                    //Kullanıcı bilgilendiriliyor
                    //Alanlar temizleniyor
                    textBox_KitapAdi.Text = "";
                    textBox_KitapTur.Text = "";
                    textBox_KitapYazar.Text = "";
                    textBox_YayinEvi.Text = "";
                    dateTimePicker_BasimTarihi.Text = "";
                    textBox_SayfaSayisi.Text = "";
                }
            }
            catch(Exception ex)//Hata oluşursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }


           
        }

        private void button_KitapSil_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Silme iiçn gerekli veri tabanı sprgusu yazılıyor
                string sorgu = "delete from Kitap where kitapID like '" + textBox_KitapID.Text + "%'";
                OleDbCommand komut = new OleDbCommand(sorgu, connection);
                string onay = textBox_KitapID.Text.ToString();
                DialogResult olay = MessageBox.Show(onay + "KitapIDli Kayıt Silinsin mi?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //Kullanıcıdan onay bekleniyor
                if (DialogResult.Yes == olay)//Onay verilirse
                {
                    komut.ExecuteNonQuery();
                    //Veri tabanı işlemi gerçekleşiyor
                    MessageBox.Show("Kayıt Başarılı bir şekilde silindi", "Kitap Silme");
                    //Kullanıcı bilgilendiriliyor
                    //Alanlar temizleniyor
                    textBox_KitapAdi.Text = "";
                    textBox_KitapTur.Text = "";
                    textBox_KitapYazar.Text = "";
                    textBox_YayinEvi.Text = "";
                    dateTimePicker_BasimTarihi.Text = "";
                    textBox_SayfaSayisi.Text = "";


                }
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
            catch(Exception ex)//HAta oluşursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
        }
    }
}
