-- Создание схемы "Task"
create schema Task

-- Создание таблицы "Task.comment"
create table Task.comment
(
	comment int identity,
	add_date datetime,
	person int,
	text nvarchar(max) not null,
	task int,
	constraint PK__comment primary key (comment),
	constraint FK__comment__person foreign key (person) references Person.person,
	constraint FK__comment__task foreign key (task) references Task.task
)