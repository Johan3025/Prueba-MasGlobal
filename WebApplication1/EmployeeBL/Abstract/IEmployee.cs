using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace EmployeeBL.Abstracts
{
    public interface IEmployee
    {
        /// <summary>
        /// Create a Project.
        /// </summary>
        /// <param > Request.</param>
        /// <returns> Response.</returns>
        IList<Employees> CreateProjectModified();
    }
}
