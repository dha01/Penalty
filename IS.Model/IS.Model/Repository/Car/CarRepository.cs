using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Car;

namespace IS.Model.Repository.Car
{
	/// <summary>
	/// Репозиторий автомобилей.
	/// </summary>
	public class CarRepository : ICarRepository
	{
		/// <summary>
		/// Получает автомобиль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автомобиль.</returns>
		public CarItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<CarItem>(@"
select
	c.car Id,
	c.release_date ReleaseDate,
	c.brand Brand,
	c.mem Mem,
	c.vin Vin,
	c.price Price,
	c.color Color
from Car.car c
where c.car = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по автомобилю.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		public void Update(CarItem car)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Car.car
set
	release_date = @ReleaseDate,
	brand = @Brand,
	mem = @Mem,
	vin = @Vin,
	price = @Price,
	color = @Color
where car = @Id", car);
			}
		}

		/// <summary>
		/// Создает новый автомоибль.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		/// <returns>Идентификатор созданного автомобиля.</returns>
		public int Create(CarItem car)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Car.car
(
	release_date,
	brand,
	mem,
	vin,
	price,
	color
)
values
(
	@ReleaseDate,
	@Brand,
	@Mem,
	@Vin,
	@Price,
	@Color
)

select scope_identity()", car);
			}
		}

		/// <summary>
		/// Удаляет автомобиль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Car.car
where car = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех автомобилей.
		/// </summary>
		/// <returns>Список автомобилей.</returns>
		public List<CarItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<CarItem>(@"
select
	c.car Id,
	c.release_date ReleaseDate,
	c.brand Brand,
	c.mem Mem,
	c.vin Vin,
	c.price Price,
	c.color Color
from Car.car c");
			}
		}
	}
}
