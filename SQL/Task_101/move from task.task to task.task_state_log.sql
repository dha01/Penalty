-- Пернос статусов задач из Task.task в Task.task_state_log
insert into Task.task_state_log 
(
	Task.task,
	Task.task_state
)
select
	t.task,
	case
		when t.is_perform = 1 then 
		(
			select task_state 
			from Task.task_state
			where code = 'Complete'
		) 
		when t.is_open = 1 and t.is_perform = 0 then 
		(
			select task_state 
			from Task.task_state
			where code = 'Progress'
		) 
		when t.is_open = 0 and t.is_perform = 0 then 
		(
			select task_state 
			from Task.task_state
			where code = 'Wait'
		) 
	end	
from Task.task t

-- Удалние колонок is_perform и is_open из таблицы Task.task

alter table Task.task drop DF__task__is_open
alter table Task.task drop DF__task__is_perform

alter table Task.task drop column is_open
alter table Task.task drop column is_perform