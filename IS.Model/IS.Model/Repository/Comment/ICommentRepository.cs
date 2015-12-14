using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Access;
using IS.Model.Item.Comment;

namespace IS.Model.Repository.Comment
{
	/// <summary>
	/// Интерфейс репозитория комментариев.
	/// </summary>
	public interface ICommentRepository : IRepository<CommentItem>
	{
		/// <summary>
		/// Получает комментарий по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Комментарий.</returns>
		CommentItem Get(int id);

		/// <summary>
		/// Обновляет данные по комментарию.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		void Update(CommentItem comment);

		/// <summary>
		/// Создает новый комментарий.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		/// <returns>Идентификатор созданного комментария.</returns>
		int Create(CommentItem comment);

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех комментариев по идентификатору задачи.
		/// </summary>
		/// <param name="task_id">Идентификатор задачи.</param>
		/// <returns>Список комментариев.</returns>
		List<CommentItem> GetListByTaskId(int task_id);
	}
}
