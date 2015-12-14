-- Создание схемы "Specialty"
create schema Specialty

-- Создание таблицы "qualification"
create table Specialty.qualification
(
	qualification int identity (1,1) not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__qualification primary key (qualification)
)
-- Добавляние записей в таблицу.
insert into Specialty.qualification(code,memo)
	values
			('Bachelor', 'Бакалавр'),
			('Master', 'Магистр'),
			('Expert', 'Специалист')