using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Word = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    EnUkPronounce = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    EnUsPronounce = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    ViPronounce = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Word);
                });

            migrationBuilder.CreateTable(
                name: "WordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vi = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    En = table.Column<string>(type: "varchar", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordTypeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Word = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    WordTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTypeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordTypeLinks_WordTypes_WordTypeId",
                        column: x => x.WordTypeId,
                        principalTable: "WordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordTypeLinks_Words_Word",
                        column: x => x.Word,
                        principalTable: "Words",
                        principalColumn: "Word",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordMeanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordTypeLinkId = table.Column<int>(type: "integer", nullable: false),
                    ViMeaning = table.Column<string>(type: "varchar", maxLength: 256, nullable: false),
                    EnMeaning = table.Column<string>(type: "varchar", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordMeanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordMeanings_WordTypeLinks_WordTypeLinkId",
                        column: x => x.WordTypeLinkId,
                        principalTable: "WordTypeLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordMeaningId = table.Column<int>(type: "integer", nullable: false),
                    EnExample = table.Column<string>(type: "varchar", maxLength: 256, nullable: false),
                    ViMeaning = table.Column<string>(type: "varchar", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examples_WordMeanings_WordMeaningId",
                        column: x => x.WordMeaningId,
                        principalTable: "WordMeanings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_WordMeaningId",
                table: "Examples",
                column: "WordMeaningId");

            migrationBuilder.CreateIndex(
                name: "IX_WordMeanings_WordTypeLinkId",
                table: "WordMeanings",
                column: "WordTypeLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_WordTypeLinks_Word",
                table: "WordTypeLinks",
                column: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_WordTypeLinks_WordTypeId",
                table: "WordTypeLinks",
                column: "WordTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "WordMeanings");

            migrationBuilder.DropTable(
                name: "WordTypeLinks");

            migrationBuilder.DropTable(
                name: "WordTypes");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
