using System;

namespace IS.Model.Item.Flowers
{
	/// <summary>
	/// Класс для хранения данных по цветам.
	/// </summary>
	public class FlowersItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название цветка.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Семейство.
		/// </summary>
		public FlowersFamily Family { get; set; }

		/// <summary>
		/// Цвет цветка.
		/// </summary>
		public FlowersColor Color { get; set; }

		/// <summary>
		/// Наличие шипов.
		/// </summary>
		public string Thorns { get; set; }

		/// <summary>
		/// Тип цветка.
		/// </summary>
		public string LongTerm { get; set; }

		/// <summary>
		/// Высота цветка.
		/// </summary>
		public int Height { get; set; }
	}

	/// <summary>
	/// Семейства цветов.
	/// </summary>
	public enum FlowersFamily
	{
		/// <summary>
		/// Шиповниковые.
		/// </summary>
		Shipownikovie,
		/// <summary>
		/// Астровые.
		/// </summary>
		Astrovie,
		/// <summary>
		/// Зонтичные.
		/// </summary>
		Zontichnie,
		/// <summary>
		/// Биксовые.
		/// </summary>
		Biksovie,
		/// <summary>
		/// Вязовые.
		/// </summary>
		Vyazovie,
		/// <summary>
		/// Злаки.
		/// </summary>
		Zlaki,
	}

	/// <summary>
	/// Цвета цветов.
	/// </summary>
	public enum FlowersColor
	{
		/// <summary>
		/// Красный.
		/// </summary>
		Red,
		/// <summary>
		/// Белый.
		/// </summary>
		White,
		/// <summary>
		/// Синий.
		/// </summary>
		Blue,
		/// <summary>
		/// Жёлтый
		/// </summary>
		Yellow,
		/// <summary>
		/// Розовый. 
		/// </summary>
		Pink,
		/// <summary>
		/// Бордовый.
		/// </summary>
		Magenta,


	}
}

