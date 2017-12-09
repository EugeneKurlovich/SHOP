create database StoreDB;
use storeDB;

select * from producer;
insert into producer(name_producer, country,city) values ('Дняпроўскi збан','РБ','Гомель');
insert into producer(name_producer, country,city) values ('Идеал','РБ','Минск');
insert into producer (name_producer, country,city) values ('Кстати','РБ','Гродно');
insert into producer(name_producer, country,city) values ('Бабушкины деликатесы','РБ','Могилёв');
insert into producer(name_producer, country,city) values ('Белорусская кофейня','РБ','Витебск');
insert into producer(name_producer, country,city) values ('Вкус рыбы','РБ','Речица');
insert into producer(name_producer, country,city) values ('Коммунарка','РБ','Минск');
insert into producer(name_producer, country,city) values ('Трайпл','РБ','Брест');
insert into producer(name_producer, country,city) values ('МяскоВит','РБ','Минск');
insert into producer(name_producer, country,city) values ('ТворожкоМорожко','РФ','Смоленск');
insert into producer(name_producer, country,city) values ('Хлебный Дар','РФ','Москва');
insert into producer(name_producer, country,city) values ('Ферма','РБ','Минская область');
insert into producer(name_producer, country,city) values ('Хозяйственная Ферма','РФ','Московская область');
insert into producer(name_producer, country,city) values ('Соусный мир','Украина','Киев');

select * from categories;

insert into categories(id_cat, name_cat) values(0, 'молочные продукты');
insert into categories(id_cat, name_cat) values(1, 'соки,напитки');
insert into categories(id_cat, name_cat) values(2, 'мясо');
insert into categories(id_cat, name_cat) values(3, 'рыба');
insert into categories(id_cat, name_cat) values(4, 'чай, кофе');
insert into categories(id_cat, name_cat) values(5, 'конфеты');
insert into categories(id_cat, name_cat) values(6, 'печенье');
insert into categories(id_cat, name_cat) values(7, 'зерновые');
insert into categories(id_cat, name_cat) values(8, 'фрукты');
insert into categories(id_cat, name_cat) values(9, 'овощи');
insert into categories(id_cat, name_cat) values(11, 'соусы');
insert into categories(id_cat, name_cat) values(12, 'хлебобулочные изделия');


select * from products;
insert into products(name_product,price, id_producer, id_cat, description_product,ammount) values('Хлеб', 1, 11,12, 'Нормальный хлеб', 50);

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
ammount int,
sum_delivery double precision
);

go
create procedure addNewEmployee
(
@name_employee varchar(100),
@surname_employee varchar(100),
@post varchar(100),
@log varchar(100),
@pass varchar (100),
@salary double precision
)
as
insert into employee (name_employee,surname_employee, post,empl_login,empl_passw, salary)
values (@name_employee, @surname_employee,@post, @log, @pass, @salary);

select * from employee;
select * from products;
drop procedure selectProducts;

create procedure selectProducts
as select id_product, name_product, price, description_product,ammount, (select name_cat from categories where products.id_cat = categories.id_cat), (select name_producer from producer where products.id_producer = producer.id_producer) from products;

select * from employee;

create procedure selectEmployee
as select id_employee, name_employee, surname_employee, post, empl_login, empl_passw, salary from employee;