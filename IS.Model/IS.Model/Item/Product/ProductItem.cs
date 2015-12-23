using System;

namespace IS.Model.Item.Product
{
	/// <summary>
	/// Класс для хранения данных продуктов.
	/// </summary>
	public class ProductItem
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
		/// Срок годности.
		/// </summary>
		public DateTime ExpirationDate { get; set; }

		/// <summary>
		/// Тип продукта.
		/// </summary>
		public ProductType ProductType { get; set; }

		/// <summary>
		/// Еденица измерения.
		/// </summary>
		public ProductUnit ProductUnit { get; set; }

		/// <summary>
		/// Номер полки.
		/// </summary>
		public int Position { get; set; }

		/// <summary>
		/// Стоимость.
		/// </summary>
		public int Price { get; set; }
	}

	/// <summary>
	/// Тип продукта.
	/// </summary>
	public enum ProductType
	{
		/// <summary>
		/// Молочная продукция.
		/// </summary>
		Milk,
		/// <summary>
		/// Хлебная продукция.
		/// </summary>
		Bread,
		/// <summary>
		/// Мясная продукция.
		/// </summary>
		Meat,
		/// <summary>
		/// Рыбная продукция.
		/// </summary>
		Fish
	}

	/// <summary>
	/// Единицы измерения.
	/// </summary>
	public enum ProductUnit
	{
		/// <summary>
		/// Литры.
		/// </summary>
		Liter,
		/// <summary>
		/// Поштучно.
		/// </summary>
		Piece,
		/// <summary>
		/// Килограммы.
		/// </summary>
		Kilogram
	}
}