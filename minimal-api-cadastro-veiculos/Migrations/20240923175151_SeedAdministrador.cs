﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_cadastro_veiculos.Migrations
{
    public partial class SeedAdministrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "id", "Email", "Perfil", "Senha" },
                values: new object[] { 1, "administrador@teste.com", "Adm", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administradores",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
