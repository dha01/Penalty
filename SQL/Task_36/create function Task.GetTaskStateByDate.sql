-- Создание табличной функции "Task.GetTaskStateByDate"
create function Task.GetTaskStateByDate
( @date datetime )
returns table
as
return
select
	src.task,
	src.task_state
from
	Task.task_state_log src
	join
	(
		select
			t.task,
			max(t.event_date) event_date
		from Task.task_state_log t
		where t.event_date <= @date
		group by t.task
	) constraint_table on
	src.task = constraint_table.task
	and src.event_date = constraint_table.event_date
