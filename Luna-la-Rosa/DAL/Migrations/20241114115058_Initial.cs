using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "add_on_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_add_on_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bouquet_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bouquet_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bouquets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    main_color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    size = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    image = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    description = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    popularity_score = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bouquets", x => x.id);
                    table.CheckConstraint("CK_Bouquet_Size", "size IN ('Small', 'Medium', 'Large')");
                });

            migrationBuilder.CreateTable(
                name: "flower_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flower_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "User"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "add_ons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    image = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_add_ons", x => x.id);
                    table.ForeignKey(
                        name: "fk_add_ons_add_on_types_type_id",
                        column: x => x.type_id,
                        principalTable: "add_on_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bouquet_category_bouquets",
                columns: table => new
                {
                    bouquet_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bouquet_category_bouquets", x => new { x.bouquet_id, x.category_id });
                    table.ForeignKey(
                        name: "fk_bouquet_category_bouquets_bouquet_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "bouquet_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bouquet_category_bouquets_bouquets_bouquet_id",
                        column: x => x.bouquet_id,
                        principalTable: "bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flowers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    available_quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    image = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flowers", x => x.id);
                    table.ForeignKey(
                        name: "fk_flowers_flower_types_type_id",
                        column: x => x.type_id,
                        principalTable: "flower_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "custom_bouquets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_custom_bouquets", x => x.id);
                    table.ForeignKey(
                        name: "fk_custom_bouquets_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    delivery_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    delivery_address = table.Column<string>(type: "text", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.CheckConstraint("CK_Order_PaymentMethod", "payment_method IN ('Card', 'Cash on Delivery')");
                    table.ForeignKey(
                        name: "fk_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "shopping_carts",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shopping_carts", x => x.user_id);
                    table.ForeignKey(
                        name: "fk_shopping_carts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bouquet_flowers",
                columns: table => new
                {
                    bouquet_id = table.Column<int>(type: "integer", nullable: false),
                    flower_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bouquet_flowers", x => new { x.bouquet_id, x.flower_id });
                    table.ForeignKey(
                        name: "fk_bouquet_flowers_bouquets_bouquet_id",
                        column: x => x.bouquet_id,
                        principalTable: "bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bouquet_flowers_flowers_flower_id",
                        column: x => x.flower_id,
                        principalTable: "flowers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bouquet_add_ons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    custom_bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    add_on_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bouquet_add_ons", x => x.id);
                    table.ForeignKey(
                        name: "fk_bouquet_add_ons_add_ons_add_on_id",
                        column: x => x.add_on_id,
                        principalTable: "add_ons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bouquet_add_ons_bouquets_bouquet_id",
                        column: x => x.bouquet_id,
                        principalTable: "bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bouquet_add_ons_custom_bouquets_custom_bouquet_id",
                        column: x => x.custom_bouquet_id,
                        principalTable: "custom_bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "custom_bouquet_flowers",
                columns: table => new
                {
                    custom_bouquet_id = table.Column<int>(type: "integer", nullable: false),
                    flower_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_custom_bouquet_flowers", x => new { x.custom_bouquet_id, x.flower_id });
                    table.ForeignKey(
                        name: "fk_custom_bouquet_flowers_custom_bouquets_custom_bouquet_id",
                        column: x => x.custom_bouquet_id,
                        principalTable: "custom_bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_custom_bouquet_flowers_flowers_flower_id",
                        column: x => x.flower_id,
                        principalTable: "flowers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_bouquets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    custom_bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_bouquets", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_bouquets_bouquets_bouquet_id",
                        column: x => x.bouquet_id,
                        principalTable: "bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_order_bouquets_custom_bouquets_custom_bouquet_id",
                        column: x => x.custom_bouquet_id,
                        principalTable: "custom_bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_order_bouquets_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    payment_method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    transaction_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.CheckConstraint("CK_Payment_PaymentMethod", "payment_method IN ('Card', 'Cash on Delivery')");
                    table.ForeignKey(
                        name: "fk_payments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cart_id = table.Column<int>(type: "integer", nullable: false),
                    bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    custom_bouquet_id = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_items_bouquets_bouquet_id",
                        column: x => x.bouquet_id,
                        principalTable: "bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cart_items_custom_bouquets_custom_bouquet_id",
                        column: x => x.custom_bouquet_id,
                        principalTable: "custom_bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cart_items_shopping_carts_cart_id",
                        column: x => x.cart_id,
                        principalTable: "shopping_carts",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_add_ons",
                columns: table => new
                {
                    order_bouquet_id = table.Column<int>(type: "integer", nullable: false),
                    add_on_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    card_note = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_add_ons", x => new { x.order_bouquet_id, x.add_on_id });
                    table.ForeignKey(
                        name: "fk_order_add_ons_add_ons_add_on_id",
                        column: x => x.add_on_id,
                        principalTable: "add_ons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_order_add_ons_order_bouquets_order_bouquet_id",
                        column: x => x.order_bouquet_id,
                        principalTable: "order_bouquets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_item_add_ons",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "integer", nullable: false),
                    add_on_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    card_note = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_item_add_ons", x => new { x.cart_item_id, x.add_on_id });
                    table.ForeignKey(
                        name: "fk_cart_item_add_ons_add_ons_add_on_id",
                        column: x => x.add_on_id,
                        principalTable: "add_ons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cart_item_add_ons_cart_items_cart_item_id",
                        column: x => x.cart_item_id,
                        principalTable: "cart_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, new DateTime(2024, 6, 6, 17, 15, 33, 404, DateTimeKind.Utc).AddTicks(9515), "Nemo quasi dolorem.", new byte[] { 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148, 75 }, false, "ivory", "Gorgeous Wooden Shoes", 26, 12.825448612135575m, "Medium", new DateTime(2024, 11, 3, 22, 50, 34, 278, DateTimeKind.Utc).AddTicks(3306) },
                    { 2, new DateTime(2024, 2, 1, 10, 10, 19, 694, DateTimeKind.Utc).AddTicks(4412), "Nobis quasi iusto.", new byte[] { 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217, 247 }, false, "silver", "Licensed Cotton Keyboard", 85, 160.916991813535453m, "Small", new DateTime(2024, 11, 9, 11, 55, 58, 510, DateTimeKind.Utc).AddTicks(3548) },
                    { 3, new DateTime(2024, 9, 28, 1, 5, 5, 983, DateTimeKind.Utc).AddTicks(9159), "Veritatis architecto cumque.", new byte[] { 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31, 164 }, false, "teal", "Gorgeous Metal Pizza", 43, 489.222411759766755m, "Medium", new DateTime(2024, 11, 1, 1, 1, 22, 742, DateTimeKind.Utc).AddTicks(3714) },
                    { 4, new DateTime(2024, 5, 24, 16, 59, 52, 273, DateTimeKind.Utc).AddTicks(3897), "Odio architecto ut.", new byte[] { 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100, 80 }, false, "maroon", "Licensed Frozen Towels", 1, 251.889648560383228m, "Small", new DateTime(2024, 11, 6, 14, 6, 46, 974, DateTimeKind.Utc).AddTicks(3869) },
                    { 5, new DateTime(2024, 1, 19, 9, 54, 38, 562, DateTimeKind.Utc).AddTicks(8642), "Illum architecto labore.", new byte[] { 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170, 252 }, false, "orchid", "Incredible Plastic Ball", 60, 0m, "Medium", new DateTime(2024, 11, 12, 3, 12, 11, 206, DateTimeKind.Utc).AddTicks(4031) },
                    { 6, new DateTime(2024, 9, 15, 0, 49, 24, 852, DateTimeKind.Utc).AddTicks(3379), "Consectetur beatae quas.", new byte[] { 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239, 169 }, false, "fuchsia", "Refined Rubber Chips", 18, 183.134031854166448m, "Large", new DateTime(2024, 11, 3, 16, 17, 35, 438, DateTimeKind.Utc).AddTicks(4188) },
                    { 7, new DateTime(2024, 5, 11, 16, 44, 11, 141, DateTimeKind.Utc).AddTicks(8106), "Similique beatae est.", new byte[] { 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53, 85 }, false, "green", "Fantastic Fresh Tuna", 77, 7.7736311619047194m, "Medium", new DateTime(2024, 11, 9, 5, 22, 59, 670, DateTimeKind.Utc).AddTicks(4334) },
                    { 8, new DateTime(2024, 1, 6, 9, 38, 57, 431, DateTimeKind.Utc).AddTicks(2835), "Rerum vitae eaque.", new byte[] { 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122, 1 }, false, "black", "Unbranded Wooden Pants", 35, 426.036659462394543m, "Large", new DateTime(2024, 10, 31, 18, 28, 23, 902, DateTimeKind.Utc).AddTicks(4480) },
                    { 9, new DateTime(2024, 9, 2, 0, 33, 43, 720, DateTimeKind.Utc).AddTicks(7569), "Quia vitae nemo.", new byte[] { 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191, 174 }, false, "turquoise", "Practical Granite Car", 94, 291.799185727163508m, "Small", new DateTime(2024, 11, 6, 7, 33, 48, 134, DateTimeKind.Utc).AddTicks(4635) },
                    { 10, new DateTime(2024, 4, 28, 16, 28, 30, 10, DateTimeKind.Utc).AddTicks(2298), "Cumque dicta in.", new byte[] { 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5, 90 }, false, "magenta", "Tasty Soft Cheese", 52, 281.388732479600820m, "Large", new DateTime(2024, 11, 11, 20, 39, 12, 366, DateTimeKind.Utc).AddTicks(4781) },
                    { 11, new DateTime(2023, 12, 24, 9, 23, 16, 299, DateTimeKind.Utc).AddTicks(7025), "Beatae dicta voluptas.", new byte[] { 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74, 6 }, false, "azure", "Sleek Steel Table", 10, 107.1945399978172951m, "Small", new DateTime(2024, 11, 3, 9, 44, 36, 598, DateTimeKind.Utc).AddTicks(4926) },
                    { 12, new DateTime(2024, 8, 20, 0, 18, 2, 589, DateTimeKind.Utc).AddTicks(1753), "Blanditiis sunt aut.", new byte[] { 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144, 179 }, false, "yellow", "Tasty Plastic Keyboard", 69, 253.8870095950024694m, "Medium", new DateTime(2024, 11, 8, 22, 50, 0, 830, DateTimeKind.Utc).AddTicks(5074) },
                    { 13, new DateTime(2024, 4, 15, 16, 12, 48, 878, DateTimeKind.Utc).AddTicks(6479), "Fugiat sunt autem.", new byte[] { 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213, 95 }, false, "pink", "Sleek Rubber Pizza", 27, 28.138873247960082m, "Small", new DateTime(2024, 10, 31, 11, 55, 25, 62, DateTimeKind.Utc).AddTicks(5217) },
                    { 14, new DateTime(2023, 12, 11, 9, 7, 35, 168, DateTimeKind.Utc).AddTicks(1215), "Non explicabo facilis.", new byte[] { 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27, 11 }, false, "sky blue", "Small Frozen Towels", 86, 15.896536649622264m, "Medium", new DateTime(2024, 11, 6, 1, 0, 49, 294, DateTimeKind.Utc).AddTicks(5373) },
                    { 15, new DateTime(2024, 8, 7, 0, 2, 21, 457, DateTimeKind.Utc).AddTicks(5943), "Officia explicabo repudiandae.", new byte[] { 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96, 184 }, false, "ivory", "Awesome Concrete Ball", 44, 45.669674235707860m, "Large", new DateTime(2024, 11, 11, 14, 6, 13, 526, DateTimeKind.Utc).AddTicks(5521) },
                    { 16, new DateTime(2024, 4, 2, 15, 57, 7, 747, DateTimeKind.Utc).AddTicks(670), "Delectus aspernatur dolor.", new byte[] { 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165, 100 }, false, "silver", "Ergonomic Granite Sausages", 2, 63.9347409205207827m, "Medium", new DateTime(2024, 11, 3, 3, 11, 37, 758, DateTimeKind.Utc).AddTicks(5665) },
                    { 17, new DateTime(2023, 11, 28, 8, 51, 54, 36, DateTimeKind.Utc).AddTicks(5395), "Nisi aspernatur ducimus.", new byte[] { 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235, 16 }, false, "mint green", "Generic Soft Tuna", 61, 100.15797754244778m, "Large", new DateTime(2024, 11, 8, 16, 17, 1, 990, DateTimeKind.Utc).AddTicks(5809) },
                    { 18, new DateTime(2024, 7, 24, 23, 46, 40, 326, DateTimeKind.Utc).AddTicks(131), "Quisquam aut porro.", new byte[] { 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48, 189 }, false, "maroon", "Rustic Wooden Pants", 19, 0m, "Small", new DateTime(2024, 11, 14, 5, 22, 26, 222, DateTimeKind.Utc).AddTicks(5965) },
                    { 19, new DateTime(2024, 3, 20, 16, 41, 26, 615, DateTimeKind.Utc).AddTicks(4858), "Aspernatur aut voluptatibus.", new byte[] { 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118, 105 }, false, "orchid", "Handcrafted Cotton Car", 78, 151.323291827143697m, "Large", new DateTime(2024, 11, 5, 18, 27, 50, 454, DateTimeKind.Utc).AddTicks(6109) },
                    { 20, new DateTime(2023, 11, 15, 8, 36, 12, 904, DateTimeKind.Utc).AddTicks(9583), "Voluptatum odit magnam.", new byte[] { 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187, 21 }, false, "gold", "Rustic Metal Fish", 36, 8.638050181156997m, "Small", new DateTime(2024, 11, 11, 7, 33, 14, 686, DateTimeKind.Utc).AddTicks(6253) },
                    { 21, new DateTime(2024, 7, 11, 23, 30, 59, 194, DateTimeKind.Utc).AddTicks(4309), "At odit sint.", new byte[] { 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1, 194 }, false, "green", "Handcrafted Frozen Table", 95, 265.745365301959770m, "Large", new DateTime(2024, 11, 2, 20, 38, 38, 918, DateTimeKind.Utc).AddTicks(6399) },
                    { 22, new DateTime(2024, 3, 7, 16, 25, 45, 483, DateTimeKind.Utc).AddTicks(9048), "Incidunt aut repellendus.", new byte[] { 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70, 110 }, false, "white", "Intelligent Concrete Keyboard", 53, 0m, "Small", new DateTime(2024, 11, 8, 9, 44, 3, 150, DateTimeKind.Utc).AddTicks(6555) },
                    { 23, new DateTime(2024, 11, 2, 8, 20, 31, 773, DateTimeKind.Utc).AddTicks(3776), "Est aut illo.", new byte[] { 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140, 26 }, false, "turquoise", "Handmade Rubber Pizza", 11, 296.010970633482165m, "Medium", new DateTime(2024, 11, 13, 22, 49, 27, 382, DateTimeKind.Utc).AddTicks(6703) },
                    { 24, new DateTime(2024, 6, 28, 23, 15, 18, 62, DateTimeKind.Utc).AddTicks(8500), "Maiores fugit voluptatem.", new byte[] { 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209, 199 }, false, "magenta", "Gorgeous Fresh Towels", 70, 127.432431771155702m, "Small", new DateTime(2024, 11, 5, 11, 54, 51, 614, DateTimeKind.Utc).AddTicks(6847) },
                    { 25, new DateTime(2024, 2, 23, 16, 10, 4, 352, DateTimeKind.Utc).AddTicks(3227), "Commodi fugit officia.", new byte[] { 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22, 115 }, false, "cyan", "Licensed Wooden Bike", 28, 519.620786034325221m, "Medium", new DateTime(2024, 11, 11, 1, 0, 15, 846, DateTimeKind.Utc).AddTicks(6990) },
                    { 26, new DateTime(2024, 10, 20, 7, 4, 50, 641, DateTimeKind.Utc).AddTicks(7955), "Quod sed at.", new byte[] { 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92, 31 }, false, "yellow", "Incredible Cotton Sausages", 87, 252.383289298221026m, "Large", new DateTime(2024, 11, 2, 14, 5, 40, 78, DateTimeKind.Utc).AddTicks(7139) },
                    { 27, new DateTime(2024, 6, 15, 22, 59, 36, 931, DateTimeKind.Utc).AddTicks(2679), "Fugit sed quia.", new byte[] { 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161, 204 }, false, "orange", "Refined Soft Tuna", 45, 43.616438151624273m, "Medium", new DateTime(2024, 11, 8, 3, 11, 4, 310, DateTimeKind.Utc).AddTicks(7281) },
                    { 28, new DateTime(2024, 2, 10, 15, 54, 23, 220, DateTimeKind.Utc).AddTicks(7407), "Quos quia reprehenderit.", new byte[] { 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231, 120 }, false, "sky blue", "Fantastic Steel Pants", 3, 108.774249401304143m, "Large", new DateTime(2024, 11, 13, 16, 16, 28, 542, DateTimeKind.Utc).AddTicks(7427) },
                    { 29, new DateTime(2024, 10, 7, 6, 49, 9, 510, DateTimeKind.Utc).AddTicks(2133), "Accusamus quia expedita.", new byte[] { 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44, 36 }, false, "ivory", "Refined Plastic Chair", 62, 339.140616388591128m, "Small", new DateTime(2024, 11, 5, 5, 21, 52, 774, DateTimeKind.Utc).AddTicks(7572) },
                    { 30, new DateTime(2024, 6, 2, 22, 43, 55, 799, DateTimeKind.Utc).AddTicks(6864), "Dolore consequuntur molestiae.", new byte[] { 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114, 209 }, false, "lavender", "Fantastic Rubber Fish", 20, 46.77527729551086m, "Large", new DateTime(2024, 11, 10, 18, 27, 17, 6, DateTimeKind.Utc).AddTicks(7723) }
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
                    { 1, new DateTime(2024, 3, 12, 7, 5, 14, 460, DateTimeKind.Utc).AddTicks(859), "Bernita_Konopelski43@gmail.com", "Pedro", "Hackett", "Ay7ZbbzDk0", "976-609-8805 x52963", "User", new DateTime(2024, 11, 5, 0, 14, 57, 422, DateTimeKind.Utc).AddTicks(8997) },
                    { 2, new DateTime(2024, 8, 10, 2, 27, 5, 875, DateTimeKind.Utc).AddTicks(9147), "Guillermo.Cummerata30@hotmail.com", "Sonya", "Schulist", "lJ5hPDb6ee", "(969) 291-0386 x7600", "User", new DateTime(2024, 11, 7, 11, 55, 25, 30, DateTimeKind.Utc).AddTicks(4380) },
                    { 3, new DateTime(2024, 5, 14, 3, 43, 15, 939, DateTimeKind.Utc).AddTicks(4202), "Max56@gmail.com", "Nils", "Kreiger", "17yADOlbuq", "609-545-5342", "User", new DateTime(2024, 11, 13, 14, 25, 39, 461, DateTimeKind.Utc).AddTicks(6301) },
                    { 4, new DateTime(2024, 10, 31, 1, 39, 17, 304, DateTimeKind.Utc).AddTicks(7188), "Yoshiko.Maggio@hotmail.com", "Karina", "Krajcik", "bJLg6XDTjR", "886.440.0316 x3659", "User", new DateTime(2024, 11, 1, 9, 14, 50, 879, DateTimeKind.Utc).AddTicks(4670) },
                    { 5, new DateTime(2024, 9, 2, 11, 18, 27, 798, DateTimeKind.Utc).AddTicks(2070), "Edd.Gislason@yahoo.com", "Clare", "Roberts", "xzXCMm7Moj", "810-973-1391", "Admin", new DateTime(2024, 11, 3, 8, 14, 7, 507, DateTimeKind.Utc).AddTicks(7334) },
                    { 6, new DateTime(2024, 11, 6, 1, 53, 25, 940, DateTimeKind.Utc).AddTicks(8265), "Kobe_Windler80@hotmail.com", "Micheal", "Spencer", "XJdNcgX1iD", "601-423-0429 x4071", "Admin", new DateTime(2024, 11, 14, 11, 41, 5, 434, DateTimeKind.Utc).AddTicks(3259) },
                    { 7, new DateTime(2024, 1, 16, 3, 19, 26, 111, DateTimeKind.Utc).AddTicks(5686), "Sasha36@yahoo.com", "Albina", "Rogahn", "zpqJxJsFlr", "330.590.4772 x110", "User", new DateTime(2024, 11, 12, 8, 56, 48, 452, DateTimeKind.Utc).AddTicks(5981) },
                    { 8, new DateTime(2024, 2, 27, 11, 28, 38, 700, DateTimeKind.Utc).AddTicks(9715), "Casimir81@hotmail.com", "Hans", "Thompson", "TNK51cW5zt", "446-886-7515 x51416", "Admin", new DateTime(2024, 11, 7, 11, 53, 23, 696, DateTimeKind.Utc).AddTicks(1774) },
                    { 9, new DateTime(2024, 5, 10, 3, 32, 7, 389, DateTimeKind.Utc).AddTicks(5376), "Jada.Beer@yahoo.com", "Adolphus", "Bednar", "HyzXwNmVwk", "1-336-620-3589 x271", "User", new DateTime(2024, 11, 2, 2, 41, 17, 138, DateTimeKind.Utc).AddTicks(5821) },
                    { 10, new DateTime(2024, 5, 17, 13, 42, 3, 898, DateTimeKind.Utc).AddTicks(3334), "Neva_Rosenbaum29@hotmail.com", "Shawn", "Hagenes", "DK4P_2z1QR", "1-932-211-3106", "User", new DateTime(2024, 11, 2, 17, 28, 0, 559, DateTimeKind.Utc).AddTicks(7228) },
                    { 11, new DateTime(2024, 2, 5, 22, 17, 47, 376, DateTimeKind.Utc).AddTicks(1215), "Alvera.Koch17@yahoo.com", "Sebastian", "Sanford", "oE22uNmVSp", "559-623-7242 x1822", "Admin", new DateTime(2024, 11, 8, 17, 13, 31, 913, DateTimeKind.Utc).AddTicks(725) },
                    { 12, new DateTime(2024, 8, 2, 20, 48, 13, 359, DateTimeKind.Utc).AddTicks(43), "Eula62@hotmail.com", "Abby", "Willms", "KKboscDQvI", "828-222-1876 x612", "Admin", new DateTime(2024, 10, 31, 21, 43, 57, 509, DateTimeKind.Utc).AddTicks(9806) },
                    { 13, new DateTime(2024, 4, 24, 15, 20, 56, 484, DateTimeKind.Utc).AddTicks(6346), "Lonnie7@yahoo.com", "Kieran", "Wiza", "weWrZV6AS1", "(215) 798-5313 x72534", "User", new DateTime(2024, 11, 4, 1, 40, 10, 102, DateTimeKind.Utc).AddTicks(4936) },
                    { 14, new DateTime(2024, 7, 13, 4, 23, 45, 508, DateTimeKind.Utc).AddTicks(841), "Tiana_Lueilwitz@gmail.com", "Omari", "Rogahn", "k0LcIYE8gj", "(262) 739-0593 x4331", "Admin", new DateTime(2024, 11, 7, 1, 22, 0, 949, DateTimeKind.Utc).AddTicks(4153) },
                    { 15, new DateTime(2024, 4, 7, 13, 49, 18, 64, DateTimeKind.Utc).AddTicks(9612), "Dagmar_Funk66@yahoo.com", "Dora", "Dach", "ol0y9MElRR", "861.974.3384", "User", new DateTime(2024, 11, 1, 17, 26, 39, 284, DateTimeKind.Utc).AddTicks(2457) },
                    { 16, new DateTime(2024, 8, 2, 12, 20, 28, 217, DateTimeKind.Utc).AddTicks(3619), "Johnson.Wilderman54@gmail.com", "Maurice", "Mueller", "Lz0k1WvPyi", "(869) 790-6732", "User", new DateTime(2024, 11, 10, 12, 5, 39, 721, DateTimeKind.Utc).AddTicks(66) },
                    { 17, new DateTime(2024, 4, 5, 3, 39, 54, 831, DateTimeKind.Utc).AddTicks(1531), "Quinten88@yahoo.com", "Jaiden", "Lubowitz", "GQSmfsRurB", "349-814-5419", "User", new DateTime(2024, 11, 6, 17, 2, 48, 731, DateTimeKind.Utc).AddTicks(7894) },
                    { 18, new DateTime(2024, 4, 29, 16, 43, 0, 777, DateTimeKind.Utc).AddTicks(1826), "Aylin.Heller@gmail.com", "Diego", "Barton", "L3vTQoW9H3", "1-548-255-8154", "Admin", new DateTime(2024, 11, 1, 7, 46, 49, 585, DateTimeKind.Utc).AddTicks(6355) },
                    { 19, new DateTime(2023, 11, 16, 11, 3, 35, 198, DateTimeKind.Utc).AddTicks(4284), "Giuseppe_Beatty@yahoo.com", "Marcia", "MacGyver", "GaAupi2_P3", "1-473-524-9425 x7357", "User", new DateTime(2024, 10, 31, 15, 17, 42, 739, DateTimeKind.Utc).AddTicks(8729) },
                    { 20, new DateTime(2024, 3, 29, 0, 21, 16, 583, DateTimeKind.Utc).AddTicks(2419), "Marley.Rogahn3@gmail.com", "Nico", "Hilpert", "rMJDsQ9E4M", "710-501-5734", "Admin", new DateTime(2024, 11, 6, 3, 7, 46, 944, DateTimeKind.Utc).AddTicks(1869) },
                    { 21, new DateTime(2024, 3, 6, 1, 6, 28, 740, DateTimeKind.Utc).AddTicks(3849), "Wilfredo68@hotmail.com", "Frida", "Rosenbaum", "vVhqEa7JYS", "939-799-7596", "User", new DateTime(2024, 11, 1, 8, 12, 1, 429, DateTimeKind.Utc).AddTicks(9155) },
                    { 22, new DateTime(2024, 7, 24, 8, 17, 13, 384, DateTimeKind.Utc).AddTicks(7369), "Donny13@gmail.com", "Bernie", "Nicolas", "jhMbDOgvDi", "(827) 778-6836", "Admin", new DateTime(2024, 11, 11, 0, 25, 42, 107, DateTimeKind.Utc).AddTicks(8540) },
                    { 23, new DateTime(2024, 10, 25, 3, 32, 12, 298, DateTimeKind.Utc).AddTicks(8665), "Kennedy_Sporer@hotmail.com", "Elinore", "Ernser", "4ng6HJIER8", "(509) 937-9866 x55567", "User", new DateTime(2024, 11, 10, 13, 7, 8, 811, DateTimeKind.Utc).AddTicks(8044) },
                    { 24, new DateTime(2024, 6, 27, 0, 2, 12, 587, DateTimeKind.Utc).AddTicks(3768), "Rylee.Little53@gmail.com", "America", "Windler", "My3zjzsYeG", "640.379.5089 x745", "Admin", new DateTime(2024, 11, 2, 14, 5, 19, 506, DateTimeKind.Utc).AddTicks(6299) },
                    { 25, new DateTime(2024, 3, 17, 8, 37, 56, 65, DateTimeKind.Utc).AddTicks(1664), "Candelario.Flatley40@hotmail.com", "Camila", "Moen", "NcmMMCOA4h", "324-503-6387 x461", "Admin", new DateTime(2024, 11, 8, 13, 50, 50, 859, DateTimeKind.Utc).AddTicks(9810) },
                    { 26, new DateTime(2024, 7, 26, 22, 55, 11, 531, DateTimeKind.Utc).AddTicks(1267), "Isabell94@gmail.com", "Bette", "Homenick", "TN2qJhP19k", "431.322.2770", "Admin", new DateTime(2024, 11, 3, 23, 2, 41, 312, DateTimeKind.Utc).AddTicks(434) },
                    { 27, new DateTime(2024, 6, 22, 13, 55, 4, 124, DateTimeKind.Utc).AddTicks(4495), "Myrtle39@hotmail.com", "Odessa", "Jakubowski", "51S2Qst4eF", "(638) 514-0815 x160", "Admin", new DateTime(2024, 11, 3, 13, 16, 29, 49, DateTimeKind.Utc).AddTicks(680) },
                    { 28, new DateTime(2024, 5, 29, 0, 6, 31, 195, DateTimeKind.Utc).AddTicks(545), "Alexanne_Hayes@yahoo.com", "Carlie", "Lind", "JNIXwsWQAI", "1-745-800-2658 x5649", "User", new DateTime(2024, 11, 12, 13, 24, 57, 266, DateTimeKind.Utc).AddTicks(5261) },
                    { 29, new DateTime(2024, 4, 25, 5, 54, 24, 499, DateTimeKind.Utc).AddTicks(7672), "Erick.Batz90@hotmail.com", "Sandra", "O'Kon", "uUVTKS_tS0", "509.977.0013 x477", "Admin", new DateTime(2024, 11, 11, 17, 40, 38, 98, DateTimeKind.Utc).AddTicks(9311) },
                    { 30, new DateTime(2024, 2, 17, 9, 52, 12, 952, DateTimeKind.Utc).AddTicks(816), "Lilian_Rippin77@yahoo.com", "Tomas", "Schmitt", "ANaEt8hLXN", "268-672-8223", "User", new DateTime(2024, 11, 12, 20, 10, 57, 540, DateTimeKind.Utc).AddTicks(5550) }
                });

            migrationBuilder.InsertData(
                table: "add_ons",
                columns: new[] { "id", "created_at", "image", "is_deleted", "name", "price", "type_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 25, 10, 42, 38, 91, DateTimeKind.Utc).AddTicks(442), new byte[] { 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148, 75 }, false, "Ergonomic Granite Cheese", 13.492858981943158m, 2 },
                    { 2, new DateTime(2024, 3, 9, 9, 20, 22, 126, DateTimeKind.Utc).AddTicks(778), new byte[] { 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217, 247 }, false, "Fantastic Wooden Chips", 3.071088037486689m, 4 },
                    { 3, new DateTime(2024, 10, 23, 5, 58, 6, 161, DateTimeKind.Utc).AddTicks(369), new byte[] { 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31, 164 }, false, "Handcrafted Fresh Mouse", 11.649317093030239m, 2 },
                    { 4, new DateTime(2024, 6, 7, 3, 35, 50, 195, DateTimeKind.Utc).AddTicks(9945), new byte[] { 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100, 80 }, false, "Tasty Rubber Shirt", 1.2275461485737681m, 5 },
                    { 5, new DateTime(2024, 1, 21, 2, 13, 34, 230, DateTimeKind.Utc).AddTicks(9528), new byte[] { 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170, 252 }, false, "Gorgeous Concrete Tuna", 9.805775204117301m, 2 },
                    { 6, new DateTime(2024, 9, 4, 22, 51, 18, 265, DateTimeKind.Utc).AddTicks(9095), new byte[] { 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239, 169 }, false, "Awesome Frozen Pizza", 18.384004259660832m, 5 },
                    { 7, new DateTime(2024, 4, 19, 20, 29, 2, 300, DateTimeKind.Utc).AddTicks(8663), new byte[] { 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53, 85 }, false, "Refined Metal Car", 7.962233315204382m, 2 },
                    { 8, new DateTime(2023, 12, 3, 19, 6, 46, 335, DateTimeKind.Utc).AddTicks(8228), new byte[] { 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122, 1 }, false, "Rustic Plastic Ball", 16.540462370747913m, 5 },
                    { 9, new DateTime(2024, 7, 18, 15, 44, 30, 370, DateTimeKind.Utc).AddTicks(7793), new byte[] { 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191, 174 }, false, "Practical Steel Shoes", 6.118691426291444m, 3 },
                    { 10, new DateTime(2024, 3, 2, 14, 22, 14, 405, DateTimeKind.Utc).AddTicks(7357), new byte[] { 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5, 90 }, false, "Handmade Soft Chicken", 14.696920481834994m, 5 },
                    { 11, new DateTime(2024, 10, 16, 10, 59, 58, 440, DateTimeKind.Utc).AddTicks(6928), new byte[] { 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74, 6 }, false, "Small Granite Salad", 4.275149537378525m, 3 },
                    { 12, new DateTime(2024, 5, 31, 8, 37, 42, 475, DateTimeKind.Utc).AddTicks(6495), new byte[] { 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144, 179 }, false, "Incredible Wooden Computer", 12.853378592922056m, 5 },
                    { 13, new DateTime(2024, 1, 14, 7, 15, 26, 510, DateTimeKind.Utc).AddTicks(6058), new byte[] { 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213, 95 }, false, "Generic Fresh Gloves", 2.4316076484656003m, 3 },
                    { 14, new DateTime(2024, 8, 29, 3, 53, 10, 545, DateTimeKind.Utc).AddTicks(5621), new byte[] { 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27, 11 }, false, "Unbranded Rubber Towels", 11.009836704009137m, 1 },
                    { 15, new DateTime(2024, 4, 13, 1, 30, 54, 580, DateTimeKind.Utc).AddTicks(5181), new byte[] { 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96, 184 }, false, "Intelligent Concrete Cheese", 19.588065759552668m, 3 },
                    { 16, new DateTime(2023, 11, 27, 0, 8, 38, 615, DateTimeKind.Utc).AddTicks(4743), new byte[] { 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165, 100 }, false, "Sleek Frozen Chips", 9.166294815096218m, 1 },
                    { 17, new DateTime(2024, 7, 11, 20, 46, 22, 650, DateTimeKind.Utc).AddTicks(4312), new byte[] { 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235, 16 }, false, "Licensed Metal Mouse", 17.744523870639749m, 4 },
                    { 18, new DateTime(2024, 2, 24, 19, 24, 6, 685, DateTimeKind.Utc).AddTicks(3875), new byte[] { 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48, 189 }, false, "Ergonomic Plastic Shirt", 7.32275292618328m, 1 },
                    { 19, new DateTime(2024, 10, 9, 16, 1, 50, 720, DateTimeKind.Utc).AddTicks(3438), new byte[] { 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118, 105 }, false, "Fantastic Steel Soap", 15.90098198172683m, 4 },
                    { 20, new DateTime(2024, 5, 24, 13, 39, 34, 755, DateTimeKind.Utc).AddTicks(3000), new byte[] { 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187, 21 }, false, "Handcrafted Soft Bacon", 5.479211037270361m, 1 },
                    { 21, new DateTime(2024, 1, 7, 12, 17, 18, 790, DateTimeKind.Utc).AddTicks(2560), new byte[] { 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1, 194 }, false, "Tasty Cotton Chair", 14.057440092813892m, 4 },
                    { 22, new DateTime(2024, 8, 22, 8, 55, 2, 825, DateTimeKind.Utc).AddTicks(2123), new byte[] { 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70, 110 }, false, "Gorgeous Wooden Ball", 3.635669148357423m, 2 },
                    { 23, new DateTime(2024, 4, 6, 6, 32, 46, 860, DateTimeKind.Utc).AddTicks(1683), new byte[] { 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140, 26 }, false, "Awesome Fresh Shoes", 12.213898203900973m, 4 },
                    { 24, new DateTime(2023, 11, 20, 5, 10, 30, 895, DateTimeKind.Utc).AddTicks(1252), new byte[] { 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209, 199 }, false, "Refined Granite Chicken", 1.792127259444504m, 2 },
                    { 25, new DateTime(2024, 7, 5, 1, 48, 14, 930, DateTimeKind.Utc).AddTicks(814), new byte[] { 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22, 115 }, false, "Rustic Concrete Salad", 10.370356314988035m, 4 },
                    { 26, new DateTime(2024, 2, 18, 0, 25, 58, 965, DateTimeKind.Utc).AddTicks(376), new byte[] { 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92, 31 }, false, "Practical Frozen Computer", 18.948585370531585m, 2 },
                    { 27, new DateTime(2024, 10, 2, 21, 3, 42, 999, DateTimeKind.Utc).AddTicks(9937), new byte[] { 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161, 204 }, false, "Handmade Metal Gloves", 8.526814426075116m, 5 },
                    { 28, new DateTime(2024, 5, 17, 18, 41, 27, 34, DateTimeKind.Utc).AddTicks(9501), new byte[] { 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231, 120 }, false, "Small Plastic Hat", 17.105043481618647m, 2 },
                    { 29, new DateTime(2023, 12, 31, 17, 19, 11, 69, DateTimeKind.Utc).AddTicks(9061), new byte[] { 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44, 36 }, false, "Incredible Steel Fish", 6.683272537162197m, 5 },
                    { 30, new DateTime(2024, 8, 15, 13, 56, 55, 104, DateTimeKind.Utc).AddTicks(8630), new byte[] { 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114, 209 }, false, "Generic Soft Chips", 15.261501592705728m, 2 }
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
                    { 1, new DateTime(2024, 11, 11, 4, 6, 49, 916, DateTimeKind.Utc).AddTicks(8756), 0m, 8 },
                    { 2, new DateTime(2024, 11, 2, 8, 51, 8, 860, DateTimeKind.Utc).AddTicks(2313), 105.867808293489768m, 24 },
                    { 3, new DateTime(2024, 10, 24, 12, 35, 27, 803, DateTimeKind.Utc).AddTicks(4446), 476.396963147631180m, 9 },
                    { 4, new DateTime(2024, 10, 15, 17, 19, 46, 746, DateTimeKind.Utc).AddTicks(6567), 173.537385522172556m, 25 },
                    { 5, new DateTime(2024, 11, 5, 23, 4, 5, 689, DateTimeKind.Utc).AddTicks(8688), 91.252610928496615m, 11 },
                    { 6, new DateTime(2024, 10, 28, 3, 48, 24, 633, DateTimeKind.Utc).AddTicks(798), 183.134031854166448m, 26 },
                    { 7, new DateTime(2024, 10, 19, 7, 32, 43, 576, DateTimeKind.Utc).AddTicks(2904), 73.9354806448963714m, 12 },
                    { 8, new DateTime(2024, 11, 9, 13, 17, 2, 519, DateTimeKind.Utc).AddTicks(5010), 426.036659462394543m, 28 },
                    { 9, new DateTime(2024, 10, 31, 18, 1, 21, 462, DateTimeKind.Utc).AddTicks(7118), 206.025785835937254m, 13 },
                    { 10, new DateTime(2024, 10, 22, 21, 45, 40, 405, DateTimeKind.Utc).AddTicks(9224), 293.673084629547576m, 29 },
                    { 11, new DateTime(2024, 11, 13, 3, 29, 59, 349, DateTimeKind.Utc).AddTicks(1329), 117.0003152019345961m, 15 },
                    { 12, new DateTime(2024, 11, 4, 8, 14, 18, 292, DateTimeKind.Utc).AddTicks(3435), 266.1713617449492254m, 30 },
                    { 13, new DateTime(2024, 10, 26, 11, 58, 37, 235, DateTimeKind.Utc).AddTicks(5541), 77.167749268546587m, 16 },
                    { 14, new DateTime(2024, 10, 17, 16, 42, 56, 178, DateTimeKind.Utc).AddTicks(7654), 0m, 2 },
                    { 15, new DateTime(2024, 11, 7, 22, 27, 15, 121, DateTimeKind.Utc).AddTicks(9762), 45.669674235707860m, 17 },
                    { 16, new DateTime(2024, 10, 30, 3, 11, 34, 65, DateTimeKind.Utc).AddTicks(1867), 30.5183782347097977m, 3 },
                    { 17, new DateTime(2024, 10, 21, 6, 55, 53, 8, DateTimeKind.Utc).AddTicks(3975), 157.003733654042535m, 19 },
                    { 18, new DateTime(2024, 11, 11, 12, 40, 11, 951, DateTimeKind.Utc).AddTicks(6084), 33.416362685810985m, 4 },
                    { 19, new DateTime(2024, 11, 2, 17, 24, 30, 894, DateTimeKind.Utc).AddTicks(8190), 128.150971548702002m, 20 },
                    { 20, new DateTime(2024, 10, 24, 21, 8, 49, 838, DateTimeKind.Utc).AddTicks(297), 8.638050181156997m, 6 },
                    { 21, new DateTime(2024, 10, 16, 1, 53, 8, 781, DateTimeKind.Utc).AddTicks(2403), 185.727288911923320m, 21 },
                    { 22, new DateTime(2024, 11, 6, 7, 37, 27, 724, DateTimeKind.Utc).AddTicks(4508), 0m, 7 },
                    { 23, new DateTime(2024, 10, 28, 12, 21, 46, 667, DateTimeKind.Utc).AddTicks(6622), 355.824985523626779m, 23 },
                    { 24, new DateTime(2024, 10, 19, 16, 6, 5, 610, DateTimeKind.Utc).AddTicks(8729), 127.432431771155702m, 8 },
                    { 25, new DateTime(2024, 11, 9, 21, 50, 24, 554, DateTimeKind.Utc).AddTicks(834), 525.099997071595582m, 24 },
                    { 26, new DateTime(2024, 11, 1, 2, 34, 43, 497, DateTimeKind.Utc).AddTicks(2942), 181.405193815662030m, 10 },
                    { 27, new DateTime(2024, 10, 23, 6, 19, 2, 440, DateTimeKind.Utc).AddTicks(5045), 38.137227114353912m, 25 },
                    { 28, new DateTime(2024, 11, 13, 12, 3, 21, 383, DateTimeKind.Utc).AddTicks(7149), 55.540677789384896m, 11 },
                    { 29, new DateTime(2024, 11, 4, 16, 47, 40, 326, DateTimeKind.Utc).AddTicks(9256), 339.140616388591128m, 27 },
                    { 30, new DateTime(2024, 10, 26, 20, 31, 59, 270, DateTimeKind.Utc).AddTicks(1360), 111.018685611439244m, 12 }
                });

            migrationBuilder.InsertData(
                table: "flowers",
                columns: new[] { "id", "available_quantity", "color", "created_at", "image", "is_deleted", "name", "price", "type_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 77, "yellow", new DateTime(2024, 4, 24, 11, 10, 35, 489, DateTimeKind.Utc).AddTicks(2317), new byte[] { 64, 151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165, 74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163, 40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189, 63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144, 180, 62, 7, 253, 177, 146, 205, 125, 148 }, false, "Rose yellow", 23.883523313740054m, 1, new DateTime(2024, 11, 10, 5, 1, 28, 344, DateTimeKind.Utc).AddTicks(2334) },
                    { 2, 99, "maroon", new DateTime(2023, 12, 23, 12, 46, 19, 261, DateTimeKind.Utc).AddTicks(2184), new byte[] { 36, 185, 227, 111, 124, 56, 152, 183, 221, 32, 11, 193, 22, 30, 236, 46, 240, 189, 22, 70, 242, 169, 230, 147, 108, 98, 105, 51, 239, 133, 90, 185, 10, 83, 176, 245, 168, 71, 129, 47, 255, 114, 188, 101, 43, 174, 82, 135, 80, 29, 184, 180, 125, 127, 163, 122, 210, 79, 3, 25, 206, 100, 199, 87, 198, 81, 182, 194, 109, 247, 134, 168, 60, 230, 70, 128, 237, 129, 104, 189, 16, 226, 227, 209, 204, 165, 60, 139, 176, 54, 34, 88, 67, 103, 97, 155, 170, 100, 159, 217 }, false, "Orchid maroon", 9.133934847141572m, 3, new DateTime(2024, 11, 4, 22, 14, 43, 143, DateTimeKind.Utc).AddTicks(4037) },
                    { 3, 20, "magenta", new DateTime(2024, 8, 22, 12, 22, 3, 33, DateTimeKind.Utc).AddTicks(1850), new byte[] { 7, 219, 227, 58, 99, 160, 50, 39, 80, 164, 163, 189, 140, 110, 200, 39, 204, 31, 222, 234, 117, 207, 39, 221, 248, 74, 197, 199, 65, 39, 242, 91, 168, 195, 210, 103, 1, 139, 224, 160, 240, 169, 36, 114, 102, 185, 124, 247, 84, 82, 223, 125, 120, 27, 51, 56, 179, 5, 66, 24, 219, 107, 230, 41, 177, 71, 21, 200, 155, 97, 37, 64, 62, 61, 249, 204, 171, 181, 119, 62, 205, 206, 114, 239, 71, 116, 227, 140, 144, 154, 179, 252, 72, 199, 197, 133, 195, 250, 193, 31 }, false, "Rose magenta", 43.384346380543139m, 1, new DateTime(2024, 11, 13, 15, 27, 57, 942, DateTimeKind.Utc).AddTicks(5632) },
                    { 4, 41, "silver", new DateTime(2024, 4, 21, 12, 57, 46, 805, DateTimeKind.Utc).AddTicks(1507), new byte[] { 235, 253, 226, 6, 74, 8, 204, 152, 196, 39, 58, 186, 1, 191, 164, 32, 168, 129, 166, 141, 249, 245, 104, 39, 132, 50, 32, 90, 147, 201, 139, 253, 70, 51, 245, 218, 91, 207, 64, 17, 225, 224, 140, 127, 161, 196, 166, 102, 89, 134, 6, 70, 115, 184, 195, 245, 148, 187, 129, 24, 232, 113, 4, 251, 156, 60, 116, 206, 202, 202, 197, 216, 65, 148, 172, 24, 104, 232, 133, 191, 139, 186, 0, 13, 194, 68, 138, 142, 111, 255, 69, 160, 78, 40, 41, 111, 219, 145, 227, 100 }, false, "Orchid silver", 28.634757913944657m, 3, new DateTime(2024, 11, 8, 8, 41, 12, 741, DateTimeKind.Utc).AddTicks(7219) },
                    { 5, 63, "black", new DateTime(2023, 12, 20, 14, 33, 30, 577, DateTimeKind.Utc).AddTicks(1157), new byte[] { 206, 30, 226, 209, 49, 113, 101, 9, 56, 171, 210, 183, 118, 16, 128, 26, 132, 228, 110, 48, 124, 26, 169, 112, 16, 26, 124, 237, 230, 107, 35, 159, 228, 162, 23, 76, 181, 20, 159, 130, 209, 23, 245, 140, 220, 207, 208, 213, 94, 186, 46, 16, 110, 84, 83, 179, 117, 113, 193, 23, 245, 120, 35, 204, 135, 50, 210, 212, 248, 52, 100, 112, 68, 235, 95, 100, 37, 28, 148, 65, 73, 166, 143, 43, 60, 19, 49, 143, 79, 99, 215, 67, 83, 136, 141, 89, 244, 40, 4, 170 }, false, "Tulip black", 13.885169447346224m, 2, new DateTime(2024, 11, 3, 1, 54, 27, 540, DateTimeKind.Utc).AddTicks(8802) },
                    { 6, 84, "salmon", new DateTime(2024, 8, 19, 14, 9, 14, 349, DateTimeKind.Utc).AddTicks(807), new byte[] { 177, 64, 225, 157, 24, 217, 255, 122, 171, 46, 106, 179, 236, 96, 92, 19, 96, 70, 55, 212, 255, 64, 234, 186, 157, 1, 215, 129, 56, 13, 187, 66, 130, 18, 57, 191, 15, 88, 255, 243, 194, 78, 93, 153, 23, 219, 251, 69, 98, 238, 85, 217, 105, 240, 227, 113, 86, 39, 0, 22, 2, 126, 65, 158, 114, 40, 49, 217, 39, 157, 4, 8, 70, 67, 18, 177, 227, 80, 162, 194, 6, 145, 30, 73, 183, 226, 216, 145, 46, 199, 104, 231, 88, 232, 241, 67, 12, 190, 38, 239 }, false, "Orchid salmon", 48.135580980747742m, 3, new DateTime(2024, 11, 11, 19, 7, 42, 340, DateTimeKind.Utc).AddTicks(384) },
                    { 7, 5, "cyan", new DateTime(2024, 4, 18, 14, 44, 58, 121, DateTimeKind.Utc).AddTicks(456), new byte[] { 149, 98, 225, 104, 255, 65, 153, 234, 31, 178, 1, 176, 97, 177, 56, 13, 60, 168, 255, 119, 130, 102, 42, 4, 41, 233, 50, 20, 139, 175, 84, 228, 31, 130, 91, 49, 104, 156, 95, 101, 178, 132, 197, 166, 82, 230, 37, 180, 103, 34, 124, 162, 100, 141, 115, 47, 55, 221, 63, 22, 15, 133, 95, 112, 94, 29, 144, 223, 85, 6, 164, 160, 73, 154, 196, 253, 160, 132, 177, 67, 196, 125, 172, 104, 50, 177, 127, 146, 14, 44, 250, 139, 93, 72, 85, 45, 37, 85, 72, 53 }, false, "Tulip cyan", 33.38599251414926m, 2, new DateTime(2024, 11, 6, 12, 20, 57, 139, DateTimeKind.Utc).AddTicks(1965) },
                    { 8, 26, "mint green", new DateTime(2023, 12, 17, 16, 20, 41, 893, DateTimeKind.Utc).AddTicks(114), new byte[] { 120, 132, 224, 52, 230, 170, 51, 91, 147, 53, 153, 173, 215, 1, 20, 6, 24, 10, 199, 26, 5, 139, 107, 77, 181, 209, 142, 167, 221, 81, 236, 134, 189, 241, 125, 164, 194, 224, 190, 214, 163, 187, 46, 179, 141, 241, 79, 36, 108, 87, 163, 108, 95, 41, 3, 237, 24, 146, 126, 21, 28, 139, 126, 65, 73, 19, 239, 229, 132, 112, 67, 55, 76, 241, 119, 73, 93, 184, 191, 196, 130, 105, 59, 134, 173, 128, 38, 148, 238, 144, 139, 47, 98, 169, 186, 23, 61, 236, 106, 122 }, false, "Orchid mint green", 18.636404047550827m, 3, new DateTime(2024, 11, 1, 5, 34, 11, 938, DateTimeKind.Utc).AddTicks(3557) },
                    { 9, 48, "turquoise", new DateTime(2024, 8, 16, 15, 56, 25, 664, DateTimeKind.Utc).AddTicks(9763), new byte[] { 92, 166, 223, 255, 206, 18, 204, 204, 6, 185, 49, 169, 76, 82, 240, 255, 245, 109, 143, 190, 136, 177, 172, 151, 66, 185, 233, 58, 47, 243, 132, 40, 91, 97, 159, 23, 28, 37, 30, 71, 147, 242, 150, 192, 201, 252, 121, 147, 113, 139, 202, 53, 90, 197, 147, 170, 249, 72, 189, 20, 41, 146, 156, 19, 52, 9, 78, 235, 178, 217, 227, 207, 78, 72, 42, 149, 26, 236, 206, 69, 63, 85, 201, 164, 40, 79, 205, 149, 205, 244, 29, 211, 103, 9, 30, 1, 86, 130, 140, 191 }, false, "Tulip turquoise", 3.8868155809523597m, 2, new DateTime(2024, 11, 9, 22, 47, 26, 737, DateTimeKind.Utc).AddTicks(5137) },
                    { 10, 69, "ivory", new DateTime(2024, 4, 15, 16, 32, 9, 436, DateTimeKind.Utc).AddTicks(9410), new byte[] { 63, 200, 223, 203, 181, 122, 102, 61, 122, 60, 200, 166, 194, 163, 204, 249, 209, 207, 87, 97, 11, 214, 237, 224, 206, 161, 68, 206, 130, 149, 29, 202, 249, 209, 194, 137, 118, 105, 125, 184, 132, 41, 254, 205, 4, 7, 163, 3, 117, 191, 242, 254, 86, 98, 36, 104, 218, 254, 253, 20, 54, 152, 186, 229, 31, 254, 172, 240, 225, 67, 131, 103, 81, 159, 221, 226, 216, 31, 220, 198, 253, 65, 88, 194, 163, 30, 116, 151, 173, 89, 174, 119, 108, 105, 130, 235, 110, 25, 174, 5 }, false, "Orchid ivory", 38.137227114353912m, 3, new DateTime(2024, 11, 4, 16, 0, 41, 536, DateTimeKind.Utc).AddTicks(6716) },
                    { 11, 91, "green", new DateTime(2023, 12, 14, 18, 7, 53, 208, DateTimeKind.Utc).AddTicks(9057), new byte[] { 35, 234, 222, 150, 156, 227, 0, 174, 238, 192, 96, 162, 55, 243, 168, 242, 173, 49, 31, 4, 142, 252, 46, 42, 90, 136, 160, 97, 212, 55, 181, 108, 151, 64, 228, 252, 207, 173, 221, 41, 116, 96, 103, 218, 63, 18, 205, 114, 122, 243, 25, 199, 81, 254, 180, 38, 187, 180, 60, 19, 67, 159, 217, 182, 10, 244, 11, 246, 15, 172, 34, 255, 84, 246, 144, 46, 149, 83, 235, 71, 187, 45, 230, 224, 29, 237, 27, 152, 140, 189, 64, 27, 113, 202, 230, 213, 135, 176, 207, 74 }, false, "Tulip green", 23.38763864775543m, 2, new DateTime(2024, 11, 13, 9, 13, 56, 335, DateTimeKind.Utc).AddTicks(8295) },
                    { 12, 12, "pink", new DateTime(2024, 8, 13, 17, 43, 36, 980, DateTimeKind.Utc).AddTicks(8707), new byte[] { 6, 12, 222, 98, 131, 75, 154, 30, 97, 67, 248, 159, 172, 68, 133, 235, 137, 147, 232, 168, 17, 34, 111, 116, 230, 112, 251, 244, 39, 217, 77, 14, 52, 176, 6, 110, 41, 242, 60, 154, 101, 151, 207, 231, 122, 29, 247, 226, 127, 39, 64, 145, 76, 154, 68, 228, 156, 106, 123, 18, 80, 165, 247, 136, 245, 234, 106, 252, 62, 22, 194, 151, 86, 77, 66, 122, 82, 135, 249, 201, 120, 25, 117, 255, 152, 188, 193, 154, 108, 34, 209, 191, 118, 42, 74, 191, 159, 70, 241, 144 }, false, "Orchid pink", 8.638050181156997m, 3, new DateTime(2024, 11, 8, 2, 27, 11, 134, DateTimeKind.Utc).AddTicks(9878) },
                    { 13, 33, "orchid", new DateTime(2024, 4, 12, 18, 19, 20, 752, DateTimeKind.Utc).AddTicks(8354), new byte[] { 234, 45, 221, 45, 106, 180, 51, 143, 213, 199, 144, 156, 34, 149, 97, 229, 101, 246, 176, 75, 148, 71, 176, 189, 115, 88, 86, 135, 121, 123, 230, 176, 210, 32, 40, 225, 131, 54, 156, 11, 85, 206, 55, 244, 181, 40, 33, 81, 132, 92, 103, 90, 71, 55, 212, 162, 125, 31, 186, 18, 93, 171, 22, 90, 225, 223, 201, 2, 108, 127, 97, 47, 89, 164, 245, 198, 16, 187, 8, 74, 54, 5, 3, 29, 19, 139, 104, 155, 75, 134, 99, 99, 123, 138, 174, 169, 184, 221, 19, 213 }, false, "Tulip orchid", 42.888461714558515m, 2, new DateTime(2024, 11, 2, 19, 40, 25, 934, DateTimeKind.Utc).AddTicks(1456) },
                    { 14, 55, "azure", new DateTime(2023, 12, 11, 19, 55, 4, 524, DateTimeKind.Utc).AddTicks(7999), new byte[] { 205, 79, 221, 249, 81, 28, 205, 0, 73, 74, 39, 152, 151, 229, 61, 222, 65, 88, 120, 238, 24, 109, 240, 7, 255, 64, 178, 27, 203, 29, 126, 82, 112, 143, 74, 83, 221, 122, 252, 124, 70, 5, 160, 1, 240, 52, 76, 193, 136, 144, 142, 35, 66, 211, 100, 95, 94, 213, 250, 17, 106, 178, 52, 43, 204, 213, 40, 7, 154, 233, 1, 199, 92, 251, 168, 18, 205, 239, 22, 203, 244, 241, 146, 59, 142, 90, 15, 156, 43, 234, 245, 7, 128, 234, 18, 147, 208, 116, 53, 27 }, false, "Rose azure", 28.138873247960082m, 1, new DateTime(2024, 11, 11, 12, 53, 40, 733, DateTimeKind.Utc).AddTicks(3034) },
                    { 15, 76, "teal", new DateTime(2024, 8, 10, 19, 30, 48, 296, DateTimeKind.Utc).AddTicks(7643), new byte[] { 176, 113, 220, 196, 56, 132, 103, 113, 188, 206, 191, 149, 13, 54, 25, 216, 29, 186, 64, 146, 155, 147, 49, 80, 139, 40, 13, 174, 30, 191, 22, 244, 14, 255, 108, 198, 55, 190, 91, 237, 54, 60, 8, 14, 43, 63, 118, 48, 141, 196, 182, 237, 61, 111, 244, 29, 63, 139, 57, 16, 119, 184, 82, 253, 183, 203, 134, 13, 201, 82, 161, 94, 94, 82, 91, 95, 138, 35, 37, 76, 178, 221, 32, 89, 9, 41, 182, 158, 11, 79, 134, 171, 133, 75, 118, 125, 233, 10, 87, 96 }, false, "Tulip teal", 13.3892847813616m, 2, new DateTime(2024, 11, 6, 6, 6, 55, 532, DateTimeKind.Utc).AddTicks(4610) },
                    { 16, 98, "tan", new DateTime(2024, 4, 9, 20, 6, 32, 68, DateTimeKind.Utc).AddTicks(7298), new byte[] { 148, 147, 220, 144, 31, 237, 1, 225, 48, 81, 87, 146, 130, 134, 245, 209, 249, 28, 8, 53, 30, 184, 114, 154, 23, 15, 105, 65, 112, 97, 175, 150, 172, 111, 143, 57, 144, 3, 187, 95, 39, 114, 112, 27, 102, 74, 160, 159, 146, 248, 221, 182, 56, 12, 132, 219, 32, 65, 120, 15, 132, 191, 113, 207, 162, 192, 229, 19, 247, 188, 64, 246, 97, 169, 14, 171, 72, 86, 51, 205, 111, 201, 175, 119, 131, 248, 93, 159, 234, 179, 24, 79, 138, 171, 219, 103, 1, 161, 121, 165 }, false, "Rose tan", 47.639696314763118m, 1, new DateTime(2024, 10, 31, 23, 20, 10, 331, DateTimeKind.Utc).AddTicks(6198) },
                    { 17, 18, "indigo", new DateTime(2023, 12, 8, 21, 42, 15, 840, DateTimeKind.Utc).AddTicks(6946), new byte[] { 119, 181, 219, 91, 7, 85, 154, 82, 164, 213, 238, 142, 248, 215, 209, 202, 214, 127, 208, 216, 161, 222, 179, 228, 164, 247, 196, 212, 195, 3, 71, 56, 74, 222, 177, 171, 234, 71, 26, 208, 23, 169, 217, 40, 161, 85, 202, 15, 150, 44, 4, 127, 51, 168, 20, 153, 1, 247, 183, 15, 145, 197, 143, 160, 141, 182, 68, 25, 38, 37, 224, 142, 100, 0, 193, 247, 5, 138, 66, 78, 45, 181, 61, 150, 254, 199, 4, 161, 202, 23, 169, 243, 143, 11, 63, 81, 26, 56, 154, 235 }, false, "Tulip indigo", 32.890107848164685m, 2, new DateTime(2024, 11, 9, 16, 33, 25, 130, DateTimeKind.Utc).AddTicks(7777) },
                    { 18, 40, "yellow", new DateTime(2024, 8, 7, 21, 17, 59, 612, DateTimeKind.Utc).AddTicks(6590), new byte[] { 91, 215, 218, 39, 238, 189, 52, 195, 24, 88, 134, 139, 109, 40, 173, 196, 178, 225, 153, 124, 36, 4, 244, 45, 48, 223, 31, 104, 21, 165, 223, 218, 231, 78, 211, 30, 68, 139, 122, 65, 8, 224, 65, 53, 220, 96, 244, 126, 155, 97, 43, 72, 47, 69, 164, 87, 226, 173, 246, 14, 158, 204, 173, 114, 120, 172, 163, 30, 84, 142, 127, 38, 102, 87, 115, 67, 194, 190, 80, 207, 235, 161, 204, 180, 121, 151, 171, 162, 169, 124, 59, 151, 148, 107, 163, 60, 50, 206, 188, 48 }, false, "Rose yellow", 18.140519381566203m, 1, new DateTime(2024, 11, 4, 9, 46, 39, 929, DateTimeKind.Utc).AddTicks(9354) },
                    { 19, 61, "maroon", new DateTime(2024, 4, 6, 21, 53, 43, 384, DateTimeKind.Utc).AddTicks(6238), new byte[] { 62, 249, 218, 242, 213, 38, 206, 52, 139, 220, 30, 135, 226, 120, 137, 189, 142, 67, 97, 31, 167, 41, 53, 119, 188, 199, 123, 251, 103, 71, 120, 124, 133, 190, 245, 144, 158, 207, 217, 178, 248, 23, 169, 66, 24, 107, 30, 238, 160, 149, 82, 18, 42, 225, 53, 21, 195, 98, 54, 13, 171, 210, 204, 68, 100, 161, 2, 36, 131, 248, 31, 190, 105, 174, 38, 144, 127, 242, 95, 81, 168, 140, 91, 210, 244, 102, 82, 164, 137, 224, 204, 59, 153, 204, 7, 38, 75, 101, 222, 118 }, false, "Tulip maroon", 3.3909309149677553m, 2, new DateTime(2024, 11, 13, 2, 59, 54, 729, DateTimeKind.Utc).AddTicks(934) },
                    { 20, 83, "magenta", new DateTime(2023, 12, 5, 23, 29, 27, 156, DateTimeKind.Utc).AddTicks(5883), new byte[] { 34, 27, 217, 190, 188, 142, 104, 165, 255, 95, 181, 132, 88, 201, 101, 183, 106, 165, 41, 195, 42, 79, 118, 193, 73, 175, 214, 142, 186, 233, 16, 30, 35, 46, 23, 3, 247, 20, 57, 35, 233, 78, 18, 79, 83, 118, 72, 93, 165, 201, 122, 219, 37, 125, 197, 210, 164, 24, 117, 13, 184, 217, 234, 21, 79, 151, 96, 42, 177, 97, 191, 86, 108, 5, 217, 220, 61, 38, 109, 210, 102, 120, 233, 240, 111, 53, 249, 165, 104, 68, 94, 223, 158, 44, 107, 16, 99, 252, 0, 187 }, false, "Rose magenta", 37.641342448369288m, 1, new DateTime(2024, 11, 7, 20, 13, 9, 528, DateTimeKind.Utc).AddTicks(2512) },
                    { 21, 4, "silver", new DateTime(2024, 8, 4, 23, 5, 10, 928, DateTimeKind.Utc).AddTicks(5527), new byte[] { 5, 60, 217, 137, 163, 247, 1, 21, 115, 227, 77, 129, 205, 26, 65, 176, 70, 8, 241, 102, 173, 117, 182, 10, 213, 150, 49, 33, 12, 139, 168, 192, 193, 157, 57, 117, 81, 88, 153, 148, 217, 133, 122, 92, 142, 129, 114, 205, 169, 253, 161, 164, 32, 26, 85, 144, 133, 206, 180, 12, 197, 223, 9, 231, 58, 141, 191, 47, 224, 203, 94, 238, 110, 92, 140, 40, 250, 90, 124, 83, 36, 100, 120, 14, 234, 4, 160, 167, 72, 169, 239, 131, 163, 140, 207, 250, 124, 146, 34, 1 }, false, "Orchid silver", 22.891753981770806m, 3, new DateTime(2024, 11, 2, 13, 26, 24, 327, DateTimeKind.Utc).AddTicks(4087) },
                    { 22, 25, "black", new DateTime(2024, 4, 3, 23, 40, 54, 700, DateTimeKind.Utc).AddTicks(5173), new byte[] { 233, 94, 216, 85, 138, 95, 155, 134, 230, 102, 229, 125, 67, 106, 29, 169, 34, 106, 185, 9, 48, 154, 247, 84, 97, 126, 141, 181, 95, 45, 65, 98, 95, 13, 92, 232, 171, 156, 248, 5, 202, 188, 226, 105, 201, 141, 156, 60, 174, 49, 200, 109, 27, 182, 229, 78, 102, 132, 243, 11, 210, 230, 39, 185, 37, 130, 30, 53, 14, 52, 254, 133, 113, 179, 63, 116, 183, 142, 139, 212, 225, 80, 6, 45, 100, 211, 71, 168, 39, 13, 129, 38, 168, 236, 51, 228, 148, 41, 68, 70 }, false, "Rose black", 8.142165515172373m, 1, new DateTime(2024, 11, 11, 6, 39, 39, 126, DateTimeKind.Utc).AddTicks(5666) },
                    { 23, 47, "salmon", new DateTime(2023, 12, 3, 1, 16, 38, 472, DateTimeKind.Utc).AddTicks(4822), new byte[] { 204, 128, 216, 32, 113, 199, 53, 247, 90, 234, 125, 122, 184, 187, 249, 163, 254, 204, 129, 173, 179, 192, 56, 157, 237, 102, 232, 72, 177, 207, 217, 4, 253, 125, 126, 91, 5, 225, 88, 118, 187, 243, 75, 118, 4, 152, 199, 172, 179, 102, 239, 55, 22, 82, 117, 12, 71, 58, 51, 11, 223, 236, 69, 138, 16, 120, 125, 59, 60, 158, 158, 29, 116, 11, 242, 192, 117, 193, 153, 85, 159, 60, 149, 75, 223, 162, 238, 170, 7, 114, 19, 202, 174, 77, 151, 206, 173, 192, 102, 140 }, false, "Orchid salmon", 42.392577048573891m, 3, new DateTime(2024, 11, 5, 23, 52, 53, 925, DateTimeKind.Utc).AddTicks(7246) },
                    { 24, 68, "fuchsia", new DateTime(2024, 8, 2, 0, 52, 22, 244, DateTimeKind.Utc).AddTicks(4474), new byte[] { 176, 162, 215, 236, 88, 48, 206, 104, 206, 109, 20, 119, 45, 11, 213, 156, 219, 46, 74, 80, 55, 229, 121, 231, 122, 78, 68, 219, 3, 113, 114, 166, 154, 236, 160, 205, 94, 37, 183, 231, 171, 41, 179, 131, 63, 163, 241, 27, 184, 154, 23, 0, 17, 239, 5, 202, 40, 240, 114, 10, 236, 243, 100, 92, 251, 109, 220, 65, 107, 7, 61, 181, 118, 98, 164, 13, 50, 245, 168, 214, 93, 40, 35, 105, 90, 113, 148, 171, 231, 214, 164, 110, 179, 173, 251, 184, 197, 86, 135, 209 }, false, "Rose fuchsia", 27.642988581975458m, 1, new DateTime(2024, 10, 31, 17, 6, 8, 724, DateTimeKind.Utc).AddTicks(8832) },
                    { 25, 90, "purple", new DateTime(2024, 4, 1, 1, 28, 6, 16, DateTimeKind.Utc).AddTicks(4232), new byte[] { 147, 196, 215, 183, 64, 152, 104, 216, 65, 241, 172, 115, 163, 92, 177, 149, 183, 144, 18, 243, 186, 11, 186, 49, 6, 54, 159, 111, 86, 19, 10, 72, 56, 92, 194, 64, 184, 105, 23, 89, 156, 96, 27, 144, 122, 174, 27, 138, 188, 206, 62, 201, 12, 139, 149, 135, 9, 165, 177, 9, 249, 249, 130, 46, 231, 99, 58, 70, 153, 113, 221, 77, 121, 185, 87, 89, 239, 41, 182, 87, 26, 20, 178, 135, 213, 64, 59, 173, 198, 58, 54, 18, 184, 13, 96, 162, 222, 237, 169, 22 }, false, "Orchid purple", 12.893400115376976m, 3, new DateTime(2024, 11, 9, 10, 19, 23, 524, DateTimeKind.Utc).AddTicks(532) },
                    { 26, 10, "violet", new DateTime(2023, 11, 30, 3, 3, 49, 788, DateTimeKind.Utc).AddTicks(3909), new byte[] { 118, 230, 214, 131, 39, 0, 2, 73, 181, 116, 68, 112, 24, 173, 141, 143, 147, 243, 218, 151, 61, 49, 251, 122, 146, 30, 250, 2, 168, 181, 162, 234, 214, 204, 228, 178, 18, 173, 118, 202, 140, 151, 132, 157, 181, 185, 69, 250, 193, 2, 101, 147, 8, 39, 37, 69, 234, 91, 240, 9, 6, 0, 161, 255, 210, 89, 153, 76, 200, 218, 124, 229, 124, 16, 10, 165, 173, 93, 197, 217, 216, 0, 64, 165, 80, 15, 226, 174, 166, 159, 199, 182, 189, 109, 196, 140, 246, 132, 203, 92 }, false, "Rose violet", 47.143811648778543m, 1, new DateTime(2024, 11, 4, 3, 32, 38, 323, DateTimeKind.Utc).AddTicks(2131) },
                    { 27, 32, "lime", new DateTime(2024, 7, 30, 2, 39, 33, 560, DateTimeKind.Utc).AddTicks(3554), new byte[] { 90, 8, 214, 78, 14, 105, 156, 186, 41, 248, 219, 108, 142, 253, 105, 136, 111, 85, 162, 58, 192, 86, 60, 196, 31, 5, 86, 149, 251, 87, 59, 140, 116, 59, 6, 37, 108, 242, 214, 59, 125, 206, 236, 170, 240, 196, 111, 105, 198, 54, 140, 92, 3, 196, 181, 3, 204, 17, 47, 8, 19, 6, 191, 209, 189, 78, 248, 82, 246, 68, 28, 125, 126, 103, 189, 241, 106, 145, 211, 90, 150, 236, 207, 196, 203, 222, 137, 176, 133, 3, 89, 90, 194, 206, 40, 118, 15, 26, 237, 161 }, false, "Orchid lime", 32.394223182180061m, 3, new DateTime(2024, 11, 12, 20, 45, 53, 122, DateTimeKind.Utc).AddTicks(3709) },
                    { 28, 53, "green", new DateTime(2024, 3, 29, 4, 15, 17, 332, DateTimeKind.Utc).AddTicks(3201), new byte[] { 61, 42, 213, 26, 245, 209, 53, 43, 156, 124, 115, 105, 3, 78, 69, 130, 75, 183, 106, 221, 67, 124, 125, 14, 171, 237, 177, 40, 77, 249, 211, 46, 18, 171, 41, 151, 198, 54, 54, 172, 109, 5, 84, 183, 43, 207, 153, 217, 202, 107, 179, 37, 254, 96, 70, 193, 173, 199, 111, 7, 32, 13, 221, 163, 168, 68, 87, 88, 37, 173, 188, 21, 129, 190, 112, 61, 39, 197, 226, 219, 83, 216, 93, 226, 69, 173, 48, 177, 101, 103, 234, 254, 199, 46, 140, 96, 39, 177, 15, 231 }, false, "Tulip green", 17.644634715581628m, 2, new DateTime(2024, 11, 7, 13, 59, 7, 921, DateTimeKind.Utc).AddTicks(5286) },
                    { 29, 75, "pink", new DateTime(2023, 11, 27, 4, 51, 1, 104, DateTimeKind.Utc).AddTicks(2849), new byte[] { 33, 75, 212, 229, 220, 57, 207, 156, 16, 255, 11, 102, 121, 158, 33, 123, 39, 25, 50, 129, 198, 162, 189, 87, 55, 213, 12, 188, 159, 155, 107, 209, 176, 27, 75, 10, 31, 122, 149, 29, 94, 60, 189, 196, 102, 219, 195, 72, 207, 159, 219, 238, 249, 252, 214, 127, 142, 125, 174, 7, 45, 19, 252, 116, 147, 58, 182, 93, 83, 23, 91, 172, 132, 21, 34, 138, 228, 248, 240, 92, 17, 196, 236, 0, 192, 124, 215, 179, 68, 204, 124, 162, 204, 142, 240, 74, 64, 72, 49, 44 }, false, "Orchid pink", 2.895046248983146m, 3, new DateTime(2024, 11, 2, 7, 12, 22, 720, DateTimeKind.Utc).AddTicks(6866) },
                    { 30, 97, "orchid", new DateTime(2024, 7, 27, 4, 26, 44, 876, DateTimeKind.Utc).AddTicks(2494), new byte[] { 4, 109, 212, 177, 195, 162, 105, 12, 132, 131, 162, 98, 238, 239, 253, 116, 3, 124, 251, 36, 73, 199, 254, 161, 195, 189, 104, 79, 242, 61, 4, 115, 77, 138, 109, 124, 121, 191, 245, 142, 78, 115, 37, 209, 162, 230, 237, 184, 212, 211, 2, 184, 244, 153, 102, 60, 111, 51, 237, 6, 58, 26, 26, 70, 126, 47, 20, 99, 130, 128, 251, 68, 134, 108, 213, 214, 162, 44, 255, 221, 207, 176, 122, 30, 59, 75, 126, 180, 36, 48, 13, 70, 209, 238, 84, 52, 88, 223, 82, 114 }, false, "Tulip orchid", 37.145457782384664m, 2, new DateTime(2024, 11, 11, 0, 25, 37, 519, DateTimeKind.Utc).AddTicks(8445) }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "comment", "created_at", "delivery_address", "delivery_date", "delivery_price", "payment_method", "status", "total_price", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, "Cumque hic explicabo neque eum quibusdam ipsum autem.", new DateTime(2024, 7, 25, 0, 9, 23, 949, DateTimeKind.Utc).AddTicks(5296), "1602 Fidel Village, Port Marisol, Niue", new DateTime(2033, 5, 9, 7, 35, 17, 161, DateTimeKind.Utc).AddTicks(5197), 244.165126338678080m, "Cash on Delivery", "Pending", 256.379024542579053m, new DateTime(2024, 11, 2, 23, 18, 43, 126, DateTimeKind.Utc).AddTicks(1261), 8 },
                    { 2, "Vitae laboriosam sit.", new DateTime(2024, 2, 20, 19, 57, 40, 973, DateTimeKind.Utc).AddTicks(3559), "20700 Princess Lock, Georgianaburgh, Philippines", new DateTime(2031, 12, 7, 4, 14, 48, 691, DateTimeKind.Utc).AddTicks(6824), 99.679361767917440m, "Cash on Delivery", "Processing", 579.217377156120161m, new DateTime(2024, 11, 1, 22, 48, 33, 69, DateTimeKind.Utc).AddTicks(7955), 24 },
                    { 3, "Voluptatum numquam qui et vitae asperiores blanditiis excepturi unde.", new DateTime(2024, 6, 30, 0, 51, 28, 392, DateTimeKind.Utc).AddTicks(9162), "3358 Demarco Village, Alexanderton, Trinidad and Tobago", new DateTime(2028, 7, 29, 1, 33, 21, 654, DateTimeKind.Utc).AddTicks(4352), 435.193597197157280m, "Cash on Delivery", "Shipped", 2148.641203010752669m, new DateTime(2024, 11, 7, 12, 47, 38, 837, DateTimeKind.Utc).AddTicks(2839), 9 },
                    { 4, "Ut eum libero et sunt aspernatur quis dolorem et.", new DateTime(2024, 7, 26, 17, 15, 54, 551, DateTimeKind.Utc).AddTicks(2087), "47253 Maxime Locks, Oswaldomouth, Mali", new DateTime(2039, 2, 17, 20, 12, 46, 556, DateTimeKind.Utc).AddTicks(7051), 290.707832626396640m, "Cash on Delivery", "Delivered", 619.6142055460318053m, new DateTime(2024, 11, 5, 4, 48, 2, 845, DateTimeKind.Utc).AddTicks(4017), 25 },
                    { 5, "Deleniti architecto quo dolor consectetur.", new DateTime(2024, 2, 16, 20, 22, 18, 492, DateTimeKind.Utc).AddTicks(6823), "5193 Corkery Village, North Jaylanland, Venezuela", new DateTime(2027, 9, 25, 3, 11, 45, 489, DateTimeKind.Utc).AddTicks(2179), 146.222068055636480m, "Cash on Delivery", "Processing", 152.905340592798677m, new DateTime(2024, 11, 11, 5, 36, 50, 844, DateTimeKind.Utc).AddTicks(6759), 11 },
                    { 6, "Quidem laborum voluptatem consequatur magni quis eum explicabo ea.", new DateTime(2024, 8, 31, 18, 5, 34, 858, DateTimeKind.Utc).AddTicks(8170), "747 Mertz Locks, Lake Landenville, San Marino", new DateTime(2036, 5, 28, 16, 30, 28, 393, DateTimeKind.Utc).AddTicks(7633), 481.736303484875840m, "Cash on Delivery", "Shipped", 2278.605754973649484m, new DateTime(2024, 11, 1, 16, 59, 29, 954, DateTimeKind.Utc).AddTicks(6044), 26 },
                    { 7, "Accusantium placeat error quia deleniti iure doloremque tenetur accusantium.", new DateTime(2024, 5, 22, 15, 50, 17, 14, DateTimeKind.Utc).AddTicks(1169), "8849 Baumbach Villages, North Shanny, India", new DateTime(2049, 1, 6, 14, 29, 30, 640, DateTimeKind.Utc).AddTicks(2068), 337.25053891411520m, "Card", "Delivered", 337.25053891411520m, new DateTime(2024, 11, 4, 10, 23, 26, 993, DateTimeKind.Utc).AddTicks(7108), 12 },
                    { 8, "Saepe velit aut consequatur nisi eum atque tempore vel facilis.", new DateTime(2024, 2, 11, 14, 34, 59, 169, DateTimeKind.Utc).AddTicks(4159), "921 Kuhn Locks, Brennastad, Moldova", new DateTime(2025, 9, 1, 4, 29, 5, 288, DateTimeKind.Utc).AddTicks(316), 192.764774343355040m, "Card", "Pending", 1017.464431365702097m, new DateTime(2024, 11, 7, 3, 47, 24, 32, DateTimeKind.Utc).AddTicks(8163), 28 },
                    { 9, "Illo excepturi dolor.", new DateTime(2024, 4, 15, 10, 37, 10, 63, DateTimeKind.Utc).AddTicks(8377), "05948 Trevion Ville, East Macfurt, Micronesia", new DateTime(2052, 6, 29, 19, 37, 48, 696, DateTimeKind.Utc).AddTicks(5904), 48.2790097725945440m, "Cash on Delivery", "Processing", 260.2306914223499640m, new DateTime(2024, 11, 10, 2, 1, 57, 491, DateTimeKind.Utc).AddTicks(5354), 13 },
                    { 10, "Hic amet ratione corporis.", new DateTime(2024, 3, 9, 21, 34, 50, 570, DateTimeKind.Utc).AddTicks(9183), "296 Gerson Lodge, South Margarete, Wallis and Futuna", new DateTime(2033, 2, 19, 23, 30, 24, 894, DateTimeKind.Utc).AddTicks(8825), 383.793245201834240m, "Card", "Delivered", 722.933861590425368m, new DateTime(2024, 11, 7, 3, 5, 7, 119, DateTimeKind.Utc).AddTicks(3265), 29 },
                    { 11, "Unde pariatur officiis omnis animi.", new DateTime(2024, 6, 24, 4, 29, 59, 176, DateTimeKind.Utc).AddTicks(915), "33301 Roberta Vista, New Stellaport, Slovenia", new DateTime(2054, 2, 13, 1, 55, 15, 267, DateTimeKind.Utc).AddTicks(9316), 239.30748063107360m, "Cash on Delivery", "Pending", 2265.0377384741036573m, new DateTime(2024, 11, 7, 10, 44, 17, 153, DateTimeKind.Utc).AddTicks(3961), 15 },
                    { 12, "Sapiente velit autem.", new DateTime(2024, 11, 7, 4, 30, 2, 492, DateTimeKind.Utc).AddTicks(215), "4618 Easton Lodge, Ratkebury, Madagascar", new DateTime(2052, 1, 26, 23, 24, 41, 872, DateTimeKind.Utc).AddTicks(4107), 94.821716060313440m, "Card", "Processing", 1882.584693859604332m, new DateTime(2024, 11, 11, 8, 19, 29, 568, DateTimeKind.Utc).AddTicks(1096), 30 },
                    { 13, "Eaque consectetur sunt aut necessitatibus aut quod.", new DateTime(2024, 9, 25, 2, 18, 29, 945, DateTimeKind.Utc).AddTicks(9056), "50865 Renner Vista, North Callieborough, Austria", new DateTime(2025, 9, 29, 6, 12, 41, 839, DateTimeKind.Utc).AddTicks(2729), 430.335951489552800m, "Card", "Shipped", 935.106600338177433m, new DateTime(2024, 11, 6, 18, 47, 9, 228, DateTimeKind.Utc).AddTicks(3390), 16 },
                    { 14, "Id cum veniam.", new DateTime(2024, 7, 6, 10, 25, 14, 413, DateTimeKind.Utc).AddTicks(1247), "7463 Daugherty Lodge, Lake Oswald, Samoa", new DateTime(2047, 4, 17, 16, 22, 46, 365, DateTimeKind.Utc).AddTicks(2917), 285.850186918792640m, "Cash on Delivery", "Delivered", 305.438252678345308m, new DateTime(2024, 11, 1, 13, 33, 52, 16, DateTimeKind.Utc).AddTicks(8930), 2 },
                    { 15, "Quia consequatur non.", new DateTime(2024, 5, 5, 13, 52, 50, 373, DateTimeKind.Utc).AddTicks(6855), "883 Murazik Vista, Port Dorcasport, Iceland", new DateTime(2029, 11, 26, 14, 21, 48, 611, DateTimeKind.Utc).AddTicks(7384), 141.3644223480320m, "Card", "Pending", 234.904545688957212m, new DateTime(2024, 11, 10, 16, 11, 3, 241, DateTimeKind.Utc).AddTicks(2951), 17 },
                    { 16, "Molestias earum est.", new DateTime(2024, 3, 4, 18, 20, 26, 334, DateTimeKind.Utc).AddTicks(2407), "9109 Blanda Loop, Pedroville, Angola", new DateTime(2042, 7, 7, 10, 20, 50, 858, DateTimeKind.Utc).AddTicks(1848), 476.878657777271360m, "Cash on Delivery", "Shipped", 841.481172668039924m, new DateTime(2024, 11, 5, 18, 48, 14, 465, DateTimeKind.Utc).AddTicks(6891), 3 },
                    { 17, "Eos eveniet architecto sit et ut consequatur.", new DateTime(2024, 5, 29, 22, 44, 13, 331, DateTimeKind.Utc).AddTicks(7781), "058 Juana Walk, Emmanuelburgh, Thailand", new DateTime(2044, 4, 15, 1, 35, 3, 518, DateTimeKind.Utc).AddTicks(8679), 332.392893206511200m, "Card", "Delivered", 2056.127596815642040m, new DateTime(2024, 11, 6, 19, 2, 30, 442, DateTimeKind.Utc).AddTicks(6042), 19 },
                    { 18, "Quia voluptatem aperiam voluptatem laudantium.", new DateTime(2024, 10, 7, 13, 1, 2, 901, DateTimeKind.Utc).AddTicks(7074), "29550 Wallace Mall, McCulloughburgh, Israel", new DateTime(2029, 7, 13, 10, 58, 31, 611, DateTimeKind.Utc).AddTicks(8592), 187.907128635750560m, "Card", "Pending", 199.556445728780799m, new DateTime(2024, 11, 8, 18, 9, 38, 742, DateTimeKind.Utc).AddTicks(4368), 4 },
                    { 19, "Consectetur tempore nisi molestias sed libero natus maxime enim.", new DateTime(2024, 5, 30, 0, 42, 10, 545, DateTimeKind.Utc).AddTicks(1269), "322 Heather Walks, New Filiberto, Falkland Islands (Malvinas)", new DateTime(2051, 10, 4, 19, 36, 23, 125, DateTimeKind.Utc).AddTicks(7353), 43.4213640649902560m, "Cash on Delivery", "Processing", 52.0594142461472530m, new DateTime(2024, 11, 3, 8, 46, 32, 807, DateTimeKind.Utc).AddTicks(3136), 20 },
                    { 20, "Voluptatum facere quis.", new DateTime(2024, 11, 7, 8, 11, 8, 554, DateTimeKind.Utc).AddTicks(5287), "46003 Sandra Manor, Wunschport, Estonia", new DateTime(2036, 9, 24, 2, 56, 29, 476, DateTimeKind.Utc).AddTicks(9012), 378.935599494229760m, "Card", "Shipped", 1042.191632507924240m, new DateTime(2024, 11, 5, 6, 4, 14, 271, DateTimeKind.Utc).AddTicks(9478), 6 },
                    { 21, "Dolore ducimus est.", new DateTime(2024, 11, 14, 10, 46, 26, 732, DateTimeKind.Utc).AddTicks(8218), "507 Halvorson Walks, Bernhardbury, Palestinian Territory", new DateTime(2029, 3, 25, 13, 37, 42, 732, DateTimeKind.Utc).AddTicks(5957), 234.449834923469120m, "Cash on Delivery", "Delivered", 234.449834923469120m, new DateTime(2024, 11, 6, 22, 4, 15, 773, DateTimeKind.Utc).AddTicks(5661), 21 },
                    { 22, "Quod dolore impedit porro vero cum pariatur voluptatem fuga.", new DateTime(2024, 1, 27, 1, 14, 58, 370, DateTimeKind.Utc).AddTicks(301), "63467 Runolfsdottir Manor, Homenickmouth, Bosnia and Herzegovina", new DateTime(2043, 12, 6, 19, 54, 27, 341, DateTimeKind.Utc).AddTicks(9178), 89.964070352708960m, "Card", "Processing", 116.2588932981057571m, new DateTime(2024, 11, 10, 4, 0, 49, 712, DateTimeKind.Utc).AddTicks(8002), 7 },
                    { 23, "Eius officiis quos debitis et.", new DateTime(2023, 12, 1, 7, 16, 7, 831, DateTimeKind.Utc).AddTicks(1641), "8724 Ebert Wall, South Arnaldo, Hungary", new DateTime(2040, 10, 15, 13, 14, 6, 583, DateTimeKind.Utc).AddTicks(2942), 425.478305781948320m, "Card", "Shipped", 999.727208581625481m, new DateTime(2024, 11, 10, 0, 29, 59, 119, DateTimeKind.Utc).AddTicks(5166), 23 },
                    { 24, "Consequatur id quae esse ab sapiente similique.", new DateTime(2024, 4, 24, 3, 31, 16, 821, DateTimeKind.Utc).AddTicks(6664), "91921 Okuneva Manors, Sauertown, Uruguay", new DateTime(2051, 2, 17, 11, 52, 25, 206, DateTimeKind.Utc).AddTicks(9356), 280.992541211188160m, "Card", "Delivered", 2423.389736727061848m, new DateTime(2024, 11, 12, 0, 44, 16, 607, DateTimeKind.Utc).AddTicks(6278), 8 },
                    { 25, "Asperiores eos voluptatibus eius voluptas.", new DateTime(2024, 9, 20, 12, 30, 16, 83, DateTimeKind.Utc).AddTicks(6320), "0479 Berenice Way, Kreigerport, Nicaragua", new DateTime(2036, 1, 5, 8, 12, 11, 76, DateTimeKind.Utc).AddTicks(1737), 136.506776640427520m, "Card", "Pending", 635.164434279857154m, new DateTime(2024, 11, 6, 0, 16, 50, 780, DateTimeKind.Utc).AddTicks(6496), 24 },
                    { 26, "Vel eum enim.", new DateTime(2024, 8, 23, 10, 35, 10, 809, DateTimeKind.Utc).AddTicks(7404), "184 Kaylee Meadow, Lakinshire, Christmas Island", new DateTime(2032, 11, 27, 23, 41, 1, 749, DateTimeKind.Utc).AddTicks(7167), 472.021012069667360m, "Cash on Delivery", "Processing", 2176.250908438698116m, new DateTime(2024, 11, 9, 2, 8, 33, 471, DateTimeKind.Utc).AddTicks(550), 10 },
                    { 27, "Ea rem iste laudantium ut saepe ratione esse consequatur.", new DateTime(2024, 1, 17, 5, 51, 22, 764, DateTimeKind.Utc).AddTicks(1315), "3215 Abe Ways, South Shannahaven, Cote d'Ivoire", new DateTime(2046, 12, 6, 11, 49, 22, 4, DateTimeKind.Utc).AddTicks(4608), 327.535247498906720m, "Card", "Shipped", 971.203214753048532m, new DateTime(2024, 11, 12, 7, 47, 42, 731, DateTimeKind.Utc).AddTicks(5062), 25 },
                    { 28, "Iusto sequi sed porro est.", new DateTime(2024, 1, 21, 10, 57, 7, 479, DateTimeKind.Utc).AddTicks(4672), "459 Ivory Meadows, Port Alfredo, Moldova", new DateTime(2040, 5, 18, 16, 42, 21, 356, DateTimeKind.Utc).AddTicks(5667), 183.049482928146560m, "Cash on Delivery", "Pending", 397.4385629237811502m, new DateTime(2024, 11, 8, 6, 37, 52, 583, DateTimeKind.Utc).AddTicks(9883), 11 },
                    { 29, "Libero sapiente saepe neque ut dolor et.", new DateTime(2024, 3, 19, 7, 20, 23, 98, DateTimeKind.Utc).AddTicks(2010), "59615 Tromp Ways, Earleneland, Australia", new DateTime(2054, 2, 17, 3, 47, 19, 869, DateTimeKind.Utc).AddTicks(4786), 38.563718357385920m, "Card", "Processing", 1496.736712452833385m, new DateTime(2024, 11, 6, 16, 42, 0, 407, DateTimeKind.Utc).AddTicks(9380), 27 },
                    { 30, "Corrupti non et quia veritatis excepturi rerum.", new DateTime(2024, 1, 18, 17, 22, 57, 740, DateTimeKind.Utc).AddTicks(8014), "633 Heidenreich Meadows, Gerholdton, Wallis and Futuna", new DateTime(2047, 11, 7, 11, 43, 40, 963, DateTimeKind.Utc).AddTicks(4143), 374.077953786625280m, "Card", "Shipped", 374.077953786625280m, new DateTime(2024, 11, 4, 7, 35, 18, 340, DateTimeKind.Utc).AddTicks(3628), 12 }
                });

            migrationBuilder.InsertData(
                table: "shopping_carts",
                columns: new[] { "user_id", "created_at", "updated_at" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 7, 13, 14, 36, 31, 853, DateTimeKind.Utc).AddTicks(2463), new DateTime(2024, 11, 10, 12, 17, 5, 756, DateTimeKind.Utc).AddTicks(4081) },
                    { 17, new DateTime(2024, 6, 27, 4, 38, 27, 342, DateTimeKind.Utc).AddTicks(4264), new DateTime(2024, 11, 2, 7, 6, 27, 436, DateTimeKind.Utc).AddTicks(7431) },
                    { 18, new DateTime(2024, 2, 6, 6, 33, 38, 619, DateTimeKind.Utc).AddTicks(4750), new DateTime(2024, 11, 8, 20, 3, 3, 235, DateTimeKind.Utc).AddTicks(9047) },
                    { 20, new DateTime(2024, 6, 10, 18, 40, 22, 831, DateTimeKind.Utc).AddTicks(6063), new DateTime(2024, 11, 8, 1, 55, 49, 117, DateTimeKind.Utc).AddTicks(780) },
                    { 21, new DateTime(2023, 12, 2, 14, 41, 20, 576, DateTimeKind.Utc).AddTicks(1962), new DateTime(2024, 11, 3, 23, 20, 29, 957, DateTimeKind.Utc).AddTicks(2454) },
                    { 23, new DateTime(2024, 8, 15, 10, 32, 40, 874, DateTimeKind.Utc).AddTicks(8662), new DateTime(2024, 11, 12, 22, 38, 22, 395, DateTimeKind.Utc).AddTicks(7308) },
                    { 24, new DateTime(2024, 7, 30, 0, 34, 36, 364, DateTimeKind.Utc).AddTicks(659), new DateTime(2024, 11, 4, 17, 27, 44, 76, DateTimeKind.Utc).AddTicks(727) },
                    { 25, new DateTime(2023, 12, 19, 0, 39, 25, 87, DateTimeKind.Utc).AddTicks(163), new DateTime(2024, 11, 12, 4, 31, 8, 276, DateTimeKind.Utc).AddTicks(9105) },
                    { 26, new DateTime(2024, 1, 4, 10, 37, 29, 597, DateTimeKind.Utc).AddTicks(8364), new DateTime(2024, 11, 6, 9, 41, 46, 596, DateTimeKind.Utc).AddTicks(5755) },
                    { 30, new DateTime(2024, 1, 20, 20, 35, 34, 108, DateTimeKind.Utc).AddTicks(6561), new DateTime(2024, 10, 31, 14, 52, 24, 916, DateTimeKind.Utc).AddTicks(2404) }
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
                    { 1, 15, 24, null, 0m, 4 },
                    { 2, 5, 25, null, 0m, 5 },
                    { 3, null, 24, 26, 0m, 1 },
                    { 4, null, 20, 17, 0m, 3 },
                    { 5, 8, 30, null, 0m, 4 },
                    { 6, null, 20, 29, 0m, 5 },
                    { 7, null, 30, 20, 0m, 1 },
                    { 8, 11, 21, null, 0m, 2 },
                    { 9, 2, 9, null, 0m, 3 },
                    { 10, null, 21, 23, 0m, 4 },
                    { 11, 14, 9, null, 0m, 5 },
                    { 12, 5, 21, null, 0m, 1 },
                    { 13, null, 26, 26, 0m, 2 },
                    { 14, null, 23, 17, 0m, 3 },
                    { 15, 8, 26, null, 0m, 4 },
                    { 16, null, 23, 29, 0m, 5 },
                    { 17, null, 17, 20, 0m, 1 },
                    { 18, 11, 18, null, 0m, 3 },
                    { 19, 2, 17, null, 0m, 4 },
                    { 20, null, 18, 23, 0m, 5 },
                    { 21, null, 17, 14, 0m, 1 },
                    { 22, 5, 24, null, 0m, 2 },
                    { 23, null, 25, 26, 0m, 3 },
                    { 24, null, 24, 17, 0m, 4 },
                    { 25, 8, 25, null, 0m, 5 },
                    { 26, 29, 30, null, 0m, 1 },
                    { 27, null, 20, 20, 0m, 2 },
                    { 28, 11, 30, null, 0m, 3 },
                    { 29, 2, 20, null, 0m, 4 },
                    { 30, null, 30, 23, 0m, 5 }
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
                    { 1, 139.360920395404640m, 23, "Card", "Completed", new DateTime(2024, 10, 22, 7, 17, 40, 436, DateTimeKind.Utc).AddTicks(6426) },
                    { 2, 390.125071206188480m, 27, "Card", "Pending", new DateTime(2024, 10, 15, 21, 36, 56, 360, DateTimeKind.Utc).AddTicks(6495) },
                    { 3, 160.889222016972320m, 20, "Cash on Delivery", "Failed", new DateTime(2024, 11, 8, 12, 56, 12, 284, DateTimeKind.Utc).AddTicks(5787) },
                    { 4, 411.653372827755680m, 18, "Cash on Delivery", "Completed", new DateTime(2024, 11, 2, 3, 15, 28, 208, DateTimeKind.Utc).AddTicks(5058) },
                    { 5, 182.417523638539520m, 24, "Card", "Pending", new DateTime(2024, 10, 26, 16, 34, 44, 132, DateTimeKind.Utc).AddTicks(4329) },
                    { 6, 433.181674449323360m, 29, "Cash on Delivery", "Failed", new DateTime(2024, 10, 20, 6, 54, 0, 56, DateTimeKind.Utc).AddTicks(3609) },
                    { 7, 203.94582526010720m, 15, "Cash on Delivery", "Completed", new DateTime(2024, 11, 12, 22, 13, 15, 980, DateTimeKind.Utc).AddTicks(2881) },
                    { 8, 454.709976070891040m, 12, "Card", "Completed", new DateTime(2024, 11, 6, 12, 32, 31, 904, DateTimeKind.Utc).AddTicks(2149) },
                    { 9, 225.474126881674880m, 17, "Card", "Pending", new DateTime(2024, 10, 31, 2, 51, 47, 828, DateTimeKind.Utc).AddTicks(1418) },
                    { 10, 476.238277692458720m, 22, "Cash on Delivery", "Failed", new DateTime(2024, 10, 24, 16, 11, 3, 752, DateTimeKind.Utc).AddTicks(687) },
                    { 11, 247.002428503242560m, 7, "Card", "Completed", new DateTime(2024, 10, 18, 6, 30, 19, 675, DateTimeKind.Utc).AddTicks(9954) },
                    { 12, 497.766579314026400m, 30, "Card", "Pending", new DateTime(2024, 11, 10, 21, 49, 35, 599, DateTimeKind.Utc).AddTicks(9222) },
                    { 13, 268.530730124810240m, 25, "Cash on Delivery", "Failed", new DateTime(2024, 11, 4, 12, 8, 51, 523, DateTimeKind.Utc).AddTicks(8490) },
                    { 14, 39.2948809355939360m, 13, "Cash on Delivery", "Completed", new DateTime(2024, 10, 29, 2, 28, 7, 447, DateTimeKind.Utc).AddTicks(7758) },
                    { 15, 290.059031746377920m, 8, "Card", "Pending", new DateTime(2024, 10, 22, 15, 47, 23, 371, DateTimeKind.Utc).AddTicks(7025) },
                    { 16, 60.8231825571615200m, 10, "Cash on Delivery", "Failed", new DateTime(2024, 10, 16, 6, 6, 39, 295, DateTimeKind.Utc).AddTicks(6291) }
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

            migrationBuilder.CreateIndex(
                name: "ix_add_ons_type_id",
                table: "add_ons",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquet_add_ons_add_on_id",
                table: "bouquet_add_ons",
                column: "add_on_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquet_add_ons_bouquet_id",
                table: "bouquet_add_ons",
                column: "bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquet_add_ons_custom_bouquet_id",
                table: "bouquet_add_ons",
                column: "custom_bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquet_category_bouquets_category_id",
                table: "bouquet_category_bouquets",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquet_flowers_flower_id",
                table: "bouquet_flowers",
                column: "flower_id");

            migrationBuilder.CreateIndex(
                name: "ix_bouquets_main_color",
                table: "bouquets",
                column: "main_color");

            migrationBuilder.CreateIndex(
                name: "ix_bouquets_size",
                table: "bouquets",
                column: "size");

            migrationBuilder.CreateIndex(
                name: "ix_cart_item_add_ons_add_on_id",
                table: "cart_item_add_ons",
                column: "add_on_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_bouquet_id",
                table: "cart_items",
                column: "bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_cart_id",
                table: "cart_items",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_custom_bouquet_id",
                table: "cart_items",
                column: "custom_bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_custom_bouquet_flowers_flower_id",
                table: "custom_bouquet_flowers",
                column: "flower_id");

            migrationBuilder.CreateIndex(
                name: "ix_custom_bouquets_user_id",
                table: "custom_bouquets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_flowers_color",
                table: "flowers",
                column: "color");

            migrationBuilder.CreateIndex(
                name: "ix_flowers_type_id",
                table: "flowers",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_add_ons_add_on_id",
                table: "order_add_ons",
                column: "add_on_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_bouquets_bouquet_id",
                table: "order_bouquets",
                column: "bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_bouquets_custom_bouquet_id",
                table: "order_bouquets",
                column: "custom_bouquet_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_bouquets_order_id",
                table: "order_bouquets",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_status",
                table: "orders",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_order_id",
                table: "payments",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bouquet_add_ons");

            migrationBuilder.DropTable(
                name: "bouquet_category_bouquets");

            migrationBuilder.DropTable(
                name: "bouquet_flowers");

            migrationBuilder.DropTable(
                name: "cart_item_add_ons");

            migrationBuilder.DropTable(
                name: "custom_bouquet_flowers");

            migrationBuilder.DropTable(
                name: "order_add_ons");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "bouquet_categories");

            migrationBuilder.DropTable(
                name: "cart_items");

            migrationBuilder.DropTable(
                name: "flowers");

            migrationBuilder.DropTable(
                name: "add_ons");

            migrationBuilder.DropTable(
                name: "order_bouquets");

            migrationBuilder.DropTable(
                name: "shopping_carts");

            migrationBuilder.DropTable(
                name: "flower_types");

            migrationBuilder.DropTable(
                name: "add_on_types");

            migrationBuilder.DropTable(
                name: "bouquets");

            migrationBuilder.DropTable(
                name: "custom_bouquets");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
