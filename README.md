# 学员管理系统

甲骨文实习项目 — 基于 C# 三层架构的 WinForms 桌面应用

---

## 项目简介

学员管理系统是一个用于管理学员信息、学科信息和成绩信息的桌面应用程序。项目采用经典的**三层架构**（UI → BLL → DAL）设计，使用 ADO.NET 操作 SQL Server 数据库，实现了用户登录、学员管理、学科管理、成绩管理及成绩统计等功能。

## 技术栈

| 类别 | 技术 |
|------|------|
| 开发语言 | C# |
| 框架 | .NET Framework 4.7.2 |
| UI 框架 | Windows Forms (WinForms) |
| 数据库 | SQL Server |
| 数据访问 | ADO.NET（SqlConnection / SqlCommand / SqlDataAdapter） |
| 开发工具 | Visual Studio |
| 版本控制 | Git |

---

## 项目结构

```
WindowsFormsApp1/
│
├── entity/                    # 实体类层 — 与数据库表一一对应
│   ├── UserInfo.cs            #   用户实体（id, name, pwd, status）
│   ├── StuInfo.cs             #   学员实体（id, name, gender, birth, photo, remark）
│   ├── CourseInfo.cs          #   学科实体（id, name, remark）
│   └── ScoreInfo.cs           #   成绩实体（stuId, courseId, score, remark）
│
├── dal/                       # 数据访问层 — 封装 CRUD SQL 操作
│   ├── UserDao.cs             #   用户表增删改查
│   ├── StudentDao.cs          #   学员表增删改查
│   ├── CourseDao.cs           #   学科表增删改查
│   └── ScoreDao.cs            #   成绩表增删改查 + 联合查询
│
├── bll/                       # 业务逻辑层 — 处理业务规则与验证
│   ├── UserBll.cs             #   登录验证、用户状态管理
│   ├── StudentBll.cs          #   学员业务（含删除保护校验）
│   ├── CourseBll.cs           #   学科业务（含删除保护校验）
│   └── ScoreBll.cs            #   成绩业务（含重复录入校验）
│
├── util/                      # 工具类层
│   ├── DBUtil.cs              #   数据库连接管理 + 4 种执行模式
│   └── FileHelper.cs          #   项目根目录定位 + 相对路径解析
│
├── imgs/                      # 静态资源
│   └── default.jpg            #   学员默认头像
│
├── ppt/                       # 瑞士风项目答辩 PPT
│   └── index.html             #   单文件 HTML 演示文稿（10 页）
│
├── FormMain.cs                # 主窗体（MDI 容器 + 菜单导航）
├── Form1.cs                   # 登录窗体
├── FrmAddStudent.cs           # 添加学员
├── FrmStudentManagement.cs    # 学员管理列表
├── FrmModifyStudent.cs        # 修改学员
├── FrmAddCourse.cs            # 添加学科
├── FrmCourseManagement.cs     # 学科管理列表
├── FrmModifyCourse.cs         # 修改学科
├── FrmAddScore.cs             # 添加成绩
├── FrmScoreManagement.cs      # 成绩管理列表
├── FrmModifyScore.cs          # 修改成绩
├── FrmScoreStatistics.cs      # 成绩统计（按学员/按课程/总览）
├── FrmAddUser.cs              # 添加用户
├── FrmUserManagment.cs        # 用户管理列表
├── FrmModifyUser.cs           # 修改用户
├── create_sql(3).sql          # 数据库建表脚本 + 示例数据
└── WindowsFormsApp1.csproj    # 项目文件
```

---

## 三层架构

```
┌─────────────────────────────────────────────────┐
│  UI 层（WinForms 界面）                          │
│  Form1 · FormMain · FrmAdd/Management/Modify     │
│  负责用户交互、输入验证、数据展示                    │
├─────────────────────────────────────────────────┤
│  BLL 层（业务逻辑）                               │
│  UserBll · StudentBll · CourseBll · ScoreBll     │
│  处理业务规则（如删除保护、重复校验）                 │
├─────────────────────────────────────────────────┤
│  DAL 层（数据访问）                               │
│  UserDao · StudentDao · CourseDao · ScoreDao     │
│  封装 SQL 语句，通过 DBUtil 执行数据库操作           │
├─────────────────────────────────────────────────┤
│  DB（SQL Server · studentDB）                    │
│  userInfo · stuInfo · courseInfo · scoreInfo      │
└─────────────────────────────────────────────────┘
```

**调用链路**：UI → BLL → DAL → DBUtil → SQL Server

每一层只依赖其下一层，实体类（entity）贯穿三层用于数据传递。

---

## 数据库设计

```sql
-- 用户表
userInfo (
  id      INT IDENTITY(1,1) PRIMARY KEY,
  name    VARCHAR(100) UNIQUE NOT NULL,
  pwd     CHAR(6) NOT NULL,
  status  INT NOT NULL              -- 1:启用 0:禁用
)

-- 学员表
stuInfo (
  id      INT IDENTITY(1,1) PRIMARY KEY,
  name    VARCHAR(100) NOT NULL,
  gender  CHAR(2) NOT NULL,
  birth   DATE NOT NULL,
  photo   VARCHAR(200) DEFAULT('imgs/default.jpg') NOT NULL,
  remark  VARCHAR(100)
)

-- 学科表
courseInfo (
  id      INT IDENTITY(1,1) PRIMARY KEY,
  name    VARCHAR(100) NOT NULL,
  remark  VARCHAR(100)
)

-- 成绩表（复合主键 + 外键约束）
scoreInfo (
  stuId    INT,
  courseId  INT,
  score    INT,
  remark   VARCHAR(100),
  PRIMARY KEY (stuId, courseId),
  FOREIGN KEY (stuId)   REFERENCES stuInfo(id),
  FOREIGN KEY (courseId) REFERENCES courseInfo(id)
)
```

**关系说明**：`scoreInfo` 通过 `stuId` 和 `courseId` 分别关联学员表和学科表，形成多对多关系。删除学员或学科时，BLL 层会检查是否存在关联成绩记录，防止外键冲突。

---

## 功能模块

### 1. 用户登录
- 用户名 + 密码登录验证
- 状态字段控制账号启用/禁用（status=1 可登录）

### 2. 学员管理
- **添加学员**：姓名、性别、出生日期、照片（OpenFileDialog 选择 + PictureBox 实时预览）、备注
- **管理学员**：DataGridView 列表展示，支持查询、修改、删除
- **删除保护**：有成绩记录的学员禁止删除，给出提示
- **默认头像**：未上传照片时自动使用 `imgs/default.jpg`

### 3. 学科管理
- **添加学科**：学科名称、备注
- **管理学科**：列表展示，支持查询、修改、删除
- **删除保护**：有成绩记录的学科禁止删除

### 4. 成绩管理
- **添加成绩**：下拉选择学员和学科，输入分数和备注
- **管理成绩**：列表展示，支持按学员 ID 查询、修改、删除
- **重复校验**：同一学员同一学科不可重复录入

### 5. 成绩统计（三种模式）
- **按学员统计**：按学员分组，显示参考科目数、总分、平均分、最高/最低分
- **按课程统计**：按课程分组，显示参考人数、总分、平均分、最高/最低分、及格人数、及格率
- **总览统计**：全局汇总 — 总学员数、总课程数、总记录数、总平均分、最高/最低分、及格率、优秀率、分数段分布（0-59 / 60-69 / 70-79 / 80-89 / 90-100）
- 使用 LINQ `GroupBy` 在内存中聚合，支持一键刷新

---

## 关键技术点

### DBUtil — 数据库工具类
封装 `SqlConnection` 生命周期，提供 4 种执行模式：
| 方法 | 用途 | 返回类型 |
|------|------|----------|
| `ExecuteNonQuery` | 增删改（INSERT/UPDATE/DELETE） | `int`（受影响行数） |
| `ExecuteReader` | 读取流式数据 | `SqlDataReader` |
| `ExecuteScalar` | 查询单值（如 COUNT） | `object` |
| `ExecuteQuery` | 填充 DataTable | `DataTable` |

所有方法接收 `params SqlParameter[]` 参数，防止 SQL 注入。

### FileHelper — 文件工具类
- `FindProjectRoot()`：从 `AppDomain.BaseDirectory` 向上遍历查找 `.csproj` 文件，定位项目根目录，解决 `bin/Debug` 下运行时的相对路径问题
- `GetFullPath()`：将相对路径（如 `imgs/default.jpg`）解析为绝对路径
- `FileExists()`：自动处理相对/绝对路径的文件存在性检查

### MDI 多文档界面
主窗体 `FormMain` 作为 MDI 容器，各功能窗体以子窗体方式打开，支持多窗口并排操作。

### 参数化查询防注入
所有 SQL 操作通过 `SqlParameter[]` 传递参数，避免字符串拼接导致的 SQL 注入风险。

---

## 使用说明

### 环境要求
- Windows 操作系统
- Visual Studio 2019/2022
- SQL Server（Express 或完整版）
- .NET Framework 4.7.2

### 运行步骤

1. **创建数据库**：在 SQL Server 中执行 `create_sql(3).sql` 脚本，创建 `studentDB` 数据库及 4 张表
2. **修改连接字符串**：打开 `util/DBUtil.cs`，修改 `connStr` 中的 `Data Source`、`User ID`、`Password` 为你的 SQL Server 配置
3. **打开项目**：使用 Visual Studio 打开 `WindowsFormsApp1.sln`
4. **生成并运行**：按 `Ctrl+Shift+B` 生成解决方案，按 `F5` 运行
5. **登录系统**：使用默认账号 `admin` / `123` 登录

### 默认账号
| 用户名 | 密码 | 状态 |
|--------|------|------|
| admin | 123 | 启用 |

---

## 更新日志（部分）
2026-6-27开始该项目
- **2026-07-01**
  - 新增成绩统计模块（按学员 / 按课程 / 总览三种统计模式）
  - 新增默认头像图片及 FileHelper 路径解析工具类
  - 修复修改学员窗体中相对路径无法加载图片的问题
  - 制作瑞士国际主义风格项目答辩 PPT（10 页）
  - 优化整体项目结构

- **2026-06-30**
  - 重构项目为三层架构（UI → BLL → DAL）
  - 实现用户管理、学员管理、学科管理、成绩管理 CRUD 功能
  - 实现学员和学科的删除保护（外键关联检查）
  - 实现学员照片上传与 PictureBox 预览
  - 完成数据库设计与建表脚本

