using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Comment;

namespace IS.Model.Repository.Comment
{
	/// <summary>
	/// Интерфейс репозитория комментариев.
	/// </summary>
	public class CommentRepository : ICommentRepository
	{
		/// <summary>
		/// Получает комментарий по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Комментарий.</returns>
		public CommentItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<CommentItem>(@"
select
	c.comment Id,
	c.add_date AddDate,
	c.person PersonId,
	c.text Text,
	c.task TaskId
from Task.comment c
where c.comment = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по комментарию.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		public void Update(CommentItem comment)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Task.comment
set
	add_date = @AddDate,
	person = @PersonId,
	text = @Text,
	task = @TaskId
where comment = @Id", comment);
			}
		}

		/// <summary>
		/// Создает новый комментарий.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		/// <returns>Идентификатор созданного комментария.</returns>
		public int Create(CommentItem comment)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Task.comment
(
	add_date,
	person,
	text,
	task
)
values
(
	@AddDate,
	@PersonId,
	@Text,
	@TaskId
)

select scope_identity()", comment);
			}
		}

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Task.comment
where comment = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список комментариев по идентификатору задачи.
		/// </summary>
		/// <param name="task_id">Идентификатор задачи.</param>
		/// <returns>Список комментариев.</returns>
		public List<CommentItem> GetListByTaskId(int task_id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<CommentItem>(@"
select
	c.comment Id,
	c.add_date AddDate,
	c.person PersonId,
	c.text Text,
	c.task TaskId
from Task.comment c
where c.TaskId = @task_id", new { task_id });
			}
		}
	}
}
