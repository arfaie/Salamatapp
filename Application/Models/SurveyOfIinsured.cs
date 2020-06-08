using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    [Table("SurveyOfIinsureds")]

    public class SurveyOfIinsured
    {
        [Key]
        public int Id { get; set; }

        public int IdCity { get; set; }

        [ForeignKey("IdCity")]
        public virtual TblCity_ TblCity { get; set; }

        public bool Gender { get; set; }
        public DateTime DateTime { get; set; }


        public string hospitalName { get; set; }

        public string hospitalStay { get; set; }

        public bool hospitalOwnership { get; set; }

        public int  IdBime { get; set; }

        [ForeignKey("IdBime")]
        public virtual tbl_Bime TblBime { get; set; }

        public string IdQ1 { get; set; }
        public string IdQ2 { get; set; }
        public string IdQ3 { get; set; }
        public string IdQ4 { get; set; }
        public string IdQ5 { get; set; }
        public string IdQ6 { get; set; }

        public string Des { get; set; }



    }
}
