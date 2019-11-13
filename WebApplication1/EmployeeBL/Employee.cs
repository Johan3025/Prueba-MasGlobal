using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeBL.Abstracts;
using Newtonsoft.Json.Linq;
using WebApplication3.Models;

namespace EmployeeBL
{
    public class Employee : IEmployee
    {

        public IList<Employees> CreateProjectModified()
        {
            string baseUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            var json = new WebClient().DownloadString(baseUrl);


            JArray PersonArray = JArray.Parse(json);

            IList<Employees> persona = PersonArray.Select(p => new Employees
            {
                name = (string)p["name"],
                contractTypeName = (string)p["contractTypeName"],
                roleId = (string)p["roleId"],
                roleName = (string)p["roleName"],
                roleDescription = (string)p["roleDescription"],
                hourlySalary = (int)p["hourlySalary"],
                monthlySalary = (int)p["monthlySalary"]

            }).ToList();


            foreach (var item in persona)
            {
                if (item.contractTypeName == "HourlySalaryEmployee")
                {
                    item.Total = 120 * item.hourlySalary * 12;
                }
                else
                {
                    item.Total = item.monthlySalary * 12;
                }

            }

            return persona;
        }
    }
}
