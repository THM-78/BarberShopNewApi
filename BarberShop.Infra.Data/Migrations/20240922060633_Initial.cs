using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblBarbershopInfos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    InstaPage = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblBarbe__3213E83F6E0234E6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblBeforeAfters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeforeImgUrl = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AfterImgUrl = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblBefor__3213E83FAD125F25", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblDiscountCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDiscountCode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblHairStylistLevels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StylistLevel = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblHairS__3213E83FA3C6BC8C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblPrice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblPrice__3213E83FA4E7D200", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblServices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PeriodOfTime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblServi__3213E83F26D0962F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblSuggestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblSugge__3213E83F16289D30", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblUsers__3213E83F10259958", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblWorkPhotos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblWorkP__3213E83F9C53EF76", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblHairStylists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HairStylistLevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblHairS__3213E83FD7CF83D6", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblHairStylists_TblHairStylistLevels1",
                        column: x => x.HairStylistLevelId,
                        principalTable: "TblHairStylistLevels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TblServicePriceRels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairStylistId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblServi__3213E83F72C9987B", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblServicePriceRels_TblHairStylists",
                        column: x => x.HairStylistId,
                        principalTable: "TblHairStylists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblServicePriceRels_TblServices",
                        column: x => x.ServiceId,
                        principalTable: "TblServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblReservation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    ServicePriceRelId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblReservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_TblReservation_TblServicePriceRels",
                        column: x => x.ServicePriceRelId,
                        principalTable: "TblServicePriceRels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TblReservation_TblUsers",
                        column: x => x.UserId,
                        principalTable: "TblUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblHairStylists_HairStylistLevelId",
                table: "TblHairStylists",
                column: "HairStylistLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblReservation_ServicePriceRelId",
                table: "TblReservation",
                column: "ServicePriceRelId");

            migrationBuilder.CreateIndex(
                name: "IX_TblReservation_UserId",
                table: "TblReservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePriceRels_HairStylistId",
                table: "TblServicePriceRels",
                column: "HairStylistId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePriceRels_ServiceId",
                table: "TblServicePriceRels",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "UQ__TblWorkP__372CE60D1D9E51F6",
                table: "TblWorkPhotos",
                column: "ImageUrl",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBarbershopInfos");

            migrationBuilder.DropTable(
                name: "TblBeforeAfters");

            migrationBuilder.DropTable(
                name: "TblDiscountCode");

            migrationBuilder.DropTable(
                name: "TblPrice");

            migrationBuilder.DropTable(
                name: "TblReservation");

            migrationBuilder.DropTable(
                name: "TblSuggestions");

            migrationBuilder.DropTable(
                name: "TblWorkPhotos");

            migrationBuilder.DropTable(
                name: "TblServicePriceRels");

            migrationBuilder.DropTable(
                name: "TblUsers");

            migrationBuilder.DropTable(
                name: "TblHairStylists");

            migrationBuilder.DropTable(
                name: "TblServices");

            migrationBuilder.DropTable(
                name: "TblHairStylistLevels");
        }
    }
}
