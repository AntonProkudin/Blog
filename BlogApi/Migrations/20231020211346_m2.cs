using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUsers",
                table: "TblUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblRecord",
                table: "TblRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblComment",
                table: "TblComment");

            migrationBuilder.RenameTable(
                name: "TblUsers",
                newName: "UsersTbl");

            migrationBuilder.RenameTable(
                name: "TblRecord",
                newName: "RecordTbl");

            migrationBuilder.RenameTable(
                name: "TblComment",
                newName: "CommentTbl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersTbl",
                table: "UsersTbl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordTbl",
                table: "RecordTbl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentTbl",
                table: "CommentTbl",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersTbl",
                table: "UsersTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordTbl",
                table: "RecordTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentTbl",
                table: "CommentTbl");

            migrationBuilder.RenameTable(
                name: "UsersTbl",
                newName: "TblUsers");

            migrationBuilder.RenameTable(
                name: "RecordTbl",
                newName: "TblRecord");

            migrationBuilder.RenameTable(
                name: "CommentTbl",
                newName: "TblComment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUsers",
                table: "TblUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblRecord",
                table: "TblRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblComment",
                table: "TblComment",
                column: "Id");
        }
    }
}
