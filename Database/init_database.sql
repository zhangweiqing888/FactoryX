-- FactoryX 数据库初始化脚本
-- 创建时间: 2024年12月19日
-- 说明: 初始化FactoryX工厂管理系统的数据库

-- 1. 创建数据库（如果不存在）
-- 注意：这个命令需要在postgres数据库中执行
-- CREATE DATABASE "FactoryX";

-- 2. 创建专用用户（如果不存在）
-- 注意：这个命令需要在postgres数据库中执行
-- CREATE USER factoryx_user WITH PASSWORD 'FactoryX2024!';

-- 3. 给用户分配数据库权限
-- 注意：这个命令需要在postgres数据库中执行
-- GRANT ALL PRIVILEGES ON DATABASE "FactoryX" TO factoryx_user;

-- 4. 连接到FactoryX数据库后执行以下语句

-- 创建扩展（如果需要）
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- 注意：实际的表结构将通过Entity Framework迁移创建
-- 运行以下命令来应用迁移：
-- dotnet ef database update --project FactoryX.Infrastructure --startup-project FactoryX.Web

-- 5. 插入基础示例数据（在迁移完成后执行）
-- 插入示例用户
INSERT INTO "users" ("Username", "PasswordHash", "Role", "FullName", "Email", "IsActive", "created_at", "updated_at") 
VALUES 
    ('admin', 'admin123', 'Admin', '系统管理员', 'admin@factoryx.com', true, now(), now()),
    ('operator1', 'operator123', 'Operator', '操作员张三', 'operator1@factoryx.com', true, now(), now()),
    ('manager1', 'manager123', 'Manager', '经理李四', 'manager1@factoryx.com', true, now(), now())
ON CONFLICT ("Username") DO NOTHING;

-- 插入示例机器
INSERT INTO "machines" ("Name", "Status", "Capacity", "created_at", "updated_at")
VALUES 
    ('注塑机-01', 'Running', 1000, now(), now()),
    ('冲压机-01', 'Idle', 800, now(), now()),
    ('焊接机-01', 'Maintenance', 1200, now(), now());

-- 插入示例产品
INSERT INTO "products" ("Name", "Code", "Description", "created_at", "updated_at")
VALUES 
    ('塑料外壳A型', 'PROD001', '注塑成型的塑料外壳，适用于电子产品', now(), now()),
    ('金属支架B型', 'PROD002', '冲压成型的金属支架，强度高', now(), now()),
    ('连接器C型', 'PROD003', '精密加工的连接器，质量可靠', now(), now());

-- 插入示例操作员
INSERT INTO "operators" ("Name", "EmployeeNumber", "created_at", "updated_at")
VALUES 
    ('张三', 'EMP001', now(), now()),
    ('李四', 'EMP002', now(), now()),
    ('王五', 'EMP003', now(), now());

-- 插入示例班次
INSERT INTO "shifts" ("Name", "StartTime", "EndTime", "created_at", "updated_at")
VALUES 
    ('早班', '08:00:00', '16:00:00', now(), now()),
    ('中班', '16:00:00', '00:00:00', now(), now()),
    ('夜班', '00:00:00', '08:00:00', now(), now());

-- 插入示例工单
INSERT INTO "work_orders" ("ProductId", "MachineId", "Quantity", "StartDate", "EndDate", "Status", "created_at", "updated_at")
VALUES 
    (1, 1, 100, '2024-12-01', '2024-12-02', 'InProgress', now(), now()),
    (2, 2, 80, '2024-12-01', '2024-12-01', 'Completed', now(), now()),
    (3, 3, 120, '2024-12-02', '2024-12-03', 'Pending', now(), now());

-- 插入示例生产记录
INSERT INTO "production_records" ("WorkOrderId", "OperatorId", "QuantityProduced", "Timestamp", "created_at", "updated_at")
VALUES 
    (1, 1, 50, '2024-12-01 10:00:00', now(), now()),
    (2, 2, 80, '2024-12-01 14:30:00', now(), now()),
    (3, 3, 0, '2024-12-02 08:00:00', now(), now());

-- 插入示例停机时间
INSERT INTO "downtimes" ("MachineId", "StartTime", "EndTime", "Reason", "created_at", "updated_at")
VALUES 
    (1, '2024-12-01 12:00:00', '2024-12-01 13:00:00', '设备维护', now(), now()),
    (2, '2024-12-01 16:00:00', '2024-12-01 16:30:00', '换模调试', now(), now()),
    (3, '2024-12-01 09:00:00', '2024-12-01 11:00:00', '设备故障', now(), now());

-- 插入示例物料
INSERT INTO "materials" ("Name", "Code", "Unit", "created_at", "updated_at")
VALUES 
    ('ABS塑料颗粒', 'MAT001', 'kg', now(), now()),
    ('钢板', 'MAT002', 'kg', now(), now()),
    ('焊丝', 'MAT003', 'kg', now(), now());

-- 插入示例物料使用记录
INSERT INTO "material_usages" ("WorkOrderId", "MaterialId", "Quantity", "created_at", "updated_at")
VALUES 
    (1, 1, 25, now(), now()),
    (2, 2, 40, now(), now()),
    (3, 3, 5, now(), now());

-- 显示插入的数据
SELECT 'users' as table_name, COUNT(*) as record_count FROM "users"
UNION ALL
SELECT 'machines', COUNT(*) FROM "machines"
UNION ALL
SELECT 'products', COUNT(*) FROM "products"
UNION ALL
SELECT 'operators', COUNT(*) FROM "operators"
UNION ALL
SELECT 'shifts', COUNT(*) FROM "shifts"
UNION ALL
SELECT 'work_orders', COUNT(*) FROM "work_orders"
UNION ALL
SELECT 'production_records', COUNT(*) FROM "production_records"
UNION ALL
SELECT 'downtimes', COUNT(*) FROM "downtimes"
UNION ALL
SELECT 'materials', COUNT(*) FROM "materials"
UNION ALL
SELECT 'material_usages', COUNT(*) FROM "material_usages";

-- 完成提示
SELECT '数据库初始化完成！' as message;
