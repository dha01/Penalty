using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
    /// <summary>
    /// Репозиторий людей.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Получает человека по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Человека.</returns>
        public PersonItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<PersonItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.Person p
where p.person = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные у человека.
        /// </summary>
        /// <param name="person">Человека.</param>
        public void Update(PersonItem person)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update Person.person
set
	last_name = @LastName,
	first_name = @FirstName,
	father_name = @FatherName,
	birthday = @Birthday
where person = @Id", person);
            }
        }

        /// <summary>
        /// Создает нового человека.
        /// </summary>
        /// <param name="person">Задача.</param>
        /// <returns>Идентификатор созданного человека.</returns>
        public int Create(PersonItem person)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecScalar<int>(@"
insert into Person.person
(
	last_name,
	first_name,
	father_name,
	birthday
)
values
(
	@LastName,
	@FirstName,
	@FatherName,
	@Birthday
)

select scope_identity()", person);
            }
        }

        /// <summary>
        /// Удаляет человека.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            using (SqlHelper sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
delete from Person.person
where person = @id", new { id });
            }
        }

        /// <summary>
        /// Получает список всех людей.
        /// </summary>
        /// <returns>Список людей.</returns>
        public List<PersonItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<PersonItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.Person p");
            }
        }
    }
}
