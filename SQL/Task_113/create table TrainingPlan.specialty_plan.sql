-- Создание таблицы TrainingPlan.specialty_plan
create table TrainingPlan.specialty_plan
(
	specialty_plan int identity (1,1),
	name varchar(max) not null,
	specialty_detail int not null,
	semester int not null,
	lesson_type int not null,
	discipline int not null,
	auditory int not null,
	constraint PK__specialty_plan primary key (specialty_plan),
	constraint FK__plan__specialty_detail foreign key (specialty_detail) references Specialty.specialty_detail,
	constraint FK__plan__semester foreign key (semester) references Calendar.semester,
	constraint FK__plan__lesson_type foreign key (lesson_type) references TrainingPlan.lesson_type,
	constraint FK__plan__discipline foreign key (discipline) references Discipline.discipline,
	constraint FK__plan__auditory foreign key (auditory) references Auditory.auditory
)