using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePaymentMethodConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payment_PaymentMethod",
                table: "payments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Order_PaymentMethod",
                table: "orders");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Payment_PaymentMethod",
                table: "payments",
                sql: "payment_method IN ('Card', 'Cash')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Order_PaymentMethod",
                table: "orders",
                sql: "payment_method IN ('Card', 'Cash')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Order_Status",
                table: "orders",
                sql: "status IN ('Pending', 'Processing', 'Shipped')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payment_PaymentMethod",
                table: "payments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Order_PaymentMethod",
                table: "orders");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Order_Status",
                table: "orders");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Payment_PaymentMethod",
                table: "payments",
                sql: "payment_method IN ('Card', 'Cash on Delivery')");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Order_PaymentMethod",
                table: "orders",
                sql: "payment_method IN ('Card', 'Cash on Delivery')");
        }
    }
}
