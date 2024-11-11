using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATyarışıoyunu
{
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("insert into Tbl_AtYarısı(KullaniciAd,Sifre) values (@p1,@p2)", bag.baglanti());
                cmd.Parameters.AddWithValue("@p1", newtextBox1.Text);
                cmd.Parameters.AddWithValue("@p2", newtextBox2.Text);
                cmd.ExecuteNonQuery();
                bag.baglanti().Close();
                if (newtextBox1.Text == "" || newtextBox2.Text=="")
                {
                    MessageBox.Show("KULLANICI ADI VEYA SIFRE BOS BIRAKILAMAZ");
                }
                else
                {
                    MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz:" + newtextBox2.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // SQL hatası 2627, birincil anahtar çakışması anlamına gelir
                {
                    // Birincil anahtar çakışması hatasını ele al
                    MessageBox.Show("GİRDİGİNİZ KULLANICI ADI KULLANILDI");
                }

            }

           
                     //ArgumentNullException
               
            }
          

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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
