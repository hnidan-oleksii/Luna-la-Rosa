using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBehaviorOnUserDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE orders
DROP CONSTRAINT fk_orders_users_user_id;

ALTER TABLE orders
ADD CONSTRAINT fk_orders_users_user_id
FOREIGN KEY (user_id)
REFERENCES users (id)
ON DELETE CASCADE;

ALTER TABLE custom_bouquets
DROP CONSTRAINT fk_custom_bouquets_users_user_id;

ALTER TABLE custom_bouquets
ADD CONSTRAINT fk_custom_bouquets_users_user_id
FOREIGN KEY (user_id)
REFERENCES users (id)
ON DELETE CASCADE;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}