using System;

namespace IS.Model.Item.Team
{
	/// <summary>
	/// Класс для хранения данных о сущности групп.
	/// </summary>
	public class TeamItem
	{
		/// <summary>
		/// Идентификатор группы.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название группы.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата создания группы.
		/// </summary>
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// Специальность группы.
		/// </summary>
		public int SpecialtyDetailId { get; set; }
	}
}
