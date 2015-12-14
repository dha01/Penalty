-- Создание табличной функции "Lecturer.GetLecturerByDate"
create function Lecturer.GetLecturerByDate
( @date datetime )
returns table
as
return 
select
	l.person,
	l.cathedra
from Person.lecturer l
where l.event_date <= @date
group by l.person, l.cathedra
having sum(l.act) = 1

