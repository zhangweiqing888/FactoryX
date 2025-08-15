-- FactoryX 数据库索引优化脚本
-- 创建时间: 2024年12月19日
-- 说明: 为FactoryX系统创建必要的数据库索引，提高查询性能

-- 注意：这些索引语句需要在Entity Framework迁移完成后执行
-- 建议在数据库表结构稳定后再创建索引

-- 1. 用户表索引
CREATE INDEX IF NOT EXISTS "IX_Users_Username" ON "Users" ("Username");
CREATE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users" ("Email");
CREATE INDEX IF NOT EXISTS "IX_Users_Role" ON "Users" ("Role");
CREATE INDEX IF NOT EXISTS "IX_Users_IsActive" ON "Users" ("IsActive");

-- 2. 机器表索引
CREATE INDEX IF NOT EXISTS "IX_Machines_Name" ON "Machines" ("Name");
CREATE INDEX IF NOT EXISTS "IX_Machines_SerialNumber" ON "Machines" ("SerialNumber");
CREATE INDEX IF NOT EXISTS "IX_Machines_Status" ON "Machines" ("Status");
CREATE INDEX IF NOT EXISTS "IX_Machines_Location" ON "Machines" ("Location");
CREATE INDEX IF NOT EXISTS "IX_Machines_Type" ON "Machines" ("Type");

-- 3. 产品表索引
CREATE INDEX IF NOT EXISTS "IX_Products_Code" ON "Products" ("Code");
CREATE INDEX IF NOT EXISTS "IX_Products_Name" ON "Products" ("Name");
CREATE INDEX IF NOT EXISTS "IX_Products_Category" ON "Products" ("Category");
CREATE INDEX IF NOT EXISTS "IX_Products_IsActive" ON "Products" ("IsActive");

-- 4. 操作员表索引
CREATE INDEX IF NOT EXISTS "IX_Operators_EmployeeId" ON "Operators" ("EmployeeId");
CREATE INDEX IF NOT EXISTS "IX_Operators_Name" ON "Operators" ("Name");
CREATE INDEX IF NOT EXISTS "IX_Operators_Department" ON "Operators" ("Department");
CREATE INDEX IF NOT EXISTS "IX_Operators_IsActive" ON "Operators" ("IsActive");

-- 5. 班次表索引
CREATE INDEX IF NOT EXISTS "IX_Shifts_Name" ON "Shifts" ("Name");
CREATE INDEX IF NOT EXISTS "IX_Shifts_StartTime" ON "Shifts" ("StartTime");
CREATE INDEX IF NOT EXISTS "IX_Shifts_IsActive" ON "Shifts" ("IsActive");

-- 6. 工单表索引
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_OrderNumber" ON "WorkOrders" ("OrderNumber");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_Status" ON "WorkOrders" ("Status");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_Priority" ON "WorkOrders" ("Priority");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_StartDate" ON "WorkOrders" ("StartDate");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_DueDate" ON "WorkOrders" ("DueDate");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_ProductId" ON "WorkOrders" ("ProductId");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_AssignedMachineId" ON "WorkOrders" ("AssignedMachineId");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_AssignedOperatorId" ON "WorkOrders" ("AssignedOperatorId");

-- 7. 生产记录表索引
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_WorkOrderId" ON "ProductionRecords" ("WorkOrderId");
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_MachineId" ON "ProductionRecords" ("MachineId");
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_OperatorId" ON "ProductionRecords" ("OperatorId");
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_ProductionDate" ON "ProductionRecords" ("ProductionDate");
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_ShiftId" ON "ProductionRecords" ("ShiftId");

-- 8. 停机时间表索引
CREATE INDEX IF NOT EXISTS "IX_Downtimes_MachineId" ON "Downtimes" ("MachineId");
CREATE INDEX IF NOT EXISTS "IX_Downtimes_StartTime" ON "Downtimes" ("StartTime");
CREATE INDEX IF NOT EXISTS "IX_Downtimes_EndTime" ON "Downtimes" ("EndTime");
CREATE INDEX IF NOT EXISTS "IX_Downtimes_Reason" ON "Downtimes" ("Reason");

-- 9. 物料表索引
CREATE INDEX IF NOT EXISTS "IX_Materials_Code" ON "Materials" ("Code");
CREATE INDEX IF NOT EXISTS "IX_Materials_Name" ON "Materials" ("Name");
CREATE INDEX IF NOT EXISTS "IX_Materials_Category" ON "Materials" ("Category");
CREATE INDEX IF NOT EXISTS "IX_Materials_IsActive" ON "Materials" ("IsActive");

-- 10. 物料使用记录表索引
CREATE INDEX IF NOT EXISTS "IX_MaterialUsages_ProductionRecordId" ON "MaterialUsages" ("ProductionRecordId");
CREATE INDEX IF NOT EXISTS "IX_MaterialUsages_MaterialId" ON "MaterialUsages" ("MaterialId");
CREATE INDEX IF NOT EXISTS "IX_MaterialUsages_UsageDate" ON "MaterialUsages" ("UsageDate");

-- 11. 复合索引（提高多字段查询性能）
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_Status_Priority" ON "WorkOrders" ("Status", "Priority");
CREATE INDEX IF NOT EXISTS "IX_WorkOrders_StartDate_DueDate" ON "WorkOrders" ("StartDate", "DueDate");
CREATE INDEX IF NOT EXISTS "IX_ProductionRecords_Date_Machine" ON "ProductionRecords" ("ProductionDate", "MachineId");
CREATE INDEX IF NOT EXISTS "IX_Downtimes_Machine_Time" ON "Downtimes" ("MachineId", "StartTime");

-- 12. 全文搜索索引（PostgreSQL特有功能）
-- 为产品描述创建全文搜索索引
CREATE INDEX IF NOT EXISTS "IX_Products_Description_FTS" ON "Products" USING gin(to_tsvector('chinese', "Description"));

-- 13. 部分索引（只对活跃记录建立索引）
CREATE INDEX IF NOT EXISTS "IX_Users_Active_Username" ON "Users" ("Username") WHERE "IsActive" = true;
CREATE INDEX IF NOT EXISTS "IX_Machines_Active_Status" ON "Machines" ("Status") WHERE "IsActive" = true;
CREATE INDEX IF NOT EXISTS "IX_Products_Active_Code" ON "Products" ("Code") WHERE "IsActive" = true;

-- 显示创建的索引
SELECT 
    schemaname,
    tablename,
    indexname,
    indexdef
FROM pg_indexes 
WHERE tablename IN (
    'Users', 'Machines', 'Products', 'Operators', 'Shifts', 
    'WorkOrders', 'ProductionRecords', 'Downtimes', 'Materials', 'MaterialUsages'
)
ORDER BY tablename, indexname;

-- 完成提示
SELECT '数据库索引创建完成！' as message;
