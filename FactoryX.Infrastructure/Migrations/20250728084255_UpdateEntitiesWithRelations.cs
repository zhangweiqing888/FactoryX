using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactoryX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operators",
                table: "Operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Downtimes",
                table: "Downtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrders",
                table: "WorkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionRecords",
                table: "ProductionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialUsages",
                table: "MaterialUsages");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "shifts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Operators",
                newName: "operators");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "materials");

            migrationBuilder.RenameTable(
                name: "Machines",
                newName: "machines");

            migrationBuilder.RenameTable(
                name: "Downtimes",
                newName: "downtimes");

            migrationBuilder.RenameTable(
                name: "WorkOrders",
                newName: "work_orders");

            migrationBuilder.RenameTable(
                name: "ProductionRecords",
                newName: "production_records");

            migrationBuilder.RenameTable(
                name: "MaterialUsages",
                newName: "material_usages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "shifts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "operators",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "materials",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "machines",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "downtimes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "work_orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "production_records",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "material_usages",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "shifts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "shifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "shifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "products",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "products",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "operators",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNumber",
                table: "operators",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "operators",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "operators",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "materials",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "materials",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "materials",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "materials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "materials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "machines",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "machines",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "machines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "machines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "downtimes",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "downtimes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "downtimes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "work_orders",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "work_orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "work_orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "production_records",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "production_records",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "material_usages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "material_usages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shifts",
                table: "shifts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operators",
                table: "operators",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_machines",
                table: "machines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_downtimes",
                table: "downtimes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_work_orders",
                table: "work_orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_production_records",
                table: "production_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_material_usages",
                table: "material_usages",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_users_Username",
                table: "users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_Code",
                table: "products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_materials_Code",
                table: "materials",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_downtimes_MachineId",
                table: "downtimes",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_work_orders_MachineId",
                table: "work_orders",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_work_orders_ProductId",
                table: "work_orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_production_records_OperatorId",
                table: "production_records",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_production_records_WorkOrderId",
                table: "production_records",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_material_usages_MaterialId",
                table: "material_usages",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_material_usages_WorkOrderId",
                table: "material_usages",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_downtimes_machines_MachineId",
                table: "downtimes",
                column: "MachineId",
                principalTable: "machines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_material_usages_materials_MaterialId",
                table: "material_usages",
                column: "MaterialId",
                principalTable: "materials",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_material_usages_work_orders_WorkOrderId",
                table: "material_usages",
                column: "WorkOrderId",
                principalTable: "work_orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_production_records_operators_OperatorId",
                table: "production_records",
                column: "OperatorId",
                principalTable: "operators",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_production_records_work_orders_WorkOrderId",
                table: "production_records",
                column: "WorkOrderId",
                principalTable: "work_orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_work_orders_machines_MachineId",
                table: "work_orders",
                column: "MachineId",
                principalTable: "machines",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_work_orders_products_ProductId",
                table: "work_orders",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_downtimes_machines_MachineId",
                table: "downtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_material_usages_materials_MaterialId",
                table: "material_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_material_usages_work_orders_WorkOrderId",
                table: "material_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_production_records_operators_OperatorId",
                table: "production_records");

            migrationBuilder.DropForeignKey(
                name: "FK_production_records_work_orders_WorkOrderId",
                table: "production_records");

            migrationBuilder.DropForeignKey(
                name: "FK_work_orders_machines_MachineId",
                table: "work_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_work_orders_products_ProductId",
                table: "work_orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Username",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shifts",
                table: "shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_Code",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operators",
                table: "operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_Code",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_machines",
                table: "machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_downtimes",
                table: "downtimes");

            migrationBuilder.DropIndex(
                name: "IX_downtimes_MachineId",
                table: "downtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_work_orders",
                table: "work_orders");

            migrationBuilder.DropIndex(
                name: "IX_work_orders_MachineId",
                table: "work_orders");

            migrationBuilder.DropIndex(
                name: "IX_work_orders_ProductId",
                table: "work_orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_production_records",
                table: "production_records");

            migrationBuilder.DropIndex(
                name: "IX_production_records_OperatorId",
                table: "production_records");

            migrationBuilder.DropIndex(
                name: "IX_production_records_WorkOrderId",
                table: "production_records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_material_usages",
                table: "material_usages");

            migrationBuilder.DropIndex(
                name: "IX_material_usages_MaterialId",
                table: "material_usages");

            migrationBuilder.DropIndex(
                name: "IX_material_usages_WorkOrderId",
                table: "material_usages");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "products");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "products");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "operators");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "operators");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "machines");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "downtimes");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "downtimes");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "work_orders");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "work_orders");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "production_records");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "production_records");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "material_usages");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "material_usages");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "shifts",
                newName: "Shifts");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "operators",
                newName: "Operators");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "machines",
                newName: "Machines");

            migrationBuilder.RenameTable(
                name: "downtimes",
                newName: "Downtimes");

            migrationBuilder.RenameTable(
                name: "work_orders",
                newName: "WorkOrders");

            migrationBuilder.RenameTable(
                name: "production_records",
                newName: "ProductionRecords");

            migrationBuilder.RenameTable(
                name: "material_usages",
                newName: "MaterialUsages");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shifts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Operators",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Materials",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Machines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Downtimes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WorkOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductionRecords",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MaterialUsages",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shifts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Operators",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNumber",
                table: "Operators",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Materials",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Materials",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Machines",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Machines",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Downtimes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "WorkOrders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operators",
                table: "Operators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Downtimes",
                table: "Downtimes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrders",
                table: "WorkOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionRecords",
                table: "ProductionRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialUsages",
                table: "MaterialUsages",
                column: "Id");
        }
    }
}
