using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    public partial class Intal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1666)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1866))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(6893)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(7084))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(6904)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(7132))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenge_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(738)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(945))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9643)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9861))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NC_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5130)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5349))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NCC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    NcId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7788)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7992))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCC_NC_NcId",
                        column: x => x.NcId,
                        principalTable: "NC",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageProductDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3265)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3527))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageProductDetail_PackageProduct_PackageProductId",
                        column: x => x.PackageProductId,
                        principalTable: "PackageProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProductDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NccId = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Slush = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2272)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2478))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInformation_NCC_NccId",
                        column: x => x.NccId,
                        principalTable: "NCC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthInformation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NccId = table.Column<int>(type: "int", nullable: false),
                    PackageProductId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Remain = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4274)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4529))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_NCC_NccId",
                        column: x => x.NccId,
                        principalTable: "NCC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_PackageProduct_PackageProductId",
                        column: x => x.PackageProductId,
                        principalTable: "PackageProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPlayChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengerId = table.Column<int>(type: "int", nullable: false),
                    NccId = table.Column<int>(type: "int", nullable: false),
                    Complete = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChallengeId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8525)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8727))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlayChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlayChallenge_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPlayChallenge_NCC_NccId",
                        column: x => x.NccId,
                        principalTable: "NCC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlayEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NccId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complete = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(229)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(435))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlayEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlayEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlayEvent_NCC_NccId",
                        column: x => x.NccId,
                        principalTable: "NCC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckIn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remain = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9015)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9226))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckIn_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckIn_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeDelete = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6135)),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6428))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_UserId",
                table: "Challenge",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_InvoiceId",
                table: "CheckIn",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_UserId",
                table: "CheckIn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_NccId",
                table: "HealthInformation",
                column: "NccId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_UserId",
                table: "HealthInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_NccId",
                table: "Invoice",
                column: "NccId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PackageProductId",
                table: "Invoice",
                column: "PackageProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_NC_UserId",
                table: "NC",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NCC_NcId",
                table: "NCC",
                column: "NcId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProductDetail_PackageProductId",
                table: "PackageProductDetail",
                column: "PackageProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProductDetail_ProductId",
                table: "PackageProductDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayChallenge_ChallengeId",
                table: "UserPlayChallenge",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayChallenge_NccId",
                table: "UserPlayChallenge",
                column: "NccId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayEvent_EventId",
                table: "UserPlayEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayEvent_NccId",
                table: "UserPlayEvent",
                column: "NccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIn");

            migrationBuilder.DropTable(
                name: "HealthInformation");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "PackageProductDetail");

            migrationBuilder.DropTable(
                name: "UserPlayChallenge");

            migrationBuilder.DropTable(
                name: "UserPlayEvent");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "NCC");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "NC");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
