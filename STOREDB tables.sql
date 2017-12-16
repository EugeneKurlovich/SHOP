use StoreDB;

create table products
(
id_product int Identity(1,1) primary key,
name_product varchar(100),
price double precision,
id_producer int,
id_cat int,
description_product varchar(100),
ammount int
);

create table producer
(
id_producer int Identity(1,1) primary key,
name_producer varchar(100),
country varchar(100),
city varchar(20) 
);

create table employee
(
id_employee int Identity(1,1) primary key,
name_employee varchar(100),
surname_employee varchar(100),
post varchar(100),
empl_login varchar(100),
empl_passw varchar(100),
salary double precision
);

create table sales
(
id_sales int Identity(1,1) primary key,
date_sales date,
id_product int,
ammount int,
sum_sales double precision
);

create table categories
(
id_cat int primary key,
name_cat varchar(100)
);

create table delivery
(
id_delivery int  Identity(1,1) primary key,
id_producer int,
id_employee int,
id_product int,
ammount int,
sum_delivery double precision
);