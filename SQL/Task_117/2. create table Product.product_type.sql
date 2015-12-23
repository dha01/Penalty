-- Создание таблицы Product.product_type.
create table Product.product_type
(
	product_type int identity(1,1) not null,
	code varchar(128) not null,
	mem nvarchar(512) null,
	constraint PK__product_type primary key (product_type)
)

-- Создание основных типов продуктов.
insert into Product.product_type (code, mem)
values
	('Milk', 'Молочная продукция.'),
	('Bread', 'Хлебная продукция.'),	
	('Meat', 'Мясная продукция.'),	
	('Fish', 'Рыбная продукция.')


