using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATyarışıoyunu
{
    public partial class newForm1 : Form
    {
        public newForm1()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4J14V6R\\SQLEXPRESS;Initial Catalog=AtYarısıVeriTabani;Integrated Security=True");
        sqlbaglantisi bag = new sqlbaglantisi();
        int birinciatsolauzaklık, ikinciatsolauzak, üçüncüatsolauzaklık;




        public int kasa;
        public int oyun=0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            button1.Enabled= false;
            lbSecilenAt.Text = comboBox2.SelectedItem.ToString();
            lbYatirilanPara.Text = comboBox1.SelectedItem.ToString();
            timer3.Enabled = false;
            timer4.Enabled = false;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label16.BackColor = Color.White;
            //Bakiye();

            
            LblBDenek.Text = (int.Parse(LblBakiyeDeneme.Text) - int.Parse(lbYatirilanPara.Text)).ToString();
            if (int.Parse(LblBDenek.Text) >= 0)
            {
                oyun++;
                KasadakiPara.Text = LblBDenek.Text;
                timer1.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;

            }
            
            else
            {
                timer1.Enabled = false;
                
                //comboBox1.Items.Clear();
                //comboBox2.Items.Clear();
                button1.Enabled = false;
                MessageBox.Show("BAKİYENİZ YETERSİZDİR");
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

            }
            


            //comboBox1.SelectedIndex = -1;
            //comboBox2.SelectedIndex = -1;
            //button1.Enabled = false;
            //lbYatirilanPara.Text = comboBox1.SelectedItem.ToString();
            //timer1.Enabled = true;
            timer2.Enabled = true;
            //button3.Enabled = false;
            //button2.Enabled = false;
            label7.Text = "00";
            //KasadakiPara.Text = "00";
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)

        {
            
            int derece = Convert.ToInt32(label7.Text);
            derece++;
            label7.Text = derece.ToString();
            lbBitirmeSuresi.Text = derece.ToString();

            int birinciatgenişlik = pictureBox1.Width;
            int ikinciatgenişlik= pictureBox2.Width;
            int üçüncüatgenişlik= pictureBox3.Width;


            int bitişuzaklığı = label5.Left;

            pictureBox1.Left = pictureBox1.Left + rastgele.Next(5, 15);
            pictureBox2.Left = pictureBox2.Left + rastgele.Next(5, 15);
            pictureBox3.Left = pictureBox3.Left + rastgele.Next(5, 15);

            if(pictureBox1.Left>pictureBox2.Left+5 && pictureBox1.Left > pictureBox3.Left + 5)
            {
                label6.Text = "1 Numaralı at yarışı önde götürüyor";


            }

            if (pictureBox2.Left > pictureBox1.Left + 5 && pictureBox2.Left > pictureBox3.Left + 5)
            {
                label6.Text = "2 Numaralı at iyi bir atakla öne geçti";


            }

            if (pictureBox3.Left > pictureBox2.Left + 5 && pictureBox3.Left > pictureBox1.Left + 5)
            {
                label6.Text = "3 Numaralı at liderliği ele geçirdi";


            }

            

            if (birinciatgenişlik + pictureBox1.Left >= bitişuzaklığı)
            {
                timer1.Enabled=false;
                MessageBox.Show("1 Numaralı At yarışı kazandı!!!");
                button1.Enabled = true;

                label12.Text = "1";
                label11.Text = lbSecilenAt.Text;
                if (lbSecilenAt.Text == label12.Text)
                {
                    timer3.Enabled=true;
                    //pictureboxwin.Visible = true;
                    //KasadakiPara.Text = lbYatirilanPara.Text;
                    kasa = Convert.ToInt16(KasadakiPara.Text) +(Convert.ToInt16(lbYatirilanPara.Text))*2;
                    KasadakiPara.Text = kasa.ToString();
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    lbKazanmaDurumu.Text = "True";
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                }
                else
                {
                    timer4.Enabled = true;
                    //kasa = Convert.ToInt16(KasadakiPara.Text) - Convert.ToInt16(lbYatirilanPara.Text);
                    //KasadakiPara.Text = kasa.ToString();
                    //LblBakiyeDeneme.Text = KasadakiPara.Text;
                    //pictureboxlose.Visible = true;
                    lbKazanmaDurumu.Text = "False";
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                }
                
                pictureBox1.Left = 0;
                pictureBox2.Left = 0;
                pictureBox3.Left = 0;
                //button3.Enabled = true;
                //button2.Enabled = true;
                //button4.Enabled = true;
                YarisiKaydet();
            }
            if (ikinciatgenişlik + pictureBox2.Left >= bitişuzaklığı)
            {
                timer1.Enabled = false;
                MessageBox.Show("2 Numaralı At yarışı kazandı!!!");
                button1.Enabled = true;

                label12.Text = "2";
                label11.Text = lbSecilenAt.Text;
                if (lbSecilenAt.Text == label12.Text)
                {
                    timer3.Enabled = true;
                    //pictureboxwin.Visible = true;
                    //KasadakiPara.Text = lbYatirilanPara.Text;
                    kasa = Convert.ToInt16(KasadakiPara.Text) +(Convert.ToInt16(lbYatirilanPara.Text))*2;
                    KasadakiPara.Text = kasa.ToString();
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    lbKazanmaDurumu.Text = "True";
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;

                }
                else
                {
                    timer4.Enabled = true;
                    //kasa = Convert.ToInt16(KasadakiPara.Text) - Convert.ToInt16(lbYatirilanPara.Text);
                    //KasadakiPara.Text = kasa.ToString();
                    //LblBakiyeDeneme.Text = KasadakiPara.Text;
                    lbKazanmaDurumu.Text = "False";
                    //pictureboxlose.Visible = true;
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                }

                
                pictureBox1.Left = 0;
                pictureBox2.Left = 0;
                pictureBox3.Left = 0;
                //button3.Enabled = true;
                //button2.Enabled = true;
                //button4.Enabled = true;
                YarisiKaydet();

            }
            if (üçüncüatgenişlik + pictureBox3.Left >= bitişuzaklığı)
            {
                timer1.Enabled = false;
                MessageBox.Show("3 Numaralı At yarışı kazandı!!!");
                button1.Enabled = true;

                label12.Text = "3";
                label11.Text = lbSecilenAt.Text;
                if (lbSecilenAt.Text == label12.Text)
                {
                    timer3.Enabled = true;
                    //pictureboxwin.Visible = true;
                    lbKazanmaDurumu.Text = "True";
                    kasa= Convert.ToInt16(KasadakiPara.Text) + (Convert.ToInt16(lbYatirilanPara.Text))* 2;
                    KasadakiPara.Text=kasa.ToString();
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    // LblBakiye.Text= (int.Parse(LblBakiye.Text)-int.Parse(lbYatirilanPara.Text)).ToString();
                }
                else
                {
                    timer4.Enabled = true;
                    //kasa = Convert.ToInt16(KasadakiPara.Text) - Convert.ToInt16(lbYatirilanPara.Text);
                    //KasadakiPara.Text = kasa.ToString();
                    //LblBakiyeDeneme.Text = KasadakiPara.Text;
                    lbKazanmaDurumu.Text = "False";
                    //pictureboxlose.Visible = true;
                    LblBakiyeDeneme.Text = KasadakiPara.Text;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                }

                

                pictureBox1.Left = 0;
                pictureBox2.Left = 0;
                pictureBox3.Left = 0;
                //button3.Enabled = true;
                //button2.Enabled = true;
                //button4.Enabled = true;
                YarisiKaydet();
            }


        }
        
        

            
             private void timer2_Tick(object sender, EventArgs e)
           {
   /*
            LblBDenek.Text = (int.Parse(LblBDenek.Text) - int.Parse(lbYatirilanPara.Text)).ToString();
            if (int.Parse(LblBDenek.Text) >= 0)
            {
                LblBakiye.Text = LblBDenek.Text;
                
            }
            else
            {
                button1.Enabled = false;
                MessageBox.Show("BAKİYENİZ YETERSİZDİR");
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                
              }
             

            /*
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                
                button1.Enabled = true;
                lbYatirilanPara.Text = comboBox1.SelectedItem.ToString();
                lbSecilenAt.Text = comboBox2.SelectedItem.ToString();
                //LblBakiye.Text = (int.Parse(LblBakiye.Text) - int.Parse(lbYatirilanPara.Text)).ToString();
                //button3.Enabled = false;
                //button2.Enabled = false;
                //button4.Enabled=false;
               

            }
            */
        }
       
        public void YarisiKaydet()  
        {
            SqlCommand cm = new SqlCommand("insert into Tbl_AtOyunTablosu (KacinciOyunu,OyuncuAdi,Bahis,BitirmeSuresi,SecilenAt,KazanmaDurumu,Bakiye) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bag.baglanti());
            cm.Parameters.AddWithValue("@p1", oyun);
            cm.Parameters.AddWithValue("@p2", kullaniciadi);
            cm.Parameters.AddWithValue("@p3", int.Parse(lbYatirilanPara.Text));
            cm.Parameters.AddWithValue("@p4", int.Parse(lbBitirmeSuresi.Text));
            cm.Parameters.AddWithValue("@p5", int.Parse(lbSecilenAt.Text));
            cm.Parameters.AddWithValue("@p6", bool.Parse(lbKazanmaDurumu.Text));
            cm.Parameters.AddWithValue("@p7", int.Parse(KasadakiPara.Text));         
            cm.ExecuteNonQuery();
            bag.baglanti().Close();
        }
         /*
        public void TopListesi()
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_AtOyunTablosu (OyuncuAdi,YatirilanPara,BitirmeSuresi,SecilenAt,KazanmaDurumu,Kasa,KalanBakiye) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bag.baglanti());
            cmd.Parameters.AddWithValue("@p1", kullaniciadi);
            cmd.Parameters.AddWithValue("@p2", Convert.ToInt16(lbYatirilanPara.Text));
            cmd.Parameters.AddWithValue("@p3", int.Parse(lbBitirmeSuresi.Text));
            cmd.Parameters.AddWithValue("@p4", int.Parse(lbSecilenAt.Text));
            cmd.Parameters.AddWithValue("@p5", bool.Parse(lbKazanmaDurumu.Text));
            cmd.Parameters.AddWithValue("@p6", int.Parse(KasadakiPara.Text));
            cmd.Parameters.AddWithValue("@p7", int.Parse(LblBakiye.Text));
            cmd.ExecuteNonQuery();
            bag.baglanti().Close(); 
        }
         */
        private void Bakiye()
        {
            /*
            if (comboBox1.SelectedIndex>=0)
            {
                //pictureboxlose.Visible = false;
                //pictureboxwin.Visible = false;
                LblBakiyeDeneme.Text = (int.Parse(LblBakiyeDeneme.Text) - int.Parse(lbYatirilanPara.Text)).ToString();
               if(int.Parse(LblBakiyeDeneme.Text) >= 0)
                {
                    LblBakiye.Text = LblBakiyeDeneme.Text;

                }
                else
                {
                    //MessageBox.Show("BAKİYENİZ YETERSİZDİR");
                    //comboBox1.Items.Clear();
                    //comboBox2.Items.Clear();    
                    button1.Enabled = false;
                }


            }

            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newAtYarısıVeriTabaniDataSet.Tbl_AtOyunTablosu' table. You can move, or remove it, as needed.
            //this.tbl_AtOyunTablosuTableAdapter1.Fill(this.newAtYarısıVeriTabaniDataSet.Tbl_AtOyunTablosu);
        }

        public string kullaniciadi;
        public string gelenveri;

        FrmProfil frm = new FrmProfil();
        private void button3_Click(object sender, EventArgs e)
        {           
            //frm.ad = kullaniciadi;
            //frm.para = lbYatirilanPara.Text;
            //frm.sure = lbBitirmeSuresi.Text;
            //frm.at = lbSecilenAt.Text;
            //frm.kasam = KasadakiPara.Text;
            //frm.kazdurum = lbKazanmaDurumu.Text;
            /*
            SqlCommand cmd = new SqlCommand("insert into Tbl_AtOyunTablosu (OyuncuAd,YatırılanPara,BitirmeSüresi,SecilenAt,KazanılanPara) values (@p1,@p2,@p3,@p4,@p5)", bag.baglanti());
            cmd.Parameters.AddWithValue("@p1", kullaniciadi);
            cmd.Parameters.AddWithValue("@p2",label14.Text);
            cmd.Parameters.AddWithValue("@p3", label13.Text);
            cmd.Parameters.AddWithValue("@p4", label15.Text);
            cmd.Parameters.AddWithValue("@p5", KasadakiPara.Text);
            cmd.ExecuteNonQuery();
            */
            /*
            string query = "SELECT * FROM Tbl_AtOyunTablosu";
            SqlDataAdapter adapter = new SqlDataAdapter(query,bag.baglanti());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            */
            //dataGridView1.DataSource = dataTable;
            //button3.Enabled = false;

            //bag.baglanti().Close();


            //this.tbl_AtOyunTablosuTableAdapter1.Fill(this.newAtYarısıVeriTabaniDataSet.Tbl_AtOyunTablosu);




        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            newFrmChart frg=new newFrmChart();
            frg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //DataTable dt1=new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Delete * From Tbl_AtOyunTablosu", bag.baglanti());   DATAGRİDVİEW KODUYLA YALNIZ VERİ ÇEKİLİR.
            //da.Fill(dt1);
            //dataGridView1.DataSource = dt1;
            
            //SqlCommand komutsil = new SqlCommand("Delete From Tbl_AtOyunTablosu", bag.baglanti());
            //SqlCommand command = new SqlCommand("DBCC CHECKIDENT('" +"Tbl_AtOyunTablosu" + "', RESEED, 0)", bag.baglanti());
            //komutsil.ExecuteNonQuery();
            //command.ExecuteNonQuery();
            //bag.baglanti() .Close();
            //MessageBox.Show("Kayıt Silindi");
            //this.tbl_AtOyunTablosuTableAdapter1.Fill(this.newAtYarısıVeriTabaniDataSet.Tbl_AtOyunTablosu);
            //button4.Enabled = false;
           




        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmProfil fp=new FrmProfil();
            fp.label1.Text = kullaniciadi;
            fp.Show();
            timer3.Enabled = false;
            timer4.Enabled = false;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label16.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmEniyiler fy=new FrmEniyiler();
            fy.Show();
            timer3.Enabled = false;
            timer4.Enabled = false;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
            label5.BackColor = Color.White;
            label16.BackColor = Color.White;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vERİLERİMToolStripMenuItem_Click(object sender, EventArgs e)

        {
            /*
            FrmProfil fp = new FrmProfil();
            fp.label1.Text = kullaniciadi;
            fp.Show();
            */

            button5.PerformClick();



            /*





            FrmProfil fp = new FrmProfil();
            fp.Enabled = true;
            fp.ShowDialog();
            string query = "SELECT * FROM Tbl_AtOyunTablosu where OyuncuAdi='" + label1.Text + "'order by KacinciOyun asc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, bag.baglanti());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            timer3.Enabled = false;
            timer4.Enabled = false;
                 
            DataGridView dataGridView1 = fp.DataGridView1;
            dataGridView1.DataSource = dataTable;
            */
            
            
            //fp.btnListele_Click(sender,e);

        }

        private void iSTATİSTİKLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            timer3.Enabled = false;
            timer4.Enabled = false;

            
            FrmProfil kc=new FrmProfil();
            kc.label1.Text=kullaniciadi;
            //kc.Show();
            kc.Hide();
            kc.btnIstatıstıks_Click_1(this, EventArgs.Empty);

        }

        private void gİRİŞSAYFASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer4.Enabled = false;

            newFrmGiris fr = new newFrmGiris();
            fr.Show();
            this.Close();
        }

        private void kAYITSAYFASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer4.Enabled = false;

            FrmKayıt fk=new FrmKayıt();
            fk.Show();
        }

        private void yARATICIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer4.Enabled = false;

            MessageBox.Show("BU form ÖMER SİRAC İSLAMOĞLU TARAFINDAN YAPILMIŞTIR", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KasadakiPara_TextChanged(object sender, EventArgs e)
        {

        }
       private bool isGreen = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            
            //1234516
            if (isGreen)
            {
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label16.BackColor = Color.White;
            }
            else
            {
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
                label4.BackColor = Color.Green;
                label5.BackColor = Color.Green;
                label16.BackColor = Color.Green;
            }
            isGreen = !isGreen;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
         // bool isGreen = false;
            if (isGreen)
            {
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label16.BackColor = Color.White;
            }
            else
            {
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                label3.BackColor = Color.Red;
                label4.BackColor = Color.Red;
                label5.BackColor = Color.Red;
                label16.BackColor = Color.Red;
            }
            isGreen = !isGreen;
        }
        public string Yatirma;

        private void YukleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer4.Enabled = false;
            FrmBakiyeYatirma fy = new FrmBakiyeYatirma();
                fy.Enabled = true;
                fy.ShowDialog();


                if (fy.comboBox1.SelectedIndex!=-1)
                {
                    KasadakiPara.Text = (int.Parse(fy.comboBox1.Text) + int.Parse(KasadakiPara.Text)).ToString();
                    LblBakiyeDeneme.Text=KasadakiPara.Text;
                    button1.Enabled = true;
                }
                fy.Dispose();

            string kullanici = " BAKIYE YUKLEME";
            SqlCommand cm = new SqlCommand("insert into Tbl_AtOyunTablosu (KacinciOyunu,OyuncuAdi,Bakiye) values (@p1,@p2,@p3)", bag.baglanti());
            cm.Parameters.AddWithValue("@p1", oyun);
            cm.Parameters.AddWithValue("@p2", kullaniciadi + kullanici);           
            cm.Parameters.AddWithValue("@p3", int.Parse(KasadakiPara.Text));
            cm.ExecuteNonQuery();
            bag.baglanti().Close();
            

        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Red;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = this.BackColor;
        }

        public static FrmArkadasEkle fkArkadasEkle;
        
        private void eKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fkArkadasEkle==null)
            {
                fkArkadasEkle = new FrmArkadasEkle();
            }
                
           fkArkadasEkle.adi = kullaniciadi;

           fkArkadasEkle.Show();
            
        }

       
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
           {

           


               
            

           }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {


            lbYatirilanPara.Text = comboBox1.SelectedItem.ToString();
            LblBDenek.Text = (int.Parse(LblBakiyeDeneme.Text) - int.Parse(lbYatirilanPara.Text)).ToString();
            if (int.Parse(LblBDenek.Text) >= 0)
            {
                button1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;


                button1.Enabled = false;
                MessageBox.Show("BAKİYENİZ YETERSİZDİR");

            }


        }

        Random rastgele =new Random();

        
        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            //UpdateYatirilanParaText();
            //lbYatirilanPara.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
            //lbYatirilanPara.Text = comboBox1.SelectedItem.ToString();
            //SqlCommand cmd = new SqlCommand("Select KalanBakiye from Tbl_AtOyunTablosu where OyuncuAdi='"+kullaniciadi+"'", bag.baglanti());
            SqlCommand cmd = new SqlCommand("SELECT KacinciOyunu,Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + kullaniciadi + " BAKIYE YUKLEME' OR OyuncuAdi='" + kullaniciadi + "' ORDER BY KacinciOyunu DESC,Bakiye DESC ", bag.baglanti());
            //SqlCommand md = new SqlCommand("SELECT Kasa FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + kullaniciadi + "' ORDER BY Kasa ASC ", bag.baglanti());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                try
                {
                    KasadakiPara.Text = dr["Bakiye"].ToString();
                    LblBakiyeDeneme.Text = dr["Bakiye"].ToString();
                    oyun = Convert.ToInt32(dr["KacinciOyunu"]);
                }
                catch (Exception)
                {
                     oyun = 0;

                }
                
                //LblBDenek.Text = LblBakiyeDeneme.Text;
                //KasadakiPara.Text = dr[0].ToString();   
            }
            
            
                // Bakiye null ise varsayılan değeri atayın
                // Varsayılan değer
                

            
                //LblBDenek.Text = LblBakiyeDeneme.Text;
                /*
                SqlCommand cd = new SqlCommand("SELECT Kasa FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + kullaniciadi + "' order by KacinciOyun DESC", bag.baglanti());
                 SqlDataReader dr2 = cd.ExecuteReader();
                if (dr2.Read())
                {
                    KasadakiPara.Text=(dr2[0].ToString()) ;
                }
                */
                //label1.Text = "Hoşgeldin "+ kullaniciadi;
                //button3.Enabled = false;
                //button2.Enabled = false;
                //button4 .Enabled = false;
                birinciatsolauzaklık = pictureBox1.Left;
            ikinciatsolauzak= pictureBox2.Left;
            üçüncüatsolauzaklık = pictureBox3.Left;
            //Lblad.Text = kullaniciadi;

            

            MessageBox.Show("LÜTFEN BİR PARA VE AT NUMARASI GİRİN", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }
    }
}
