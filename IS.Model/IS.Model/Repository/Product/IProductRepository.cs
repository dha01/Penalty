using System.Collections.Generic;
using IS.Model.Item.Product;

namespace IS.Model.Repository.Product
{
	/// <summary>
	/// Интерфейс репозитория продуктов.
	/// </summary>
	public interface IProductRepository : IRepository<ProductItem>
	{
		/// <summary>
		/// Получает продукт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Продукт.</returns>
		ProductItem Get(int id);

		/// <summary>
		/// Обновляет данные о продукте.
		/// </summary>
		/// <param name="product">Продукт.</param>
		void Update(ProductItem product);

		/// <summary>
		/// Создает новый продукт.
		/// </summary>
		/// <param name="product">Продукт.</param>
		/// <returns>Идентификатор созданного продукта.</returns>
		int Create(ProductItem product);

		/// <summary>
		/// Удаляет продукт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех продуктов.
		/// </summary>
		/// <returns>Список продуктов.</returns>
		List<ProductItem> GetList();
	}
}