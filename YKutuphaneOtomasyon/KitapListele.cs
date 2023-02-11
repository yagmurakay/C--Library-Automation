using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Access veri tabanın için gerekn kütüphane

namespace YKutuphaneOtomasyon
{
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
             Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı yapılıyor
        public void Kayitlar()//Kitapları veri tabanından çekip getiren method
        {

            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                string sorgu = "select KitapID,KitapAd,Tur,Yazar,YayinEvi,BasimTarihi,SayfaSayisi from Kitap";
                //Verileri çekmek için gerekli sorgu yazılıyor
                OleDbCommand komut = new OleDbCommand(sorgu, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                dataGridView_KitapLİste.DataSource = table;//Veri kaynağı atanıyor
                //Gerekli alanlar oluşturulup isimlendiriliyor
                dataGridView_KitapLİste.Columns[0].HeaderText = "KitapID";
                dataGridView_KitapLİste.Columns[1].HeaderText = "Kitap Adi";
                dataGridView_KitapLİste.Columns[2].HeaderText = "Tur";
                dataGridView_KitapLİste.Columns[3].HeaderText = "Yazar";
                dataGridView_KitapLİste.Columns[4].HeaderText = "Yayin Evi";
                dataGridView_KitapLİste.Columns[5].HeaderText = "Basim Tarihi";
                dataGridView_KitapLİste.Columns[6].HeaderText = "Sayfa Sayısı";

                //Alanların genişlikleri belirleniyor
                dataGridView_KitapLİste.Columns[0].Width = 100;
                dataGridView_KitapLİste.Columns[1].Width = 100;
                dataGridView_KitapLİste.Columns[2].Width = 100;
                dataGridView_KitapLİste.Columns[3].Width = 100;
                dataGridView_KitapLİste.Columns[4].Width = 100;
                dataGridView_KitapLİste.Columns[5].Width = 100;
                dataGridView_KitapLİste.Columns[6].Width = 60;

                dataGridView_KitapLİste.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //Tıklandığında tüm satırın seçilmesi sağlanıyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }
            catch(Exception ex)//Hata olursa
            {
                MessageBox.Show(ex.Message, "Bir Şeya Oldu");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }

        }


        private void KitapListele_Load(object sender, EventArgs e)
        {
            textBox_KitapArama.Focus();
            Kayitlar();//Veri tabanında olan kayıtlar getiriliyor
            textBox_KitapArama.Focus();
        }

        private void textBox_KitapArama_TextChanged(object sender, EventArgs e)
        {   //Her tuşlamada arama yapılıyor
            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                //Veri tabanından verileri kitap arama kısmına yazılan ID ye göre çektiğimiz sorgu
                string Sorgu = "select * from Kitap where KitapID like '" + textBox_KitapArama.Text + "%'";
                OleDbCommand Komut = new OleDbCommand(Sorgu, connection);

                OleDbDataAdapter Adaptor = new OleDbDataAdapter(Komut);
                DataTable table = new DataTable();
                Adaptor.Fill(table);
                dataGridView_KitapLİste.DataSource = table;//VEri kaynağı atanıyor
                connection.Close();//VEri tabanı bağlantısı kesiliyor
            }
            catch(Exception ex)//Hata olursa 
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu");//KUllanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kapatılıyor
            }
        }

        private void button_TeslimAlanlar_Click(object sender, EventArgs e)
        {   //Kitabı Teslim alanlar listeleniyor
            if (textBox_KitapArama.Text.Length == 6)//Girilen ID tam ise işlem yapılıyor
            {
                try
                {
                    connection.Open();//Veri tabanı bağlantısı açılıyor

                    string Sorgu = "select AdSoyad,TCNo,KitapID,AlisTarihi,BitisTarihi from Emanet where KitapID like '" + textBox_KitapArama.Text + "%' ";
                    //O kitap için kaydedilmiş emanet sorgu ile çekilerek daha önce kimlerin almış olduğu listeleniyor
                    OleDbCommand Komut = new OleDbCommand(Sorgu, connection);
                    OleDbDataAdapter Adapter = new OleDbDataAdapter(Komut);
                    DataTable table = new DataTable();
                    Adapter.Fill(table);
                    //GElen veriler oluşturulan tablo tipli değişkene atanıyor
                    dataGridView_KitapLİste.DataSource = table;//Veri kaynağı atanıyor
                    //Alanlar oluşturulup isimlendiriliyor
                    dataGridView_KitapLİste.Columns[0].HeaderText = "Tc Kimlik No";
                    dataGridView_KitapLİste.Columns[1].HeaderText = "Ad Soyad";
                    dataGridView_KitapLİste.Columns[2].HeaderText = "KitapID ";
                    dataGridView_KitapLİste.Columns[3].HeaderText = "Başlangic Tarihi";
                    dataGridView_KitapLİste.Columns[4].HeaderText = "Teslim Tarihi";
                    //Alanların genişlikleri belirleniyor
                    dataGridView_KitapLİste.Columns[0].Width = 125;
                    dataGridView_KitapLİste.Columns[1].Width = 125;
                    dataGridView_KitapLİste.Columns[2].Width = 125;
                    dataGridView_KitapLİste.Columns[3].Width = 155;
                    dataGridView_KitapLİste.Columns[4].Width = 155;

                    
                    dataGridView_KitapLİste.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //Tıklandığında tüm satırın seçilmesi sağlanıyor
                    connection.Close();//Veri tabanı bağlantısı kapatılıyor
                }
                catch (Exception ex)//Hata olursa
                {

                    MessageBox.Show(ex.Message,"Bir Şey Oldu!!!");//kullanıcı bilgilendiriliyor
                    connection.Close();//Veri tabanı bağlantısı kapatılıyor
                }
            }
            else//ID değeri tam değilse
            {
                MessageBox.Show("Lütfen Bir ID Numarası Giriniz");
            }

        }

        private void textBox_KitapArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
