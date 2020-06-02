using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OfficeRefrandum
    {
        [Key]
        public int Id { get; set; }

        public bool Gender { get; set; }

        public bool isMarried { get; set; }

        public int YearsOfService { get; set; }

        public int IdEdu { get; set; }

        [ForeignKey("IdEdu")]
        public virtual tbl_Education TblEducation { get; set; }

        public int EmployeeId { get; set; }

        
        [ForeignKey("EmployeeId")]
        public virtual EmployeeType EmployeeType { get; set; }

        public string IdQ1 { get; set; }
        public string IdQ2 { get; set; }
        public string IdQ3 { get; set; }
        public string IdQ4 { get; set; }
        public string IdQ5 { get; set; }
        public string IdQ6 { get; set; }
        public string IdQ7 { get; set; }
        public string IdQ8 { get; set; }
        public string IdQ9 { get; set; }
        public string IdQ10 { get; set; }
        public string IdQ11 { get; set; }
    }
}
