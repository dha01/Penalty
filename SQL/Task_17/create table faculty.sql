--Создание схемы Faculty
create schema Faculty 

--Создание таблицы Faculty
create table Faculty.faculty
(
	faculty int identity(1,1),
	full_name varchar(255),
	short_name varchar(30),
	constraint PK_faculty primary  key (faculty)
)

--Добавление записи
insert into Faculty.faculty(full_name,short_name)
values
		(
			'Информатика и вычислительная техника',
			'ИВТ'
		)






