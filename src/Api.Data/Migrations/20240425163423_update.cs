using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(9098), new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(9106) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 34, 23, 340, DateTimeKind.Utc).AddTicks(1276), new DateTime(2024, 4, 25, 16, 34, 23, 340, DateTimeKind.Utc).AddTicks(1273) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 34, 23, 340, DateTimeKind.Utc).AddTicks(1296), new DateTime(2024, 4, 25, 16, 34, 23, 340, DateTimeKind.Utc).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8181), new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8191) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8202), new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8203) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8199), new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8195), new DateTime(2024, 4, 25, 13, 34, 23, 340, DateTimeKind.Local).AddTicks(8196) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(6693), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8610), new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8629), new DateTime(2024, 4, 25, 16, 34, 9, 622, DateTimeKind.Utc).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5679), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5695) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5707), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5704), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5699), new DateTime(2024, 4, 25, 13, 34, 9, 623, DateTimeKind.Local).AddTicks(5700) });
        }
    }
}
