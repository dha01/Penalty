using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Comment
{
	/// <summary>
	/// Класс для хранения комментариев.
	/// </summary>
	public class CommentItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Дата добавления комментария.
		/// </summary>
		public DateTime? AddDate { get; set; }

		/// <summary>
		/// Автор.
		/// </summary>
		public int PersonId { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Задача.
		/// </summary>
		public int TaskId { get; set; }
	}
}
