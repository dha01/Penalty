using System;

namespace IS.Model.Item.Details
{
	/// <summary>
	/// Класс для хранения данных детали.
	/// </summary>
	public class DetailsItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Наименование.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата выпуска.
		/// </summary>
		public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Ширина.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Высота.
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Длинна.
		/// </summary>
		public int Lenght { get; set; }

		/// <summary>
		/// Масса.
		/// </summary>
		public int Mass { get; set; }

		/// <summary>
		/// Идентификатор материала.
		/// </summary>
		public DetailsMaterial Material { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Mem { get; set; }

	}

	/// <summary>
	/// Материалы деталей.
	/// </summary>
	public enum DetailsMaterial
	{
		/// <summary>
		/// Дерево.
		/// </summary>
		Wood,
		/// <summary>
		/// Стекло.
		/// </summary>
		Glass
	}
}