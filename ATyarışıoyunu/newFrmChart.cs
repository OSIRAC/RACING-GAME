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

namespace ATyarışıoyunu
{
    public partial class newFrmChart : Form
    {
        public newFrmChart()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4J14V6R\\SQLEXPRESS;Initial Catalog=AtYarısıVeriTabani;Integrated Security=True");
        //sqlbaglantisi bag=new sqlbaglantisi();
        /*
        private void newFrmChart_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select KacıncıOyun,Sum(KazanılanPara) Over(Order By KacıncıOyun) From Tbl_AtOyunTablosu",bag.baglanti() );
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["TOPLAM-KASA"].Points.AddXY(dr[0], dr[1]);


            }

        




            bag.baglanti().Close();
        */
        
        }
    }

