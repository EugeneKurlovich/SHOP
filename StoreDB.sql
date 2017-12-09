create database SHOP;

use SHOP;

select * from products
 insert into products (name_product, price, id_producer,id_cat, description_product) values ('Молоко', 100, 1,0, 'tasty');
 insert into categories (id_cat, name_cat) values (0, 'молочные продукты');
 insert into producer (name_producer, country) values ('Russian Milk', 'Russia');
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

drop table employee;

create table employee
(
id_employee int Identity(1,1) primary key,
name_employee varchar(100),
surname_employee varchar(100),
date_birthday date,
post varchar(100),
empl_login varchar(100),
empl_passw varchar(100)
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


drop procedure addNewEmployee;
go
create procedure addNewEmployee
(
@name_employee varchar(100),
@surname_employee varchar(100),
@date_birthday date,
@post varchar(100),
@log varchar(100),
@pass varchar (100)
)
as
insert into employee (name_employee,surname_employee,date_birthday, post,empl_login,empl_passw)
values (@name_employee, @surname_employee, @date_birthday,@post, @log, @pass);

select * from employee;

create procedure selectProducts
as select name_product, price, description_product from products;

select * from employee