using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NazarSanji2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cityname = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true),
                    hostName = table.Column<string>(nullable: true),
                    malekiyat = table.Column<string>(nullable: true),
                    modatBastari = table.Column<string>(nullable: true),
                    sandogName = table.Column<string>(nullable: true),
                    ans1 = table.Column<string>(nullable: true),
                    ans2 = table.Column<string>(nullable: true),
                    ans3 = table.Column<string>(nullable: true),
                    ans4 = table.Column<string>(nullable: true),
                    ans5 = table.Column<string>(nullable: true),
                    ans6 = table.Column<string>(nullable: true),
                    tozihaot = table.Column<string>(nullable: true),
                    ComDate = table.Column<string>(nullable: true),
                    ComTime = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NazarSanji2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_TYPE_",
                columns: table => new
                {
                    id_Role_type = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_type_Name = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_TYPE_", x => x.id_Role_type);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Arzyabi",
                columns: table => new
                {
                    idArzyabi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arzyabi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Arzyabi", x => x.idArzyabi);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Bime",
                columns: table => new
                {
                    idBime = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Bime", x => x.idBime);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CommentOrgan",
                columns: table => new
                {
                    idComment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentText = table.Column<string>(nullable: false),
                    ComTime = table.Column<string>(nullable: false),
                    flag = table.Column<bool>(nullable: false),
                    ComDate = table.Column<string>(nullable: false),
                    OrganName = table.Column<string>(nullable: false),
                    OrganCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CommentOrgan", x => x.idComment);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Contact",
                columns: table => new
                {
                    idContact = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    mail = table.Column<string>(nullable: false),
                    fax = table.Column<string>(nullable: false),
                    postalCode = table.Column<string>(nullable: false),
                    tel = table.Column<string>(nullable: false),
                    website = table.Column<string>(nullable: false),
                    postBox = table.Column<string>(nullable: false),
                    adress = table.Column<string>(nullable: false),
                    TelSmart = table.Column<string>(nullable: false),
                    Des = table.Column<string>(nullable: false),
                    x = table.Column<string>(nullable: false),
                    y = table.Column<string>(nullable: false),
                    lastUpdate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Contact", x => x.idContact);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Edarat",
                columns: table => new
                {
                    idOffice = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(nullable: false),
                    admin = table.Column<string>(nullable: false),
                    Tell = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: false),
                    adress = table.Column<string>(nullable: false),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true),
                    x = table.Column<string>(nullable: false),
                    y = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Edarat", x => x.idOffice);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Education",
                columns: table => new
                {
                    idEdu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EduName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Education", x => x.idEdu);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Informing",
                columns: table => new
                {
                    idInfo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infoDes = table.Column<string>(nullable: false),
                    InfoDateTime = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    imagename = table.Column<string>(nullable: true),
                    privatePer = table.Column<bool>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Informing", x => x.idInfo);
                });

            migrationBuilder.CreateTable(
                name: "tbl_InformingOrgan",
                columns: table => new
                {
                    idInfo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infoDes = table.Column<string>(nullable: false),
                    InfoDateTime = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    privatePer = table.Column<bool>(nullable: false),
                    filename1 = table.Column<string>(nullable: true),
                    filename2 = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_InformingOrgan", x => x.idInfo);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Institution",
                columns: table => new
                {
                    idIns = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Tell = table.Column<string>(nullable: false),
                    UpdateDate = table.Column<string>(nullable: false),
                    flag = table.Column<bool>(nullable: true),
                    x = table.Column<string>(nullable: false),
                    y = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Institution", x => x.idIns);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Moraje",
                columns: table => new
                {
                    idMoraje = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Moraje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Moraje", x => x.idMoraje);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Pishkhan",
                columns: table => new
                {
                    idPishkhan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    tel = table.Column<string>(nullable: false),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true),
                    x = table.Column<string>(nullable: false),
                    y = table.Column<string>(nullable: false),
                    ManagerName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Pishkhan", x => x.idPishkhan);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Reason",
                columns: table => new
                {
                    idReason = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReasonText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Reason", x => x.idReason);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Setadi",
                columns: table => new
                {
                    idSetadi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    edare = table.Column<string>(nullable: false),
                    tel = table.Column<string>(nullable: false),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Setadi", x => x.idSetadi);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sex",
                columns: table => new
                {
                    idSex = table.Column<bool>(nullable: false),
                    sexName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sex", x => x.idSex);
                });

            migrationBuilder.CreateTable(
                name: "tbl_State",
                columns: table => new
                {
                    idState = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_State", x => x.idState);
                });

            migrationBuilder.CreateTable(
                name: "TblAudience",
                columns: table => new
                {
                    idAudience = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameAudience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAudience", x => x.idAudience);
                });

            migrationBuilder.CreateTable(
                name: "TblCashDeskInsurance",
                columns: table => new
                {
                    idCashDeskInsurance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    namelCashDeskInsurance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCashDeskInsurance", x => x.idCashDeskInsurance);
                });

            migrationBuilder.CreateTable(
                name: "TblCity_",
                columns: table => new
                {
                    idCity = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCity_", x => x.idCity);
                });

            migrationBuilder.CreateTable(
                name: "TblContent",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contentTitel = table.Column<string>(nullable: false),
                    contentText = table.Column<string>(nullable: false),
                    ContenteDate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContent", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "TblEducation2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEducation2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEXPERT_",
                columns: table => new
                {
                    idExpert = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpertName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEXPERT_", x => x.idExpert);
                });

            migrationBuilder.CreateTable(
                name: "TblINSTITUTE_TYPE_",
                columns: table => new
                {
                    idINSTITUTE_TYPE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    INSTITUTE_TYPE = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblINSTITUTE_TYPE_", x => x.idINSTITUTE_TYPE);
                });

            migrationBuilder.CreateTable(
                name: "TblLongOfServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLongOfServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMadarek_",
                columns: table => new
                {
                    idMadarek = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MadarekName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMadarek_", x => x.idMadarek);
                });

            migrationBuilder.CreateTable(
                name: "TblMenu",
                columns: table => new
                {
                    menuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    menuName = table.Column<string>(nullable: true),
                    menuFatherID = table.Column<int>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: true),
                    MenueDate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMenu", x => x.menuId);
                });

            migrationBuilder.CreateTable(
                name: "TblOwner_",
                columns: table => new
                {
                    idOwner = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOwner_", x => x.idOwner);
                });

            migrationBuilder.CreateTable(
                name: "TblPassWord",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPassWord", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblPersonal",
                columns: table => new
                {
                    idPerson = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    natCode = table.Column<string>(nullable: false),
                    family = table.Column<string>(nullable: false),
                    fname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPersonal", x => x.idPerson);
                });

            migrationBuilder.CreateTable(
                name: "TblRepDevice",
                columns: table => new
                {
                    idDevice = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IMEI = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    API = table.Column<string>(nullable: true),
                    SDK = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRepDevice", x => x.idDevice);
                });

            migrationBuilder.CreateTable(
                name: "TblReport",
                columns: table => new
                {
                    ReportID = table.Column<byte>(nullable: false),
                    ReportName = table.Column<string>(nullable: true),
                    ReportURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblReport", x => x.ReportID);
                });

            migrationBuilder.CreateTable(
                name: "TblReshteh_",
                columns: table => new
                {
                    idReshteh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    reshtehName = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblReshteh_", x => x.idReshteh);
                });

            migrationBuilder.CreateTable(
                name: "TblTel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(nullable: true),
                    lname = table.Column<string>(nullable: true),
                    tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblTypeMasolyat",
                columns: table => new
                {
                    TypeMasolyat = table.Column<string>(nullable: true),
                    TypeMasolyatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTypeMasolyat", x => x.TypeMasolyatID);
                });

            migrationBuilder.CreateTable(
                name: "TblUserVisite",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateVisite = table.Column<string>(nullable: true),
                    CountUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserVisite", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblVer",
                columns: table => new
                {
                    IdVer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    verCode = table.Column<int>(nullable: false),
                    DateUpdate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVer", x => x.IdVer);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ApplicationRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeRefrandums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<bool>(nullable: false),
                    isMarried = table.Column<bool>(nullable: false),
                    IdEdu = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    IdQ1 = table.Column<string>(nullable: true),
                    IdQ2 = table.Column<string>(nullable: true),
                    IdQ3 = table.Column<string>(nullable: true),
                    IdQ4 = table.Column<string>(nullable: true),
                    IdQ5 = table.Column<string>(nullable: true),
                    IdQ6 = table.Column<string>(nullable: true),
                    IdQ7 = table.Column<string>(nullable: true),
                    IdQ8 = table.Column<string>(nullable: true),
                    IdQ9 = table.Column<string>(nullable: true),
                    IdQ10 = table.Column<string>(nullable: true),
                    IdQ11 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeRefrandums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeRefrandums_tbl_Education_IdEdu",
                        column: x => x.IdEdu,
                        principalTable: "tbl_Education",
                        principalColumn: "idEdu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Comment",
                columns: table => new
                {
                    idComment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idState = table.Column<int>(nullable: false),
                    idSex = table.Column<bool>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    idEducation = table.Column<int>(nullable: false),
                    idBime = table.Column<int>(nullable: false),
                    idMoraje = table.Column<int>(nullable: false),
                    IdQ1 = table.Column<int>(nullable: false),
                    IdQ2 = table.Column<int>(nullable: false),
                    IdQ3 = table.Column<int>(nullable: false),
                    IdQ4 = table.Column<int>(nullable: false),
                    IdQ5 = table.Column<int>(nullable: false),
                    IdQ6 = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    ComTime = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: false),
                    ComDate = table.Column<string>(nullable: true),
                    FirstPerson = table.Column<string>(nullable: true),
                    SecondPeson = table.Column<string>(nullable: true),
                    idReason = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Comment", x => x.idComment);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_Bime_idBime",
                        column: x => x.idBime,
                        principalTable: "tbl_Bime",
                        principalColumn: "idBime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_Education_idEducation",
                        column: x => x.idEducation,
                        principalTable: "tbl_Education",
                        principalColumn: "idEdu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_Moraje_idMoraje",
                        column: x => x.idMoraje,
                        principalTable: "tbl_Moraje",
                        principalColumn: "idMoraje",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_Reason_idReason",
                        column: x => x.idReason,
                        principalTable: "tbl_Reason",
                        principalColumn: "idReason",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_sex_idSex",
                        column: x => x.idSex,
                        principalTable: "tbl_sex",
                        principalColumn: "idSex",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comment_tbl_State_idState",
                        column: x => x.idState,
                        principalTable: "tbl_State",
                        principalColumn: "idState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<bool>(nullable: false),
                    IdCity = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    IdEdu = table.Column<int>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    WicheService = table.Column<string>(nullable: true),
                    FlagMoraje = table.Column<string>(nullable: true),
                    IdQ1 = table.Column<string>(nullable: true),
                    IdQ2 = table.Column<string>(nullable: true),
                    IdQ3 = table.Column<string>(nullable: true),
                    IdQ4 = table.Column<string>(nullable: true),
                    IdQ5 = table.Column<string>(nullable: true),
                    IdQ6 = table.Column<string>(nullable: true),
                    IdQ7 = table.Column<string>(nullable: true),
                    IdQ8 = table.Column<string>(nullable: true),
                    IdQ9 = table.Column<string>(nullable: true),
                    IdQ10 = table.Column<string>(nullable: true),
                    IdQ11 = table.Column<string>(nullable: true),
                    IdQ12 = table.Column<string>(nullable: true),
                    IdQ13 = table.Column<string>(nullable: true),
                    IdQ14 = table.Column<string>(nullable: true),
                    IdQ15 = table.Column<string>(nullable: true),
                    IdQ16 = table.Column<string>(nullable: true),
                    Des = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTables_TblCity__IdCity",
                        column: x => x.IdCity,
                        principalTable: "TblCity_",
                        principalColumn: "idCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTables_tbl_Education_IdEdu",
                        column: x => x.IdEdu,
                        principalTable: "tbl_Education",
                        principalColumn: "idEdu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyOfIinsureds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCity = table.Column<int>(nullable: false),
                    hospitalName = table.Column<string>(nullable: true),
                    hospitalStay = table.Column<string>(nullable: true),
                    hospitalOwnership = table.Column<bool>(nullable: false),
                    IdBime = table.Column<int>(nullable: false),
                    IdQ1 = table.Column<string>(nullable: true),
                    IdQ2 = table.Column<string>(nullable: true),
                    IdQ3 = table.Column<string>(nullable: true),
                    IdQ4 = table.Column<string>(nullable: true),
                    IdQ5 = table.Column<string>(nullable: true),
                    IdQ6 = table.Column<string>(nullable: true),
                    Des = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyOfIinsureds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyOfIinsureds_tbl_Bime_IdBime",
                        column: x => x.IdBime,
                        principalTable: "tbl_Bime",
                        principalColumn: "idBime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyOfIinsureds_TblCity__IdCity",
                        column: x => x.IdCity,
                        principalTable: "TblCity_",
                        principalColumn: "idCity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblComplaint",
                columns: table => new
                {
                    idComplaint = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idCity = table.Column<int>(nullable: false),
                    mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    idAudience = table.Column<int>(nullable: false),
                    fName = table.Column<string>(nullable: true),
                    lName = table.Column<string>(nullable: true),
                    CodeInsu = table.Column<string>(nullable: true),
                    natcode = table.Column<string>(nullable: true),
                    idCashDeskInsurance = table.Column<int>(nullable: false),
                    insurerName = table.Column<string>(nullable: true),
                    unitComplaint = table.Column<string>(nullable: true),
                    des = table.Column<string>(nullable: true),
                    img = table.Column<byte[]>(nullable: true),
                    timeSend = table.Column<string>(nullable: true),
                    dateSend = table.Column<string>(nullable: true),
                    readed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblComplaint", x => x.idComplaint);
                    table.ForeignKey(
                        name: "FK_TblComplaint_TblAudience_idAudience",
                        column: x => x.idAudience,
                        principalTable: "TblAudience",
                        principalColumn: "idAudience",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblComplaint_TblCashDeskInsurance_idCashDeskInsurance",
                        column: x => x.idCashDeskInsurance,
                        principalTable: "TblCashDeskInsurance",
                        principalColumn: "idCashDeskInsurance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblComplaint_TblCity__idCity",
                        column: x => x.idCity,
                        principalTable: "TblCity_",
                        principalColumn: "idCity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblINSTITUTE_",
                columns: table => new
                {
                    idInstitues = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codeOrgan = table.Column<int>(nullable: true),
                    nameOrgan = table.Column<string>(nullable: true),
                    nameOrganMain = table.Column<string>(nullable: true),
                    hos = table.Column<string>(nullable: true),
                    idINSTITUTE_TYPE = table.Column<int>(nullable: true),
                    idowner = table.Column<int>(nullable: true),
                    idCity = table.Column<int>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    TEL = table.Column<string>(nullable: true),
                    ZIP = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblINSTITUTE_", x => x.idInstitues);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE__TblCity__idCity",
                        column: x => x.idCity,
                        principalTable: "TblCity_",
                        principalColumn: "idCity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE__TblINSTITUTE_TYPE__idINSTITUTE_TYPE",
                        column: x => x.idINSTITUTE_TYPE,
                        principalTable: "TblINSTITUTE_TYPE_",
                        principalColumn: "idINSTITUTE_TYPE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE__TblOwner__idowner",
                        column: x => x.idowner,
                        principalTable: "TblOwner_",
                        principalColumn: "idOwner",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institute_Personal",
                columns: table => new
                {
                    id_personal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codeOrgan = table.Column<int>(nullable: true),
                    nezamId = table.Column<string>(nullable: true),
                    DRName = table.Column<string>(nullable: true),
                    DrFamily = table.Column<string>(nullable: true),
                    Id_ROLETYPE = table.Column<int>(nullable: true),
                    Id_MADRAK = table.Column<int>(nullable: true),
                    Id_RESHTEH = table.Column<int>(nullable: true),
                    Id_EXPERT = table.Column<int>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true),
                    passWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute_Personal", x => x.id_personal);
                    table.ForeignKey(
                        name: "FK_Institute_Personal_TblEXPERT__Id_EXPERT",
                        column: x => x.Id_EXPERT,
                        principalTable: "TblEXPERT_",
                        principalColumn: "idExpert",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institute_Personal_TblMadarek__Id_MADRAK",
                        column: x => x.Id_MADRAK,
                        principalTable: "TblMadarek_",
                        principalColumn: "idMadarek",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institute_Personal_TblReshteh__Id_RESHTEH",
                        column: x => x.Id_RESHTEH,
                        principalTable: "TblReshteh_",
                        principalColumn: "idReshteh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institute_Personal_ROLE_TYPE__Id_ROLETYPE",
                        column: x => x.Id_ROLETYPE,
                        principalTable: "ROLE_TYPE_",
                        principalColumn: "id_Role_type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblINSTITUTE_PERSONEL_",
                columns: table => new
                {
                    id_personal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codeOrgan = table.Column<int>(nullable: true),
                    nezamId = table.Column<string>(nullable: true),
                    Tekrari = table.Column<double>(nullable: true),
                    DRName = table.Column<string>(nullable: true),
                    DrFamily = table.Column<string>(nullable: true),
                    Id_ROLETYPE = table.Column<int>(nullable: true),
                    Id_MADRAK = table.Column<int>(nullable: true),
                    Id_RESHTEH = table.Column<int>(nullable: true),
                    Id_EXPERT = table.Column<int>(nullable: true),
                    lastUpdate = table.Column<string>(nullable: true),
                    flag = table.Column<bool>(nullable: true),
                    passWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblINSTITUTE_PERSONEL_", x => x.id_personal);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE_PERSONEL__TblEXPERT__Id_EXPERT",
                        column: x => x.Id_EXPERT,
                        principalTable: "TblEXPERT_",
                        principalColumn: "idExpert",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE_PERSONEL__TblMadarek__Id_MADRAK",
                        column: x => x.Id_MADRAK,
                        principalTable: "TblMadarek_",
                        principalColumn: "idMadarek",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE_PERSONEL__TblReshteh__Id_RESHTEH",
                        column: x => x.Id_RESHTEH,
                        principalTable: "TblReshteh_",
                        principalColumn: "idReshteh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblINSTITUTE_PERSONEL__ROLE_TYPE__Id_ROLETYPE",
                        column: x => x.Id_ROLETYPE,
                        principalTable: "ROLE_TYPE_",
                        principalColumn: "id_Role_type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationRoleId",
                table: "AspNetUsers",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_Personal_Id_EXPERT",
                table: "Institute_Personal",
                column: "Id_EXPERT");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_Personal_Id_MADRAK",
                table: "Institute_Personal",
                column: "Id_MADRAK");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_Personal_Id_RESHTEH",
                table: "Institute_Personal",
                column: "Id_RESHTEH");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_Personal_Id_ROLETYPE",
                table: "Institute_Personal",
                column: "Id_ROLETYPE");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_EmployeeId",
                table: "OfficeRefrandums",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_IdEdu",
                table: "OfficeRefrandums",
                column: "IdEdu");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_IdCity",
                table: "ServiceTables",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_IdEdu",
                table: "ServiceTables",
                column: "IdEdu");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyOfIinsureds_IdBime",
                table: "SurveyOfIinsureds",
                column: "IdBime");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyOfIinsureds_IdCity",
                table: "SurveyOfIinsureds",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idBime",
                table: "tbl_Comment",
                column: "idBime");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idEducation",
                table: "tbl_Comment",
                column: "idEducation");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idMoraje",
                table: "tbl_Comment",
                column: "idMoraje");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idReason",
                table: "tbl_Comment",
                column: "idReason");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idSex",
                table: "tbl_Comment",
                column: "idSex");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comment_idState",
                table: "tbl_Comment",
                column: "idState");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplaint_idAudience",
                table: "TblComplaint",
                column: "idAudience");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplaint_idCashDeskInsurance",
                table: "TblComplaint",
                column: "idCashDeskInsurance");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplaint_idCity",
                table: "TblComplaint",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE__idCity",
                table: "TblINSTITUTE_",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE__idINSTITUTE_TYPE",
                table: "TblINSTITUTE_",
                column: "idINSTITUTE_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE__idowner",
                table: "TblINSTITUTE_",
                column: "idowner");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE_PERSONEL__Id_EXPERT",
                table: "TblINSTITUTE_PERSONEL_",
                column: "Id_EXPERT");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE_PERSONEL__Id_MADRAK",
                table: "TblINSTITUTE_PERSONEL_",
                column: "Id_MADRAK");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE_PERSONEL__Id_RESHTEH",
                table: "TblINSTITUTE_PERSONEL_",
                column: "Id_RESHTEH");

            migrationBuilder.CreateIndex(
                name: "IX_TblINSTITUTE_PERSONEL__Id_ROLETYPE",
                table: "TblINSTITUTE_PERSONEL_",
                column: "Id_ROLETYPE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Institute_Personal");

            migrationBuilder.DropTable(
                name: "NazarSanji2");

            migrationBuilder.DropTable(
                name: "OfficeRefrandums");

            migrationBuilder.DropTable(
                name: "ServiceTables");

            migrationBuilder.DropTable(
                name: "SurveyOfIinsureds");

            migrationBuilder.DropTable(
                name: "tbl_Arzyabi");

            migrationBuilder.DropTable(
                name: "tbl_Comment");

            migrationBuilder.DropTable(
                name: "tbl_CommentOrgan");

            migrationBuilder.DropTable(
                name: "tbl_Contact");

            migrationBuilder.DropTable(
                name: "Tbl_Edarat");

            migrationBuilder.DropTable(
                name: "tbl_Informing");

            migrationBuilder.DropTable(
                name: "tbl_InformingOrgan");

            migrationBuilder.DropTable(
                name: "tbl_Institution");

            migrationBuilder.DropTable(
                name: "Tbl_Pishkhan");

            migrationBuilder.DropTable(
                name: "Tbl_Setadi");

            migrationBuilder.DropTable(
                name: "TblComplaint");

            migrationBuilder.DropTable(
                name: "TblContent");

            migrationBuilder.DropTable(
                name: "TblEducation2");

            migrationBuilder.DropTable(
                name: "TblINSTITUTE_");

            migrationBuilder.DropTable(
                name: "TblINSTITUTE_PERSONEL_");

            migrationBuilder.DropTable(
                name: "TblLongOfServices");

            migrationBuilder.DropTable(
                name: "TblMenu");

            migrationBuilder.DropTable(
                name: "TblPassWord");

            migrationBuilder.DropTable(
                name: "TblPersonal");

            migrationBuilder.DropTable(
                name: "TblRepDevice");

            migrationBuilder.DropTable(
                name: "TblReport");

            migrationBuilder.DropTable(
                name: "TblTel");

            migrationBuilder.DropTable(
                name: "TblTypeMasolyat");

            migrationBuilder.DropTable(
                name: "TblUserVisite");

            migrationBuilder.DropTable(
                name: "TblVer");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "tbl_Bime");

            migrationBuilder.DropTable(
                name: "tbl_Education");

            migrationBuilder.DropTable(
                name: "tbl_Moraje");

            migrationBuilder.DropTable(
                name: "tbl_Reason");

            migrationBuilder.DropTable(
                name: "tbl_sex");

            migrationBuilder.DropTable(
                name: "tbl_State");

            migrationBuilder.DropTable(
                name: "TblAudience");

            migrationBuilder.DropTable(
                name: "TblCashDeskInsurance");

            migrationBuilder.DropTable(
                name: "TblCity_");

            migrationBuilder.DropTable(
                name: "TblINSTITUTE_TYPE_");

            migrationBuilder.DropTable(
                name: "TblOwner_");

            migrationBuilder.DropTable(
                name: "TblEXPERT_");

            migrationBuilder.DropTable(
                name: "TblMadarek_");

            migrationBuilder.DropTable(
                name: "TblReshteh_");

            migrationBuilder.DropTable(
                name: "ROLE_TYPE_");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
