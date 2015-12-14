using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Calendar
{
	/// <summary>
	/// Класс для хранения данных о семестре.
	/// </summary>
	public class SemesterItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Дата начала семестра.
		/// </summary>
		public DateTime FromDate { get; set; }

		/// <summary>
		/// Дата конца семестра.
		/// </summary>
		public DateTime TrimDate { get; set; }
	}
}
