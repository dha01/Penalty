--Создание схемы "Person"
create schema Person

--Создание таблицы "lecturer"
create table Person.lecturer
(
	lecturer int identity (1,1) not null,
	even_date datetime,
	person int,
	cathedra int,
	act tinyint,
	constraint PK__lecturer primary key (lecturer),
	constraint FK__lecturer__person foreign key (person) references Person.person,
	constraint FK__lecturer__cafedra foreign key (cathedra) references Cathedra.cathedra
)