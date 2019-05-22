using Dapper.Mvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Mvc.Web.Repository
{
   public interface IEmployeeRepository
    {
        Task<Employee> GetById(int id);
        Task<List<Employee>> GetAllEmployees();
    }
}
