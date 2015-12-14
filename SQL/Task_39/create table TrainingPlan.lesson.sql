-- Создание схемы TrainingPlan
create schema TrainingPlan

-- Создание таблицы TrainingPlan.lesson
create table TrainingPlan.lesson(
	lesson int identity (1,1),
	discipline int not null,
	lesson_type int not null,
	work_day int not null,
	from_time time not null,
	trim_time time not null,
	constraint PK__lesson primary key (lesson),
	constraint FK__lesson__discipline foreign key (discipline) references Discipline.discipline,
	constraint FK__lesson__lesson_type foreign key (lesson_type) references TrainingPlan.lesson_type,
	constraint FK__lesson__work_day foreign key (work_day) references Calendar.work_day
)