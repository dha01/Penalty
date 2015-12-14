-- Создание схемы "Auditory"
create schema Auditory

-- Создание таблицы "Auditory.housing"
create table Auditory.housing
(
	housing int identity,
	number int not null,
	name nvarchar(255) not null,
	level int not null,
	memo nvarchar(max) not null
)


