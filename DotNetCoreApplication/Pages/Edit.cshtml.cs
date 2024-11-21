using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotNetCoreApplication.Pages
{
    public class EditModel : PageModel
    {
        public empinfo objempInfo = new empinfo();
        public List<empinfo> EmpList = new List<empinfo>();
        public string errorMessage = "";
        public string successMessage = "";
       

        public void OnGet()
        {
            if(Request.QueryString.HasValue)
            {
                string strItemID = Convert.ToString(Request.Query["Id"]);               
                string strconnection = @"Data Source=COMM-DELL-MJ\SQLEXPRESS;Initial Catalog=DotNetCore;User ID=mjaved; password=#Commit@123;";
                try
                {
                    using (SqlConnection con = new SqlConnection(strconnection))
                    {
                        con.Open();
                        string strSQL = "SELECT [ID],[Name],[Age],[Address],[Mobile] FROM [Employee] WHERE ID=" + strItemID;
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
                    errorMessage = ex.Message;
                    return;
                }
            }
        }



        public void OnPostSubmit()
        {           
            string strItemID = Convert.ToString(Request.Form["ID"]).Trim();
            objempInfo.Name = Convert.ToString(Request.Form["Name"]).Trim();
            objempInfo.Age = Convert.ToString(Request.Form["Age"]).Trim();
            objempInfo.Address = Convert.ToString(Request.Form["Address"]).Trim();
            objempInfo.Mobile = Convert.ToString(Request.Form["Mobile"]).Trim();
            if (objempInfo.Name.Length == 0 || objempInfo.Age.Length == 0 || objempInfo.Address.Length == 0 || objempInfo.Mobile.Length == 0)
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
                    string strSQL = "UPDATE [dbo].[Employee]" +
                                        " SET [Name] = @name ,[Age] =@age ,[Address] = @address ,[Mobile] = @mobile WHERE ID =" + strItemID.Trim();
                    using (SqlCommand cmd = new SqlCommand(strSQL, con))
                    {
                        cmd.Parameters.AddWithValue("@name", objempInfo.Name.Trim());
                        cmd.Parameters.AddWithValue("@age", objempInfo.Age.Trim());
                        cmd.Parameters.AddWithValue("@address", objempInfo.Address.Trim());
                        cmd.Parameters.AddWithValue("@mobile", objempInfo.Mobile.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message.ToString();
                return;
            }
            objempInfo.Name = ""; objempInfo.Age = ""; objempInfo.Address = ""; objempInfo.Mobile = "";
            successMessage = "Employee details updated";
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
