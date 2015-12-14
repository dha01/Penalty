-- Создание схемы "Person"
create schema Person

-- Создание таблицы "Person.student"
create table Person.student
(
	student int identity not null,
	event_date datetime not null,
	person int not null,
	team int not null,
	act int,
	constraint PK__student primary key (student),
	constraint FK__student__team foreign key (team) references Team.team,
	constraint FK__student__person foreign key (person) references Person.person
)