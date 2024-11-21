using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetCoreApplication;
using System.Data.SqlClient;

namespace DotNetCoreApplication.Pages
{
    public class CreateModel : PageModel
    {
        public empinfo objempInfo = new empinfo();
        public string errorMessage = "";
        public string successMessage = "";

        
        public void OnGet()
        {
        }

      

        public void OnPostSubmit() 
        {
            objempInfo.Name = Convert.ToString(Request.Form["Name"]);
            objempInfo.Age = Convert.ToString(Request.Form["Age"]);
            objempInfo.Address = Convert.ToString(Request.Form["Address"]);
            objempInfo.Mobile = Convert.ToString(Request.Form["Mobile"]);
            if(objempInfo.Name.Length==0 || objempInfo.Age.Length==0 || objempInfo.Address.Length==0 || objempInfo.Mobile.Length==0)
            {
                errorMessage = "All the fields are required.";
                return;
            }

            try
            {
                string strconnection = @"Data Source=COMM-DELL-MJ\SQLEXPRESS;Initial Catalog=DotNetCore;User ID=mjaved; password=#Commit@123;";
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    con.Open();
                    string strSQL = "INSERT INTO [Employee] " +
                                    " ([Name],[Age],[Address],[Mobile])" +
                                    "  VALUES  (@name,@age,@address,@mobile)";
                    using (SqlCommand cmd = new SqlCommand(strSQL, con))
                    {
                        cmd.Parameters.AddWithValue("@name", objempInfo.Name);
                        cmd.Parameters.AddWithValue("@age", objempInfo.Age);
                        cmd.Parameters.AddWithValue("@address", objempInfo.Address);
                        cmd.Parameters.AddWithValue("@mobile", objempInfo.Mobile);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message.ToString();
                return;
            }
            objempInfo.Name = ""; objempInfo.Age = "";objempInfo.Address = ""; objempInfo.Mobile = "";
            successMessage = "Employee details saved";
            Response.Redirect("/EmpList");
            
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
