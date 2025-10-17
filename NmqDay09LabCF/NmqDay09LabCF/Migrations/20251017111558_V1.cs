using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NmqDay09LabCF.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NmqLoai_San_Pham",
                columns: table => new
                {
                    nmqId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmqMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nmqTenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nmqTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NmqLoai_San_Pham", x => x.nmqId);
                });

            migrationBuilder.CreateTable(
                name: "NmqSan_Pham",
                columns: table => new
                {
                    nmqId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmqMaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nmqTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nmqHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nmqSoLuong = table.Column<int>(type: "int", nullable: false),
                    nmqDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nmqMaLoai = table.Column<long>(type: "bigint", nullable: false),
                    nmqTrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NmqLoai_San_PhamnmqId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NmqSan_Pham", x => x.nmqId);
                    table.ForeignKey(
                        name: "FK_NmqSan_Pham_NmqLoai_San_Pham_NmqLoai_San_PhamnmqId",
                        column: x => x.NmqLoai_San_PhamnmqId,
                        principalTable: "NmqLoai_San_Pham",
                        principalColumn: "nmqId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NmqSan_Pham_NmqLoai_San_PhamnmqId",
                table: "NmqSan_Pham",
                column: "NmqLoai_San_PhamnmqId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NmqSan_Pham");

            migrationBuilder.DropTable(
                name: "NmqLoai_San_Pham");
        }
    }
}
