-- Создание схемы Calendar
create schema Calendar

-- Создание таблицы Calendar.semester
create table Calendar.semester (
	semester int identity (1,1),
	from_date date not null,
	trim_date date not null,
	constraint PK__semester primary key (semester)
)