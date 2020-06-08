using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.ClassAndDataModel;
using Application.Models;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public static IHostingEnvironment _environment;

        String userName = "Rahbars";
        String Password = "$epehr_N_A@M1394#";

        public APIController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }



        [HttpGet("WM_Menu")]
        public List<TblMenu> WM_Menu(string Update)
        {
            

            List<TblMenu> Menue = (from x in _context.TblMenu where x.MenueDate.CompareTo(Update) >= 0 select x).ToList();
            List<TblMenu> ls = new List<TblMenu>();
            foreach (TblMenu t in Menue)
            {
                TblMenu o = new TblMenu();
                o.flag = (Boolean)t.flag;
                o.menuFatherID = (int)t.menuFatherID;
                o.menuId = t.menuId;
                o.menuName = (string)t.menuName;
                o.order = (int)t.order;
                o.MenueDate = (string)t.MenueDate;
                o.link = (string)t.link;
                ls.Add(o);
            }
            return ls;

        }

        [HttpPost("WM_Comment")]
        public List<tbl_Comment> WM_Comment(tbl_Comment tbl_)
        {
            tbl_Comment tbl = new tbl_Comment();
            clsTarikh tarix = new clsTarikh();
            //string[] a = args.Split('~');
            //tbl.idState = int.Parse(a[0]);
            //if (tbl.idSex == false)
            //{
            //    tbl.idSex = false;
            //}
            //else
            //{
            //    tbl.idSex = true;
            //}
            tbl.idState = tbl_.idState;
            tbl.idSex = tbl_.idSex;
            tbl.age = tbl_.age;
            tbl.idEducation = tbl_.idEducation;
            tbl.idBime = tbl_.idBime;
            tbl.idMoraje = tbl_.idMoraje;
            tbl.idReason = tbl_.idReason;
            tbl.IdQ1 = tbl_.IdQ1;
            tbl.IdQ2 = tbl_.IdQ2;
            tbl.IdQ3 = tbl_.IdQ3;
            tbl.IdQ4 = tbl_.IdQ4;
            tbl.IdQ5 = tbl_.IdQ5;
            tbl.IdQ6 = tbl_.IdQ6;
            tbl.CommentText = tbl_.CommentText;
            tbl.FirstPerson = tbl_.FirstPerson;
            tbl.SecondPeson = tbl_.SecondPeson;
            tbl.ComDate = tarix.date();
            tbl.ComTime = tarix.time();
            _context.tbl_Comment.Add(tbl);
            _context.SaveChanges();
            return null;
        }

        [HttpGet("WM_Inform")]
        public List<tbl_Informing_ViewModel> WM_Inform(string Update)
        {
            List<tbl_Informing> ls_tblInform;
            ls_tblInform = (from x in _context.tbl_Informing where x.lastUpdate.CompareTo(Update) > 0 && x.privatePer == false select x).ToList();

            //TblPersonal tblper = (from x in _context.TblPersonal where x.natCode.CompareTo(nat) == 0 select x).FirstOrDefault();
            //if (tblper == null)
            //else
            //    ls_tblInform = (from x in _context.tbl_Informing where x.lastUpdate.CompareTo(Update) > 0 select x).ToList();
            List<tbl_Informing_ViewModel> ls_clsInforming = new List<tbl_Informing_ViewModel>();
            foreach (tbl_Informing t in ls_tblInform)
            {
                tbl_Informing_ViewModel ob = new tbl_Informing_ViewModel();
                ob.idInfo = t.idInfo;
                ob.infoDes = t.infoDes;
                ob.lastUpdate = t.lastUpdate;
                ob.InfoDateTime = t.InfoDateTime;
                if (t.privatePer == true)
                    ob.isprivate = "1";
                else
                    ob.isprivate = "0";
                ob.flag = (bool)t.flag;
                ls_clsInforming.Add(ob);
            }
            return ls_clsInforming;

        }

        [HttpGet("WM_OfficeInform")]
        public List<tbl_Informing_ViewModel> WM_OfficeInform(string Update, string nat)
        {
            List<tbl_Informing> ls_tblInform=null;
            List<tbl_Informing_ViewModel> ls_clsInforming = new List<tbl_Informing_ViewModel>();

            TblPersonal tblper = (from x in _context.TblPersonal where x.natCode.CompareTo(nat) == 0 select x).FirstOrDefault();
            if (tblper != null)
            {
                ls_tblInform = (from x in _context.tbl_Informing where x.lastUpdate.CompareTo(Update) > 0 && x.privatePer == true select x).ToList();
                foreach (tbl_Informing t in ls_tblInform)
                {
                    tbl_Informing_ViewModel ob = new tbl_Informing_ViewModel();
                    ob.idInfo = t.idInfo;
                    ob.infoDes = t.infoDes;
                    ob.lastUpdate = t.lastUpdate;
                    ob.InfoDateTime = t.InfoDateTime;
                    if (t.privatePer == true)
                        ob.isprivate = "1";
                    else
                        ob.isprivate = "0";
                    ob.flag = (bool)t.flag;
                    ls_clsInforming.Add(ob);
                }
            }

               
            return ls_clsInforming;

        }
        private string CheckNatCode(string nat)
        {
            TblPersonal tblper = (from x in _context.TblPersonal where x.natCode.CompareTo(nat) == 0 select x).FirstOrDefault();
            if (tblper == null)
                return "false";
            else
                return "true";
        }

        [HttpGet("WM_Content")]
        public List<TblContent> WM_Content(string Update)
        {
            List<TblContent> ls_tableContent = (from x in _context.TblContent where x.ContenteDate.CompareTo(Update) >= 0 select x).ToList();
            List<TblContent> ls_ClsContent = new List<TblContent>();
            foreach (TblContent t in ls_tableContent)
            {
                TblContent ob = new TblContent();
                ob.flag = (Boolean)t.flag;
                ob.ContenteDate = t.ContenteDate;
                ob.ContentId = t.ContentId;
                ob.contentText = t.contentText;
                ob.contentTitel = t.contentTitel;
                ls_ClsContent.Add(ob);
            }
            return ls_ClsContent;

        }

        [HttpGet("WM_Edarat")]
        public List<Tbl_Edarat_ViewModel> WM_Edarat(string Update)
        {
            List<Tbl_Edarat_ViewModel> ls_clsEdarat = new List<Tbl_Edarat_ViewModel>();
            List<Tbl_Edarat> ls_TblEdarat = (from x in _context.Tbl_Edarat where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (Tbl_Edarat t in ls_TblEdarat)
            {
                Tbl_Edarat_ViewModel o = new Tbl_Edarat_ViewModel();
                o.flag = (Boolean)t.flag;
                o.admin = (string)t.admin;
                o.Address = (string)t.adress;
                o.Tel = (string)t.Tell;
                o.city = (string)t.city;
                o.Fax = (string)t.Fax;
                o.idOffice = (int)t.idOffice;
                o.lastUpdate = (string)t.lastUpdate;
                o.position = t.x + "," + t.y;
                ls_clsEdarat.Add(o);
            }
            return ls_clsEdarat;
        }

        [HttpGet("WM_Pishkhan")]
        public List<Tbl_Pishkhan_ViewModel> WM_Pishkhan(string Update)
        {
            List<Tbl_Pishkhan_ViewModel> ls_clsPishkhan = new List<Tbl_Pishkhan_ViewModel>();
            List<Tbl_Pishkhan> ls_tablePishkhan = (from x in _context.Tbl_Pishkhan where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (Tbl_Pishkhan t in ls_tablePishkhan)
            {
                Tbl_Pishkhan_ViewModel o = new Tbl_Pishkhan_ViewModel();
                o.flag = (Boolean)t.flag;
                o.Address = t.address;
                o.city = t.city;
                o.code = t.code;
                o.idPishkhan = t.idPishkhan;
                o.lastUpdate = t.lastUpdate;
                o.street = t.street;
                o.Tel = t.tel;
                o.managerName = t.ManagerName;
                o.position = t.x + "," + t.y;
                ls_clsPishkhan.Add(o);
            }
            return ls_clsPishkhan;
        }

        [HttpGet("WM_Setadi")]
        public List<Tbl_Setadi> WM_Setadi(string Update)
        {

            List<Tbl_Setadi> ls_clsSetadi = new List<Tbl_Setadi>();
            List<Tbl_Setadi> ls_tSetadi = (from x in _context.Tbl_Setadi where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (Tbl_Setadi t in ls_tSetadi)
            {
                Tbl_Setadi o = new Tbl_Setadi();
                o.flag = (Boolean)t.flag;
                o.idSetadi = t.idSetadi;
                o.edare = t.edare;
                o.tel = t.tel;
                o.lastUpdate = t.lastUpdate;
                ls_clsSetadi.Add(o);
            }
            return ls_clsSetadi;
        }

        [HttpGet("WM_Contact")]
        public List<tbl_Contact_ViewModel> WM_Contact(string Update)
        {

            List<tbl_Contact> ls_TblIn = (from x in _context.tbl_Contact where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            List<tbl_Contact_ViewModel> ls_clsContact = new List<tbl_Contact_ViewModel>();
            foreach (tbl_Contact tbl in ls_TblIn)
            {
                tbl_Contact_ViewModel cls = new tbl_Contact_ViewModel();
                cls.idContact = tbl.idContact;
                cls.adress = tbl.adress;
                cls.fax = tbl.fax;
                cls.postBox = tbl.postBox;
                cls.website = tbl.website;
                cls.tel = tbl.tel;
                cls.postalCode = tbl.postalCode;
                cls.mail = tbl.mail;
                cls.lastUpdate = tbl.lastUpdate;
                cls.Des = tbl.Des;
                cls.TelSmart = tbl.TelSmart;
                var x = tbl.x;
                var y = tbl.y;
                cls.position = x + "," + y;
                ls_clsContact.Add(cls);
            }
            return ls_clsContact;

        }

        [HttpPost("WM_InsertComplaint")]
        public string WM_InsertComplaint(TblComplaint entity, string User, string Pass/*,
              string idState,
                string mobile,
                string Address,
                string idAudience,
                string fName,
                string lName,
                string CodeInsu,
                string natcode,
                string idCashDeskInsurance,
                string insurerName,
                string PishkhanName,
                string Other,
                string unitComplaint,
                string des,
            string img*/
           )
        {
            CLassControl dd = new CLassControl();
            if (User == userName && Pass == Password)
            {
                try
                {
                    TblComplaint t = new TblComplaint();
                    if (entity.Address == null)
                        t.Address = "-";
                    else
                    {
                        t.Address = entity.Address == "null" ? "" : entity.Address;
                    }

                    if (entity.CodeInsu == null)
                        t.CodeInsu = "-";
                    else
                    {
                        t.CodeInsu = entity.CodeInsu == "null" ? "" : entity.CodeInsu;
                    }
                    t.dateSend = dd.GetFarsiDate();
                    if (entity.des == null)
                        t.des = "-";
                    else
                    {
                        t.des = entity.des == "null" ? "" : entity.des;
                    }
                    t.fName = entity.fName == "null" ? "" : entity.fName;
                    t.lName = entity.lName == "null" ? "" : entity.lName;
                    t.mobile = entity.mobile;
                    if (entity.natcode == null)
                    {
                        t.natcode = "-";
                    }
                    else
                    {
                        t.natcode = entity.natcode;
                    }

                    t.readed = false;
                    t.timeSend = CLassControl.getTime();
                    t.insurerName = entity.insurerName == "null" ? "" : entity.insurerName;
                    t.unitComplaint = entity.unitComplaint == "null" ? "" : entity.unitComplaint;
                    t.idCity = int.Parse(entity.idCity.ToString());
                    t.idAudience = int.Parse(entity.idAudience.ToString());
                    t.idCashDeskInsurance = int.Parse(entity.idCashDeskInsurance.ToString());
                    _context.TblComplaint.Add(t);
                    _context.SaveChanges();

                    //string img = entity.img.ToString();
                    //byte[] bytes = System.Convert.FromBase64String(img);
                    //byte[] bitmapData = new byte[entity.img.Length];
                    //bitmapData = Convert.FromBase64String(img);
                    //t.img = bitmapData;
                    //var path = Path.Combine(_environment.WebRootPath, "imageUpload");
                    return "شکایت با موفقیت ثبت شد";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
            else
                return "خطای نام و رمز عبور";
        }

        [HttpGet("WM_Types")]
        public List<ROLE_TYPE_> WM_Types(string Update)
        {

            List<ROLE_TYPE_> ls_clsTypes = new List<ROLE_TYPE_>();
            List<ROLE_TYPE_> ls_tType = (from x in _context.ROLE_TYPE_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (ROLE_TYPE_ t in ls_tType)
            {
                ROLE_TYPE_ o = new ROLE_TYPE_();
                o.id_Role_type = t.id_Role_type;
                o.lastUpdate = t.lastUpdate;
                o.Role_type_Name = t.Role_type_Name;
                o.flag = (bool)t.flag;
                ls_clsTypes.Add(o);
            }
            return ls_clsTypes;
        }

        [HttpGet("WM_City")]
        public List<TblCity_> WM_City(string Update)
        {

            List<TblCity_> ls_clsCity = new List<TblCity_>();
            List<TblCity_> ls_tCity = (from x in _context.TblCity_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblCity_ t in ls_tCity)
            {
                TblCity_ o = new TblCity_();
                o.idCity = t.idCity;
                o.lastUpdate = t.lastUpdate;
                o.CityName = t.CityName;
                o.flag = (Boolean)t.flag;
                ls_clsCity.Add(o);
            }
            return ls_clsCity;

        }

        [HttpGet("WM_Institute")]
        public IEnumerable<View_NewInstitutes> WM_Institute()
        {
            var select2 = _context.View_NewInstitutes.ToList();



            //var select = _context.View_NewInstitutes.AsEnumerable();
            return select2;
        }

        [HttpGet("WM_Owner")]
        public List<TblOwner_> WM_Owner(string Update)
        {

            List<TblOwner_> ls_clsOwner = new List<TblOwner_>();
            List<TblOwner_> ls_tOwner = (from x in _context.TblOwner_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblOwner_ t in ls_tOwner)
            {
                TblOwner_ o = new TblOwner_();
                o.idOwner = t.idOwner;
                o.lastUpdate = t.lastUpdate;
                o.OwnerName = t.OwnerName;
                o.flag = (bool)t.flag;
                ls_clsOwner.Add(o);
            }
            return ls_clsOwner;

        }

        [HttpGet("WM_Madarek")]
        public List<TblMadarek_> WM_Madarek(string Update)
        {

            List<TblMadarek_> ls_clsMadarek = new List<TblMadarek_>();
            List<TblMadarek_> ls_tMadarek = (from x in _context.TblMadarek_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblMadarek_ t in ls_tMadarek)
            {
                TblMadarek_ o = new TblMadarek_();
                o.idMadarek = t.idMadarek;
                o.lastUpdate = t.lastUpdate;
                o.flag = (bool)t.flag;
                o.MadarekName = t.MadarekName;
                ls_clsMadarek.Add(o);
            }
            return ls_clsMadarek;

        }

        [HttpGet("WM_Reshte")]
        public List<TblReshteh_> WM_Reshte(string Update)
        {

            List<TblReshteh_> ls_clsReshte = new List<TblReshteh_>();
            List<TblReshteh_> ls_tReshte = (from x in _context.TblReshteh_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblReshteh_ t in ls_tReshte)
            {
                TblReshteh_ o = new TblReshteh_();
                o.idReshteh = t.idReshteh;
                o.lastUpdate = t.lastUpdate;
                o.reshtehName = t.reshtehName;
                o.flag = (bool)t.flag;
                ls_clsReshte.Add(o);
            }
            return ls_clsReshte;

        }

        [HttpGet("WM_InstituteType")]
        public List<TblINSTITUTE_TYPE_> WM_InstituteType(string Update)
        {

            List<TblINSTITUTE_TYPE_> ls_clsInstituteType = new List<TblINSTITUTE_TYPE_>();
            List<TblINSTITUTE_TYPE_> ls_tInstituteType = (from x in _context.TblINSTITUTE_TYPE_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblINSTITUTE_TYPE_ t in ls_tInstituteType)
            {
                TblINSTITUTE_TYPE_ o = new TblINSTITUTE_TYPE_();
                o.idINSTITUTE_TYPE = t.idINSTITUTE_TYPE;
                o.lastUpdate = t.lastUpdate;
                o.INSTITUTE_TYPE = t.INSTITUTE_TYPE;
                o.flag = (bool)t.flag;
                ls_clsInstituteType.Add(o);
            }
            return ls_clsInstituteType;

        }

        [HttpGet("WM_InstitutePersonal")]
        public IEnumerable<ViewPeronal> WM_InstitutePersonal()
        {
            //List<ViewPeronal> ls_clsInstitutePersonal = new List<ViewPeronal>();

            var select = _context.ViewPeronal.AsEnumerable();




            ////var select = new List<ViewPeronal>();

            //if (flag == 1)
            //{
            //    var select = _context.ViewPeronal.Where(x => x.id_personal == 5).ToList();
            //    return select;
            //}
            //else if (flag == 2)
            //{
            //    var select = _context.ViewPeronal.Where(x => x.id_personal > 9000 && x.id_personal <= 18000).ToList();
            //    return select;
            //}
            //else
            //{
            //    var select = _context.ViewPeronal.Where(x => x.id_personal > 18000).ToList();
            //    return select;
            //}

            return select;

        }

        [HttpGet("WM_Expert")]
        public List<TblEXPERT_> WM_Expert(string Update)
        {

            List<TblEXPERT_> ls_clsExpert = new List<TblEXPERT_>();
            List<TblEXPERT_> ls_tExpert = (from x in _context.TblEXPERT_ where x.lastUpdate.CompareTo(Update) >= 0 select x).ToList();
            foreach (TblEXPERT_ t in ls_tExpert)
            {
                TblEXPERT_ o = new TblEXPERT_();
                o.idExpert = t.idExpert;
                o.lastUpdate = t.lastUpdate;
                o.ExpertName = t.ExpertName;
                o.flag = (bool)t.flag;
                ls_clsExpert.Add(o);
            }
            return ls_clsExpert;

        }

        [HttpGet("WM_CheckVer")]
        public string WM_CheckVer(string User, string Pass)
        {

            TblVer l = (from x in _context.TblVer select x).First();
            return l.verCode.ToString();

        }

        [HttpGet("WM_InsertDevice")]
        public string WM_InsertDevice(
        string IMEI
        , string Brand
        , string Model
        , string API
        , string SDK
        )
        {

            try
            {
                clsTarikh tarix = new clsTarikh();
                TblRepDevice t = new TblRepDevice();
                t.API = API;
                t.Brand = Brand;
                t.Model = Model;
                t.IMEI = IMEI;
                t.SDK = SDK;
                t.Date = tarix.date();
                _context.TblRepDevice.Add(t);
                _context.SaveChanges();
                return true.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost("WM_InsertNasraSanji2")]
        public string WM_InsertNasraSanji2(NazarSanji2 entity/*,string cityname,
                                           string sex,
                                           string hostName,
                                           string malekiyat,
                                           string modatBastari,
                                           string sandogName,
                                           string ans1,
                                           string ans2,
                                           string ans3,
                                           string ans4,
                                           string ans5,
                                           string ans6,


        string tozihaot*/)
        {

            try
            {
                clsTarikh tarix = new clsTarikh();
                NazarSanji2 t = new NazarSanji2();
                t.cityname = entity.cityname == "null" ? "" : entity.cityname;
                t.sex = entity.sex == "null" ? "" : entity.sex;
                t.hostName = entity.hostName == "null" ? "" : entity.sex;
                t.malekiyat = entity.malekiyat == "null" ? "" : entity.malekiyat;
                t.modatBastari = entity.modatBastari == "null" ? "" : entity.modatBastari;
                t.sandogName = entity.sandogName == "null" ? "" : entity.sandogName;
                t.ans1 = entity.ans1 == "null" ? "" : entity.ans1;
                t.ans2 = entity.ans2 == "null" ? "" : entity.ans2;
                t.ans3 = entity.ans3 == "null" ? "" : entity.ans3;
                t.ans4 = entity.ans4 == "null" ? "" : entity.ans4;
                t.ans5 = entity.ans5 == "null" ? "" : entity.ans5;
                t.ans6 = entity.ans6 == "null" ? "" : entity.ans6;
                t.tozihaot = entity.tozihaot == "null" ? "" : entity.tozihaot;
                t.ComDate = tarix.date();
                t.ComTime = tarix.time();
                t.flag = false;
                _context.NazarSanji2.Add(t);
                _context.SaveChanges();
                return true.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet("WM_InformOrgan")]
        public List<tbl_InformingOrgan_ViewModel> WM_InformOrgan(string Update)
        {

            List<tbl_InformingOrgan> ls_tblInform;


            ls_tblInform = (from x in _context.tbl_InformingOrgan where x.lastUpdate.CompareTo(Update) > 0 select x).ToList();
            List<tbl_InformingOrgan_ViewModel> ls_clsInforming = new List<tbl_InformingOrgan_ViewModel>();
            foreach (tbl_InformingOrgan t in ls_tblInform)
            {
                tbl_InformingOrgan_ViewModel ob = new tbl_InformingOrgan_ViewModel();
                ob.idInfo = t.idInfo;
                ob.infoDes = t.infoDes;
                ob.lastUpdate = t.lastUpdate;
                ob.InfoDateTime = t.InfoDateTime;
                ob.file1 = t.filename1;
                ob.file2 = t.filename2;
                if (t.privatePer == true)
                    ob.isprivate = "1";
                else
                    ob.isprivate = "0";
                ob.flag = (bool)t.flag;
                ls_clsInforming.Add(ob);
            }
            return ls_clsInforming;

        }

        [HttpGet("WM_CommentOrgan")]
        public string WM_CommentOrgan(string args)
        {
            using (StreamWriter writetext = new StreamWriter("d:\\write.txt"))
            {
                writetext.WriteLine("0");
            }

            try
            {
                using (StreamWriter writetext = new StreamWriter("d:\\zzzz.txt"))
                {
                    writetext.WriteLine(args);
                }
                string[] a = args.Split('~');
                clsTarikh tarix = new clsTarikh();
                tbl_CommentOrgan t = new tbl_CommentOrgan();
                t.OrganName = a[0] == "null" ? "" : a[0];

                t.CommentText = a[1] == "null" ? "" : a[1];
                t.ComDate = tarix.date();
                t.ComTime = tarix.time();
                t.flag = false;
                t.OrganCode = a[2];
                _context.tbl_CommentOrgan.Add(t);
                _context.SaveChanges();
                return true.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [HttpGet("CheckPassWord")]
        public string CheckPassWord(string user, string pass)
        {
            TblPassWord c = _context.TblPassWord.Where(n => n.username.Equals(user)).FirstOrDefault();
            TblPassWord tp = _context.TblPassWord.Where(n => n.username.Equals(user)
                 && n.password.Equals(pass)).FirstOrDefault();
            if (c != null && tp == null)
                return "false";
            if (tp != null)
                return "true";
            else
            {
                TblINSTITUTE_PERSONEL_ t = _context.TblINSTITUTE_PERSONEL_.Where(n => n.passWord.Equals(user)
                     && n.passWord.Equals(pass)).FirstOrDefault();
                if (t != null)
                    return "true";
                else
                    return "false";
            }
        }

        [HttpGet("ChangePassWord")]
        public string ChangePassWord(string user, string pass)
        {

            TblPassWord tp = _context.TblPassWord.Where(n => n.username.Equals(user)).FirstOrDefault();
            if (tp != null)
            {
                tp.username = user;
                tp.password = pass;
                _context.SaveChanges();
                return "true";
            }
            else
            {
                TblPassWord t = new TblPassWord();
                t.username = user;
                t.password = pass;
                _context.TblPassWord.Add(t);
                _context.SaveChanges();
                return "true";
            }
        }

        [HttpGet]
        public IEnumerable<TblComplaint> Complaints()
        {
            IQueryable<TblComplaint> select;
            return @select = _context.TblComplaint.Where(x => x.idComplaint == 64);
            //return select;
        }

        [HttpPost("AddServiceTable")]
        public string AddServiceTable(ServiceTable model)
        {
            if (ModelState.IsValid)
            {
                _context.ServiceTables.Add(model);
                _context.SaveChanges();

                return true.ToString();
            }

            return false.ToString();
        }

        [HttpPost("addSurveyOfIinsured")]
        public string addSurveyOfIinsured(SurveyOfIinsured model)
        {
            if (ModelState.IsValid)
            {
                model.DateTime = DateTime.UtcNow;
                _context.SurveyOfIinsureds.Add(model);
                _context.SaveChanges();

                return true.ToString();
            }

            return false.ToString();
        }

        [HttpPost("addOfficeRefrandum")]
        public string addOfficeRefrandum(OfficeRefrandum model)
        {
            if (ModelState.IsValid)
            {
                var person = _context.TblPersonal.Where(x => x.natCode == model.NatCode).FirstOrDefault();
                if (person != null)
                {
                    model.SubmitDateTime = DateTime.UtcNow;
                    model.idPerson = person.idPerson;
                    _context.OfficeRefrandums.Add(model);
                    _context.SaveChanges();
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }

            return false.ToString();
        }

    }
}