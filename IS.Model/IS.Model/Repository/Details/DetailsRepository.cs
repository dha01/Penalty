using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Details;

namespace IS.Model.Repository.Details
{
    /// <summary>
    /// Репозиторий автомобилей.
    /// </summary>
    public class DetailsRepository : IDetailsRepository
    {
        /// <summary>
        /// Получает деталь по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Деталь.</returns>
        public DetailsItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<DetailsItem>(@"
select
	c.details Id,
	c.name Name,
	c.release_date ReleaseDate,
	c.width Width,
	c.height Height,
	c.lenght Ltnght,
	c.mass Mass,
	c.material Material
from Details.details c
where c.details = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные по детали.
        /// </summary>
        /// <param name="details">Деталь.</param>
        public void Update(DetailsItem details)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update Details.details
set
    name = @Name,
	release_date = @ReleaseDate,
    width = @Width,
    height = @Height,
    lenght = @Ltnght,
	mass = @Mass,
	material = @Material
where details = @Id", details);
            }
        }

        /// <summary>
        /// Создает новую деталь.
        /// </summary>
        /// <param name="details">Деталь.</param>
        /// <returns>Идентификатор созданноной детали.</returns>
        public int Create(DetailsItem details)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecScalar<int>(@"
insert into Details.details
(
    name,
	release_date,
	width,
	height,
	lenght,
	mass,
	material
)
values
(
    @Name,
	@ReleaseDate,
	@Width,
	@Height,
	@Lenght,
	@Mass,
	@material
)
select scope_identity()", details);
            }
        }

        /// <summary>
        /// Удаляет деталь.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            using (SqlHelper sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
delete from Details.details
where details = @id", new { id });
            }
        }

        /// <summary>
        /// Получает список всех деталей.
        /// </summary>
        /// <returns>Список деталей.</returns>
        public List<DetailsItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<DetailsItem>(@"
select
    c.details Id,
    c.name Name,
	c.release_date ReleaseDate,
	c.width Width,
    c.height Height,
    c.lenght Ltnght,
	c.mass Mass,
	c.material Material
from Details.details c");
            }
        }
    }
}