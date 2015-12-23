-- Создание таблицы "Details.details"
create table Details.details
(
	details int identity(1,1) not null,
	name varchar(64) not null,
	release_date date null,
	width int,
	height int,
	lenght int,
	mass int,
	material varchar(64) not null,
	constraint PK__details primary key (details)
)
-- Добавляние записей в таблицу.
insert into Details.details(name,release_date,width,height,lenght,mass,material)
	values
			('detail1','2015-01-01', 1000, 1000, 1000, 500, 'Wood'),
			('detail2','2015-04-01', 2000, 3000, 1000, 1500, 'Glass')

