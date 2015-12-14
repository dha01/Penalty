-- Создание схемы Lesson
create schema Lesson

-- Создание таблицы Lesson.lesson_time
create table Lesson.lesson_time(
	lesson_time int identity (1,1),
	number_lesson int not null,
	start_time_lesson time not null,
	end_time_lesson time not null,
	day_type int not null,
	constraint PK__lesson_time primary key (lesson_time),
	constraint FK__lesson_time__day_type foreign key (day_type) references Calendar.work_day_type,
)

-- Добавление записи в таблицу Auditory.auditory
insert into Lesson.lesson_time(
	number_lesson,
	start_time_lesson,
	end_time_lesson,
	day_type
	)
	values
	(1,
	'08:30:00',
	'10:05:00',
	1
    )