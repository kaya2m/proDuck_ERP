using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace proDuck.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "public",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    CountryName = table.Column<string>(type: "text", nullable: true),
                    CountryDialCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    Storage = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "machines",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineName = table.Column<string>(type: "text", nullable: true),
                    OperationType = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ColorCount = table.Column<int>(type: "integer", nullable: false),
                    DailyCapacity = table.Column<int>(type: "integer", nullable: false),
                    DailyCapacityKg = table.Column<decimal>(type: "numeric", nullable: false),
                    DailyCapacityLt = table.Column<decimal>(type: "numeric", nullable: false),
                    AverageWorkingSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    EmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modeltype",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Formula = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modeltype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pallet",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseName = table.Column<string>(type: "text", nullable: true),
                    PalletCode = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    StockName = table.Column<string>(type: "text", nullable: true),
                    StockQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymenttype",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymenttype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salesrepresentative",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Territory = table.Column<string>(type: "text", nullable: true),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    EmployeeCode = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    TotalSales = table.Column<int>(type: "integer", nullable: false),
                    TotalRevenue = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCommission = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberOfClients = table.Column<int>(type: "integer", nullable: false),
                    MonthlyTarget = table.Column<int>(type: "integer", nullable: false),
                    QuarterlyTarget = table.Column<int>(type: "integer", nullable: false),
                    YearlyTarget = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Manager = table.Column<string>(type: "text", nullable: true),
                    OfficeLocation = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsAvailableForContact = table.Column<bool>(type: "boolean", nullable: false),
                    AvailabilityNotes = table.Column<string>(type: "text", nullable: true),
                    LinkedInProfile = table.Column<string>(type: "text", nullable: true),
                    TwitterHandle = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesrepresentative", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salestype",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SalesManager = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salestype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unitofmeasure",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitofmeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicletype",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    M2 = table.Column<int>(type: "integer", nullable: false),
                    M3 = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicletype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "public",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                schema: "public",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_cities_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                schema: "public",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictName = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_districts_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_districts_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "neighborhoods",
                schema: "public",
                columns: table => new
                {
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NeighborhoodName = table.Column<string>(type: "text", nullable: true),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_neighborhoods", x => x.NeighborhoodId);
                    table.ForeignKey(
                        name: "FK_neighborhoods_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_neighborhoods_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_neighborhoods_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "public",
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    ContactNumber2 = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Email2 = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    TaxNumber = table.Column<string>(type: "text", nullable: true),
                    TaxOffice = table.Column<string>(type: "text", nullable: true),
                    idNumber = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "public",
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalSchema: "public",
                        principalTable: "neighborhoods",
                        principalColumn: "NeighborhoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseName = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    ContactPerson = table.Column<string>(type: "text", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouse_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "public",
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalSchema: "public",
                        principalTable: "neighborhoods",
                        principalColumn: "NeighborhoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productcard",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    CustomerProductCode = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    CustomProductName = table.Column<string>(type: "text", nullable: true),
                    InvoiceDescription = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CustomerProductName = table.Column<string>(type: "text", nullable: true),
                    InnerDimension = table.Column<string>(type: "text", nullable: true),
                    OuterDimension = table.Column<string>(type: "text", nullable: true),
                    Width = table.Column<decimal>(type: "numeric", nullable: false),
                    Length = table.Column<decimal>(type: "numeric", nullable: false),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    MachineDescription = table.Column<string>(type: "text", nullable: true),
                    CompletionDescription = table.Column<string>(type: "text", nullable: true),
                    QualityDescription = table.Column<string>(type: "text", nullable: true),
                    ShipmentDescription = table.Column<string>(type: "text", nullable: true),
                    LockStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ProcessStatus = table.Column<string>(type: "text", nullable: true),
                    LoadingAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TBL_CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productcard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productcard_category_TBL_CategoryId",
                        column: x => x.TBL_CategoryId,
                        principalSchema: "public",
                        principalTable: "category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productcard_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productcard_machines_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "public",
                        principalTable: "machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productcard_modeltype_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "public",
                        principalTable: "modeltype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productcard_pallet_PalletId",
                        column: x => x.PalletId,
                        principalSchema: "public",
                        principalTable: "pallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productcard_salesrepresentative_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalSchema: "public",
                        principalTable: "salesrepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productcard_vehicletype_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "public",
                        principalTable: "vehicletype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proposalmeeting",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommunicationType = table.Column<string>(type: "text", nullable: true),
                    CustomerRepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerContactPerson = table.Column<string>(type: "text", nullable: true),
                    CustomerContactEmail = table.Column<string>(type: "text", nullable: true),
                    CustomerContactPhone = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposalmeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proposalmeeting_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposalmeeting_salesrepresentative_CustomerRepresentativeId",
                        column: x => x.CustomerRepresentativeId,
                        principalSchema: "public",
                        principalTable: "salesrepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shippingaddress",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false),
                    Postcode = table.Column<string>(type: "text", nullable: true),
                    Telephone1 = table.Column<string>(type: "text", nullable: true),
                    Telephone2 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippingaddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shippingaddress_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shippingaddress_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shippingaddress_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shippingaddress_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "public",
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shippingaddress_neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalSchema: "public",
                        principalTable: "neighborhoods",
                        principalColumn: "NeighborhoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stockmovement",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MovementId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnId = table.Column<Guid>(type: "uuid", nullable: false),
                    MovementType = table.Column<string>(type: "text", nullable: true),
                    PreviousMovementId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreviousMovementType = table.Column<string>(type: "text", nullable: true),
                    PreviousMovementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderSequence = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    BarcodeNumber = table.Column<string>(type: "text", nullable: true),
                    PalletNumber = table.Column<string>(type: "text", nullable: true),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletCount = table.Column<int>(type: "integer", nullable: false),
                    PalletVolume = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PalletPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingBasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingStatus = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SalesRepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsSystemOutside = table.Column<bool>(type: "boolean", nullable: false),
                    SystemOutsideUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCardId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockmovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stockmovement_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockmovement_machines_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "public",
                        principalTable: "machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockmovement_productcard_ProductCardId",
                        column: x => x.ProductCardId,
                        principalSchema: "public",
                        principalTable: "productcard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_stockmovement_salesrepresentative_SalesRepresentativeId",
                        column: x => x.SalesRepresentativeId,
                        principalSchema: "public",
                        principalTable: "salesrepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockmovement_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "public",
                        principalTable: "warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proposal",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ProposalNumber = table.Column<string>(type: "text", nullable: true),
                    CompanyNumber = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentTerm = table.Column<int>(type: "integer", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountedTotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesRepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proposal_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_paymenttype_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "public",
                        principalTable: "paymenttype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_proposalmeeting_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "public",
                        principalTable: "proposalmeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_salesrepresentative_SalesRepresentativeId",
                        column: x => x.SalesRepresentativeId,
                        principalSchema: "public",
                        principalTable: "salesrepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_salestype_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalSchema: "public",
                        principalTable: "salestype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_shippingaddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "public",
                        principalTable: "shippingaddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposal_vehicletype_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "public",
                        principalTable: "vehicletype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderName = table.Column<string>(type: "text", nullable: true),
                    OrderNumber = table.Column<string>(type: "text", nullable: true),
                    ProposalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockNumber = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerCode = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    SubPaymentMethod = table.Column<string>(type: "text", nullable: true),
                    TermId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesRepresentative = table.Column<string>(type: "text", nullable: true),
                    ContactPerson = table.Column<string>(type: "text", nullable: true),
                    SalesType = table.Column<string>(type: "text", nullable: true),
                    SubSalesType = table.Column<string>(type: "text", nullable: true),
                    CustomerRepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerOrderNumber = table.Column<string>(type: "text", nullable: true),
                    RepresentativeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TBL_ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalSchema: "public",
                        principalTable: "proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_salesrepresentative_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalSchema: "public",
                        principalTable: "salesrepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_shippingaddress_TBL_ShippingAddressId",
                        column: x => x.TBL_ShippingAddressId,
                        principalSchema: "public",
                        principalTable: "shippingaddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "proposaldetail",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecialCode = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProposalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposaldetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proposaldetail_productcard_ProductCardId",
                        column: x => x.ProductCardId,
                        principalSchema: "public",
                        principalTable: "productcard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proposaldetail_proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalSchema: "public",
                        principalTable: "proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderdetail",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderSequence = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProposalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProposalDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerOrderNumber = table.Column<string>(type: "text", nullable: true),
                    SpecialCode = table.Column<string>(type: "text", nullable: true),
                    ProductCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyType = table.Column<string>(type: "text", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "numeric", nullable: false),
                    FreightAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    FreightUnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    FreightIncludedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductionQuantity = table.Column<int>(type: "integer", nullable: false),
                    LoadingQuantity = table.Column<int>(type: "integer", nullable: false),
                    PalletCount = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    ProductionDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeliveryDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeliveryTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    VehicleType = table.Column<string>(type: "text", nullable: true),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    FreightUnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ProductUnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductSalesUnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderdetail_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetail_order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "public",
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetail_productcard_ProductCardId",
                        column: x => x.ProductCardId,
                        principalSchema: "public",
                        principalTable: "productcard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetail_proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalSchema: "public",
                        principalTable: "proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetail_shippingaddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "public",
                        principalTable: "shippingaddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "public",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "public",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "public",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "public",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                schema: "public",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_CityId",
                schema: "public",
                table: "customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_CountryId",
                schema: "public",
                table: "customer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_DistrictId",
                schema: "public",
                table: "customer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_NeighborhoodId",
                schema: "public",
                table: "customer",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_CityId",
                schema: "public",
                table: "districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_CountryId",
                schema: "public",
                table: "districts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_CityId",
                schema: "public",
                table: "neighborhoods",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_CountryId",
                schema: "public",
                table: "neighborhoods",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_DistrictId",
                schema: "public",
                table: "neighborhoods",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_order_CustomerId",
                schema: "public",
                table: "order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_order_ProposalId",
                schema: "public",
                table: "order",
                column: "ProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_RepresentativeId",
                schema: "public",
                table: "order",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_order_TBL_ShippingAddressId",
                schema: "public",
                table: "order",
                column: "TBL_ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_CustomerId",
                schema: "public",
                table: "orderdetail",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_OrderId",
                schema: "public",
                table: "orderdetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_ProductCardId",
                schema: "public",
                table: "orderdetail",
                column: "ProductCardId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_ProposalId",
                schema: "public",
                table: "orderdetail",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_ShippingAddressId",
                schema: "public",
                table: "orderdetail",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_CustomerId",
                schema: "public",
                table: "productcard",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_MachineId",
                schema: "public",
                table: "productcard",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_ModelId",
                schema: "public",
                table: "productcard",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_PalletId",
                schema: "public",
                table: "productcard",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_RepresentativeId",
                schema: "public",
                table: "productcard",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_TBL_CategoryId",
                schema: "public",
                table: "productcard",
                column: "TBL_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productcard_VehicleTypeId",
                schema: "public",
                table: "productcard",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_CustomerId",
                schema: "public",
                table: "proposal",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_MeetingId",
                schema: "public",
                table: "proposal",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_PaymentTypeId",
                schema: "public",
                table: "proposal",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_SalesRepresentativeId",
                schema: "public",
                table: "proposal",
                column: "SalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_SalesTypeId",
                schema: "public",
                table: "proposal",
                column: "SalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_ShippingAddressId",
                schema: "public",
                table: "proposal",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_VehicleTypeId",
                schema: "public",
                table: "proposal",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_proposaldetail_ProductCardId",
                schema: "public",
                table: "proposaldetail",
                column: "ProductCardId");

            migrationBuilder.CreateIndex(
                name: "IX_proposaldetail_ProposalId",
                schema: "public",
                table: "proposaldetail",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_proposalmeeting_CustomerId",
                schema: "public",
                table: "proposalmeeting",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_proposalmeeting_CustomerRepresentativeId",
                schema: "public",
                table: "proposalmeeting",
                column: "CustomerRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingaddress_CityId",
                schema: "public",
                table: "shippingaddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingaddress_CountryId",
                schema: "public",
                table: "shippingaddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingaddress_CustomerId",
                schema: "public",
                table: "shippingaddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingaddress_DistrictId",
                schema: "public",
                table: "shippingaddress",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingaddress_NeighborhoodId",
                schema: "public",
                table: "shippingaddress",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_stockmovement_CustomerId",
                schema: "public",
                table: "stockmovement",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_stockmovement_MachineId",
                schema: "public",
                table: "stockmovement",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_stockmovement_ProductCardId",
                schema: "public",
                table: "stockmovement",
                column: "ProductCardId");

            migrationBuilder.CreateIndex(
                name: "IX_stockmovement_SalesRepresentativeId",
                schema: "public",
                table: "stockmovement",
                column: "SalesRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_stockmovement_WarehouseId",
                schema: "public",
                table: "stockmovement",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_CityId",
                schema: "public",
                table: "warehouse",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_CountryId",
                schema: "public",
                table: "warehouse",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_DistrictId",
                schema: "public",
                table: "warehouse",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_NeighborhoodId",
                schema: "public",
                table: "warehouse",
                column: "NeighborhoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orderdetail",
                schema: "public");

            migrationBuilder.DropTable(
                name: "proposaldetail",
                schema: "public");

            migrationBuilder.DropTable(
                name: "stockmovement",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unitofmeasure",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order",
                schema: "public");

            migrationBuilder.DropTable(
                name: "productcard",
                schema: "public");

            migrationBuilder.DropTable(
                name: "warehouse",
                schema: "public");

            migrationBuilder.DropTable(
                name: "proposal",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category",
                schema: "public");

            migrationBuilder.DropTable(
                name: "machines",
                schema: "public");

            migrationBuilder.DropTable(
                name: "modeltype",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pallet",
                schema: "public");

            migrationBuilder.DropTable(
                name: "paymenttype",
                schema: "public");

            migrationBuilder.DropTable(
                name: "proposalmeeting",
                schema: "public");

            migrationBuilder.DropTable(
                name: "salestype",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shippingaddress",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vehicletype",
                schema: "public");

            migrationBuilder.DropTable(
                name: "salesrepresentative",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "neighborhoods",
                schema: "public");

            migrationBuilder.DropTable(
                name: "districts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "public");
        }
    }
}
