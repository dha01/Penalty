-- Создание схемы "Calendar"
create schema Calendar

-- Создание таблицы "Calendar.work_week"
create table Calendar.work_week
(
	work_week int identity not null,
	from_date date not null,
	trim_date date not null,
	semester int not null,
	constraint PK__work_week primary key (work_week),
	constraint FK__work_week__semester foreign key (semester) references Calendar.semester
)