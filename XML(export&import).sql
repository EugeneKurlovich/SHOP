use StoreDB;

select * from products;
select * from delivery;
delete  from products where name_product = ' вас'; 
delete from delivery where id_product = 5

go
alter procedure ExportProducts
AS
	SELECT id_product, name_product, price, id_producer, id_cat, description_product, ammount
	FROM products
	FOR XML PATH('product'), ROOT('Products');

	ExportProducts;



alter PROCEDURE IMPORT_Products
	@xml xml
AS
Select  @xml  = 
CONVERT(XML,bulkcolumn,2) FROM OPENROWSET(BULK 'E:\SHOP\import.xml',SINGLE_BLOB) AS X
SET ARITHABORT ON
Insert into products
        (
          name_product, price, id_producer, id_cat, description_product, ammount
        )
    Select 
        P.value('name_product[1]', 'varchar(100)') AS name_product,
        P.value('price[1]', 'float') AS price,
        P.value('id_producer[1]', 'int') AS id_producer,
        P.value('id_cat[1]', 'int') AS id_cat,
        P.value('description_product[1]', 'varchar(100)') AS description_product,
        P.value('ammount[1]', 'int') as ammount

    From @xml.nodes('/Products/product') PropertyFeed(P)
GO

IMPORT_Products();