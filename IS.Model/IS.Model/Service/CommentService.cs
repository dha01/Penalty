using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Comment;
using IS.Model.Repository.Comment;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с комментариями к задачам.
	/// </summary>
	public class CommentService
	{
		#region Fields

		/// <summary>
		/// Репозиторий комментариев.
		/// </summary>
		private ICommentRepository _commentRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public CommentService()
		{
			_commentRepository = new CommentRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="comment_repository">Интерфейс репозитория комментариев.</param>
		public CommentService(ICommentRepository comment_repository)
		{
			_commentRepository = comment_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает комментарий по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Комментарий.</returns>
		public CommentItem GetById(int id)
		{
			return _commentRepository.Get(id);
		}

		/// <summary>
		/// Создает комментарий.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		/// <returns>Идентификаторо созданного комментария.</returns>
		public int Create(CommentItem comment)
		{
			if (string.IsNullOrEmpty(comment.Text))
			{
				throw new Exception("Поле 'Text' не должно быть пустым.");
			}

			return _commentRepository.Create(comment);
		}

		/// <summary>
		/// Изменяет данные о комментарие.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		public void Update(CommentItem comment)
		{
			if (string.IsNullOrEmpty(comment.Text))
			{
				throw new Exception("Поле 'Text' не должно быть пустым.");
			}

			if (GetById(comment.Id) == null)
			{
				throw new Exception("Комментарий не найден.");
			}

			_commentRepository.Update(comment);
		}

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_commentRepository.Delete(id);
		}

		/// <summary>
		/// Получает список комментариев по идентификатору задачи.
		/// </summary>
		/// <param name="task_id">Идентификатор задачи.</param>
		/// <returns>Список комментариев.</returns>
		public List<CommentItem> GetListByTaskId(int task_id)
		{
			return _commentRepository.GetListByTaskId(task_id);
		}

		#endregion
	}
}
