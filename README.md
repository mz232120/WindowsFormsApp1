# 学员管理系统 (WindowsFormsApp1)

甲骨文实习项目 - 基于三层架构的学员管理系统

## 项目简介

本项目是一个使用 C# WinForms 开发的学员管理系统，采用三层架构设计，实现用户管理、学员管理、学科管理和成绩管理功能。

## 技术栈

- 开发语言：C#
- 框架：.NET Framework 4.7.2
- 数据库：SQL Server
- 开发工具：Visual Studio

## 项目结构

```
WindowsFormsApp1/
├── entity/          # 实体类层（对应数据库表）
│   ├── UserInfo.cs      # 用户实体
│   ├── CourseInfo.cs    # 学科实体
│   ├── StuInfo.cs       # 学员实体
│   └── ScoreInfo.cs     # 成绩实体（含外键关联）
│
├── dal/             # 数据访问层 (Data Access Layer)
│   ├── UserDao.cs       # 用户数据库操作
│   ├── CourseDao.cs     # 学科数据库操作
│   ├── StudentDao.cs    # 学员数据库操作
│   └── ScoreDao.cs      # 成绩数据库操作
│
├── bll/             # 业务逻辑层 (Business Logic Layer)
│   ├── UserBll.cs       # 用户业务处理
│   ├── CourseBll.cs     # 学科业务处理
│   ├── StudentBll.cs    # 学员业务处理
│   └── ScoreBll.cs      # 成绩业务处理
│
├── util/            # 工具类
│   └── DBUtil.cs        # 数据库连接和通用操作
│
└── ui/              # 界面层 (WinForms)
    ├── FormMain.cs           # 主窗体（MDI容器）
    ├── FrmAddUser.cs         # 添加用户
    ├── FrmUserManagment.cs   # 用户管理
    ├── FrmModifyUser.cs      # 修改用户
    ├── FrmAddCourse.cs       # 添加学科
    ├── FrmCourseManagement.cs # 学科管理
    ├── FrmModifyCourse.cs    # 修改学科
    ├── FrmAddStudent.cs      # 添加学员
    ├── FrmStudentManagement.cs # 学员管理
    ├── FrmModifyStudent.cs   # 修改学员
    ├── FrmAddScore.cs        # 添加成绩
    ├── FrmScoreManagement.cs # 成绩管理
    └── FrmModifyScore.cs     # 修改成绩
```

## 功能模块

### 1. 用户管理
- 添加用户（用户名、密码、状态）
- 管理用户（查询、修改、删除）
- 用户登录验证

### 2. 学员管理
- 添加学员（姓名、性别、出生日期、照片、备注）
- 管理学员（查询、修改、删除）
- 删除保护：有成绩记录的学员不能删除

### 3. 学科管理
- 添加学科（学科名称、备注）
- 管理学科（查询、修改、删除）
- 删除保护：有成绩记录的学科不能删除

### 4. 成绩管理
- 添加成绩（选择学员、学科、输入分数）
- 管理成绩（查询、修改、删除）
- 支持按学员ID查询

## 数据库设计

```sql
-- 用户表
userInfo (id, name, pwd, status)

-- 学员表
stuInfo (id, name, gender, birth, photo, remark)

-- 学科表
courseInfo (id, name, remark)

-- 成绩表（含外键）
scoreInfo (stuId, courseId, score, remark)
  - stuId → stuInfo.id
  - courseId → courseInfo.id
```

## 三层架构说明

| 层级 | 说明 |
|------|------|
| **entity** | 实体类，与数据库表一一对应 |
| **dal** | 数据访问层，封装数据库CRUD操作 |
| **bll** | 业务逻辑层，处理业务规则和验证 |
| **ui** | 界面层，负责用户交互和显示 |

## 使用说明

1. 确保已安装 SQL Server 并创建数据库
2. 执行 `create_sql(3).sql` 脚本创建数据库和表
3. 修改 `util/DBUtil.cs` 中的数据库连接字符串
4. 使用 Visual Studio 打开项目并运行

## 更新日志

- **2026-06-30**：重构项目为三层架构，添加学员管理和成绩管理功能
