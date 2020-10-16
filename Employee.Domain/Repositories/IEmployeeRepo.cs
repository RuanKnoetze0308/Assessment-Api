using Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Repositories
{
    public interface IEmployeeRepo
    {

        bool SaveChanges();


        IEnumerable<Staff> GetAllStaff();
        Staff GetStaffbyId(int Id);
        void CreateMember(Staff member);
        void UpdateMember(Staff update);
        void DeleteMember(Staff delete);
    }
}
