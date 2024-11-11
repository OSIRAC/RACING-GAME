using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATyarışıoyunu
{
    public partial class Frmkazac : Form
    {
        public Frmkazac()
        {
            InitializeComponent();
        }
        public string ad;
        sqlbaglantisi bag = new sqlbaglantisi();
         
        private void Frmkazac_Load(object sender, EventArgs e)
        {

            
            //SqlCommand md = new SqlCommand("select sum(YatirilanPara) as YatirilanPara, sum(Case When KazanmaDurumu = 1 Then YatirilanPara Else 0 END) as KazanilanPara, sum(Case When KazanmaDurumu = 0 Then YatirilanPara Else 0 END) as KaybedilenPara from Tbl_AtOyunTablosu Where OyuncuAdi='"+ad+"'", bag.baglanti());
            SqlCommand md=new SqlCommand("SELECT SUM(Bahis) AS Bahis, 2 * SUM(CASE WHEN KazanmaDurumu = 1 THEN Bahis ELSE 0 END) AS KazanilanPara, SUM(CASE WHEN KazanmaDurumu = 0 THEN Bahis ELSE 0 END) AS KaybedilenPara, (SELECT TOP 1 Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + ad + "' OR OyuncuAdi= '" + ad + " BAKIYE YUKLEME' ORDER BY KacinciOyunu desc,Bakiye desc) AS Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + ad + "'",bag.baglanti());

            //SqlDataAdapter adapter = new SqlDataAdapter("select OyuncuAdi, sum(YatirilanPara) as YatirilanPara, sum(Case When KazanmaDurumu = 1 Then YatirilanPara Else 0 END) as KazanilanPara, sum(Case When KazanmaDurumu = 0 Then YatirilanPara Else 0 END) as KaybedilenPara from Tbl_AtOyunTablosu where OyuncuAdi=@p1 group by OyuncuAdi", bag.baglanti());

            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);

            SqlDataReader dr1 = md.ExecuteReader();
            this.chart1.Titles.Add("OYUNLARIN TOPLAM İSTATİSTİĞİ");
            while (dr1.Read())
            {
               
                this.chart1.Series["Bahis"].Points.AddY(dr1[0]);
                this.chart1.Series["KazanilanPara"].Points.AddY(dr1[1]);
                this.chart1.Series["KaybedilenPara"].Points.AddY(dr1[2]);
                this.chart1.Series["Bakiye"].Points.AddY(dr1[3]);
                //chart1.Series["KAZANÇ"].Points.AddXY("KAZANILAN", dr["KazanilanPara"]);
            }
            bag.baglanti().Close();

            //SqlDataAdapter adapter = new SqlDataAdapter("select KacinciOyun,sum(YatirilanPara) as YatirilanPara, sum(Case When KazanmaDurumu = 1 Then YatirilanPara Else 0 END) as KazanilanPara, sum(Case When KazanmaDurumu = 0 Then YatirilanPara Else 0 END) as KaybedilenPara from Tbl_AtOyunTablosu Where OyuncuAdi ='"+ad+"'" KacinciOyun, bag.baglanti());
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT SUM(Bahis) AS Bahis, 2 * SUM(CASE WHEN KazanmaDurumu = 1 THEN Bahis ELSE 0 END) AS KazanilanPara, SUM(CASE WHEN KazanmaDurumu = 0 THEN Bahis ELSE 0 END) AS KaybedilenPara, (SELECT TOP 1 Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + ad + "' OR OyuncuAdi= '" + ad + " BAKIYE YUKLEME ' ORDER BY KacinciOyunu desc,Bakiye desc) AS Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi = '" + ad + "'", bag.baglanti());

            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT SUM(Bahis) AS Bahis, 2 * SUM(CASE WHEN KazanmaDurumu = 1 THEN Bahis ELSE 0 END) AS KazanilanPara, SUM(CASE WHEN KazanmaDurumu = 0 THEN Bahis ELSE 0 END) AS KaybedilenPara, (SELECT TOP 1 Bakiye FROM Tbl_AtOyunTablosu ORDER BY KacinciOyunu desc) AS Bakiye FROM Tbl_AtOyunTablosu WHERE OyuncuAdi='" + ad + "'", bag.baglanti());

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource= dataTable;







            /*
            SqlCommand cmd = new SqlCommand("Select KacıncıOyun,Sum(KazanılanPara) Over(Order By KacıncıOyun) From Tbl_AtOyunTablosu", bag.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["TOPLAM-KASA"].Points.AddXY(dr[0], dr[1]);


            }
            */
            bag.baglanti().Close();

            

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
