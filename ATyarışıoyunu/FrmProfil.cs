using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace ATyarışıoyunu
{
    public partial class FrmProfil : Form
    {


        public DataGridView DataGridView1 // DataGridView'ı bir özellik olarak tanımlayın
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }

        public FrmProfil()
        {
            InitializeComponent();
            

        }
        sqlbaglantisi bag = new sqlbaglantisi();
        
        public string para, sure, at, kasam,kazdurum;
        //public DataGridView dataGridView1;
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Teal;
        }

        private void btnIstatıstıks_Click(object sender, EventArgs e)
        {
            
        }

        public void btnIstatıstıks_Click_1(object sender, EventArgs e)
        {
            Frmkazac kc = new Frmkazac();
            kc.ad = label1.Text;
            kc.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }
       
        public void btnListele_Click(object sender, EventArgs e)
        {
            //this.tbl_AtOyunTablosuTableAdapter.Fill(this.atYarısıVeriTabaniDataSet1.Tbl_AtOyunTablosu);
            string query = "SELECT * FROM Tbl_AtOyunTablosu where OyuncuAdi='"+label1.Text+ " BAKIYE YUKLEME' OR OyuncuAdi='" + label1.Text + "' order by KacinciOyunu asc,Bakiye asc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, bag.baglanti());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FrmProfil_Load(object sender, EventArgs e)
        {
 


            groupBox1.Text=label1.Text;


            btnListele.PerformClick();

            
            /*
                newForm1 fr=new newForm1();
                fr.YarisiKaydet();
                this.tbl_AtOyunTablosuTableAdapter.Fill(this.atYarısıVeriTabaniDataSet1.Tbl_AtOyunTablosu);



            /*
                        string query = "SELECT * FROM Tbl_AtOyunTablosu";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, bag.baglanti());
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        //button3.Enabled = false;


                        bag.baglanti().Close();

                        this.tbl_AtOyunTablosuTableAdapter.Fill(this.atYarısıVeriTabaniDataSet1.Tbl_AtOyunTablosu);
                        */

        }
    }
}
