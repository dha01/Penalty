-- Создание таблицы "Product.product"
create table Product.product
(
	product int identity(1,1) not null,
	name nvarchar(256) not null,
	expiration_date date null,
	price int null,
	position int null,
	product_type nvarchar(256) not null,
	unit nvarchar(256) not null
	constraint PK__product primary key (product)
)
-- Добавляние записей в таблицу.
insert into Product.product(name,expiration_date,price,position,product_type,unit)
	values
			('Молоко', '2016-01-01', 35, 2, 'Milk', 'Liter'),
			('Хлеб', '2017-01-01', 55, 1, 'Bread', 'Piece'),
			('Сосиски', '2017-01-01', 120, 3, 'Meat', 'Kilogram')
