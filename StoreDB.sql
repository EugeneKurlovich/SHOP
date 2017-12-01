create database SHOP;

use SHOP;

create table products
(
id_product int Identity(1,1) primary key,
name_product varchar(100),
price double precision,
id_producer int,
id_cat int,
description_product varchar(100)
);

create table producer
(
id_producer int Identity(1,1) primary key,
name_producer varchar(100),
country varchar(100) 
);

create table categories
(
id_cat int primary key,
name_cat varchar(100)
);

create table employee
(
id_employee int Identity(1,1) primary key,
name_employee varchar(100),
surname_employee varchar(100),
date_birthday date,
post varchar(100)
);

create table sales
(
id_sales int Identity(1,1) primary key,
date_sales date,
id_product int,
ammount int,
id_employe int,
sum_sales double precision
);

go
create procedure addNewEmployee
(
@name_employee varchar(100),
@surname_employee varchar(100),
@date_birthday date,
@post varchar(100)
)
as
insert into employee (name_employee,surname_employee,date_birthday, post)
values (@name_employee, @surname_employee, @date_birthday,@post);

select * from employee;

