using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Access veri tabanı için gerekli kütüphane


namespace YKutuphaneOtomasyon
{
    public partial class OgrenciListele : Form
    {
        public OgrenciListele()
        {
            InitializeComponent();
        }

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
            Application.StartupPath + "\\database.mdb");
        //Veri tabanı bağlantısı yapılıyor
        public void Kayitlar()
        {   //Veri tabanındaki kayıtları ekrana getiren metot
            connection.Open();//Veri tabanı bağlantısı açılıyor
            string sorgu = "select * from ogrenci";
            //Tüm kayıtları çeken sorgu yazılıyor
            OleDbCommand komut = new OleDbCommand(sorgu, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
            DataTable Table = new DataTable();
            adapter.Fill(Table);//Oluşturulan Tablo nesnesi veri tabanında gelen verilerle doluyor
            dataGridView_ogrlistele.DataSource = Table;//Veri kaynağı atanıyor
            //Sütun isimleri veriliyor
            dataGridView_ogrlistele.Columns[0].HeaderText = "Tc Kimlik No";
            dataGridView_ogrlistele.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView_ogrlistele.Columns[2].HeaderText = "Telefon";
            dataGridView_ogrlistele.Columns[3].HeaderText = "Mail Adresi";
            dataGridView_ogrlistele.Columns[4].HeaderText = "Üyelik Olduğu Tarih";
            dataGridView_ogrlistele.Columns[5].HeaderText = "Cinsiyet";
            dataGridView_ogrlistele.Columns[6].HeaderText = "Aldığı kitap sayısı";
            dataGridView_ogrlistele.Columns[7].HeaderText = "Emanet Kitap sayısı";
            dataGridView_ogrlistele.Columns[8].HeaderText = "Ceza";
            //Sütun genişlikleri veriliyor
            dataGridView_ogrlistele.Columns[0].Width = 100;
            dataGridView_ogrlistele.Columns[1].Width = 100;
            dataGridView_ogrlistele.Columns[2].Width = 100;
            dataGridView_ogrlistele.Columns[3].Width = 100;
            dataGridView_ogrlistele.Columns[4].Width = 100;
            dataGridView_ogrlistele.Columns[5].Width = 55;
            dataGridView_ogrlistele.Columns[6].Width = 55;
            dataGridView_ogrlistele.Columns[7].Width = 55;
            dataGridView_ogrlistele.Columns[8].Width = 55;
          
            dataGridView_ogrlistele.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tıklandığında satırın tamamını seçmeyi sağlıyor
            connection.Close();//Veri tabanı bağlantısı kapatılıyor

        }



        private void OgrenciListele_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            Kayitlar();//Veri tabanındaki verileri ekrana listeleyen metot
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //TC no ile arama işlemi yapılıyor
            //text alnına tc no yazılmaya başlandığından itibaren girilen tc no için arama başlıyor
            try
            {
                connection.Open();//Veri tabanı bağlantısı açılıyor
                string sorgu = "select * from okuyucu where tcno like '" + textBox1.Text + "%'";
                //Tc no ile arama için gerekli sorgu yazılıyor
                OleDbCommand komut = new OleDbCommand(sorgu, connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
                DataTable table = new DataTable();//Data tablosu oluşturuluyor
                adapter.Fill(table);//Tablo veri tabanındakı verilerle dolduruluyor
                dataGridView_ogrlistele.DataSource = table;//Veri kaynağı atanıyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }
            catch(Exception ex)//HAta olursa
            {
                MessageBox.Show(ex.Message, "Bir Şey Oldu!!!");//Kullanıcı bilgilendiriliyor
                connection.Close();//Veri tabanı bağlantısı kesiliyor
            }

           

        }
    }
}
