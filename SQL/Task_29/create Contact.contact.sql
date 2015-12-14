-- Создание схемы
create schema Contact

-- Создание таблицы
create table Contact.contact
(
	contact int identity(1,1),
	contact_type int,
	value varchar(255),
	constraint PK__contact primary key (contact),
	constraint FK__contact__contact_type foreign key (contact_type) references Contact.contact_type,
)

-- Создание таблицы
create table Contact.contact2person
(
	contact2person int identity(1,1),
	contact int,
	person int,
	constraint PK__contact2person primary key (contact2person),
	constraint FK__contact2person__contact foreign key (contact) references Contact.contact,
	constraint FK__contact2person__person foreign key (person) references Person.person
)

-- Добавление записи
insert into Person.person
		   (last_name,
			first_name,
			father_name,
			birthday)
values
(
	'Наумочкин',
	'Юрий',
	'Анатольевич',
	'1966-05-09'
)

declare @person int = scope_identity()

-- Добавление записи
insert into Contact.contact
(
	contact_type,
	value
)
values
(
	(select contact_type
	from Contact.contact_type
	where code = 'MobilePhone'),
	'8-999-000-00-00'
)

declare @contact int = scope_identity()

-- Добавление записи
insert into Contact.contact2person
(
	contact,
	person
)
values
(
	@contact,
	@person
)

