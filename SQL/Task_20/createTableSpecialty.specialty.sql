-- Создание схемы "Specialty"
create schema Specialty

-- Создание таблицы "Specialty.specialty_detail"
create table Specialty.specialty
(
	specialty_detail int identity (1,1) not null,
	actual_date date not null,
	specialty int not null,
	semestr_count int not null,
	training_period int not null,
	qualification int not null,
	form_study int not null,
	pay_space int not null,
	lowcost_space int not null,

	constraint PK__specialty_detail primary key (specialty_detail),
	constraint FK__specialty_detail__specialty foreign key (specialty) references Specialty.specialty,
	constraint FK__specialty_detail__qualification foreign key (qualification) references Qualification.qualification,
	constraint FK__specialty_detail__form_study foreign key (form_study) references Specialty.form_study)

-- Добавление записи в таблицу "Specialty_detail"
	insert into Specialty.specialty(actual_date,specialty,semestr_count,training_period,qualification,form_study,pay_space,lowcost_space)

	values('2015-01-01',123,8,80,1,3,25,25)
