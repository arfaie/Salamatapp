using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ServiceTable
    {
        [Key]
        public int Id { get; set; }

        public bool Gender { get; set; }

        public int IdCity { get; set; }

        [ForeignKey("IdCity")]
        public virtual TblCity_ TblCity { get; set; }

        public int Age { get; set; }

        public int IdEdu { get; set; }

        [ForeignKey("IdEdu")]
        public virtual tbl_Education TblEducation { get; set; }

        public string Job { get; set; }

        public string WicheService { get; set; }

        public string FlagMoraje { get; set; }

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
        public string IdQ12 { get; set; }
        public string IdQ13 { get; set; }
        public string IdQ14 { get; set; }
        public string IdQ15 { get; set; }
        public string IdQ16 { get; set; }

        public string Des { get; set; }





    }
}
