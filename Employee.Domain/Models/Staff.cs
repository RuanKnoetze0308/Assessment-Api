using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Models
{
    public class Staff
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int BankingDetails { get; set; }





    }
}
