﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore_Aula1.Migrations
{
    public partial class alteracaoTabelaLivroComAnoLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AnoLancamento",
                table: "Livros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoLancamento",
                table: "Livros");
        }
    }
}
