using System;

namespace IS.Model.Item.Cathedra
{
	/// <summary>
	/// Класс для хранения данных по кафедрам.
	/// </summary>
	public class CathedraItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Полное название.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Сокращенное название.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Факультеты.
		/// </summary>
		public int FacultyId { get; set; }

		
	}
}