using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class View_Comment
    {
        public int idComment { get; set; }
        public int idState { get; set; }        
        public bool idSex { get; set; }      
        public int age { get; set; }
        public int idEdu { get; set; }        
        public int idBime { get; set; }      
        public int idMoraje { get; set; }      
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
        public string StateName { get; set; }
        public string sexName { get; set; }
        public string EduName { get; set; }
        public string BimeType { get; set; }
        public string Moraje { get; set; }
        public string ReasonText { get; set; }

    }
}
