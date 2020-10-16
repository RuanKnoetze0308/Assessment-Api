using Employee.Domain.Data;
using Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Domain.Repositories
{
    public class EmployeeSqlRepo : IEmployeeRepo
    {
        private readonly ApiDbContext _context;

        public EmployeeSqlRepo(ApiDbContext context)
        {
            _context = context;
        }

        public void CreateMember(Staff member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

             _context.Employees.Add(member);
        }

        public void DeleteMember(Staff delete)
        {
            if (delete == null)
            {
                throw new ArgumentNullException(nameof(delete));
            }
            _context.Employees.Remove(delete);
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _context.Employees.ToList();
        }

        public Staff GetStaffbyId(int id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMember(Staff update)
        {
            
        }
    }
}
