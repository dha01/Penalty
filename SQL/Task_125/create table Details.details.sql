-- Создание таблицы "Details.details"
create table Details.details
(
	details int identity(1,1) not null,
	name varchar(64) not null,
	release_date date null,
	width float,
	height float,
	lenght float,
	mass float,
	details_prefix int not null,
	constraint PK__details primary key (details),
	constraint FK__details__details_prefix foreign key (details_prefix) references Details.details_prefix
)