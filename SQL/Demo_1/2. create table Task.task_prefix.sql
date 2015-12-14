-- Создание таблицы для префиксов задач.
create table Task.task_prefix
(
	task_prefix int identity(1,1) not null,
	code varchar(128) not null,
	mem nvarchar(512) null,
	constraint PK__task_prefix primary key (task_prefix)
)

-- Создание основных префиксов.
insert into Task.task_prefix (code, mem)
values
	('Task', 'Задача без категории.'),
	('Demo', 'Демонстрационные, тестовые, эксперементальные задачи.'),	
	('BugFix', 'Задача на исправление ошибки.'),	
	('Refactoring', 'Задача на рефакторинг кода.'),	
	('Doc', 'Задача на написание документации.')


