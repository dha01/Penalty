-- Создание схемы "Person"
create schema Person

-- Создание таблицы "person"
create table Person.person
(
	person int identity not null,
	last_name varchar(255) not null,
	first_name varchar(255) not null,
	father_name varchar(255) not null,
	birthday date not null,
	constraint PK__persom primary key (person)
)