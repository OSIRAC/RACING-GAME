using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ATyarışıoyunu
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source= .\\SQLEXPRESS;Initial Catalog=AtYarısıVeriTabani;Integrated Security=True");
            //SqlConnection baglan = new SqlConnection("Server = tcp:testsqldatabase-900.database.windows.net,1433; Initial Catalog = AtYarısıVeriTabaniiLKPROJEM; Persist Security Info = False; User ID = agalar_ytü; Password = Kankalar1234; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                             //                           Server = tcp:testsqldatabase - 900.database.windows.net,1433; Initial Catalog = AtYarısıVeriTabaniiLKPROJEM; Persist Security Info = False; User ID = agalar_ytü; Password = Kankalar1234; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;


            baglan.Open();
            return baglan;
        }


    }
}
