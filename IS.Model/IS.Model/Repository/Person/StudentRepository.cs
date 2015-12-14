using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public class StudentRepository : IStudentRepository
	{
		/// <summary>
		/// Получает студента по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public StudentItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<StudentItem>(@"
select
	st.person Id,
	st.team TeamId,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.GetStudentByDate (getdate()) st
	join person.person p on p.person = st.person
where st.person = @id", new { id });
			}
		}

		/// <summary>
		/// Зачисление студента в группу.
		/// </summary>
		/// <param name="student">Студенты.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		public int Create(StudentItem student)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Person.student
(
	event_date,
	person,
	team,
	act
)
values
(
	getdate(),
	@Id,
	@TeamId,
	1
)

select @Id", student);
			}
		}

		/// <summary>
		/// Исключение студента из группы.
		/// </summary>
		/// <param name="student">Студенты.</param>
		public void Delete(StudentItem student)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
insert into Person.student
(
	event_date,
	person,
	team,
	act
)
values
(
	getdate(),
	@Id,
	@TeamId,
	-1
)", student);
			}
		}

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		/// <param name="team_id">Список студентов.</param>
		public List<StudentItem> GetListByTeam(int team_id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<StudentItem>(@"
select
	st.person Id,
	st.team TeamId,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.GetStudentByDate (getdate()) st
	join person.person p on p.person = st.person
where st.team = @team_id", new { team_id });
			}
		}
	}
}
