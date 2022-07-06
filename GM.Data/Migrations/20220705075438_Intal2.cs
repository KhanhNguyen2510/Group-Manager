using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    public partial class Intal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserPlayEvent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(9042),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserPlayEvent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(8695),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserPlayChallenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6857),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserPlayChallenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6564),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(3800),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(654),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(312),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PackageProductDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(7474),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PackageProductDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(6836),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PackageProduct",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(2386),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PackageProduct",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(1710),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "NCC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(7982),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NCC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(6515),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "NC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 634, DateTimeKind.Local).AddTicks(258),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 633, DateTimeKind.Local).AddTicks(9251),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "InvoiceDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(7525),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "InvoiceDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(5404),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(9007),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(8445),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.AddColumn<int>(
                name: "NcId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "HealthInformation",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(4289),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "HealthInformation",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(3993),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Event",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(2033),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Event",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(1716),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CheckIn",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9955),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "CheckIn",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9662),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.AddColumn<int>(
                name: "NcId",
                table: "CheckIn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Challenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(965),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Challenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(550),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(6904));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NcId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "NcId",
                table: "CheckIn");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserPlayEvent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(435),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserPlayEvent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 151, DateTimeKind.Local).AddTicks(229),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserPlayChallenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8727),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserPlayChallenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(8525),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(7084),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(6893),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5349),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(5130),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PackageProductDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3527),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PackageProductDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(3265),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "PackageProduct",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1866),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PackageProduct",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 150, DateTimeKind.Local).AddTicks(1666),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "NCC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7992),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NCC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(7788),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "NC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9861),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 634, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NC",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(9643),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 633, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "InvoiceDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6428),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "InvoiceDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(6135),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "HealthInformation",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2478),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "HealthInformation",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(2272),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(3993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Event",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(945),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Event",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 149, DateTimeKind.Local).AddTicks(738),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CheckIn",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9226),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "CheckIn",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(9015),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Challenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(7132),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Challenge",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 16, 32, 26, 148, DateTimeKind.Local).AddTicks(6904),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(550));
        }
    }
}
