using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Product;

namespace IS.Model.Repository.Product
{
	/// <summary>
	/// Репозиторий продуктов.
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		/// <summary>
		/// Получает продукт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Продукт.</returns>
		public ProductItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<ProductItem>(@"
select
	p.product Id,
	p.name Name,
	p.expiration_date ExpirationDate,
	p.price Price,
	p.position Position,
	t.code ProductType,
	u.code ProductUnit
from Product.product p
	join Product.product_type t on p.product_type = t.product_type
	join Product.product_unit u on p.product_unit = u.product_unit
where p.product = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные о продукте.
		/// </summary>
		/// <param name="product">Продукт.</param>
		public void Update(ProductItem product)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Product.product
set
	name = @Name,
	expiration_date = @ExpirationDate,
	price = @Price,
	position = @Position,
	product_type = (select top 1 t.product_type from Product.product_type t where t.code = @ProductType),
	product_unit = (select top 1 u.product_unit from Product.product_unit u where u.code = @ProductUnit)
where product = @Id", product);
			}
		}

		/// <summary>
		/// Создает новый продукт.
		/// </summary>
		/// <param name="product">Продукт.</param>
		/// <returns>Идентификатор созданного продукта.</returns>
		public int Create(ProductItem product)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Product.product
(
	name,
	expiration_date,
	price,
	position,
	product_type,
	product_unit
)
values
(
	@Name,
	@ExpirationDate,
	@Price,
	@Position,
	(select top 1 t.product_type from Product.product_type t where t.code = @ProductType),
	(select top 1 u.product_unit from Product.product_unit u where u.code = @ProductUnit)
)
select scope_identity()", product);
			}
		}

		/// <summary>
		/// Удаляет продукт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Product.product
where product = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех продуктов.
		/// </summary>
		/// <returns>Список продуктов.</returns>
		public List<ProductItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<ProductItem>(@"
select
	p.product Id,
	p.name Name,
	p.expiration_date ExpirationDate,
	p.price Price,
	p.position Position,
	t.code ProductType,
	u.code ProductUnit
from Product.product p
	join Product.product_type t on p.product_type = t.product_type
	join Product.product_unit u on p.product_unit = u.product_unit");
			}
		}
	}
}