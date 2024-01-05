using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week10_1.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddingCaching : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RegistrationFee",
                table: "Students",
                type: "numeric(19,12)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,8)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RegistrationFee",
                table: "Students",
                type: "numeric(10,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(19,12)",
                oldNullable: true);
        }
    }
}
