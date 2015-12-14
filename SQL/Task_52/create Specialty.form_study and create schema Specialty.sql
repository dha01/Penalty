-- Создание схемы "Specialty"
create schema Specialty

-- Создание таблицы "form_study"
create table Specialty.form_study
(
	form_study int identity not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__form_study primary key (form_study)
)
-- Добавляние записей в таблицу.
insert into Specialty.form_study(code,memo)
	values
			('Fulltime', 'Очная'),
			('Distance', 'Заочная')