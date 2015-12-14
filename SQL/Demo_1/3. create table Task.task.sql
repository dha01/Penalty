-- Создание таблицы для задач.
create table Task.task
(
	task int identity(1,1) not null,
	number int not null,
	task_prefix int not null,
	header nvarchar(256) not null,
	mem nvarchar(max) not null,
	created datetime not null constraint DF__task__created default (getdate()),
	deadline datetime null,
	priority int not null constraint DF__task__priority default 10,
	performer nvarchar(128) null,
	author nvarchar(128) null,
	is_perform bit not null constraint DF__task__is_perform default 0,
	is_open bit not null constraint DF__task__is_open default 1,
	constraint PK__task primary key (task),
	constraint FK__task__task_prefix foreign key (task_prefix) references Task.task_prefix
)

