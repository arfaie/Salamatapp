using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblINSTITUTE_PERSONEL_
    {
        [Key]
        public int id_personal { get; set; }
        public int? codeOrgan { get; set; }
        public string nezamId { get; set; }
        public double? Tekrari { get; set; }
        public string DRName { get; set; }
        public string DrFamily { get; set; }
        public int? Id_ROLETYPE { get; set; }

        [ForeignKey("Id_ROLETYPE")]
        public virtual ROLE_TYPE_ ROLE_TYPE_ { get; set; }

        public int? Id_MADRAK { get; set; }

        [ForeignKey("Id_MADRAK")]
        public virtual TblMadarek_ TblMadarek_ { get; set; }

        public int? Id_RESHTEH { get; set; }

        [ForeignKey("Id_RESHTEH")]
        public virtual TblReshteh_ TblReshteh_ { get; set; }

        public int? Id_EXPERT { get; set; }

        [ForeignKey("Id_EXPERT")]
        public virtual TblEXPERT_ TblEXPERT_ { get; set; }

        
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
        public string passWord { get; set; }
    }
}
