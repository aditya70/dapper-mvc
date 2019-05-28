using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Mvc.Web.Controllers
{
    public class ProductController : Controller
    {
        //java tpoint
        //csharpcorner


        public IActionResult Index()
        {
            SqlConnection con = new SqlConnection("server=.;initial catalog=DemoDb;integrated security=true");
            SqlCommand cmd = new SqlCommand("select * from product", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var productName = rdr["ProductName"];
                var productCode = rdr["ProductCode"];
                Console.WriteLine(productName);
            }
            con.Close();
            return View();
        }

        public IActionResult GetProduct()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection //not works  
              // con = new SqlConnection("data source=.; database=student; integrated security=SSPI");

                // Creating Connection  
                con = new SqlConnection("server=.;initial catalog=DemoDb;integrated security=true");
                // writing sql query  
                SqlCommand cm = new SqlCommand("select * from product", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["ProductName"]);
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }

            // Closing the connection  
            finally
            {
                con.Close();
            }

            return Ok();
        }
      
        public IActionResult GetAllProduct()
        {
            using (SqlConnection con = new SqlConnection("server=.;initial catalog=DemoDb;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("select * from product");
                SqlDataAdapter sda = new SqlDataAdapter("select * from product", con);
                DataSet ds = new DataSet();
                sda.Fill(ds);

            }
            return View();
        }
    }
}