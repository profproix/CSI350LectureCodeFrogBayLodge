using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FrogBayLodge.Migrations
{
    /// <inheritdoc />
    public partial class AddingSpa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spa", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spa",
                columns: new[] { "Id", "Description", "Package", "Price" },
                values: new object[,]
                {
                    { 1, "Experience the ultimate relaxation with a Swedish massage, known for its gentle yet effective techniques that soothe muscles and promote circulation. Enjoy a blissful escape from stress and tension as skilled hands knead away knots, leaving you feeling rejuvenated and refreshed.", "Swedish Massage", 150.0 },
                    { 2, "Dive deep into muscle tension and knots with a deep tissue massage, designed to target chronic pain and tightness.Through firm pressure and slow strokes, this treatment reaches the deeper layers of muscles, releasing tension and restoring mobility for a renewed sense of well - being.", "Deep Tissue Massage", 180.0 },
                    { 3, " Reveal your skin's natural radiance with the Diamond Glow facial, a luxurious treatment that exfoliates, extracts, and infuses the skin with nourishing serums. Using diamond-tipped technology, this non-invasive procedure gently buffs away dead skin cells, leaving your complexion smoother, brighter, and more youthful-looking.", "Diamond Glow Facial", 130.0 },
                    { 4, "Renew your skin with the transformative Frog Peel facial, featuring a potent blend of exfoliating acids to rejuvenate and clarify the complexion. This advanced peel helps to diminish fine lines, acne scars, and hyperpigmentation, revealing smoother, more even-toned skin with a healthy glow.", "Frog Peel Facial", 140.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spa");
        }
    }
}
