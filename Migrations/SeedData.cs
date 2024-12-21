using Microsoft.EntityFrameworkCore.Migrations;

namespace AmentumExploratory.Migrations
{
    public static class SeedData
    {
        public static void SeedContact(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData
            (
                table: "Contacts",
                columns: ["Id", "Name", "Email", "Reason", "Comments", "ContactDateTime"],
                values: new object[,]
                {
                    {
                        1,
                        "Iskra Indra",
                        "iskra_12@example.com",
                        1,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2023, 1, 8)
                    },
                    {
                        2,
                        "Rahima Jónas",
                        "ra_jo@example.com",
                        2,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2023, 4, 3)
                    },
                    {
                        3,
                        "Nazir Hanne",
                        "hanne_the_great@example.com",
                        3,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2024, 3, 19)
                    },
                    {
                        4,
                        "Dinesh Shahin",
                        "xxdineshxx@example.com",
                        0,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2024, 5, 12)
                    },
                    {
                        5,
                        "Minik Zaxaria",
                        "zaxariasworld@example.com",
                        0,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2022, 9, 22)
                    },
                    {
                        6,
                        "Hildiberht Kali",
                        "notarchbtw@example.com",
                        2,
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        new DateTime(2022, 1, 15)
                    },
                }
            );
        }
    }
}
