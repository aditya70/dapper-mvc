using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Mvc.Web.Models;
using Microsoft.Extensions.Configuration;

namespace Dapper.Mvc.Web.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            using (IDbConnection conn = Connection)
            {
                string query = "select Id,Employee_ID,SA_Sector from employee";
              //  conn.Open();
                var result = await conn.QueryAsync<Employee>(query);
                return result.ToList();
            }
             
        }

        public async Task<Employee> GetById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string query = "select Id,Employee_ID,SA_Sector from employee where Id=@Id";
              //  conn.Open();
                var result = await conn.QueryAsync<Employee>(query, new { Id = id });
                return result.FirstOrDefault();
            }
        }
    }
}
