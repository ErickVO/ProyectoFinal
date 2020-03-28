﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudioEA.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticulosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuariosId = table.Column<int>(nullable: false),
                    NombreArticulos = table.Column<string>(nullable: true),
                    Categorias = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticulosId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    NombreCategorias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriasId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    ComprasId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.ComprasId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Lugar = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosId);
                });

            migrationBuilder.CreateTable(
                name: "Fotografos",
                columns: table => new
                {
                    FotografoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sueldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografos", x => x.FotografoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreUsuario = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalle",
                columns: table => new
                {
                    ComprasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComprasId = table.Column<int>(nullable: false),
                    ArticulosId = table.Column<int>(nullable: false),
                    CantidadArticulos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalle", x => x.ComprasDetalleId);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_Articulos_ArticulosId",
                        column: x => x.ArticulosId,
                        principalTable: "Articulos",
                        principalColumn: "ArticulosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "ComprasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FotografoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MontoTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Fotografos_FotografoId",
                        column: x => x.FotografoId,
                        principalTable: "Fotografos",
                        principalColumn: "FotografoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    CantidadArticulo = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    ArticulosId = table.Column<int>(nullable: true),
                    EventosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.VentasDetalleId);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Articulos_ArticulosId",
                        column: x => x.ArticulosId,
                        principalTable: "Articulos",
                        principalColumn: "ArticulosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "EventosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_ArticulosId",
                table: "ComprasDetalle",
                column: "ArticulosId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_ComprasId",
                table: "ComprasDetalle",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FotografoId",
                table: "Ventas",
                column: "FotografoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_ArticulosId",
                table: "VentasDetalle",
                column: "ArticulosId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_EventosId",
                table: "VentasDetalle",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fotografos");
        }
    }
}
