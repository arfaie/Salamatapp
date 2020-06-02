using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblComplaint
    {
        [Key]
        public int idComplaint { get; set; }
        public int idCity { get; set; }

        [ForeignKey("idCity")]
        public virtual TblCity_ TblCity_ { get; set; }

        public string mobile { get; set; }
        public string Address { get; set; }
        public int idAudience { get; set; }

        [ForeignKey("idAudience")]
        public virtual TblAudience TblAudience { get; set; }

        public string fName { get; set; }
        public string lName { get; set; }
        public string CodeInsu { get; set; }
        public string natcode { get; set; }
        public int idCashDeskInsurance { get; set; }

        [ForeignKey("idCashDeskInsurance")]
        public virtual TblCashDeskInsurance TblCashDeskInsurance { get; set; }

        public string insurerName { get; set; }
        public string unitComplaint { get; set; }
        public string des { get; set; }
        public byte[] img { get; set; }
        public string timeSend { get; set; }
        public string dateSend { get; set; }
        public bool? readed { get; set; }
    }
}
