-- Создание схемы Flowers
create schema Flowers

-- Создание таблицы Flowers.flowers
create table Flowers.flowers
(
	flowers int identity (1,1) not null,
	name nvarchar (255) not null,
	family nvarchar (255) not null,
	color nvarchar (255) not null,
	thorns varchar (4) not null,
	longterm varchar (4) not null,
	height int not null,
	constraint PK__flowers primary key (flowers)
)

-- Добавление записи в таблицу Flowers.flowers
insert into Flowers.flowers(
	name,
	family,
	color,
	thorns,
	longterm,
	height
	)
	values
	('Роза',
	'Shipownikovie',
	'Red',
	'Да',
	'Да',
	90
    )