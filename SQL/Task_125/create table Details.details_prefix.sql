-- Создание таблицы для префиксов деталей
create table Details.details_prefix
(
	details_prefix int identity(1,1) not null,
	code varchar(128) not null,
	mem nvarchar(512) null,
	constraint PK__detail_prefix primary key (details_prefix)
)

-- Создание основных префиксов.
insert into Details.details_prefix (code, mem)
values
	('Wood', 'Дерево.'),
	('Stone', 'Камень.')