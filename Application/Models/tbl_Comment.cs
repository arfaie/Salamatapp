using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Comment
    {
        [Key]
        public int idComment { get; set; }
        public int idState { get; set; }

        [ForeignKey("idState")]
        public virtual tbl_State Tbl_State { get; set; }

        public bool idSex { get; set; }

        [ForeignKey("idSex")]
        public virtual tbl_sex Tbl_Sex { get; set; }

        public int age { get; set; }
        public int idEducation { get; set; }

        [ForeignKey("idEducation")]
        public virtual tbl_Education Tbl_Education { get; set; }

        public int idBime { get; set; }

        [ForeignKey("idBime")]
        public virtual tbl_Bime Tbl_Bime { get; set; }

        public int idMoraje { get; set; }

        [ForeignKey("idMoraje")]
        public virtual tbl_Moraje Tbl_Moraje { get; set; }
       
        public int IdQ1 { get; set; }
        public int IdQ2 { get; set; }
        public int IdQ3 { get; set; }
        public int IdQ4 { get; set; }
        public int IdQ5 { get; set; }
        public int IdQ6 { get; set; }
        public string CommentText { get; set; }
        public string ComTime { get; set; }
        public bool flag { get; set; }
        public string ComDate { get; set; }
        public string FirstPerson { get; set; }
        public string SecondPeson { get; set; }
        public int idReason { get; set; }

        [ForeignKey("idReason")]
        public virtual tbl_Reason Tbl_Reason { get; set; }


    }
}
