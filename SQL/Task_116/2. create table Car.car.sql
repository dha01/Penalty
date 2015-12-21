-- Создание таблицы "Car.car"
create table Car.car
(
	car int identity(1,1) not null,
	release_date date null,
	brand varchar(64) not null,
	mem nvarchar(max) null,
	vin int null,
	price int null,
	color varchar(64) not null,
	constraint PK__car primary key (car)
)
-- Добавляние записей в таблицу.
insert into Car.car(release_date,brand,mem,vin,price,color)
	values
			('2015-01-01', 'Nissan', 'Test1', 145421547, 100000, 'Black'),
			('2013-01-01', 'Audi', 'Test2', 754542312, 70000, 'White'),
			('2008-01-01', 'Opel', 'Test3', 18787545, 50000, 'Blue')
