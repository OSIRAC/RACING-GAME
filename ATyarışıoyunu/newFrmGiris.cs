using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Threading;


namespace ATyarışıoyunu
{


    public partial class newFrmGiris : Form
    {
        public newFrmGiris()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4J14V6R\\SQLEXPRESS;Initial Catalog=AtYarısıVeriTabani;Integrated Security=True");
        sqlbaglantisi bag = new sqlbaglantisi();
        //Random rastgele = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlCommand komut = new SqlCommand("Select * From Tbl_AtYarısı Where KullaniciAd=@p1 and Sifre=@p2", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {

                newForm1 frm = new newForm1();
                frm.kullaniciadi = textBox1.Text;


                //Frmkazac fc = new Frmkazac();
                //fc.ad = textBox1.Text;
                while (progressBar1.Value != 100)
                {
                    progressBar1.Value += 1;
                    progressBar1.Value += 2;
                    progressBar1.Value += 5;
                    progressBar1.Value += 12;
                    Thread.Sleep(1000);

                }
                
                //this.Hide();
                frm.Show();
                //frm.Dispose();
                progressBar1.Value = 0;

                //this.Close();



            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Ya da Şifre");
            }
            bag.baglanti().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayıt kyd = new FrmKayıt();
            kyd.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newFrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = this.BackColor;
        }
    }
}
 
    

