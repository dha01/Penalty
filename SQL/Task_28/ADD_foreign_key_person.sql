--Добавить поле person для создания вторичного ключа

alter table Access.[user]
add
	person int
	constraint FK__user__person foreign key (person)
	references Person.person (person)