using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HubAllergies",
                columns: table => new
                {
                    AllergyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubAllergies", x => x.AllergyId);
                });

            migrationBuilder.CreateTable(
                name: "HubCuisines",
                columns: table => new
                {
                    CuisineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubCuisines", x => x.CuisineId);
                });

            migrationBuilder.CreateTable(
                name: "HubDietaryRestrictions",
                columns: table => new
                {
                    DietaryRestrictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubDietaryRestrictions", x => x.DietaryRestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "HubDietaryTags",
                columns: table => new
                {
                    DietaryTagId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubDietaryTags", x => x.DietaryTagId);
                });

            migrationBuilder.CreateTable(
                name: "HubIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubIngredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "HubPersons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubPersons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "HubRecipes",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubRecipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "LinkIngredientAllergies",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllergyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkIngredientAllergies", x => new { x.IngredientId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_LinkIngredientAllergies_HubAllergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "HubAllergies",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkIngredientAllergies_HubIngredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "HubIngredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatIngredients", x => new { x.IngredientId, x.LoadDate });
                    table.ForeignKey(
                        name: "FK_SatIngredients_HubIngredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "HubIngredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPersonAllergies",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllergyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPersonAllergies", x => new { x.PersonId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_LinkPersonAllergies_HubAllergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "HubAllergies",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPersonAllergies_HubPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "HubPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPersonCuisinePreferences",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CuisineId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPersonCuisinePreferences", x => new { x.PersonId, x.CuisineId });
                    table.ForeignKey(
                        name: "FK_LinkPersonCuisinePreferences_HubCuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "HubCuisines",
                        principalColumn: "CuisineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPersonCuisinePreferences_HubPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "HubPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPersonDietaryRestrictions",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    DietaryRestrictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPersonDietaryRestrictions", x => new { x.PersonId, x.DietaryRestrictionId });
                    table.ForeignKey(
                        name: "FK_LinkPersonDietaryRestrictions_HubDietaryRestrictions_Dietar~",
                        column: x => x.DietaryRestrictionId,
                        principalTable: "HubDietaryRestrictions",
                        principalColumn: "DietaryRestrictionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPersonDietaryRestrictions_HubPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "HubPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatPersons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatPersons", x => new { x.PersonId, x.LoadDate });
                    table.ForeignKey(
                        name: "FK_SatPersons_HubPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "HubPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPersonRecipe",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPersonRecipe", x => new { x.PersonId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_LinkPersonRecipe_HubPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "HubPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPersonRecipe_HubRecipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "HubRecipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkRecipeCuisines",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CuisineId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRecipeCuisines", x => new { x.RecipeId, x.CuisineId });
                    table.ForeignKey(
                        name: "FK_LinkRecipeCuisines_HubCuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "HubCuisines",
                        principalColumn: "CuisineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkRecipeCuisines_HubRecipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "HubRecipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkRecipeDietaryTags",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    DietaryTagId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRecipeDietaryTags", x => new { x.RecipeId, x.DietaryTagId });
                    table.ForeignKey(
                        name: "FK_LinkRecipeDietaryTags_HubDietaryTags_DietaryTagId",
                        column: x => x.DietaryTagId,
                        principalTable: "HubDietaryTags",
                        principalColumn: "DietaryTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkRecipeDietaryTags_HubRecipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "HubRecipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatRecipes",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecordSource = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatRecipes", x => new { x.RecipeId, x.LoadDate });
                    table.ForeignKey(
                        name: "FK_SatRecipes_HubRecipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "HubRecipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkIngredientAllergies_AllergyId",
                table: "LinkIngredientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPersonAllergies_AllergyId",
                table: "LinkPersonAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPersonCuisinePreferences_CuisineId",
                table: "LinkPersonCuisinePreferences",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPersonDietaryRestrictions_DietaryRestrictionId",
                table: "LinkPersonDietaryRestrictions",
                column: "DietaryRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPersonRecipe_RecipeId",
                table: "LinkPersonRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRecipeCuisines_CuisineId",
                table: "LinkRecipeCuisines",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRecipeDietaryTags_DietaryTagId",
                table: "LinkRecipeDietaryTags",
                column: "DietaryTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkIngredientAllergies");

            migrationBuilder.DropTable(
                name: "LinkPersonAllergies");

            migrationBuilder.DropTable(
                name: "LinkPersonCuisinePreferences");

            migrationBuilder.DropTable(
                name: "LinkPersonDietaryRestrictions");

            migrationBuilder.DropTable(
                name: "LinkPersonRecipe");

            migrationBuilder.DropTable(
                name: "LinkRecipeCuisines");

            migrationBuilder.DropTable(
                name: "LinkRecipeDietaryTags");

            migrationBuilder.DropTable(
                name: "SatIngredients");

            migrationBuilder.DropTable(
                name: "SatPersons");

            migrationBuilder.DropTable(
                name: "SatRecipes");

            migrationBuilder.DropTable(
                name: "HubAllergies");

            migrationBuilder.DropTable(
                name: "HubDietaryRestrictions");

            migrationBuilder.DropTable(
                name: "HubCuisines");

            migrationBuilder.DropTable(
                name: "HubDietaryTags");

            migrationBuilder.DropTable(
                name: "HubIngredients");

            migrationBuilder.DropTable(
                name: "HubPersons");

            migrationBuilder.DropTable(
                name: "HubRecipes");
        }
    }
}
