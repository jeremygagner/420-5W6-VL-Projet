using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _420_5W6_VL_Projet.Migrations
{
    public partial class populated_links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "Lid", "Date", "Description", "Uid", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3133), "The Lord of the Rings, The Fellowship of the Ring", 1, "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg" },
                    { 2, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3167), "The Lord of the Rings, The Two Towers", 1, "https://upload.wikimedia.org/wikipedia/en/d/d0/Lord_of_the_Rings_-_The_Two_Towers_%282002%29.jpg" },
                    { 3, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3169), "The Lord of the Rings, The Return of the King", 1, "https://upload.wikimedia.org/wikipedia/en/b/be/The_Lord_of_the_Rings_-_The_Return_of_the_King_%282003%29.jpg" },
                    { 4, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3171), "The Hobbit, An Unexpected Journey", 1, "https://upload.wikimedia.org/wikipedia/en/b/b3/The_Hobbit-_An_Unexpected_Journey.jpeg" },
                    { 5, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3173), "The Hobbit, The Desolation of Smaug", 1, "https://upload.wikimedia.org/wikipedia/en/4/4f/The_Hobbit_-_The_Desolation_of_Smaug_theatrical_poster.jpg" },
                    { 6, new DateTime(2022, 11, 1, 16, 1, 50, 749, DateTimeKind.Local).AddTicks(3175), "The Hobbit, The Battle of the Five Armies", 1, "https://upload.wikimedia.org/wikipedia/en/e/e7/The_Hobbit_-_The_Battle_of_the_Five_Armies.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "Lid",
                keyValue: 6);
        }
    }
}
