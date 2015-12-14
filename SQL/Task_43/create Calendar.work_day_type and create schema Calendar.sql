-- Создание схемы Calendar.
create schema Calendar

-- Создание таблицы "work_day_type".
create table Calendar.work_day_type(
	work_day_type int identity not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__work_day_type primary key (work_day_type)
)

-- Добавляние записей в таблицу.
insert into Calendar.work_day_type(code,memo)
	values
			('Work', 'Рабочий день'),
			('Abbreviated', 'Сокращенный день'),
			('Holiday', 'Праздничный день'),
			('Weekend', 'Выходной день')