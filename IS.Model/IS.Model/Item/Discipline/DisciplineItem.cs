using System;

namespace IS.Model.Item.Discipline
{
	/// <summary>
	/// Класс для хранения данных по дисциплинам.
	/// </summary>
	public class DisciplineItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Короткое название.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Полное название.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Mem { get; set; }
	}
}
