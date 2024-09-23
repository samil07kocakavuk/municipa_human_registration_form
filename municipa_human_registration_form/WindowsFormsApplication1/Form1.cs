using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cbbox1.accdb");
        private void cb2()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select ilce from ilceler where il = '" + comboBox1.Text + "'";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["ilce"]);
            }
            baglanti.Close();
        }
        private void cb1_doldur()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select il from iller";
            OleDbDataReader oku = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["il"]);
            }
            baglanti.Close();
        }
        private void lwkaydet() 
        {
            string kang = "";
            if (radioButton1.Checked)
            {
                kang = "A+";
            }
            else if (radioButton2.Checked)
            {
                kang = "B+";
            }
            else if (radioButton3.Checked)
            {
                kang = "AB+";
            }
            else if (radioButton4.Checked)
            {
                kang = "0+";
            }
            else if (radioButton5.Checked)
            {
                kang = "A-";
            }
            else if (radioButton6.Checked)
            {
                kang = "B-";
            }
            else if (radioButton7.Checked)
            {
                kang = "AB-";
            }
            else if (radioButton8.Checked)
            {
                kang = "0-";
            }
            else
            {
                MessageBox.Show("Ya seç işte alla alla");
                return;
            }
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into kan (tcno,kang) values('" + textBox3.Text + "','" + kang.ToString() +"')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            lwdoldur();
        }
        private void cb3_doldur()
        {
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select il from iller ";
            OleDbDataReader oku = komut.ExecuteReader();
            comboBox3.Items.Clear();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["il"]);
            }
            baglanti.Close();
        }
        private void lwdoldur()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from kan ";
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tcno"].ToString();
                ekle.SubItems.Add(oku["kang"].ToString());
                listView1.Items.Add(ekle);
            } baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cb1_doldur();
            lwdoldur();
            cb3_doldur();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into iller (il) values('" + textBox1.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            cb1_doldur();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into ilceler (il,ilce) values('" + comboBox3.Text + "','" + textBox2.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            cb2();
            cb1_doldur();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into ilceler (il,ilce) values('" + textBox1.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            cb2();
            cb3_doldur();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into ilceler (il,ilce) values('" + comboBox3.Text + "','" + textBox2.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            cb2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "31")
            {
                while (true)
                {
                    MessageBox.Show("ssjjsjsjsjsjsjsjsjssjjsjs");
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            lwkaydet();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from kan where tcno = '"+textBox3.Text+"'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            lwdoldur();
            
        }

        
    }
}
// int sifresi programı yaz miss
//ne ise yarıcak
// sadece qr okutup siparis verenler baglancak
//olbilir
//ama kim ugrascak 
//valla para verseler ben yrasirim
//bende
//200k miss
//sen bok satarsın 200 işletmeye 
//valla ayp aga ya
//tmm yazdında 
//senın gıbı bu kodu yazan 200 kisi daha var
//isletme nıye senden alsın 
//niye almasın
//200 programdan senınkınımı seçıcek
//sga 100k kafe olsa 100000/2*1000
//gene ii para
//100k kafeyeı nerden bulcan
//hepsı senı nıye tercıh etsın
//alana yol silindiri dicem
//gayet iyi tercih secenegi
// mıcrosoft veya tesla benzerı sırketlerde çalısmak daha mantıklı daha temız net gelır
//orda calisirken bunu ek oolarak yapamicani kim soledi
//tmm ek olarak yazarsında vakıot kaybı 
//pasif gelir bi sure sonra
// klasık yatırımcı sozu 
//"pasıf gelır "
//valla kardeşim aktif gelir zor iş
//zor is tmmda net ve temız gelır 
//kovulmadıgın surece gelmeme ihtimali yok 
//ve 1 yıl hocanın dedigi kodu yazıp hiç satamazsan napcan 
//direk kodu sat 10kya fln
//nsaıl bu kadar emınsın 10 edicegınıe
//kaynak koldarı cok para ediyo
//ole para ediyosa ilerde banada sole bende yazip satım 
//1tb kod arşivi eqwweewqewq
//hocanın dedığı mantıklı aslında 
//benım az biraz var kod arşıvım 
//ediz simdiye kadar yazdıgımız tum kodlar almıs 
//bendede var arsiv githubda private olarak
//prıvate ??
//bana ozel gpzukuyo
//normal klasore yazsan daha mantıklı
//niye bukuta kaydedıyon 
//github gg olsa 
//senıon kodlar gg 
//github microsoftun
//olsun sunucular yine gg olamazmı
//adamlar saliselik yedek alıyodur
//iki sunucuda gg olsa 
//aga cidden 2 sunucuda oldugunumu snaion sadece
// sunucudan kastım gıthubun verileri kaydettıgı sunucular

/* bana javascrıpt ogret 
 * olr oretim 
 ama geççen ogrenme dedin
 yani istiosan oret in
 * hoca dil orenin dio ben 6 dil biliom
 * bende bilmek istıyom 
 * ama kim ugrascak 
 * aga napıyosun suadna bos vaktinde
 * 1000 sorumu cozuyon
 * kitapmi bitiriyon
 * witcher oynuyom 
 * bence yeterlı bı bahane 
 * sen bilirsin aga
 * bi sirkete girerken cvne steam profilini eklersin
 * tabıu 
 * 300 saat witcher ı olan adamı degilde kimi  alcaklar cd projecte 
 */


