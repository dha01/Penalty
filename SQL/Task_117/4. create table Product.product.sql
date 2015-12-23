-- Создание таблицы "Product.product"
create table Product.product
(
	product int identity(1,1) not null,
	name nvarchar(256) not null,
	expiration_date date null,
	price int null,
	position int null,
	product_type int null,
	product_unit int null
	constraint PK__product primary key (product),
	constraint FK__product__product_type foreign key (product_type) references Product.product_type,
	constraint FK__product__product_unit foreign key (product_unit) references Product.product_unit
)
-- Добавляние записей в таблицу.
insert into Product.product(name,expiration_date,price,position,product_type,product_unit)
	values
			('Молоко', '2016-01-01', 35, 2, 1, 1),
			('Хлеб', '2017-01-01', 55, 1, 2, 2),
			('Сосиски', '2017-01-01', 120, 3, 3, 3)
