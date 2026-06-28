--建库
create database studentDB;

use studentDB;


--建表
create table userInfo
(
  id int identity(1,1) primary key,
  name varchar(100) unique not null,
  pwd  char(6) not null,
  status  int not null 
)
select * from userInfo

create table  stuInfo
(
  id int identity(1,1) primary key,
  name varchar(100) not null,
  gender char(2) not null,
  birth  date not null,
  photo  varchar(200) default('imgs/default.jpg') not null,
  remark varchar(100)
  
)
--drop table courseInfo
create table  courseInfo
(
   id int identity(1,1) primary key,
   name  varchar(100) not null,
   remark  varchar(100)
)
--drop table scroeInfo;
create table  scoreInfo
(
   stuId int,
   courseId int,
   score  int,
   remark  varchar(100),
   primary key(stuId,courseId),--联合主键
   foreign key(stuId) references stuInfo(id),
   foreign key(courseId) references courseInfo(id)

)
--测试数据

--DML语句
--SQL: Structed  Query Language
--DDL:数据定义语言
      --create： database,table,view,role,user,trigger,procedure。。。创建结构
	  --drop:删除
	  --alter:修改
	  
--DML: 数据操作语言*****
      --select 查询,检索
	     

	  --insert:添加信息 insert into 表名[(列名,列名)]  values(值,)
	    --insert:添加信息 insert into 表名 values(值,)
	    --char,varchar,date值:'值'
		--自增列:自动增长，可以不管(sql,(oralce,mysql===>null,0替代))
		--外键的信息:必须存在主表中
		select * from userInfo;
		insert into userInfo values('admin','123',1);
		insert into userInfo values('laowang','wang',0);


		select * from  stuInfo;
		insert into stuInfo values('lucy','女','2005-01-01',default,'好年轻');
		insert into stuInfo values('tim','男','2005-09-01',default,'重读幼儿园大班');
		insert into stuInfo values('kitty','女','2006-01-01',default,'可爱');
		delete from stuInfo where id >3

		insert into stuInfo values('joy','男','2006-02-01',default,'帅气');

		select * from courseInfo

		insert into courseInfo values('数据结构','有点难');
		insert into courseInfo values('sqlserver','有点简单');
        insert into courseInfo values('C#','有点好');

		select * from stuInfo;
		select * from courseInfo;
		select * from scoreInfo;

		insert into scoreInfo values(1,1,90,'good job');
		insert into scoreInfo values(1,2,100,'good job');
		insert into scoreInfo values(1,3,98,'good job');

        insert into scoreInfo values(2,1,100,'good job');
		insert into scoreInfo values(2,2,95,'good job');
		insert into scoreInfo values(2,3,60,'come on');


		insert into scoreInfo values(3,1,50,'come on');
		insert into scoreInfo values(3,3,98,'good job');

		insert into scoreInfo values(3,4,98,'good job');--INSERT 语句与 FOREIGN KEY 约束"FK__scoreInfo__cours__403A8C7D"冲突。该冲突发生于数据库"studentDB"，表"dbo.courseInfo", column 'id'。

	  --update:修改  update 表名  set 列名= 值[, 列名2=值2,.....] where 条件=   条件:一般主键
	    
      update stuInfo  set name='??',gender ='',birth='',photo='',remark='' where id=?
	  --delete:删除  delete from 表名 where 条件
	  --truncat table  删除表


	  --select
	    --1.select * from 表名;整个表所有的信息都能查出来(效率最低)
		--2.select id,name,pwd,status from userInfo;  所有行都能查询出来
		--3.select * from userInfo where id=xxx and name=xxx :根据条件查询
		--4.select * from stuInfo where name like '%t%'
		select * from scoreInfo;
		--5.分组查询
		 select stuId, sum(score)  from scoreInfo 
		 group by stuId;

		 --6.表联接:内联(a:stuInf,b:scoreInfo)，外联(左，右)，全联，交叉联
		  select * from stuInfo;
		  select * from scoreInfo;

		  select a.name,b.score from stuInfo a,scoreInfo b
		  where a.id= b.stuId;

		  select a.name,count(b.score)as 考试科目总数,sum(b.score) as 总分 from stuInfo a,scoreInfo b
		  where a.id= b.stuId
		  group by a.name



--DCL:数据控制语言
      -- grant：赋权限  revoke:回收权限
--TCL:事务语言
      --commit ,rollback


	  ---使用Ado.net完成用户登录
	  select * from userInfo;

	  --"admin","123456"
	  select * from userInfo where name='admin' and pwd='123' and status=1
	  select * from userInfo where name='admin' and pwd='1234' and status=1
	  --有数据，就能登录，没有数据就不能登录

	    select count(*) from userInfo where name='admin' and pwd='123' and status=1
		select count(*) from userInfo where name='admin' and pwd='1234' and status=1

		 select * from userInfo where name='11' and pwd='22' and status=1

		 --修改数据
		 update userInfo set status=1 where id=2;
		 select * from userInfo;


