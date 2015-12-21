using System;

namespace IS.Model.Item.Car
{
	/// <summary>
	/// Класс для хранения данных автомобиля.
	/// </summary>
	public class CarItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Дата выпуска.
		/// </summary>
		public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Идентификатор бренда.
		/// </summary>
		public CarBrand Brand { get; set; }

		/// <summary>
		/// Идентификатор цвета.
		/// </summary>
		public CarColor Color { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Mem { get; set; }

		/// <summary>
		/// VIN автомобиля.
		/// </summary>
		public int Vin { get; set; }

		/// <summary>
		/// Стоимость.
		/// </summary>
		public int Price { get; set; }
	}

	/// <summary>
	/// Марки автомобилей.
	/// </summary>
	public enum CarBrand
	{
		/// <summary>
		/// Ниссан.
		/// </summary>
		Nissan,
		/// <summary>
		/// Опель.
		/// </summary>
		Opel,
		/// <summary>
		/// Шевроле.
		/// </summary>
		Chevrolet,
		/// <summary>
		/// Ауди.
		/// </summary>
		Audi,
		/// <summary>
		/// Шкода.
		/// </summary>
		Skoda,
		/// <summary>
		/// Тойота.
		/// </summary>
		Toyota
	}

	/// <summary>
	/// Цвета автомобилей.
	/// </summary>
	public enum CarColor
	{
		/// <summary>
		/// Черный.
		/// </summary>
		Black,
		/// <summary>
		/// Белый.
		/// </summary>
		White,
		/// <summary>
		/// Красный.
		/// </summary>
		Red,
		/// <summary>
		/// Синий.
		/// </summary>
		Blue,
		/// <summary>
		/// Зеленый.
		/// </summary>
		Green
	}
}
