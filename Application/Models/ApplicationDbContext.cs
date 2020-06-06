using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Application.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Institute_Personal> Institute_Personal { get; set; }
        public DbSet<NazarSanji2> NazarSanji2 { get; set; }
        public DbSet<ROLE_TYPE_> ROLE_TYPE_ { get; set; }
        public DbSet<tbl_Arzyabi> tbl_Arzyabi { get; set; }
        public DbSet<tbl_Bime> tbl_Bime { get; set; }
        public DbSet<tbl_Comment> tbl_Comment { get; set; }
        public DbSet<tbl_CommentOrgan> tbl_CommentOrgan { get; set; }
        public DbSet<tbl_Contact> tbl_Contact { get; set; }
        public DbSet<Tbl_Edarat> Tbl_Edarat { get; set; }
        public DbSet<tbl_Education> tbl_Education { get; set; }
        public DbSet<tbl_Informing> tbl_Informing { get; set; }
        public DbSet<tbl_InformingOrgan> tbl_InformingOrgan { get; set; }
        public DbSet<tbl_Institution> tbl_Institution { get; set; }
        public DbSet<tbl_Moraje> tbl_Moraje { get; set; }
        public DbSet<Tbl_Pishkhan> Tbl_Pishkhan { get; set; }
        public DbSet<tbl_Reason> tbl_Reason { get; set; }
        public DbSet<Tbl_Setadi> Tbl_Setadi { get; set; }
        public DbSet<tbl_sex> tbl_sex { get; set; }
        public DbSet<tbl_State> tbl_State { get; set; }
        public DbSet<TblAudience> TblAudience { get; set; }
        public DbSet<TblCashDeskInsurance> TblCashDeskInsurance { get; set; }
        public DbSet<TblCity_> TblCity_ { get; set; }
        public DbSet<TblComplaint> TblComplaint { get; set; }
        public DbSet<TblContent> TblContent { get; set; }
        public DbSet<TblEXPERT_> TblEXPERT_ { get; set; }
        public DbSet<TblINSTITUTE_> TblINSTITUTE_ { get; set; }
        public DbSet<TblINSTITUTE_PERSONEL_> TblINSTITUTE_PERSONEL_ { get; set; }
        public DbSet<TblINSTITUTE_TYPE_> TblINSTITUTE_TYPE_ { get; set; }
        public DbSet<TblMadarek_> TblMadarek_ { get; set; }
        public DbSet<TblMenu> TblMenu { get; set; }
        public DbSet<TblOwner_> TblOwner_ { get; set; }
        public DbSet<TblPassWord> TblPassWord { get; set; }
        public DbSet<TblPersonal> TblPersonal { get; set; }
        public DbSet<TblRepDevice> TblRepDevice { get; set; }
        public DbSet<TblReport> TblReport { get; set; }
        public DbSet<TblReshteh_> TblReshteh_ { get; set; }
        public DbSet<TblTel> TblTel { get; set; }
        public DbSet<TblTypeMasolyat> TblTypeMasolyat { get; set; }
        public DbSet<TblUserVisite> TblUserVisite { get; set; }
        public DbSet<TblVer> TblVer { get; set; }
        public DbSet<ServiceTable> ServiceTables { get; set; }
        public DbSet<SurveyOfIinsured> SurveyOfIinsureds { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<OfficeRefrandum> OfficeRefrandums { get; set; }

        public DbSet<Tbl_YearsOfService> TblYearsOfServices { get; set; }

        public DbSet<tbl_Education2> TblEducation2 { get; set; }

        public DbQuery<View_NewInstitutes> View_NewInstitutes { get; set; }

        public DbQuery<ViewPeronal> ViewPeronal { get; set; }

        public DbQuery<View_Comment> View_Comment { get; set; }

        public DbQuery<ViewComplaint> ViewComplaint { get; set; }


    }
}
