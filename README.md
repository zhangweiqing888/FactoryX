# FactoryX

## Overview
FactoryX is a modular backend platform for factory management, built with .NET 9. It provides a foundation for digitalizing manufacturing operations, including machine tracking, production planning, operator management, inventory, and downtime analytics. The project is structured for maintainability and extensibility, making it suitable for both learning and real-world prototyping.

## Why FactoryX?
- **Layered Structure:** Clear separation between domain, application, infrastructure, and web layers for easier maintenance.
- **Extensible:** Easily add new entities, services, or integrations as your factory grows.
- **Practical Patterns:** Uses DTOs, repository pattern, dependency injection, and mapping for a clean and testable codebase.

## Features
- Machine management (CRUD, status, capacity)
- Operator management and shift assignments
- Product and material inventory tracking
- Work order and production scheduling
- Production record logging
- Downtime tracking and reporting
- User authentication and role management
- Consistent response and request handling patterns

## Solution Structure
- **Domain:** Entity definitions
- **Application:** DTOs, validators, service abstractions, and mapping profiles 
- **Infrastructure:** EF Core DbContext, repository implementations, dependency injection helpers 
- **Web:** ASP.NET MVC Web API for UI

## Technologies Used
- .NET 9 (C#)
- ASP.NET Core Web API
- Entity Framework Core (with Npgsql for PostgreSQL)
- AutoMapper (object mapping)
- FluentValidation (input validation)
- PostgreSQL (primary database)

## Getting Started

### Prerequisites
- .NET 9 SDK
- PostgreSQL 16+
- Visual Studio 2022, VS Code, or any C# editor

### Database Setup

#### 1. 安装PostgreSQL
```bash
# Ubuntu/Debian
sudo apt update
sudo apt install postgresql postgresql-contrib

# CentOS/RHEL 8+
sudo dnf install postgresql postgresql-server postgresql-contrib
sudo postgresql-setup --initdb

# 启动服务
sudo systemctl start postgresql
sudo systemctl enable postgresql
```

#### 2. 配置PostgreSQL远程连接
```bash
# 编辑postgresql.conf
sudo nano /etc/postgresql/*/main/postgresql.conf
# 修改：listen_addresses = '*'

# 编辑pg_hba.conf
sudo nano /etc/postgresql/*/main/pg_hba.conf
# 添加：host all all 0.0.0.0/0 md5

# 重启服务
sudo systemctl restart postgresql
```

#### 3. 创建数据库和用户
```bash
# 连接到PostgreSQL
sudo -u postgres psql

# 创建数据库和用户
CREATE DATABASE "FactoryX";
CREATE USER factoryx_user WITH PASSWORD 'FactoryX2024!';
GRANT ALL PRIVILEGES ON DATABASE "FactoryX" TO factoryx_user;

# 退出
\q
```

### Project Setup

#### 1. 克隆项目
```bash
git clone https://github.com/berkanserbes/FactoryX.git
cd FactoryX
```

#### 2. 配置连接字符串
编辑 `FactoryX.Web/appsettings.json` 和 `FactoryX.Web/appsettings.Development.json`：
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=your_host;Port=5432;Database=FactoryX;Username=factoryx_user;Password=FactoryX2024!;"
  }
}
```

#### 3. 应用数据库迁移
```bash
# 还原NuGet包
dotnet restore

# 构建项目
dotnet build

# 应用数据库迁移
dotnet ef database update --project FactoryX.Infrastructure --startup-project FactoryX.Web
```

#### 4. 初始化示例数据
```bash
# 连接到FactoryX数据库
psql -U factoryx_user -h your_host -d FactoryX

# 执行初始化脚本
\i Database/init_database.sql

# 创建性能索引（可选）
\i Database/create_indexes.sql
```

#### 5. 运行项目
```bash
# 运行Web项目
dotnet run --project FactoryX.Web

# 或者使用Visual Studio
# 设置FactoryX.Web为启动项目，按F5运行
```

### 访问应用
- 主页：`https://localhost:5001` 或 `http://localhost:5000`
- 仪表板：`/Home/Dashboard`
- 默认用户：
  - 管理员：`admin` / `password`
  - 操作员：`operator1` / `password`
  - 经理：`manager1` / `password`

## Database Management

### 连接信息
- **主机**: 您的PostgreSQL服务器IP
- **端口**: 5432
- **数据库**: FactoryX
- **用户名**: factoryx_user
- **密码**: FactoryX2024!

### 数据库工具推荐
- **pgAdmin**: 官方PostgreSQL管理工具
- **DBeaver**: 跨平台数据库工具
- **Navicat**: 商业数据库管理工具

### 性能优化
- 项目包含完整的数据库索引脚本
- 支持PostgreSQL全文搜索
- 使用连接池优化性能

## Troubleshooting

### 常见问题

#### 1. 连接字符串错误
```
InvalidOperationException: The ConnectionString property has not been initialized.
```
**解决方案**: 检查appsettings.json中的连接字符串配置

#### 2. 数据库连接失败
```
Npgsql.NpgsqlException: connection to the server was lost
```
**解决方案**: 
- 检查PostgreSQL服务状态
- 验证防火墙设置
- 确认pg_hba.conf配置

#### 3. 迁移失败
```
dotnet ef : Could not execute because the specified command or file was not found.
```
**解决方案**: 安装EF Core工具
```bash
dotnet tool install --global dotnet-ef
```

### 日志查看
```bash
# 查看PostgreSQL日志
sudo tail -f /var/log/postgresql/postgresql-*.log

# 查看应用日志
# 在appsettings.json中配置日志级别
```

## Contributing
Contributions are welcome! To get started:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to your branch (`git push origin feature/your-feature`)
5. Open a Pull Request

Please follow the existing code style and add tests for new features. For major changes, open an issue first to discuss your proposal.

## License
FactoryX is released under the MIT License. See the [LICENSE](LICENSE) file for details.

---
*Built for practical factory management and learning ASP.NET MVC development.*

## 更新日志

### 2024-12-19
- 添加了完整的数据库配置说明
- 创建了数据库初始化脚本
- 添加了性能优化索引脚本
- 更新了项目运行指南
- 添加了故障排除说明