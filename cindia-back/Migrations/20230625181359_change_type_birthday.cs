using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cindia_back.Migrations
{
    /// <inheritdoc />
    public partial class change_type_birthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Users\" ALTER COLUMN \"Birthday\" TYPE timestamp with time zone USING to_timestamp(\"Birthday\", 'YYYY-MM-DD\"T\"HH24:MI:SSZ')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
