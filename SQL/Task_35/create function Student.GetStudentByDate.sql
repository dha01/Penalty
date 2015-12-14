-- Создание табличной функции "Person.GetStudentByDate"
create function Person.GetStudentByDate
( @date datetime )
returns table
as
return 
select
	s.person,
	s.team
from Person.student s
where s.event_date <= @date
group by s.person, s.team
having sum(s.act) = 1
