using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class DodajProcedureStudentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[DodajStudenta]
                @Imie NVARCHAR(50),
                @Nazwisko NVARCHAR(100),
                @IDGrupy INT = NULL,
                @ID INT OUTPUT
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO Studenci (Imie, Nazwisko, IDGrupy)
                VALUES (@Imie, @Nazwisko, @IDGrupy);

                SET @ID = SCOPE_IDENTITY();
            END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[DodajStudenta]");
        }
    }
}