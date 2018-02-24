using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Akroma.Persistence.SQL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Difficulty = table.Column<string>(nullable: true),
                    ExtraData = table.Column<string>(nullable: true),
                    GasLimit = table.Column<long>(nullable: false),
                    GasUsed = table.Column<long>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    LogsBloom = table.Column<string>(nullable: true),
                    Miner = table.Column<string>(nullable: true),
                    Nonce = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    ParentHash = table.Column<string>(nullable: true),
                    Sha3Uncles = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    StateRoot = table.Column<string>(nullable: true),
                    Timestamp = table.Column<long>(nullable: false),
                    TotalDifficulty = table.Column<string>(nullable: true),
                    TransactionsRoot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockHash = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Gas = table.Column<string>(nullable: true),
                    GasPrice = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(maxLength: 200, nullable: true),
                    Input = table.Column<string>(nullable: true),
                    Nonce = table.Column<string>(nullable: true),
                    Timestamp = table.Column<long>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    TransactionIndex = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(38,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UncleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockId = table.Column<int>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UncleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UncleEntity_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_Miner",
                table: "Blocks",
                column: "Miner");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BlockHash",
                table: "Transactions",
                column: "BlockHash");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_From",
                table: "Transactions",
                column: "From");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_To",
                table: "Transactions",
                column: "To");

            migrationBuilder.CreateIndex(
                name: "IX_UncleEntity_BlockId",
                table: "UncleEntity",
                column: "BlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UncleEntity");

            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}
