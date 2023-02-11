using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Access veri tabanı için gerekli bağlantı

namespace YKutuphaneOtomasyon
{
    public partial class Ogrenci_islem : Form
    {
        public Ogrenci_islem()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
            Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı oluşturuluyor



        private void Ogrenci_islem_Load(object sender, EventArgs e)
        {
            button_OgrenciGuncelle.Enabled = false;//Öğrencinin veri tabanında olduğu kesinleşince aktifleşecek
            button_OgrenciSil.Enabled = false;//Öğrencinin veri tabanında olduğu kesinleşince aktifleşecek
        }


        int AtIsareti, NoktaIsareti;//Mail kontrolunde kullanılacak değişkenler

        private void textBox_TCNO_TextChanged(object sender, EventArgs e)
        {
            //TC ile arama işlemi
            if (textBox_TCNO.Text.Length == 11)
            {

                if (connection.State == ConnectionState.Closed)//Veri tabanı bağlantısı kapalıysa(ki kapalı olmalı bu noktada)
                {
                    connection.Open();//Veri tabanı bağlantısı açılıyor
                    string Sorgu = "select TCNo from ogrenci"; 
                    //TC no lar öğrenci tablosundan çekilsin diye sorgu yazılıyor
                    OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
                    OleDbDataReader Oku = Komut.ExecuteReader();
                    //Okuma başlıyor
                    while (Oku.Read())
                    {
                        if (textBox_TCNO.Text == Oku[0].ToString())
                        {//Tek tek girilen tc ile karşılaştırılıyor

                            MessageBox.Show("Kayıtlı Kullanıcı Girdiniz ");//Eşleşme varsa kayıtlı demektir

                            button_OgrenciEkle.Enabled = false;//Kişi zaten kayıtlı olduğu için ekleme yapılamaz
                            //Artık günvelleme ve silme işlemleri yapıla bilecek
                            button_OgrenciSil.Enabled = true;
                            button_OgrenciGuncelle.Enabled = true;
                            //TC no ya ait veriler veri tabanından çekiliyor
                            string sorguGuncelle = ("select * from ogrenci where TCNo like '" + textBox_TCNO.Text + "%'");
                            OleDbCommand guncelleCommand = new OleDbCommand(sorguGuncelle, connection);
                            OleDbDataReader oku = guncelleCommand.ExecuteReader();

                            while (oku.Read())
                            {
                                if (textBox_TCNO.Text == oku[0].ToString())
                                {     //TC no alanı uygun ise , alanlar veri tabanındaki veriye göre çekiliyor
                                    textBox_TCNO.Text = oku[0].ToString();
                                    textBox_AdSoyad.Text = oku[1].ToString();
                                    textBox_TelNo.Text = oku[2].ToString();
                                    textBox_mail.Text = oku[3].ToString();
                                    dateTimeUyelikTarihi.Text = oku[4].ToString();
                                    comboBox_Cinsiyet.Text = oku[5].ToString();

                                }

                            }
                        }
                    }
                    connection.Close();//VEri tabanı bağlantısı kapatılıyot
                }
            }
           
        }

        private void textBox_TCNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != 08)
            {
                e.Handled = true;//TCye harf girişi engelleniyor

            }
        }

        private void button_OgrenciEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)//Bğlantı kapalıysa açılıyor(kapalı olmalı bu noktada)
                {
                    if (textBox_TCNO.Text.Length < 11)//TCno kontrolü
                    {
                        MessageBox.Show(" TC Kimlik No 11 Haneli Olmak Zorundadır.");
                    }

                    if (textBox_TCNO.Text.Length == 11 && textBox_AdSoyad.Text == "" && textBox_mail.Text == "" && comboBox_Cinsiyet.Text == "")
                    {//Boş alan kontrolü
                        MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
                    }
                    if (textBox_TCNO.Text != "" && textBox_AdSoyad.Text != "" && textBox_mail.Text != "" && comboBox_Cinsiyet.Text != "" && dateTimeUyelikTarihi.Text != "")
                    {   //GErekli alanlar boş değilse
                        connection.Open();//veri tbanaı bağlantısı açılıyor
                        string sorgu = "insert into ogrenci(TCNo,adSoyad,telefonNo,mailAdresi,UyelikDate,Cinsiyet,ToplamKitap,EldekiEmanetCount,Ceza) values (@TCNo,@adSoyad,@telefonNo,@mailAdresi,@UyelikDate,@Cinsiyet,@ToplamKitap,@EldekiEmanetCount,@Ceza)";
                        //Ekleme işlemi için derekli sorgu yazılıyor
                        OleDbCommand komut = new OleDbCommand(sorgu, connection);
                        komut.Parameters.AddWithValue("@TCNo", textBox_TCNO.Text);
                        komut.Parameters.AddWithValue("@adSoyad", textBox_AdSoyad.Text);
                        komut.Parameters.AddWithValue("@telefonNo", textBox_TelNo.Text);
                        komut.Parameters.AddWithValue("@mailAdresi", textBox_mail.Text);
                        komut.Parameters.AddWithValue("@UyelikDate", dateTimeUyelikTarihi.Text);
                        komut.Parameters.AddWithValue("@Cinsiyet", comboBox_Cinsiyet.Text);
                        komut.Parameters.AddWithValue("@ToplamKitap", 0);
                        komut.Parameters.AddWithValue("@EldekiEmanetCount", 0);
                        komut.Parameters.AddWithValue("@Ceza", 0);
                        komut.ExecuteNonQuery();
                        //Veriler ekleniyor
                        connection.Close();//Veri tabanı bağlantısı kapatılıyor
                        MessageBox.Show("Veriler başarıyla kaydedildi");
                        //ALanlat temizleniyor
                        textBox_AdSoyad.Text = "";
                        textBox_mail.Text = "";
                        textBox_TCNO.Text = "";
                        textBox_TelNo.Text = "";
                        comboBox_Cinsiyet.Text = "";

                    }

                }
                connection.Close();//veri tabanı bağlantısı kapatılıyor
            }
            catch (Exception ex)//Hata olursa
            {
                MessageBox.Show(ex.ToString(), "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
            
        }

        private void button_OgrenciSil_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Veri tabanından öğrenci silmek için gereken sorgu
                string Sorgu = "delete from ogrenci where TCNo like '" + textBox_TCNO.Text + "%'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
                string SilinsinMi = textBox_TCNO.Text.ToString();
                //Öğrencinin silinip silinmemesi için bir uyarı oluşturuldu
                DialogResult Durum = MessageBox.Show(SilinsinMi + " TC Numaralı Kayıt Silinsin Mi ? ", " Silme Onayı ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                
                if (DialogResult.Yes == Durum)//Kullanıcı yes seçerse silme işlemi yapılıyor
                {
                    Komut.ExecuteNonQuery();//Veri tabanı işlemi yapılıyor
                    MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi.");
                    //Alanlar temizleniyor
                    textBox_AdSoyad.Text = "";
                    textBox_mail.Text = "";
                    textBox_TCNO.Text = "";
                    textBox_TelNo.Text = "";
                    comboBox_Cinsiyet.Text = "";

                }
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
            catch (Exception ex)//HAta olursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }



            
        }

        private void button_OgrenciGuncelle_Click(object sender, EventArgs e)
        {
            if (textBox_TCNO.Text != "" && textBox_AdSoyad.Text != "" && textBox_TelNo.Text != "" && textBox_mail.Text != "" && dateTimeUyelikTarihi.Text != "" && comboBox_Cinsiyet.Text != "" && textBox_TCNO.Text.Length == 11)
            {//Gerekli alanlar doluysa işlem yapılıyor
                if (connection.State == ConnectionState.Closed)//Veri tabanı bağlantısı kapalıysa
                {

                    try
                    {
                        connection.Open();//Veri tabanı bağlantısı açılıyor

                        string Sorgu = "update ogrenci set adSoyad=@adSoyad,telefonNo=@telefonNo,mailAdresi=@mailAdresi,UyelikDate=@UyelikDate,Cinsiyet=@Cinsiyet where TCNo like '" + textBox_TCNO.Text + "%'";
                        //Güncelleme için gerekli sorgu yazılıyor
                        OleDbCommand Komut = new OleDbCommand(Sorgu, connection);

                        Komut.Parameters.AddWithValue("@adSoyad", textBox_AdSoyad.Text);
                        Komut.Parameters.AddWithValue("@telefonNo", textBox_TelNo.Text);
                        Komut.Parameters.AddWithValue("@mailAdresi", textBox_mail.Text);
                        Komut.Parameters.AddWithValue("@UyelikDate", dateTimeUyelikTarihi.Text);
                        Komut.Parameters.AddWithValue("@Cinsiyet", comboBox_Cinsiyet.Text);

                        Komut.ExecuteNonQuery();
                        //Güncelleme işlemi yapılıyor
                        connection.Close();//Veri tabanı bağlantısı kapatılıyor

                        MessageBox.Show("Kayıtlar Başarılı Bir Şekilde Güncellendi.");//Kullanıcı bilgilendiriliyor
                        //Alanlar temizleniyor
                        textBox_AdSoyad.Text = "";
                        textBox_mail.Text = "";
                        textBox_TCNO.Text = "";
                        textBox_TelNo.Text = "";
                        comboBox_Cinsiyet.Text = "";
                    }
                    catch (Exception ex)//Hata olursa
                    {
                        MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor
                        connection.Close();//Veri tabanı bağlantısı kapatılıyor
                    }
                   


                }
            }
            else//Boş alan varsa
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz");
            }
        }

        private void textBox_mail_Validating(object sender, CancelEventArgs e)
        {
            //Emailde @ ve . kontrolü ile doğru format kontrolü yapılıyor
            try
            {
                AtIsareti = textBox_mail.Text.IndexOf("@", 1);

                //@ işaretinden sonra nokta işareti geliyorsa
                if (AtIsareti > 0)
                {
                    NoktaIsareti = textBox_mail.Text.IndexOf(".", AtIsareti + 1);
                }
                //@ işareti ve nokta yoksa
                if (AtIsareti < 0 || NoktaIsareti < 0 || NoktaIsareti == textBox_mail.Text.Length - 1)
                {
                    MessageBox.Show("Mail adresinizi yalnış girdiniz", "MAIL HATA");
                    e.Cancel = true;
                }
            }
            catch (Exception)//Hata 
            {
                MessageBox.Show("Lütfen Epostayi Tam Giriniz.", "Mail Kontrol");//Kullanıcı bilgilendiriliyor
                textBox_mail.Focus();
            }
        }
    }
}
