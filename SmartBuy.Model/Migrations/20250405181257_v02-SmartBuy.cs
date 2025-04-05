﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBuy.Model.Migrations
{
    /// <inheritdoc />
    public partial class v02SmartBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaIdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriaIdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVendedor",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdVendedor",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaIdCategoria",
                table: "Produtos",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaIdCategoria",
                table: "Produtos",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria");
        }
    }
}
