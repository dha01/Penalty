-- Создание схемы "Contact"
create schema Contact

-- Создание таблицы "contact_type"
create table Contact.contact_type
(
	contact_type int identity not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__contact_type primary key (contact_type)
)
-- Добавляние записей в таблицу.
insert into Contact.contact_type(code,memo)
	values
			('MobilePhone', 'Мобильный телефон'),
			('CityPhone', 'Городской телефон'),
			('Skype', 'Скайп'),
			('Facebook', 'Фейсбук'),
			('VK', 'ВКонтакте'),
			('Steam', 'Стим'),
			('Twitter', 'Твиттер'),
			('Instagram', 'Инстаграм')