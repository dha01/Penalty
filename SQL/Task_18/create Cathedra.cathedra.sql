-- Создание схемы "Cathedra"
create schema Cathedra

-- Создание таблицы "cathedra"
create table Cathedra.cathedra
(
	cathedra int identity (1,1) not null,
	full_name varchar(255) not null,
	short_name varchar(30) not null,
	faculty int,
	constraint PK__cathedra primary key (cathedra),
	constraint FK__cathedra__faculty foreign key (faculty) references Faculty.faculty
)
