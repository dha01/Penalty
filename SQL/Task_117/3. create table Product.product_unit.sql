-- Создание таблицы Product.product_unit.
create table Product.product_unit
(
	product_unit int identity(1,1) not null,
	code varchar(128) not null,
	mem nvarchar(512) null,
	constraint PK__product_unit primary key (product_unit)
)

-- Создание основных единиц.
insert into Product.product_unit (code, mem)
values
	('Liter', 'Литры.'),
	('Piece', 'Поштучно.'),	
	('Kilogram', 'Килограммы.')


