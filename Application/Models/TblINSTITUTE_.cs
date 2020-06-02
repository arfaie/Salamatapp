using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblINSTITUTE_
    {
        [Key]
        public int idInstitues { get; set; }
      
        public int? codeOrgan { get; set; }
      
        public string nameOrgan { get; set; }
     
        public string nameOrganMain { get; set; }
      
        public string hos { get; set; }
        public int? idINSTITUTE_TYPE { get; set; }

        [ForeignKey("idINSTITUTE_TYPE")]
        public virtual TblINSTITUTE_TYPE_ TblINSTITUTE_TYPE_ { get; set; }

        public int? idowner { get; set; }

        [ForeignKey("idowner")]
        public virtual TblOwner_ TblOwner_ { get; set; }

        public int? idCity { get; set; }

        [ForeignKey("idCity")]
        public virtual TblCity_ TblCity_ { get; set; }
      
        public string ADDRESS { get; set; }
      
        public string TEL { get; set; }
        public string ZIP { get; set; }
     
        public string fax { get; set; }

        public string email { get; set; }
     
        public string mobile { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
