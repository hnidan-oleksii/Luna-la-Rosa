using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TruncateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET session_replication_role = 'replica';");

            migrationBuilder.Sql("TRUNCATE TABLE \"order_add_ons\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"order_bouquets\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"payments\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"orders\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"cart_item_add_ons\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"cart_items\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"shopping_carts\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"bouquet_add_ons\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"custom_bouquet_flowers\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"custom_bouquets\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"bouquet_flowers\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"bouquet_category_bouquets\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"bouquet_categories\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"bouquets\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"add_ons\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"add_on_types\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"flowers\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"flower_types\" CASCADE;");
            migrationBuilder.Sql("TRUNCATE TABLE \"users\" CASCADE;");

            migrationBuilder.Sql("SET session_replication_role = 'origin';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "add_on_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Balloon" },
                    { 2, "PostCard" },
                    { 3, "Sweets" },
                    { 4, "Wrapping" },
                    { 5, "Ribbon" }
                });

            migrationBuilder.InsertData(
                table: "bouquet_categories",
                columns: new[] { "id", "category_name" },
                values: new object[] { 1, "Wedding" });

            migrationBuilder.InsertData(
                table: "bouquets",
                columns: new[] { "id", "created_at", "description", "image", "is_deleted", "main_color", "name", "popularity_score", "price", "size", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 23, 18, 37, 41, 117, DateTimeKind.Utc).AddTicks(4323), "Nemo quasi dolorem.", new byte[] { 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148, 75 }, false, "ivory", "Gorgeous Wooden Shoes", 26, 12.825448612135575m, "Medium", new DateTime(2024, 11, 21, 0, 12, 41, 990, DateTimeKind.Utc).AddTicks(8169) },
                    { 2, new DateTime(2024, 2, 18, 11, 32, 27, 406, DateTimeKind.Utc).AddTicks(9419), "Nobis quasi iusto.", new byte[] { 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217, 247 }, false, "silver", "Licensed Cotton Keyboard", 85, 160.916991813535453m, "Small", new DateTime(2024, 11, 26, 13, 18, 6, 222, DateTimeKind.Utc).AddTicks(8557) },
                    { 3, new DateTime(2024, 10, 15, 2, 27, 13, 696, DateTimeKind.Utc).AddTicks(4168), "Veritatis architecto cumque.", new byte[] { 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31, 164 }, false, "teal", "Gorgeous Metal Pizza", 43, 489.222411759766755m, "Medium", new DateTime(2024, 11, 18, 2, 23, 30, 454, DateTimeKind.Utc).AddTicks(8724) },
                    { 4, new DateTime(2024, 6, 10, 18, 21, 59, 985, DateTimeKind.Utc).AddTicks(8912), "Odio architecto ut.", new byte[] { 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100, 80 }, false, "maroon", "Licensed Frozen Towels", 1, 251.889648560383228m, "Small", new DateTime(2024, 11, 23, 15, 28, 54, 686, DateTimeKind.Utc).AddTicks(8885) },
                    { 5, new DateTime(2024, 2, 5, 11, 16, 46, 275, DateTimeKind.Utc).AddTicks(3657), "Illum architecto labore.", new byte[] { 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170, 252 }, false, "orchid", "Incredible Plastic Ball", 60, 0m, "Medium", new DateTime(2024, 11, 29, 4, 34, 18, 918, DateTimeKind.Utc).AddTicks(9048) },
                    { 6, new DateTime(2024, 10, 2, 2, 11, 32, 564, DateTimeKind.Utc).AddTicks(8395), "Consectetur beatae quas.", new byte[] { 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239, 169 }, false, "fuchsia", "Refined Rubber Chips", 18, 183.134031854166448m, "Large", new DateTime(2024, 11, 20, 17, 39, 43, 150, DateTimeKind.Utc).AddTicks(9205) },
                    { 7, new DateTime(2024, 5, 28, 18, 6, 18, 854, DateTimeKind.Utc).AddTicks(3132), "Similique beatae est.", new byte[] { 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53, 85 }, false, "green", "Fantastic Fresh Tuna", 77, 7.7736311619047194m, "Medium", new DateTime(2024, 11, 26, 6, 45, 7, 382, DateTimeKind.Utc).AddTicks(9360) },
                    { 8, new DateTime(2024, 1, 23, 11, 1, 5, 143, DateTimeKind.Utc).AddTicks(7866), "Rerum vitae eaque.", new byte[] { 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122, 1 }, false, "black", "Unbranded Wooden Pants", 35, 426.036659462394543m, "Large", new DateTime(2024, 11, 17, 19, 50, 31, 614, DateTimeKind.Utc).AddTicks(9512) },
                    { 9, new DateTime(2024, 9, 19, 1, 55, 51, 433, DateTimeKind.Utc).AddTicks(2597), "Quia vitae nemo.", new byte[] { 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191, 174 }, false, "turquoise", "Practical Granite Car", 94, 291.799185727163508m, "Small", new DateTime(2024, 11, 23, 8, 55, 55, 846, DateTimeKind.Utc).AddTicks(9663) },
                    { 10, new DateTime(2024, 5, 15, 17, 50, 37, 722, DateTimeKind.Utc).AddTicks(7334), "Cumque dicta in.", new byte[] { 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5, 90 }, false, "magenta", "Tasty Soft Cheese", 52, 281.388732479600820m, "Large", new DateTime(2024, 11, 28, 22, 1, 20, 78, DateTimeKind.Utc).AddTicks(9818) },
                    { 11, new DateTime(2024, 1, 10, 10, 45, 24, 12, DateTimeKind.Utc).AddTicks(2065), "Beatae dicta voluptas.", new byte[] { 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74, 6 }, false, "azure", "Sleek Steel Table", 10, 107.1945399978172951m, "Small", new DateTime(2024, 11, 20, 11, 6, 44, 310, DateTimeKind.Utc).AddTicks(9968) },
                    { 12, new DateTime(2024, 9, 6, 1, 40, 10, 301, DateTimeKind.Utc).AddTicks(6925), "Blanditiis sunt aut.", new byte[] { 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144, 179 }, false, "yellow", "Tasty Plastic Keyboard", 69, 253.8870095950024694m, "Medium", new DateTime(2024, 11, 26, 0, 12, 8, 543, DateTimeKind.Utc).AddTicks(253) },
                    { 13, new DateTime(2024, 5, 2, 17, 34, 56, 591, DateTimeKind.Utc).AddTicks(1709), "Fugiat sunt autem.", new byte[] { 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213, 95 }, false, "pink", "Sleek Rubber Pizza", 27, 28.138873247960082m, "Small", new DateTime(2024, 11, 17, 13, 17, 32, 775, DateTimeKind.Utc).AddTicks(454) },
                    { 14, new DateTime(2023, 12, 28, 10, 29, 42, 880, DateTimeKind.Utc).AddTicks(6489), "Non explicabo facilis.", new byte[] { 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27, 11 }, false, "sky blue", "Small Frozen Towels", 86, 15.896536649622264m, "Medium", new DateTime(2024, 11, 23, 2, 22, 57, 7, DateTimeKind.Utc).AddTicks(652) },
                    { 15, new DateTime(2024, 8, 24, 1, 24, 29, 170, DateTimeKind.Utc).AddTicks(1225), "Officia explicabo repudiandae.", new byte[] { 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96, 184 }, false, "ivory", "Awesome Concrete Ball", 44, 45.669674235707860m, "Large", new DateTime(2024, 11, 28, 15, 28, 21, 239, DateTimeKind.Utc).AddTicks(803) },
                    { 16, new DateTime(2024, 4, 19, 17, 19, 15, 459, DateTimeKind.Utc).AddTicks(5956), "Delectus aspernatur dolor.", new byte[] { 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165, 100 }, false, "silver", "Ergonomic Granite Sausages", 2, 63.9347409205207827m, "Medium", new DateTime(2024, 11, 20, 4, 33, 45, 471, DateTimeKind.Utc).AddTicks(952) },
                    { 17, new DateTime(2023, 12, 15, 10, 14, 1, 749, DateTimeKind.Utc).AddTicks(685), "Nisi aspernatur ducimus.", new byte[] { 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235, 16 }, false, "mint green", "Generic Soft Tuna", 61, 100.15797754244778m, "Large", new DateTime(2024, 11, 25, 17, 39, 9, 703, DateTimeKind.Utc).AddTicks(1100) },
                    { 18, new DateTime(2024, 8, 11, 1, 8, 48, 38, DateTimeKind.Utc).AddTicks(5422), "Quisquam aut porro.", new byte[] { 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48, 189 }, false, "maroon", "Rustic Wooden Pants", 19, 0m, "Small", new DateTime(2024, 12, 1, 6, 44, 33, 935, DateTimeKind.Utc).AddTicks(1257) },
                    { 19, new DateTime(2024, 4, 6, 17, 3, 34, 328, DateTimeKind.Utc).AddTicks(153), "Aspernatur aut voluptatibus.", new byte[] { 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118, 105 }, false, "orchid", "Handcrafted Cotton Car", 78, 151.323291827143697m, "Large", new DateTime(2024, 11, 22, 19, 49, 58, 167, DateTimeKind.Utc).AddTicks(1405) },
                    { 20, new DateTime(2023, 12, 2, 9, 58, 20, 617, DateTimeKind.Utc).AddTicks(4884), "Voluptatum odit magnam.", new byte[] { 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187, 21 }, false, "gold", "Rustic Metal Fish", 36, 8.638050181156997m, "Small", new DateTime(2024, 11, 28, 8, 55, 22, 399, DateTimeKind.Utc).AddTicks(1555) },
                    { 21, new DateTime(2024, 7, 29, 0, 53, 6, 906, DateTimeKind.Utc).AddTicks(9612), "At odit sint.", new byte[] { 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1, 194 }, false, "green", "Handcrafted Frozen Table", 95, 265.745365301959770m, "Large", new DateTime(2024, 11, 19, 22, 0, 46, 631, DateTimeKind.Utc).AddTicks(1702) },
                    { 22, new DateTime(2024, 3, 24, 17, 47, 53, 196, DateTimeKind.Utc).AddTicks(4347), "Incidunt aut repellendus.", new byte[] { 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70, 110 }, false, "white", "Intelligent Concrete Keyboard", 53, 0m, "Small", new DateTime(2024, 11, 25, 11, 6, 10, 863, DateTimeKind.Utc).AddTicks(1856) },
                    { 23, new DateTime(2024, 11, 19, 9, 42, 39, 485, DateTimeKind.Utc).AddTicks(9079), "Est aut illo.", new byte[] { 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140, 26 }, false, "turquoise", "Handmade Rubber Pizza", 11, 296.010970633482165m, "Medium", new DateTime(2024, 12, 1, 0, 11, 35, 95, DateTimeKind.Utc).AddTicks(2005) },
                    { 24, new DateTime(2024, 7, 16, 0, 37, 25, 775, DateTimeKind.Utc).AddTicks(3807), "Maiores fugit voluptatem.", new byte[] { 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209, 199 }, false, "magenta", "Gorgeous Fresh Towels", 70, 127.432431771155702m, "Small", new DateTime(2024, 11, 22, 13, 16, 59, 327, DateTimeKind.Utc).AddTicks(2153) },
                    { 25, new DateTime(2024, 3, 11, 17, 32, 12, 64, DateTimeKind.Utc).AddTicks(8535), "Commodi fugit officia.", new byte[] { 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22, 115 }, false, "cyan", "Licensed Wooden Bike", 28, 519.620786034325221m, "Medium", new DateTime(2024, 11, 28, 2, 22, 23, 559, DateTimeKind.Utc).AddTicks(2299) },
                    { 26, new DateTime(2024, 11, 6, 9, 26, 58, 354, DateTimeKind.Utc).AddTicks(3269), "Quod sed at.", new byte[] { 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92, 31 }, false, "yellow", "Incredible Cotton Sausages", 87, 252.383289298221026m, "Large", new DateTime(2024, 11, 19, 15, 27, 47, 791, DateTimeKind.Utc).AddTicks(2453) },
                    { 27, new DateTime(2024, 7, 3, 0, 21, 44, 643, DateTimeKind.Utc).AddTicks(7999), "Fugit sed quia.", new byte[] { 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161, 204 }, false, "orange", "Refined Soft Tuna", 45, 43.616438151624273m, "Medium", new DateTime(2024, 11, 25, 4, 33, 12, 23, DateTimeKind.Utc).AddTicks(2602) },
                    { 28, new DateTime(2024, 2, 27, 17, 16, 30, 933, DateTimeKind.Utc).AddTicks(2728), "Quos quia reprehenderit.", new byte[] { 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231, 120 }, false, "sky blue", "Fantastic Steel Pants", 3, 108.774249401304143m, "Large", new DateTime(2024, 11, 30, 17, 38, 36, 255, DateTimeKind.Utc).AddTicks(2749) },
                    { 29, new DateTime(2024, 10, 24, 8, 11, 17, 222, DateTimeKind.Utc).AddTicks(7456), "Accusamus quia expedita.", new byte[] { 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44, 36 }, false, "ivory", "Refined Plastic Chair", 62, 339.140616388591128m, "Small", new DateTime(2024, 11, 22, 6, 44, 0, 487, DateTimeKind.Utc).AddTicks(2896) },
                    { 30, new DateTime(2024, 6, 20, 0, 6, 3, 512, DateTimeKind.Utc).AddTicks(2183), "Dolore consequuntur molestiae.", new byte[] { 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114, 209 }, false, "lavender", "Fantastic Rubber Fish", 20, 46.77527729551086m, "Large", new DateTime(2024, 11, 27, 19, 49, 24, 719, DateTimeKind.Utc).AddTicks(3042) }
                });

            migrationBuilder.InsertData(
                table: "flower_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Rose" },
                    { 2, "Tulip" },
                    { 3, "Orchid" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "first_name", "last_name", "password_hash", "phone_number", "role", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 29, 8, 27, 22, 171, DateTimeKind.Utc).AddTicks(4497), "Bernita_Konopelski43@gmail.com", "Pedro", "Hackett", "Ay7ZbbzDk0", "976-609-8805 x52963", "User", new DateTime(2024, 11, 22, 1, 37, 5, 134, DateTimeKind.Utc).AddTicks(2644) },
                    { 2, new DateTime(2024, 8, 27, 3, 49, 13, 587, DateTimeKind.Utc).AddTicks(2808), "Guillermo.Cummerata30@hotmail.com", "Sonya", "Schulist", "lJ5hPDb6ee", "(969) 291-0386 x7600", "User", new DateTime(2024, 11, 24, 13, 17, 32, 741, DateTimeKind.Utc).AddTicks(8042) },
                    { 3, new DateTime(2024, 5, 31, 5, 5, 23, 650, DateTimeKind.Utc).AddTicks(7952), "Max56@gmail.com", "Nils", "Kreiger", "17yADOlbuq", "609-545-5342", "User", new DateTime(2024, 11, 30, 15, 47, 47, 173, DateTimeKind.Utc).AddTicks(62) },
                    { 4, new DateTime(2024, 11, 17, 3, 1, 25, 16, DateTimeKind.Utc).AddTicks(1001), "Yoshiko.Maggio@hotmail.com", "Karina", "Krajcik", "bJLg6XDTjR", "886.440.0316 x3659", "User", new DateTime(2024, 11, 18, 10, 36, 58, 590, DateTimeKind.Utc).AddTicks(8484) },
                    { 5, new DateTime(2024, 9, 19, 12, 40, 35, 509, DateTimeKind.Utc).AddTicks(5893), "Edd.Gislason@yahoo.com", "Clare", "Roberts", "xzXCMm7Moj", "810-973-1391", "Admin", new DateTime(2024, 11, 20, 9, 36, 15, 219, DateTimeKind.Utc).AddTicks(1157) },
                    { 6, new DateTime(2024, 11, 23, 3, 15, 33, 652, DateTimeKind.Utc).AddTicks(2091), "Kobe_Windler80@hotmail.com", "Micheal", "Spencer", "XJdNcgX1iD", "601-423-0429 x4071", "Admin", new DateTime(2024, 12, 1, 13, 3, 13, 145, DateTimeKind.Utc).AddTicks(7087) },
                    { 7, new DateTime(2024, 2, 2, 4, 41, 33, 822, DateTimeKind.Utc).AddTicks(9525), "Sasha36@yahoo.com", "Albina", "Rogahn", "zpqJxJsFlr", "330.590.4772 x110", "User", new DateTime(2024, 11, 29, 10, 18, 56, 163, DateTimeKind.Utc).AddTicks(9822) },
                    { 8, new DateTime(2024, 3, 15, 12, 50, 46, 412, DateTimeKind.Utc).AddTicks(3558), "Casimir81@hotmail.com", "Hans", "Thompson", "TNK51cW5zt", "446-886-7515 x51416", "Admin", new DateTime(2024, 11, 24, 13, 15, 31, 407, DateTimeKind.Utc).AddTicks(5617) },
                    { 9, new DateTime(2024, 5, 27, 4, 54, 15, 100, DateTimeKind.Utc).AddTicks(9229), "Jada.Beer@yahoo.com", "Adolphus", "Bednar", "HyzXwNmVwk", "1-336-620-3589 x271", "User", new DateTime(2024, 11, 19, 4, 3, 24, 849, DateTimeKind.Utc).AddTicks(9674) },
                    { 10, new DateTime(2024, 6, 3, 15, 4, 11, 609, DateTimeKind.Utc).AddTicks(7198), "Neva_Rosenbaum29@hotmail.com", "Shawn", "Hagenes", "DK4P_2z1QR", "1-932-211-3106", "User", new DateTime(2024, 11, 19, 18, 50, 8, 271, DateTimeKind.Utc).AddTicks(1092) },
                    { 11, new DateTime(2024, 2, 22, 23, 39, 55, 87, DateTimeKind.Utc).AddTicks(5090), "Alvera.Koch17@yahoo.com", "Sebastian", "Sanford", "oE22uNmVSp", "559-623-7242 x1822", "Admin", new DateTime(2024, 11, 25, 18, 35, 39, 624, DateTimeKind.Utc).AddTicks(4600) },
                    { 12, new DateTime(2024, 8, 19, 22, 10, 21, 70, DateTimeKind.Utc).AddTicks(3931), "Eula62@hotmail.com", "Abby", "Willms", "KKboscDQvI", "828-222-1876 x612", "Admin", new DateTime(2024, 11, 17, 23, 6, 5, 221, DateTimeKind.Utc).AddTicks(3694) },
                    { 13, new DateTime(2024, 5, 11, 16, 43, 4, 196, DateTimeKind.Utc).AddTicks(247), "Lonnie7@yahoo.com", "Kieran", "Wiza", "weWrZV6AS1", "(215) 798-5313 x72534", "User", new DateTime(2024, 11, 21, 3, 2, 17, 813, DateTimeKind.Utc).AddTicks(8839) },
                    { 14, new DateTime(2024, 7, 30, 5, 45, 53, 219, DateTimeKind.Utc).AddTicks(4751), "Tiana_Lueilwitz@gmail.com", "Omari", "Rogahn", "k0LcIYE8gj", "(262) 739-0593 x4331", "Admin", new DateTime(2024, 11, 24, 2, 44, 8, 660, DateTimeKind.Utc).AddTicks(8064) },
                    { 15, new DateTime(2024, 4, 24, 15, 11, 25, 776, DateTimeKind.Utc).AddTicks(3529), "Dagmar_Funk66@yahoo.com", "Dora", "Dach", "ol0y9MElRR", "861.974.3384", "User", new DateTime(2024, 11, 18, 18, 48, 46, 995, DateTimeKind.Utc).AddTicks(6373) },
                    { 16, new DateTime(2024, 8, 19, 13, 42, 35, 928, DateTimeKind.Utc).AddTicks(7544), "Johnson.Wilderman54@gmail.com", "Maurice", "Mueller", "Lz0k1WvPyi", "(869) 790-6732", "User", new DateTime(2024, 11, 27, 13, 27, 47, 432, DateTimeKind.Utc).AddTicks(3991) },
                    { 17, new DateTime(2024, 4, 22, 5, 2, 2, 542, DateTimeKind.Utc).AddTicks(5466), "Quinten88@yahoo.com", "Jaiden", "Lubowitz", "GQSmfsRurB", "349-814-5419", "User", new DateTime(2024, 11, 23, 18, 24, 56, 443, DateTimeKind.Utc).AddTicks(1830) },
                    { 18, new DateTime(2024, 5, 16, 18, 5, 8, 488, DateTimeKind.Utc).AddTicks(5762), "Aylin.Heller@gmail.com", "Diego", "Barton", "L3vTQoW9H3", "1-548-255-8154", "Admin", new DateTime(2024, 11, 18, 9, 8, 57, 297, DateTimeKind.Utc).AddTicks(292) },
                    { 19, new DateTime(2023, 12, 3, 12, 25, 42, 909, DateTimeKind.Utc).AddTicks(8230), "Giuseppe_Beatty@yahoo.com", "Marcia", "MacGyver", "GaAupi2_P3", "1-473-524-9425 x7357", "User", new DateTime(2024, 11, 17, 16, 39, 50, 451, DateTimeKind.Utc).AddTicks(2675) },
                    { 20, new DateTime(2024, 4, 15, 0, 43, 24, 294, DateTimeKind.Utc).AddTicks(6374), "Marley.Rogahn3@gmail.com", "Nico", "Hilpert", "rMJDsQ9E4M", "710-501-5734", "Admin", new DateTime(2024, 11, 23, 4, 29, 54, 655, DateTimeKind.Utc).AddTicks(5825) },
                    { 21, new DateTime(2024, 3, 23, 2, 28, 36, 451, DateTimeKind.Utc).AddTicks(7810), "Wilfredo68@hotmail.com", "Frida", "Rosenbaum", "vVhqEa7JYS", "939-799-7596", "User", new DateTime(2024, 11, 18, 9, 34, 9, 141, DateTimeKind.Utc).AddTicks(3055) },
                    { 22, new DateTime(2024, 8, 10, 9, 39, 21, 96, DateTimeKind.Utc).AddTicks(1246), "Donny13@gmail.com", "Bernie", "Nicolas", "jhMbDOgvDi", "(827) 778-6836", "Admin", new DateTime(2024, 11, 28, 1, 47, 49, 819, DateTimeKind.Utc).AddTicks(2415) },
                    { 23, new DateTime(2024, 11, 11, 5, 54, 20, 10, DateTimeKind.Utc).AddTicks(2552), "Kennedy_Sporer@hotmail.com", "Elinore", "Ernser", "4ng6HJIER8", "(509) 937-9866 x55567", "User", new DateTime(2024, 11, 27, 14, 29, 16, 523, DateTimeKind.Utc).AddTicks(1931) },
                    { 24, new DateTime(2024, 7, 14, 1, 24, 20, 298, DateTimeKind.Utc).AddTicks(7647), "Rylee.Little53@gmail.com", "America", "Windler", "My3zjzsYeG", "640.379.5089 x745", "Admin", new DateTime(2024, 11, 19, 15, 27, 27, 218, DateTimeKind.Utc).AddTicks(177) },
                    { 25, new DateTime(2024, 4, 3, 9, 0, 3, 776, DateTimeKind.Utc).AddTicks(5551), "Candelario.Flatley40@hotmail.com", "Camila", "Moen", "NcmMMCOA4h", "324-503-6387 x461", "Admin", new DateTime(2024, 11, 25, 15, 12, 58, 571, DateTimeKind.Utc).AddTicks(3698) },
                    { 26, new DateTime(2024, 8, 13, 0, 17, 19, 242, DateTimeKind.Utc).AddTicks(5160), "Isabell94@gmail.com", "Bette", "Homenick", "TN2qJhP19k", "431.322.2770", "Admin", new DateTime(2024, 11, 21, 0, 24, 49, 23, DateTimeKind.Utc).AddTicks(4326) },
                    { 27, new DateTime(2024, 7, 9, 15, 17, 11, 835, DateTimeKind.Utc).AddTicks(8391), "Myrtle39@hotmail.com", "Odessa", "Jakubowski", "51S2Qst4eF", "(638) 514-0815 x160", "Admin", new DateTime(2024, 11, 20, 14, 38, 36, 760, DateTimeKind.Utc).AddTicks(4576) },
                    { 28, new DateTime(2024, 6, 15, 1, 28, 38, 906, DateTimeKind.Utc).AddTicks(4447), "Alexanne_Hayes@yahoo.com", "Carlie", "Lind", "JNIXwsWQAI", "1-745-800-2658 x5649", "User", new DateTime(2024, 11, 29, 14, 47, 4, 977, DateTimeKind.Utc).AddTicks(9163) },
                    { 29, new DateTime(2024, 5, 12, 7, 16, 32, 211, DateTimeKind.Utc).AddTicks(1577), "Erick.Batz90@hotmail.com", "Sandra", "O'Kon", "uUVTKS_tS0", "509.977.0013 x477", "Admin", new DateTime(2024, 11, 28, 19, 2, 45, 810, DateTimeKind.Utc).AddTicks(3216) },
                    { 30, new DateTime(2024, 3, 5, 11, 14, 20, 663, DateTimeKind.Utc).AddTicks(4721), "Lilian_Rippin77@yahoo.com", "Tomas", "Schmitt", "ANaEt8hLXN", "268-672-8223", "User", new DateTime(2024, 11, 29, 21, 33, 5, 251, DateTimeKind.Utc).AddTicks(9455) }
                });

            migrationBuilder.InsertData(
                table: "add_ons",
                columns: new[] { "id", "created_at", "image", "is_deleted", "name", "price", "type_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 11, 12, 4, 45, 803, DateTimeKind.Utc).AddTicks(933), new byte[] { 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148, 75 }, false, "Ergonomic Granite Cheese", 13.492858981943158m, 2 },
                    { 2, new DateTime(2024, 3, 26, 10, 42, 29, 838, DateTimeKind.Utc).AddTicks(1381), new byte[] { 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217, 247 }, false, "Fantastic Wooden Chips", 3.071088037486689m, 4 },
                    { 3, new DateTime(2024, 11, 9, 8, 20, 13, 873, DateTimeKind.Utc).AddTicks(986), new byte[] { 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31, 164 }, false, "Handcrafted Fresh Mouse", 11.649317093030239m, 2 },
                    { 4, new DateTime(2024, 6, 24, 4, 57, 57, 908, DateTimeKind.Utc).AddTicks(564), new byte[] { 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100, 80 }, false, "Tasty Rubber Shirt", 1.2275461485737681m, 5 },
                    { 5, new DateTime(2024, 2, 7, 3, 35, 41, 943, DateTimeKind.Utc).AddTicks(160), new byte[] { 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170, 252 }, false, "Gorgeous Concrete Tuna", 9.805775204117301m, 2 },
                    { 6, new DateTime(2024, 9, 22, 0, 13, 25, 977, DateTimeKind.Utc).AddTicks(9729), new byte[] { 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239, 169 }, false, "Awesome Frozen Pizza", 18.384004259660832m, 5 },
                    { 7, new DateTime(2024, 5, 6, 21, 51, 10, 12, DateTimeKind.Utc).AddTicks(9299), new byte[] { 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53, 85 }, false, "Refined Metal Car", 7.962233315204382m, 2 },
                    { 8, new DateTime(2023, 12, 20, 20, 28, 54, 47, DateTimeKind.Utc).AddTicks(8915), new byte[] { 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122, 1 }, false, "Rustic Plastic Ball", 16.540462370747913m, 5 },
                    { 9, new DateTime(2024, 8, 4, 17, 6, 38, 82, DateTimeKind.Utc).AddTicks(8485), new byte[] { 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191, 174 }, false, "Practical Steel Shoes", 6.118691426291444m, 3 },
                    { 10, new DateTime(2024, 3, 19, 15, 44, 22, 117, DateTimeKind.Utc).AddTicks(8051), new byte[] { 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5, 90 }, false, "Handmade Soft Chicken", 14.696920481834994m, 5 },
                    { 11, new DateTime(2024, 11, 2, 13, 22, 6, 152, DateTimeKind.Utc).AddTicks(7628), new byte[] { 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74, 6 }, false, "Small Granite Salad", 4.275149537378525m, 3 },
                    { 12, new DateTime(2024, 6, 17, 9, 59, 50, 187, DateTimeKind.Utc).AddTicks(7196), new byte[] { 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144, 179 }, false, "Incredible Wooden Computer", 12.853378592922056m, 5 },
                    { 13, new DateTime(2024, 1, 31, 8, 37, 34, 222, DateTimeKind.Utc).AddTicks(6761), new byte[] { 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213, 95 }, false, "Generic Fresh Gloves", 2.4316076484656003m, 3 },
                    { 14, new DateTime(2024, 9, 15, 5, 15, 18, 257, DateTimeKind.Utc).AddTicks(6326), new byte[] { 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27, 11 }, false, "Unbranded Rubber Towels", 11.009836704009137m, 1 },
                    { 15, new DateTime(2024, 4, 30, 2, 53, 2, 292, DateTimeKind.Utc).AddTicks(5891), new byte[] { 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96, 184 }, false, "Intelligent Concrete Cheese", 19.588065759552668m, 3 },
                    { 16, new DateTime(2023, 12, 14, 1, 30, 46, 327, DateTimeKind.Utc).AddTicks(5455), new byte[] { 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165, 100 }, false, "Sleek Frozen Chips", 9.166294815096218m, 1 },
                    { 17, new DateTime(2024, 7, 28, 22, 8, 30, 362, DateTimeKind.Utc).AddTicks(5020), new byte[] { 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235, 16 }, false, "Licensed Metal Mouse", 17.744523870639749m, 4 },
                    { 18, new DateTime(2024, 3, 12, 20, 46, 14, 397, DateTimeKind.Utc).AddTicks(4594), new byte[] { 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48, 189 }, false, "Ergonomic Plastic Shirt", 7.32275292618328m, 1 },
                    { 19, new DateTime(2024, 10, 26, 17, 23, 58, 432, DateTimeKind.Utc).AddTicks(4161), new byte[] { 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118, 105 }, false, "Fantastic Steel Soap", 15.90098198172683m, 4 },
                    { 20, new DateTime(2024, 6, 10, 15, 1, 42, 467, DateTimeKind.Utc).AddTicks(3727), new byte[] { 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187, 21 }, false, "Handcrafted Soft Bacon", 5.479211037270361m, 1 },
                    { 21, new DateTime(2024, 1, 24, 13, 39, 26, 502, DateTimeKind.Utc).AddTicks(3290), new byte[] { 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1, 194 }, false, "Tasty Cotton Chair", 14.057440092813892m, 4 },
                    { 22, new DateTime(2024, 9, 8, 10, 17, 10, 537, DateTimeKind.Utc).AddTicks(2854), new byte[] { 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70, 110 }, false, "Gorgeous Wooden Ball", 3.635669148357423m, 2 },
                    { 23, new DateTime(2024, 4, 23, 7, 54, 54, 572, DateTimeKind.Utc).AddTicks(2420), new byte[] { 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140, 26 }, false, "Awesome Fresh Shoes", 12.213898203900973m, 4 },
                    { 24, new DateTime(2023, 12, 7, 6, 32, 38, 607, DateTimeKind.Utc).AddTicks(1993), new byte[] { 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209, 199 }, false, "Refined Granite Chicken", 1.792127259444504m, 2 },
                    { 25, new DateTime(2024, 7, 22, 3, 10, 22, 642, DateTimeKind.Utc).AddTicks(1557), new byte[] { 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22, 115 }, false, "Rustic Concrete Salad", 10.370356314988035m, 4 },
                    { 26, new DateTime(2024, 3, 6, 1, 48, 6, 677, DateTimeKind.Utc).AddTicks(1122), new byte[] { 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92, 31 }, false, "Practical Frozen Computer", 18.948585370531585m, 2 },
                    { 27, new DateTime(2024, 10, 19, 22, 25, 50, 712, DateTimeKind.Utc).AddTicks(684), new byte[] { 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161, 204 }, false, "Handmade Metal Gloves", 8.526814426075116m, 5 },
                    { 28, new DateTime(2024, 6, 3, 20, 3, 34, 747, DateTimeKind.Utc).AddTicks(249), new byte[] { 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231, 120 }, false, "Small Plastic Hat", 17.105043481618647m, 2 },
                    { 29, new DateTime(2024, 1, 17, 18, 41, 18, 781, DateTimeKind.Utc).AddTicks(9812), new byte[] { 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44, 36 }, false, "Incredible Steel Fish", 6.683272537162197m, 5 },
                    { 30, new DateTime(2024, 9, 1, 15, 19, 2, 816, DateTimeKind.Utc).AddTicks(9375), new byte[] { 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114, 209 }, false, "Generic Soft Chips", 15.261501592705728m, 2 }
                });

            migrationBuilder.InsertData(
                table: "bouquet_category_bouquets",
                columns: new[] { "bouquet_id", "category_id" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 9, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 28, 1 },
                    { 29, 1 }
                });

            migrationBuilder.InsertData(
                table: "custom_bouquets",
                columns: new[] { "id", "created_at", "total_price", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 28, 5, 28, 57, 629, DateTimeKind.Utc).AddTicks(9188), 0m, 8 },
                    { 2, new DateTime(2024, 11, 19, 10, 13, 16, 573, DateTimeKind.Utc).AddTicks(2805), 105.867808293489768m, 24 },
                    { 3, new DateTime(2024, 11, 10, 14, 57, 35, 516, DateTimeKind.Utc).AddTicks(4941), 476.396963147631180m, 9 },
                    { 4, new DateTime(2024, 11, 1, 19, 41, 54, 459, DateTimeKind.Utc).AddTicks(7068), 173.537385522172556m, 25 },
                    { 5, new DateTime(2024, 11, 23, 0, 26, 13, 402, DateTimeKind.Utc).AddTicks(9180), 91.252610928496615m, 11 },
                    { 6, new DateTime(2024, 11, 14, 5, 10, 32, 346, DateTimeKind.Utc).AddTicks(1289), 183.134031854166448m, 26 },
                    { 7, new DateTime(2024, 11, 5, 9, 54, 51, 289, DateTimeKind.Utc).AddTicks(3401), 73.9354806448963714m, 12 },
                    { 8, new DateTime(2024, 11, 26, 14, 39, 10, 232, DateTimeKind.Utc).AddTicks(5508), 426.036659462394543m, 28 },
                    { 9, new DateTime(2024, 11, 17, 19, 23, 29, 175, DateTimeKind.Utc).AddTicks(7616), 206.025785835937254m, 13 },
                    { 10, new DateTime(2024, 11, 9, 0, 7, 48, 118, DateTimeKind.Utc).AddTicks(9724), 293.673084629547576m, 29 },
                    { 11, new DateTime(2024, 11, 30, 4, 52, 7, 62, DateTimeKind.Utc).AddTicks(1832), 117.0003152019345961m, 15 },
                    { 12, new DateTime(2024, 11, 21, 9, 36, 26, 5, DateTimeKind.Utc).AddTicks(3940), 266.1713617449492254m, 30 },
                    { 13, new DateTime(2024, 11, 12, 14, 20, 44, 948, DateTimeKind.Utc).AddTicks(6055), 77.167749268546587m, 16 },
                    { 14, new DateTime(2024, 11, 3, 19, 5, 3, 891, DateTimeKind.Utc).AddTicks(8163), 0m, 2 },
                    { 15, new DateTime(2024, 11, 24, 23, 49, 22, 835, DateTimeKind.Utc).AddTicks(269), 45.669674235707860m, 17 },
                    { 16, new DateTime(2024, 11, 16, 4, 33, 41, 778, DateTimeKind.Utc).AddTicks(2377), 30.5183782347097977m, 3 },
                    { 17, new DateTime(2024, 11, 7, 9, 18, 0, 721, DateTimeKind.Utc).AddTicks(4484), 157.003733654042535m, 19 },
                    { 18, new DateTime(2024, 11, 28, 14, 2, 19, 664, DateTimeKind.Utc).AddTicks(6592), 33.416362685810985m, 4 },
                    { 19, new DateTime(2024, 11, 19, 18, 46, 38, 607, DateTimeKind.Utc).AddTicks(8700), 128.150971548702002m, 20 },
                    { 20, new DateTime(2024, 11, 10, 23, 30, 57, 551, DateTimeKind.Utc).AddTicks(807), 8.638050181156997m, 6 },
                    { 21, new DateTime(2024, 11, 2, 4, 15, 16, 494, DateTimeKind.Utc).AddTicks(2915), 185.727288911923320m, 21 },
                    { 22, new DateTime(2024, 11, 23, 8, 59, 35, 437, DateTimeKind.Utc).AddTicks(5028), 0m, 7 },
                    { 23, new DateTime(2024, 11, 14, 13, 43, 54, 380, DateTimeKind.Utc).AddTicks(7137), 355.824985523626779m, 23 },
                    { 24, new DateTime(2024, 11, 5, 18, 28, 13, 323, DateTimeKind.Utc).AddTicks(9244), 127.432431771155702m, 8 },
                    { 25, new DateTime(2024, 11, 26, 23, 12, 32, 267, DateTimeKind.Utc).AddTicks(1350), 525.099997071595582m, 24 },
                    { 26, new DateTime(2024, 11, 18, 3, 56, 51, 210, DateTimeKind.Utc).AddTicks(3457), 181.405193815662030m, 10 },
                    { 27, new DateTime(2024, 11, 9, 8, 41, 10, 153, DateTimeKind.Utc).AddTicks(5564), 38.137227114353912m, 25 },
                    { 28, new DateTime(2024, 11, 30, 13, 25, 29, 96, DateTimeKind.Utc).AddTicks(7670), 55.540677789384896m, 11 },
                    { 29, new DateTime(2024, 11, 21, 18, 9, 48, 39, DateTimeKind.Utc).AddTicks(9777), 339.140616388591128m, 27 },
                    { 30, new DateTime(2024, 11, 12, 22, 54, 6, 983, DateTimeKind.Utc).AddTicks(1884), 111.018685611439244m, 12 }
                });

            migrationBuilder.InsertData(
                table: "flowers",
                columns: new[] { "id", "available_quantity", "color", "created_at", "image", "is_deleted", "name", "price", "type_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 77, "yellow", new DateTime(2024, 5, 11, 12, 32, 43, 200, DateTimeKind.Utc).AddTicks(8820), new byte[] { 64, 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148 }, false, "Rose yellow", 23.883523313740054m, 1, new DateTime(2024, 11, 27, 6, 23, 36, 55, DateTimeKind.Utc).AddTicks(8875) },
                    { 2, 99, "maroon", new DateTime(2024, 1, 9, 14, 8, 26, 972, DateTimeKind.Utc).AddTicks(8765), new byte[] { 36, 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217 }, false, "Orchid maroon", 9.133934847141572m, 3, new DateTime(2024, 11, 21, 23, 36, 50, 855, DateTimeKind.Utc).AddTicks(618) },
                    { 3, 20, "magenta", new DateTime(2024, 9, 8, 13, 44, 10, 744, DateTimeKind.Utc).AddTicks(8435), new byte[] { 7, 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31 }, false, "Rose magenta", 43.384346380543139m, 1, new DateTime(2024, 11, 30, 16, 50, 5, 654, DateTimeKind.Utc).AddTicks(2219) },
                    { 4, 41, "silver", new DateTime(2024, 5, 8, 14, 19, 54, 516, DateTimeKind.Utc).AddTicks(8092), new byte[] { 235, 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100 }, false, "Orchid silver", 28.634757913944657m, 3, new DateTime(2024, 11, 25, 10, 3, 20, 453, DateTimeKind.Utc).AddTicks(3805) },
                    { 5, 63, "black", new DateTime(2024, 1, 6, 15, 55, 38, 288, DateTimeKind.Utc).AddTicks(7745), new byte[] { 206, 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170 }, false, "Tulip black", 13.885169447346224m, 2, new DateTime(2024, 11, 20, 3, 16, 35, 252, DateTimeKind.Utc).AddTicks(5390) },
                    { 6, 84, "salmon", new DateTime(2024, 9, 5, 15, 31, 22, 60, DateTimeKind.Utc).AddTicks(7399), new byte[] { 177, 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239 }, false, "Orchid salmon", 48.135580980747742m, 3, new DateTime(2024, 11, 28, 20, 29, 50, 51, DateTimeKind.Utc).AddTicks(6976) },
                    { 7, 5, "cyan", new DateTime(2024, 5, 5, 16, 7, 5, 832, DateTimeKind.Utc).AddTicks(7050), new byte[] { 149, 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53 }, false, "Tulip cyan", 33.38599251414926m, 2, new DateTime(2024, 11, 23, 13, 43, 4, 850, DateTimeKind.Utc).AddTicks(8560) },
                    { 8, 26, "mint green", new DateTime(2024, 1, 3, 17, 42, 49, 604, DateTimeKind.Utc).AddTicks(6700), new byte[] { 120, 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122 }, false, "Orchid mint green", 18.636404047550827m, 3, new DateTime(2024, 11, 18, 6, 56, 19, 650, DateTimeKind.Utc).AddTicks(143) },
                    { 9, 48, "turquoise", new DateTime(2024, 9, 2, 17, 18, 33, 376, DateTimeKind.Utc).AddTicks(6359), new byte[] { 92, 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191 }, false, "Tulip turquoise", 3.8868155809523597m, 2, new DateTime(2024, 11, 27, 0, 9, 34, 449, DateTimeKind.Utc).AddTicks(1734) },
                    { 10, 69, "ivory", new DateTime(2024, 5, 2, 17, 54, 17, 148, DateTimeKind.Utc).AddTicks(6009), new byte[] { 63, 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5 }, false, "Orchid ivory", 38.137227114353912m, 3, new DateTime(2024, 11, 21, 17, 22, 49, 248, DateTimeKind.Utc).AddTicks(3315) },
                    { 11, 91, "green", new DateTime(2023, 12, 31, 19, 30, 0, 920, DateTimeKind.Utc).AddTicks(5657), new byte[] { 35, 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74 }, false, "Tulip green", 23.38763864775543m, 2, new DateTime(2024, 11, 30, 10, 36, 4, 47, DateTimeKind.Utc).AddTicks(4895) },
                    { 12, 12, "pink", new DateTime(2024, 8, 30, 19, 5, 44, 692, DateTimeKind.Utc).AddTicks(5311), new byte[] { 6, 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144 }, false, "Orchid pink", 8.638050181156997m, 3, new DateTime(2024, 11, 25, 3, 49, 18, 846, DateTimeKind.Utc).AddTicks(6483) },
                    { 13, 33, "orchid", new DateTime(2024, 4, 29, 19, 41, 28, 464, DateTimeKind.Utc).AddTicks(4961), new byte[] { 234, 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213 }, false, "Tulip orchid", 42.888461714558515m, 2, new DateTime(2024, 11, 19, 21, 2, 33, 645, DateTimeKind.Utc).AddTicks(8065) },
                    { 14, 55, "azure", new DateTime(2023, 12, 28, 21, 17, 12, 236, DateTimeKind.Utc).AddTicks(4611), new byte[] { 205, 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27 }, false, "Rose azure", 28.138873247960082m, 1, new DateTime(2024, 11, 28, 14, 15, 48, 444, DateTimeKind.Utc).AddTicks(9647) },
                    { 15, 76, "teal", new DateTime(2024, 8, 27, 20, 52, 56, 8, DateTimeKind.Utc).AddTicks(4257), new byte[] { 176, 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96 }, false, "Tulip teal", 13.3892847813616m, 2, new DateTime(2024, 11, 23, 7, 29, 3, 244, DateTimeKind.Utc).AddTicks(1224) },
                    { 16, 98, "tan", new DateTime(2024, 4, 26, 21, 28, 39, 780, DateTimeKind.Utc).AddTicks(3905), new byte[] { 148, 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165 }, false, "Rose tan", 47.639696314763118m, 1, new DateTime(2024, 11, 18, 0, 42, 18, 43, DateTimeKind.Utc).AddTicks(2804) },
                    { 17, 18, "indigo", new DateTime(2023, 12, 25, 23, 4, 23, 552, DateTimeKind.Utc).AddTicks(3563), new byte[] { 119, 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235 }, false, "Tulip indigo", 32.890107848164685m, 2, new DateTime(2024, 11, 26, 17, 55, 32, 842, DateTimeKind.Utc).AddTicks(4395) },
                    { 18, 40, "yellow", new DateTime(2024, 8, 24, 22, 40, 7, 324, DateTimeKind.Utc).AddTicks(3212), new byte[] { 91, 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48 }, false, "Rose yellow", 18.140519381566203m, 1, new DateTime(2024, 11, 21, 11, 8, 47, 641, DateTimeKind.Utc).AddTicks(5977) },
                    { 19, 61, "maroon", new DateTime(2024, 4, 23, 23, 15, 51, 96, DateTimeKind.Utc).AddTicks(2862), new byte[] { 62, 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118 }, false, "Tulip maroon", 3.3909309149677553m, 2, new DateTime(2024, 11, 30, 4, 22, 2, 440, DateTimeKind.Utc).AddTicks(7559) },
                    { 20, 83, "magenta", new DateTime(2023, 12, 23, 0, 51, 34, 868, DateTimeKind.Utc).AddTicks(2509), new byte[] { 34, 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187 }, false, "Rose magenta", 37.641342448369288m, 1, new DateTime(2024, 11, 24, 21, 35, 17, 239, DateTimeKind.Utc).AddTicks(9139) },
                    { 21, 4, "silver", new DateTime(2024, 8, 22, 0, 27, 18, 640, DateTimeKind.Utc).AddTicks(2156), new byte[] { 5, 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1 }, false, "Orchid silver", 22.891753981770806m, 3, new DateTime(2024, 11, 19, 14, 48, 32, 39, DateTimeKind.Utc).AddTicks(717) },
                    { 22, 25, "black", new DateTime(2024, 4, 21, 1, 3, 2, 412, DateTimeKind.Utc).AddTicks(1804), new byte[] { 233, 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70 }, false, "Rose black", 8.142165515172373m, 1, new DateTime(2024, 11, 28, 8, 1, 46, 838, DateTimeKind.Utc).AddTicks(2298) },
                    { 23, 47, "salmon", new DateTime(2023, 12, 20, 2, 38, 46, 184, DateTimeKind.Utc).AddTicks(1453), new byte[] { 204, 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140 }, false, "Orchid salmon", 42.392577048573891m, 3, new DateTime(2024, 11, 23, 1, 15, 1, 637, DateTimeKind.Utc).AddTicks(3879) },
                    { 24, 68, "fuchsia", new DateTime(2024, 8, 19, 2, 14, 29, 956, DateTimeKind.Utc).AddTicks(1103), new byte[] { 176, 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209 }, false, "Rose fuchsia", 27.642988581975458m, 1, new DateTime(2024, 11, 17, 18, 28, 16, 436, DateTimeKind.Utc).AddTicks(5460) },
                    { 25, 90, "purple", new DateTime(2024, 4, 18, 2, 50, 13, 728, DateTimeKind.Utc).AddTicks(757), new byte[] { 147, 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22 }, false, "Orchid purple", 12.893400115376976m, 3, new DateTime(2024, 11, 26, 11, 41, 31, 235, DateTimeKind.Utc).AddTicks(7047) },
                    { 26, 10, "violet", new DateTime(2023, 12, 17, 4, 25, 57, 500, DateTimeKind.Utc).AddTicks(405), new byte[] { 118, 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92 }, false, "Rose violet", 47.143811648778543m, 1, new DateTime(2024, 11, 21, 4, 54, 46, 34, DateTimeKind.Utc).AddTicks(8628) },
                    { 27, 32, "lime", new DateTime(2024, 8, 16, 4, 1, 41, 272, DateTimeKind.Utc).AddTicks(50), new byte[] { 90, 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161 }, false, "Orchid lime", 32.394223182180061m, 3, new DateTime(2024, 11, 29, 22, 8, 0, 834, DateTimeKind.Utc).AddTicks(205) },
                    { 28, 53, "green", new DateTime(2024, 4, 15, 4, 37, 25, 43, DateTimeKind.Utc).AddTicks(9709), new byte[] { 61, 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231 }, false, "Tulip green", 17.644634715581628m, 2, new DateTime(2024, 11, 24, 15, 21, 15, 633, DateTimeKind.Utc).AddTicks(1796) },
                    { 29, 75, "pink", new DateTime(2023, 12, 14, 6, 13, 8, 815, DateTimeKind.Utc).AddTicks(9356), new byte[] { 33, 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44 }, false, "Orchid pink", 2.895046248983146m, 3, new DateTime(2024, 11, 19, 8, 34, 30, 432, DateTimeKind.Utc).AddTicks(3374) },
                    { 30, 97, "orchid", new DateTime(2024, 8, 13, 5, 48, 52, 587, DateTimeKind.Utc).AddTicks(9001), new byte[] { 4, 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114 }, false, "Tulip orchid", 37.145457782384664m, 2, new DateTime(2024, 11, 28, 1, 47, 45, 231, DateTimeKind.Utc).AddTicks(4952) }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "comment", "created_at", "delivery_address", "delivery_date", "delivery_price", "payment_method", "status", "total_price", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, "Cumque hic explicabo neque eum quibusdam ipsum autem.", new DateTime(2024, 8, 11, 1, 31, 31, 664, DateTimeKind.Utc).AddTicks(439), "1602 Fidel Village, Port Marisol, Niue", new DateTime(2033, 5, 26, 8, 57, 24, 876, DateTimeKind.Utc).AddTicks(307), 244.165126338678080m, "Cash on Delivery", "Pending", 256.379024542579053m, new DateTime(2024, 11, 20, 0, 40, 50, 840, DateTimeKind.Utc).AddTicks(6405), 8 },
                    { 2, "Vitae laboriosam sit.", new DateTime(2024, 3, 8, 21, 19, 48, 687, DateTimeKind.Utc).AddTicks(8713), "20700 Princess Lock, Georgianaburgh, Philippines", new DateTime(2031, 12, 24, 5, 36, 56, 406, DateTimeKind.Utc).AddTicks(1975), 99.679361767917440m, "Cash on Delivery", "Processing", 579.217377156120161m, new DateTime(2024, 11, 19, 0, 10, 40, 784, DateTimeKind.Utc).AddTicks(3109), 24 },
                    { 3, "Voluptatum numquam qui et vitae asperiores blanditiis excepturi unde.", new DateTime(2024, 7, 17, 2, 13, 36, 107, DateTimeKind.Utc).AddTicks(4328), "3358 Demarco Village, Alexanderton, Trinidad and Tobago", new DateTime(2028, 8, 15, 2, 55, 29, 368, DateTimeKind.Utc).AddTicks(9511), 435.193597197157280m, "Cash on Delivery", "Shipped", 2148.641203010752669m, new DateTime(2024, 11, 24, 14, 9, 46, 551, DateTimeKind.Utc).AddTicks(8006), 9 },
                    { 4, "Ut eum libero et sunt aspernatur quis dolorem et.", new DateTime(2024, 8, 12, 18, 38, 2, 265, DateTimeKind.Utc).AddTicks(7270), "47253 Maxime Locks, Oswaldomouth, Mali", new DateTime(2039, 3, 6, 21, 34, 54, 271, DateTimeKind.Utc).AddTicks(2225), 290.707832626396640m, "Cash on Delivery", "Delivered", 619.6142055460318053m, new DateTime(2024, 11, 22, 6, 10, 10, 559, DateTimeKind.Utc).AddTicks(9201), 25 },
                    { 5, "Deleniti architecto quo dolor consectetur.", new DateTime(2024, 3, 4, 21, 44, 26, 207, DateTimeKind.Utc).AddTicks(2010), "5193 Corkery Village, North Jaylanland, Venezuela", new DateTime(2027, 10, 12, 4, 33, 53, 203, DateTimeKind.Utc).AddTicks(7364), 146.222068055636480m, "Cash on Delivery", "Processing", 152.905340592798677m, new DateTime(2024, 11, 28, 6, 58, 58, 559, DateTimeKind.Utc).AddTicks(1946), 11 },
                    { 6, "Quidem laborum voluptatem consequatur magni quis eum explicabo ea.", new DateTime(2024, 9, 17, 19, 27, 42, 573, DateTimeKind.Utc).AddTicks(3356), "747 Mertz Locks, Lake Landenville, San Marino", new DateTime(2036, 6, 14, 17, 52, 36, 108, DateTimeKind.Utc).AddTicks(2827), 481.736303484875840m, "Cash on Delivery", "Shipped", 2278.605754973649484m, new DateTime(2024, 11, 18, 18, 21, 37, 669, DateTimeKind.Utc).AddTicks(1230), 26 },
                    { 7, "Accusantium placeat error quia deleniti iure doloremque tenetur accusantium.", new DateTime(2024, 6, 8, 17, 12, 24, 728, DateTimeKind.Utc).AddTicks(6348), "8849 Baumbach Villages, North Shanny, India", new DateTime(2049, 1, 23, 15, 51, 38, 354, DateTimeKind.Utc).AddTicks(7246), 337.25053891411520m, "Card", "Delivered", 337.25053891411520m, new DateTime(2024, 11, 21, 11, 45, 34, 708, DateTimeKind.Utc).AddTicks(2288), 12 },
                    { 8, "Saepe velit aut consequatur nisi eum atque tempore vel facilis.", new DateTime(2024, 2, 28, 15, 57, 6, 883, DateTimeKind.Utc).AddTicks(9342), "921 Kuhn Locks, Brennastad, Moldova", new DateTime(2025, 9, 18, 5, 51, 13, 2, DateTimeKind.Utc).AddTicks(5495), 192.764774343355040m, "Card", "Pending", 1017.464431365702097m, new DateTime(2024, 11, 24, 5, 9, 31, 747, DateTimeKind.Utc).AddTicks(3346), 28 },
                    { 9, "Illo excepturi dolor.", new DateTime(2024, 5, 2, 11, 59, 17, 778, DateTimeKind.Utc).AddTicks(3581), "05948 Trevion Ville, East Macfurt, Micronesia", new DateTime(2052, 7, 16, 20, 59, 56, 411, DateTimeKind.Utc).AddTicks(1104), 48.2790097725945440m, "Cash on Delivery", "Processing", 260.2306914223499640m, new DateTime(2024, 11, 27, 3, 24, 5, 206, DateTimeKind.Utc).AddTicks(559), 13 },
                    { 10, "Hic amet ratione corporis.", new DateTime(2024, 3, 26, 22, 56, 58, 285, DateTimeKind.Utc).AddTicks(4389), "296 Gerson Lodge, South Margarete, Wallis and Futuna", new DateTime(2033, 3, 9, 0, 52, 32, 609, DateTimeKind.Utc).AddTicks(4032), 383.793245201834240m, "Card", "Delivered", 722.933861590425368m, new DateTime(2024, 11, 24, 4, 27, 14, 833, DateTimeKind.Utc).AddTicks(8471), 29 },
                    { 11, "Unde pariatur officiis omnis animi.", new DateTime(2024, 7, 11, 5, 52, 6, 890, DateTimeKind.Utc).AddTicks(6127), "33301 Roberta Vista, New Stellaport, Slovenia", new DateTime(2054, 3, 2, 3, 17, 22, 982, DateTimeKind.Utc).AddTicks(4526), 239.30748063107360m, "Cash on Delivery", "Pending", 2265.0377384741036573m, new DateTime(2024, 11, 24, 12, 6, 24, 867, DateTimeKind.Utc).AddTicks(9173), 15 },
                    { 12, "Sapiente velit autem.", new DateTime(2024, 11, 24, 5, 52, 10, 206, DateTimeKind.Utc).AddTicks(5430), "4618 Easton Lodge, Ratkebury, Madagascar", new DateTime(2052, 2, 13, 0, 46, 49, 586, DateTimeKind.Utc).AddTicks(9326), 94.821716060313440m, "Card", "Processing", 1882.584693859604332m, new DateTime(2024, 11, 28, 9, 41, 37, 282, DateTimeKind.Utc).AddTicks(6312), 30 },
                    { 13, "Eaque consectetur sunt aut necessitatibus aut quod.", new DateTime(2024, 10, 12, 3, 40, 37, 660, DateTimeKind.Utc).AddTicks(4280), "50865 Renner Vista, North Callieborough, Austria", new DateTime(2025, 10, 16, 7, 34, 49, 553, DateTimeKind.Utc).AddTicks(7949), 430.335951489552800m, "Card", "Shipped", 935.106600338177433m, new DateTime(2024, 11, 23, 20, 9, 16, 942, DateTimeKind.Utc).AddTicks(8615), 16 },
                    { 14, "Id cum veniam.", new DateTime(2024, 7, 23, 11, 47, 22, 127, DateTimeKind.Utc).AddTicks(6484), "7463 Daugherty Lodge, Lake Oswald, Samoa", new DateTime(2047, 5, 4, 17, 44, 54, 79, DateTimeKind.Utc).AddTicks(8152), 285.850186918792640m, "Cash on Delivery", "Delivered", 305.438252678345308m, new DateTime(2024, 11, 18, 14, 55, 59, 731, DateTimeKind.Utc).AddTicks(4167), 2 },
                    { 15, "Quia consequatur non.", new DateTime(2024, 5, 22, 15, 14, 58, 88, DateTimeKind.Utc).AddTicks(2006), "883 Murazik Vista, Port Dorcasport, Iceland", new DateTime(2029, 12, 13, 15, 43, 56, 326, DateTimeKind.Utc).AddTicks(2560), 141.3644223480320m, "Card", "Pending", 234.904545688957212m, new DateTime(2024, 11, 27, 17, 33, 10, 955, DateTimeKind.Utc).AddTicks(8092), 17 },
                    { 16, "Molestias earum est.", new DateTime(2024, 3, 21, 19, 42, 34, 48, DateTimeKind.Utc).AddTicks(7518), "9109 Blanda Loop, Pedroville, Angola", new DateTime(2042, 7, 24, 11, 42, 58, 572, DateTimeKind.Utc).AddTicks(6961), 476.878657777271360m, "Cash on Delivery", "Shipped", 841.481172668039924m, new DateTime(2024, 11, 22, 20, 10, 22, 180, DateTimeKind.Utc).AddTicks(2002), 3 },
                    { 17, "Eos eveniet architecto sit et ut consequatur.", new DateTime(2024, 6, 16, 0, 6, 21, 46, DateTimeKind.Utc).AddTicks(2902), "058 Juana Walk, Emmanuelburgh, Thailand", new DateTime(2044, 5, 2, 2, 57, 11, 233, DateTimeKind.Utc).AddTicks(3796), 332.392893206511200m, "Card", "Delivered", 2056.127596815642040m, new DateTime(2024, 11, 23, 20, 24, 38, 157, DateTimeKind.Utc).AddTicks(1164), 19 },
                    { 18, "Quia voluptatem aperiam voluptatem laudantium.", new DateTime(2024, 10, 24, 14, 23, 10, 616, DateTimeKind.Utc).AddTicks(2147), "29550 Wallace Mall, McCulloughburgh, Israel", new DateTime(2029, 7, 30, 12, 20, 39, 326, DateTimeKind.Utc).AddTicks(3669), 187.907128635750560m, "Card", "Pending", 199.556445728780799m, new DateTime(2024, 11, 25, 19, 31, 46, 456, DateTimeKind.Utc).AddTicks(9437), 4 },
                    { 19, "Consectetur tempore nisi molestias sed libero natus maxime enim.", new DateTime(2024, 6, 16, 2, 4, 18, 259, DateTimeKind.Utc).AddTicks(6198), "322 Heather Walks, New Filiberto, Falkland Islands (Malvinas)", new DateTime(2051, 10, 21, 20, 58, 30, 840, DateTimeKind.Utc).AddTicks(2337), 43.4213640649902560m, "Cash on Delivery", "Processing", 52.0594142461472530m, new DateTime(2024, 11, 20, 10, 8, 40, 521, DateTimeKind.Utc).AddTicks(8056), 20 },
                    { 20, "Voluptatum facere quis.", new DateTime(2024, 11, 24, 9, 33, 16, 269, DateTimeKind.Utc).AddTicks(173), "46003 Sandra Manor, Wunschport, Estonia", new DateTime(2036, 10, 11, 4, 18, 37, 191, DateTimeKind.Utc).AddTicks(3903), 378.935599494229760m, "Card", "Shipped", 1042.191632507924240m, new DateTime(2024, 11, 22, 7, 26, 21, 986, DateTimeKind.Utc).AddTicks(4364), 6 },
                    { 21, "Dolore ducimus est.", new DateTime(2024, 12, 1, 12, 8, 34, 447, DateTimeKind.Utc).AddTicks(3104), "507 Halvorson Walks, Bernhardbury, Palestinian Territory", new DateTime(2029, 4, 11, 14, 59, 50, 447, DateTimeKind.Utc).AddTicks(841), 234.449834923469120m, "Cash on Delivery", "Delivered", 234.449834923469120m, new DateTime(2024, 11, 23, 23, 26, 23, 488, DateTimeKind.Utc).AddTicks(547), 21 },
                    { 22, "Quod dolore impedit porro vero cum pariatur voluptatem fuga.", new DateTime(2024, 2, 13, 2, 37, 6, 84, DateTimeKind.Utc).AddTicks(5201), "63467 Runolfsdottir Manor, Homenickmouth, Bosnia and Herzegovina", new DateTime(2043, 12, 23, 21, 16, 35, 56, DateTimeKind.Utc).AddTicks(4069), 89.964070352708960m, "Card", "Processing", 116.2588932981057571m, new DateTime(2024, 11, 27, 5, 22, 57, 427, DateTimeKind.Utc).AddTicks(2901), 7 },
                    { 23, "Eius officiis quos debitis et.", new DateTime(2023, 12, 18, 8, 38, 15, 545, DateTimeKind.Utc).AddTicks(6542), "8724 Ebert Wall, South Arnaldo, Hungary", new DateTime(2040, 11, 1, 15, 36, 14, 297, DateTimeKind.Utc).AddTicks(7843), 425.478305781948320m, "Card", "Shipped", 999.727208581625481m, new DateTime(2024, 11, 27, 1, 52, 6, 834, DateTimeKind.Utc).AddTicks(67), 23 },
                    { 24, "Consequatur id quae esse ab sapiente similique.", new DateTime(2024, 5, 11, 4, 53, 24, 536, DateTimeKind.Utc).AddTicks(1576), "91921 Okuneva Manors, Sauertown, Uruguay", new DateTime(2051, 3, 6, 13, 14, 32, 921, DateTimeKind.Utc).AddTicks(4263), 280.992541211188160m, "Card", "Delivered", 2423.389736727061848m, new DateTime(2024, 11, 29, 2, 6, 24, 322, DateTimeKind.Utc).AddTicks(1190), 8 },
                    { 25, "Asperiores eos voluptatibus eius voluptas.", new DateTime(2024, 10, 7, 13, 52, 23, 798, DateTimeKind.Utc).AddTicks(1237), "0479 Berenice Way, Kreigerport, Nicaragua", new DateTime(2036, 1, 22, 9, 34, 18, 790, DateTimeKind.Utc).AddTicks(6652), 136.506776640427520m, "Card", "Pending", 635.164434279857154m, new DateTime(2024, 11, 23, 1, 38, 58, 495, DateTimeKind.Utc).AddTicks(1412), 24 },
                    { 26, "Vel eum enim.", new DateTime(2024, 9, 9, 11, 57, 18, 524, DateTimeKind.Utc).AddTicks(2330), "184 Kaylee Meadow, Lakinshire, Christmas Island", new DateTime(2032, 12, 15, 1, 3, 9, 464, DateTimeKind.Utc).AddTicks(2089), 472.021012069667360m, "Cash on Delivery", "Processing", 2176.250908438698116m, new DateTime(2024, 11, 26, 3, 30, 41, 185, DateTimeKind.Utc).AddTicks(5475), 10 },
                    { 27, "Ea rem iste laudantium ut saepe ratione esse consequatur.", new DateTime(2024, 2, 3, 7, 13, 30, 478, DateTimeKind.Utc).AddTicks(6239), "3215 Abe Ways, South Shannahaven, Cote d'Ivoire", new DateTime(2046, 12, 23, 13, 11, 29, 718, DateTimeKind.Utc).AddTicks(9536), 327.535247498906720m, "Card", "Shipped", 971.203214753048532m, new DateTime(2024, 11, 29, 9, 9, 50, 445, DateTimeKind.Utc).AddTicks(9985), 25 },
                    { 28, "Iusto sequi sed porro est.", new DateTime(2024, 2, 7, 12, 19, 15, 193, DateTimeKind.Utc).AddTicks(9603), "459 Ivory Meadows, Port Alfredo, Moldova", new DateTime(2040, 6, 4, 18, 4, 29, 71, DateTimeKind.Utc).AddTicks(593), 183.049482928146560m, "Cash on Delivery", "Pending", 397.4385629237811502m, new DateTime(2024, 11, 25, 8, 0, 0, 298, DateTimeKind.Utc).AddTicks(4814), 11 },
                    { 29, "Libero sapiente saepe neque ut dolor et.", new DateTime(2024, 4, 5, 7, 42, 30, 812, DateTimeKind.Utc).AddTicks(6947), "59615 Tromp Ways, Earleneland, Australia", new DateTime(2054, 3, 6, 5, 9, 27, 583, DateTimeKind.Utc).AddTicks(9719), 38.563718357385920m, "Card", "Processing", 1496.736712452833385m, new DateTime(2024, 11, 23, 18, 4, 8, 122, DateTimeKind.Utc).AddTicks(4317), 27 },
                    { 30, "Corrupti non et quia veritatis excepturi rerum.", new DateTime(2024, 2, 4, 18, 45, 5, 455, DateTimeKind.Utc).AddTicks(2969), "633 Heidenreich Meadows, Gerholdton, Wallis and Futuna", new DateTime(2047, 11, 24, 13, 5, 48, 677, DateTimeKind.Utc).AddTicks(9093), 374.077953786625280m, "Card", "Shipped", 374.077953786625280m, new DateTime(2024, 11, 21, 8, 57, 26, 54, DateTimeKind.Utc).AddTicks(8584), 12 }
                });

            migrationBuilder.InsertData(
                table: "shopping_carts",
                columns: new[] { "user_id", "created_at", "updated_at" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 1, 5, 2, 1, 32, 800, DateTimeKind.Utc).AddTicks(7271), new DateTime(2024, 11, 29, 5, 53, 15, 990, DateTimeKind.Utc).AddTicks(6214) },
                    { 5, new DateTime(2024, 7, 14, 6, 0, 35, 56, DateTimeKind.Utc).AddTicks(1370), new DateTime(2024, 11, 19, 8, 28, 35, 150, DateTimeKind.Utc).AddTicks(4538) },
                    { 7, new DateTime(2024, 6, 27, 20, 2, 30, 545, DateTimeKind.Utc).AddTicks(3172), new DateTime(2024, 11, 25, 3, 17, 56, 830, DateTimeKind.Utc).AddTicks(7889) },
                    { 11, new DateTime(2024, 9, 1, 11, 54, 48, 588, DateTimeKind.Utc).AddTicks(5715), new DateTime(2024, 11, 30, 0, 0, 30, 109, DateTimeKind.Utc).AddTicks(4398) },
                    { 12, new DateTime(2024, 1, 21, 11, 59, 37, 311, DateTimeKind.Utc).AddTicks(5468), new DateTime(2024, 11, 23, 11, 3, 54, 310, DateTimeKind.Utc).AddTicks(2860) },
                    { 15, new DateTime(2023, 12, 19, 16, 3, 28, 289, DateTimeKind.Utc).AddTicks(9072), new DateTime(2024, 11, 21, 0, 42, 37, 670, DateTimeKind.Utc).AddTicks(9564) },
                    { 17, new DateTime(2024, 2, 6, 21, 57, 41, 822, DateTimeKind.Utc).AddTicks(3664), new DateTime(2024, 11, 17, 16, 14, 32, 629, DateTimeKind.Utc).AddTicks(9506) },
                    { 21, new DateTime(2024, 8, 16, 1, 56, 44, 77, DateTimeKind.Utc).AddTicks(7759), new DateTime(2024, 11, 21, 18, 49, 51, 789, DateTimeKind.Utc).AddTicks(7829) },
                    { 22, new DateTime(2024, 7, 30, 15, 58, 39, 566, DateTimeKind.Utc).AddTicks(9567), new DateTime(2024, 11, 27, 13, 39, 13, 470, DateTimeKind.Utc).AddTicks(1185) },
                    { 23, new DateTime(2024, 2, 23, 7, 55, 46, 333, DateTimeKind.Utc).AddTicks(1850), new DateTime(2024, 11, 25, 21, 25, 10, 949, DateTimeKind.Utc).AddTicks(6146) }
                });

            migrationBuilder.InsertData(
                table: "bouquet_add_ons",
                columns: new[] { "id", "add_on_id", "bouquet_id", "custom_bouquet_id", "quantity" },
                values: new object[,]
                {
                    { 1, 15, 4, null, 4 },
                    { 2, 5, null, 13, 5 },
                    { 3, 26, 21, null, 1 },
                    { 4, 17, null, 30, 3 },
                    { 5, 8, 9, null, 4 },
                    { 6, 29, null, 18, 5 },
                    { 7, 20, 27, null, 1 },
                    { 8, 11, null, 5, 2 },
                    { 9, 2, 14, null, 3 },
                    { 10, 23, null, 23, 4 },
                    { 11, 14, 2, null, 5 },
                    { 12, 5, null, 11, 1 },
                    { 13, 26, null, 19, 2 },
                    { 14, 17, 28, null, 3 },
                    { 15, 8, null, 7, 4 },
                    { 16, 29, 16, null, 5 },
                    { 17, 20, null, 25, 1 },
                    { 18, 11, 3, null, 3 },
                    { 19, 2, null, 12, 4 },
                    { 20, 23, 21, null, 5 },
                    { 21, 14, null, 30, 1 },
                    { 22, 5, 9, null, 2 },
                    { 23, 26, null, 17, 3 },
                    { 24, 17, 26, null, 4 },
                    { 25, 8, null, 5, 5 },
                    { 26, 29, 14, null, 1 },
                    { 27, 20, null, 23, 2 },
                    { 28, 11, 1, null, 3 },
                    { 29, 2, null, 10, 4 },
                    { 30, 23, 19, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "bouquet_flowers",
                columns: new[] { "bouquet_id", "flower_id", "quantity" },
                values: new object[,]
                {
                    { 2, 28, 6 },
                    { 3, 16, 10 },
                    { 4, 3, 4 },
                    { 6, 21, 8 },
                    { 7, 9, 2 },
                    { 8, 4, 5 },
                    { 8, 26, 6 },
                    { 9, 21, 9 },
                    { 10, 14, 10 },
                    { 11, 1, 4 },
                    { 11, 9, 3 },
                    { 12, 19, 8 },
                    { 12, 27, 7 },
                    { 13, 14, 1 },
                    { 15, 2, 5 },
                    { 16, 19, 9 },
                    { 17, 7, 3 },
                    { 19, 25, 7 },
                    { 20, 12, 1 },
                    { 21, 30, 5 },
                    { 23, 17, 9 },
                    { 24, 5, 3 },
                    { 24, 13, 2 },
                    { 25, 23, 7 },
                    { 25, 30, 6 },
                    { 26, 18, 10 },
                    { 27, 10, 1 },
                    { 28, 5, 4 },
                    { 29, 23, 8 },
                    { 30, 11, 2 }
                });

            migrationBuilder.InsertData(
                table: "cart_items",
                columns: new[] { "id", "bouquet_id", "cart_id", "custom_bouquet_id", "price", "quantity" },
                values: new object[,]
                {
                    { 1, 15, 21, null, 0m, 4 },
                    { 2, 5, 4, null, 0m, 5 },
                    { 3, null, 21, 26, 0m, 1 },
                    { 4, null, 7, 17, 0m, 3 },
                    { 5, 8, 17, null, 0m, 4 },
                    { 6, null, 7, 29, 0m, 5 },
                    { 7, null, 17, 20, 0m, 1 },
                    { 8, 11, 15, null, 0m, 2 },
                    { 9, 2, 22, null, 0m, 3 },
                    { 10, null, 15, 23, 0m, 4 },
                    { 11, 14, 22, null, 0m, 5 },
                    { 12, 5, 15, null, 0m, 1 },
                    { 13, null, 12, 26, 0m, 2 },
                    { 14, null, 11, 17, 0m, 3 },
                    { 15, 8, 12, null, 0m, 4 },
                    { 16, null, 11, 29, 0m, 5 },
                    { 17, null, 5, 20, 0m, 1 },
                    { 18, 11, 23, null, 0m, 3 },
                    { 19, 2, 5, null, 0m, 4 },
                    { 20, null, 23, 23, 0m, 5 },
                    { 21, null, 5, 14, 0m, 1 },
                    { 22, 5, 21, null, 0m, 2 },
                    { 23, null, 4, 26, 0m, 3 },
                    { 24, null, 21, 17, 0m, 4 },
                    { 25, 8, 4, null, 0m, 5 },
                    { 26, 29, 17, null, 0m, 1 },
                    { 27, null, 7, 20, 0m, 2 },
                    { 28, 11, 17, null, 0m, 3 },
                    { 29, 2, 7, null, 0m, 4 },
                    { 30, null, 17, 23, 0m, 5 }
                });

            migrationBuilder.InsertData(
                table: "custom_bouquet_flowers",
                columns: new[] { "custom_bouquet_id", "flower_id", "quantity" },
                values: new object[,]
                {
                    { 2, 28, 6 },
                    { 3, 16, 10 },
                    { 4, 3, 4 },
                    { 6, 21, 8 },
                    { 7, 9, 2 },
                    { 8, 4, 5 },
                    { 8, 26, 6 },
                    { 9, 21, 9 },
                    { 10, 14, 10 },
                    { 11, 1, 4 },
                    { 11, 9, 3 },
                    { 12, 19, 8 },
                    { 12, 27, 7 },
                    { 13, 14, 1 },
                    { 15, 2, 5 },
                    { 16, 19, 9 },
                    { 17, 7, 3 },
                    { 19, 25, 7 },
                    { 20, 12, 1 },
                    { 21, 30, 5 },
                    { 23, 17, 9 },
                    { 24, 5, 3 },
                    { 24, 13, 2 },
                    { 25, 23, 7 },
                    { 25, 30, 6 },
                    { 26, 18, 10 },
                    { 27, 10, 1 },
                    { 28, 5, 4 },
                    { 29, 23, 8 },
                    { 30, 11, 2 }
                });

            migrationBuilder.InsertData(
                table: "order_bouquets",
                columns: new[] { "id", "bouquet_id", "custom_bouquet_id", "order_id", "price", "quantity" },
                values: new object[,]
                {
                    { 1, 15, null, 8, 0m, 4 },
                    { 2, 5, null, 24, 0m, 5 },
                    { 3, null, 26, 9, 0m, 1 },
                    { 4, null, 17, 25, 0m, 3 },
                    { 5, 8, null, 11, 0m, 4 },
                    { 6, null, 29, 26, 0m, 5 },
                    { 7, null, 20, 12, 0m, 1 },
                    { 8, 11, null, 28, 0m, 2 },
                    { 9, 2, null, 13, 0m, 3 },
                    { 10, null, 23, 29, 0m, 4 },
                    { 11, 14, null, 15, 0m, 5 },
                    { 12, 5, null, 30, 0m, 1 },
                    { 13, null, 26, 16, 0m, 2 },
                    { 14, null, 17, 2, 0m, 3 },
                    { 15, 8, null, 17, 0m, 4 },
                    { 16, null, 29, 3, 0m, 5 },
                    { 17, null, 20, 19, 0m, 1 },
                    { 18, 11, null, 4, 0m, 3 },
                    { 19, 2, null, 20, 0m, 4 },
                    { 20, null, 23, 6, 0m, 5 },
                    { 21, null, 14, 21, 0m, 1 },
                    { 22, 5, null, 7, 0m, 2 },
                    { 23, null, 26, 23, 0m, 3 },
                    { 24, null, 17, 8, 0m, 4 },
                    { 25, 8, null, 24, 0m, 5 },
                    { 26, 29, null, 10, 0m, 1 },
                    { 27, null, 20, 25, 0m, 2 },
                    { 28, 11, null, 11, 0m, 3 },
                    { 29, 2, null, 27, 0m, 4 },
                    { 30, null, 23, 12, 0m, 5 }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "id", "amount", "order_id", "payment_method", "status", "transaction_date" },
                values: new object[,]
                {
                    { 1, 139.360920395404640m, 7, "Card", "Completed", new DateTime(2024, 11, 8, 9, 39, 48, 152, DateTimeKind.Utc).AddTicks(916) },
                    { 2, 390.125071206188480m, 8, "Card", "Pending", new DateTime(2024, 11, 1, 23, 59, 4, 76, DateTimeKind.Utc).AddTicks(1064) },
                    { 3, 160.889222016972320m, 25, "Cash on Delivery", "Failed", new DateTime(2024, 11, 25, 14, 18, 20, 0, DateTimeKind.Utc).AddTicks(374) },
                    { 4, 411.653372827755680m, 29, "Cash on Delivery", "Completed", new DateTime(2024, 11, 19, 4, 37, 35, 923, DateTimeKind.Utc).AddTicks(9650) },
                    { 5, 182.417523638539520m, 15, "Card", "Pending", new DateTime(2024, 11, 12, 18, 56, 51, 847, DateTimeKind.Utc).AddTicks(8924) },
                    { 6, 433.181674449323360m, 20, "Cash on Delivery", "Failed", new DateTime(2024, 11, 6, 9, 16, 7, 771, DateTimeKind.Utc).AddTicks(8195) },
                    { 7, 203.94582526010720m, 13, "Cash on Delivery", "Completed", new DateTime(2024, 11, 29, 23, 35, 23, 695, DateTimeKind.Utc).AddTicks(7466) },
                    { 8, 454.709976070891040m, 17, "Card", "Completed", new DateTime(2024, 11, 23, 13, 54, 39, 619, DateTimeKind.Utc).AddTicks(6736) },
                    { 9, 225.474126881674880m, 18, "Card", "Pending", new DateTime(2024, 11, 17, 4, 13, 55, 543, DateTimeKind.Utc).AddTicks(6006) },
                    { 10, 476.238277692458720m, 12, "Cash on Delivery", "Failed", new DateTime(2024, 11, 10, 18, 33, 11, 467, DateTimeKind.Utc).AddTicks(5279) },
                    { 11, 247.002428503242560m, 27, "Card", "Completed", new DateTime(2024, 11, 4, 8, 52, 27, 391, DateTimeKind.Utc).AddTicks(4548) },
                    { 12, 497.766579314026400m, 23, "Card", "Pending", new DateTime(2024, 11, 27, 23, 11, 43, 315, DateTimeKind.Utc).AddTicks(3816) },
                    { 13, 268.530730124810240m, 22, "Cash on Delivery", "Failed", new DateTime(2024, 11, 21, 13, 30, 59, 239, DateTimeKind.Utc).AddTicks(3084) },
                    { 14, 39.2948809355939360m, 30, "Cash on Delivery", "Completed", new DateTime(2024, 11, 15, 3, 50, 15, 163, DateTimeKind.Utc).AddTicks(2354) },
                    { 15, 290.059031746377920m, 10, "Card", "Pending", new DateTime(2024, 11, 8, 18, 9, 31, 87, DateTimeKind.Utc).AddTicks(1621) },
                    { 16, 60.8231825571615200m, 24, "Cash on Delivery", "Failed", new DateTime(2024, 11, 2, 8, 28, 47, 11, DateTimeKind.Utc).AddTicks(891) }
                });

            migrationBuilder.InsertData(
                table: "cart_item_add_ons",
                columns: new[] { "add_on_id", "cart_item_id", "card_note", "quantity" },
                values: new object[,]
                {
                    { 23, 1, "Reiciendis ducimus ipsa est voluptates ipsam reiciendis in.", 0 },
                    { 27, 2, "Nobis placeat dolorem ut.", 0 },
                    { 17, 3, "Aut et amet aut esse cupiditate ut.", 0 },
                    { 18, 4, "Voluptas eaque placeat ullam ut ut doloribus error delectus expedita.", 0 },
                    { 29, 5, "Veniam voluptatem fuga laudantium non.", 0 },
                    { 17, 6, "Quod rerum voluptatem qui sequi alias maiores voluptatem incidunt.", 0 },
                    { 18, 8, "Doloribus error velit aut illo optio ducimus rem placeat.", 0 },
                    { 29, 8, "Optio et velit natus dolor.", 0 },
                    { 9, 9, "Reprehenderit ab laborum repellendus neque quam aut voluptas.", 0 },
                    { 16, 9, "Facere possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.", 0 },
                    { 30, 9, "Aspernatur aliquid in sit.", 0 },
                    { 11, 13, "Aut totam est expedita.", 0 },
                    { 17, 13, "Excepturi tenetur aut.", 0 },
                    { 15, 14, "Aperiam laboriosam sed pariatur accusantium.", 0 },
                    { 21, 15, "Dolorum id sapiente placeat omnis ut.", 0 },
                    { 24, 16, "Molestiae omnis unde.", 0 },
                    { 15, 17, "Ducimus earum odit rerum minima.", 0 },
                    { 3, 18, "Harum at sit architecto sint qui delectus.", 0 },
                    { 15, 20, "Vero perspiciatis soluta ipsa provident.", 0 },
                    { 4, 22, "Dolorem ea ut illum unde quos blanditiis delectus modi amet.", 0 },
                    { 5, 22, "In sapiente quo repudiandae et deserunt qui quisquam corrupti.", 0 },
                    { 30, 22, "Sequi et saepe quos voluptate odit maiores quasi quos.", 0 },
                    { 1, 23, "Ea dolorem maiores aut nemo et dignissimos tempora aut.", 0 },
                    { 8, 23, "Error nulla totam officia expedita non voluptatibus qui.", 0 },
                    { 23, 24, "Enim ratione aliquam eos.", 0 },
                    { 25, 25, "Eius magnam omnis reiciendis libero et delectus.", 0 },
                    { 27, 26, "Laboriosam sequi sed fuga quae veniam laudantium laudantium optio dolores.", 0 },
                    { 3, 29, "Praesentium inventore deleniti enim nihil itaque.", 0 },
                    { 11, 29, "Quae blanditiis et ipsum ipsum fugiat.", 0 },
                    { 26, 29, "Accusamus distinctio illo consequatur cum ipsa.", 0 }
                });

            migrationBuilder.InsertData(
                table: "order_add_ons",
                columns: new[] { "add_on_id", "order_bouquet_id", "card_note", "quantity" },
                values: new object[,]
                {
                    { 23, 1, "Reiciendis ducimus ipsa est voluptates ipsam reiciendis in.", 0 },
                    { 27, 2, "Nobis placeat dolorem ut.", 0 },
                    { 17, 3, "Aut et amet aut esse cupiditate ut.", 0 },
                    { 18, 4, "Voluptas eaque placeat ullam ut ut doloribus error delectus expedita.", 0 },
                    { 29, 5, "Veniam voluptatem fuga laudantium non.", 0 },
                    { 17, 6, "Quod rerum voluptatem qui sequi alias maiores voluptatem incidunt.", 0 },
                    { 18, 8, "Doloribus error velit aut illo optio ducimus rem placeat.", 0 },
                    { 29, 8, "Optio et velit natus dolor.", 0 },
                    { 9, 9, "Reprehenderit ab laborum repellendus neque quam aut voluptas.", 0 },
                    { 16, 9, "Facere possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.", 0 },
                    { 30, 9, "Aspernatur aliquid in sit.", 0 },
                    { 11, 13, "Aut totam est expedita.", 0 },
                    { 17, 13, "Excepturi tenetur aut.", 0 },
                    { 15, 14, "Aperiam laboriosam sed pariatur accusantium.", 0 },
                    { 21, 15, "Dolorum id sapiente placeat omnis ut.", 0 },
                    { 24, 16, "Molestiae omnis unde.", 0 },
                    { 15, 17, "Ducimus earum odit rerum minima.", 0 },
                    { 3, 18, "Harum at sit architecto sint qui delectus.", 0 },
                    { 15, 20, "Vero perspiciatis soluta ipsa provident.", 0 },
                    { 4, 22, "Dolorem ea ut illum unde quos blanditiis delectus modi amet.", 0 },
                    { 5, 22, "In sapiente quo repudiandae et deserunt qui quisquam corrupti.", 0 },
                    { 30, 22, "Sequi et saepe quos voluptate odit maiores quasi quos.", 0 },
                    { 1, 23, "Ea dolorem maiores aut nemo et dignissimos tempora aut.", 0 },
                    { 8, 23, "Error nulla totam officia expedita non voluptatibus qui.", 0 },
                    { 23, 24, "Enim ratione aliquam eos.", 0 },
                    { 25, 25, "Eius magnam omnis reiciendis libero et delectus.", 0 },
                    { 27, 26, "Laboriosam sequi sed fuga quae veniam laudantium laudantium optio dolores.", 0 },
                    { 3, 29, "Praesentium inventore deleniti enim nihil itaque.", 0 },
                    { 11, 29, "Quae blanditiis et ipsum ipsum fugiat.", 0 },
                    { 26, 29, "Accusamus distinctio illo consequatur cum ipsa.", 0 }
                });
        }
    }
}