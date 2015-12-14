-- Создание схемы TrainingPlan
create schema TrainingPlan
go

-- Создание таблицы TrainingPlan.lesson
create table TrainingPlan.lesson2auditory(
	lesson2auditory int identity ,
	lesson int not null,
	auditory int not null,  
	constraint PK__lesson2auditory primary key (lesson2auditory),
	constraint FK__lesson2auditory__auditory foreign key (auditory) references Auditory.auditory,
	constraint FK__lesson2auditory__lesson foreign key (lesson) references TraningPlan.lesson
)	