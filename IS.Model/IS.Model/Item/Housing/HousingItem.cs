using System;

namespace IS.Model.Item.Housing
{
	/// <summary>
	/// Класс для хранения данных по корпусам.
	/// </summary>
	public class HousingItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Корпус.
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Название корпуса.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Этаж.
		/// </summary>
		public int Level { get; set; }
		/// <summary>
		/// Краткое описание.
		/// </summary>
		public string Memo { get; set; }
	}
}

