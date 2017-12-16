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

create procedure selectProducts
as select id_product, name_product, price, description_product,ammount, (select name_cat from categories where products.id_cat = categories.id_cat), (select name_producer from producer where products.id_producer = producer.id_producer) from products;

create procedure selectEmployee
as select id_employee, name_employee, surname_employee, post, empl_login, empl_passw, salary from employee;

create procedure deleteEmployeeId(@id int)
as delete from employee where id_employee = @id;


create procedure updateEmployeeId(@id int,@name_employee varchar(100), @surname_employee varchar(100), @post varchar(100), @empl_login varchar(100), @empl_passw varchar(100), @salary float )
as update employee set name_employee = @name_employee, surname_employee = @surname_employee, post = @post,
empl_login = @empl_login, empl_passw = @empl_passw, salary = @salary where id_employee = @id; 

create procedure deleteAllEmployee
as delete from employee;

create procedure updatePriceProduct
(
@id int,
@price float
)
as update products set price = @price where products.id_product = @id;

create procedure getAllCat
as select id_cat, name_cat  from categories;

create procedure updateCategory(@id int , @newname varchar(30))
as update categories set name_cat = @newname where id_cat = @id;

create procedure setDiscountCategory(@id int ,@discount int)
as update products set price = (price * @discount) /100 where id_cat = @id;

create procedure getAllProducers
as select * from producer;

create procedure addNewProduct
(
@nameP varchar(30),
@price float,
@idP int,
@idC int,
@desc varchar(50),
@am int 
)
as insert into products(name_product, price, id_producer, id_cat, description_product, ammount)
values (@nameP,@price,@idP,@idC,@desc,@am);

create procedure deleteProductId(@id int)
as delete from products where id_product = @id;

create procedure getAllSales
as select id_sales,date_sales,id_product, (select name_product from products where products.id_product = sales.id_product), ammount,sum_sales from sales;
getAllSales
select * from products;
select * from sales
insert into sales(date_sales,id_product,ammount,sum_sales) values('12.12.2016',2,1,1);

create procedure getAllUsers
as select empl_login, empl_passw,post from employee

create procedure getAllDelivery
as  select id_delivery,id_producer, (select name_producer from producer where  producer.id_producer = delivery.id_producer),
id_employee,  ( select empl_login from employee where delivery.id_employee = employee.id_employee),id_product, (select name_product from products where products.id_product = delivery.id_product),
ammount, sum_delivery from delivery;

 create procedure buySelectedProduct(@id int, @am int)
 as 
 declare @amm int;
 SET @amm = (select ammount from products where id_product = @id);
 if @amm >@am
 BEGIN
 update products set ammount = ammount - @am where id_product = @id;
  declare @s int;
 declare @date date;
 declare @p float;
 SET @p = (select price from products where id_product = @id);
 SET @s = @am * @p;
 SET @date = GETDATE();
 insert into sales(date_sales,id_product,ammount,sum_sales) values
 (@date, @id,@am,@s);
 END

 create procedure filtrProduct(@id int)
 as select id_product, name_product, price, description_product,ammount, 
 (select name_cat from categories where products.id_cat = categories.id_cat),
  (select name_producer from producer where products.id_producer = producer.id_producer)
  from products where id_cat = @id;

  create procedure getAllEmplLogPass (@l varchar(10) , @p varchar(10))
  as select empl_login, empl_passw, post from employee;

  create procedure startDelivery
  (
  @id int,
  @price float,
  @idP int,
  @log varchar(10),
  @am int
  )
  as
  BEGIN
  declare @idE int;
  SET @idE = (select id_employee from employee where empl_login = @log);
  declare @sD float;
  SET @sD = @price * @am;
  END
  insert into delivery (id_producer,id_employee,id_product,ammount,sum_delivery)
  values(@idP,@idE,@id,@am,@sD);
  update products set ammount = ammount + @am;