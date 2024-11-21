using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotNetCoreApplication.Pages
{
    public class EmpListModel : PageModel
    {
        public List<empinfo> EmpList = new List<empinfo>();
        public void OnGet()
        {
            //string strconnection = @"Data Source=COMM-DELL-MJ\SQLEXPRESS;Initial Catalog=DotNetCore;User ID=mjaved; password=#Commit@123;Trusted_Connection=True;TrustServerCertificate=True";
           
            string strconnection = @"Data Source=COMM-DELL-MJ\SQLEXPRESS;Initial Catalog=DotNetCore;User ID=mjaved; password=#Commit@123;";
            try
            {

                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    con.Open();
                    string strSQL = "SELECT [ID],[Name],[Age],[Address],[Mobile] FROM [Employee]";
                    using (SqlCommand cmd = new SqlCommand(strSQL, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empinfo objempinfo = new empinfo();
                                objempinfo.ID = "" + reader.GetInt32(0);
                                objempinfo.Name = reader.GetString(1);
                                objempinfo.Age = reader.GetString(2);
                                objempinfo.Address = reader.GetString(3);
                                objempinfo.Mobile = reader.GetString(4);
                                EmpList.Add(objempinfo);
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public class empinfo
        {
            public string ID;
            public string Name;
            public string Age;
            public string Address;
            public string Mobile;
        }
    
    }
}
