using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
{
	/// <summary>
	/// Интерфейс репозитория учебных планов по специальности.
	/// </summary>
	public class PlanRepository : IPlanRepository
	{
		/// <summary>
		/// Получает учебный план по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный план.</returns>
		public PlanItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<PlanItem>(@"
select
	s.specialty_plan Id,
	s.name Name,
	s.specialty_detail SpecialtyDetail,
	s.semester Semester,
	s.lesson_type LessonType,
	s.discipline Discipline,
	s.auditory Auditory
from TrainingPlan.specialty_plan s
where s.specialty_plan = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по учебному плану.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		public void Update(PlanItem plan)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update TrainingPlan.specialty_plan
set
	name = @Name,
	specialty_detail = @SpecialtyDetail,
	semester = @Semester,
	lesson_type = @LessonType,
	discipline = @Discipline,
	auditory = @Auditory
where specialty_plan = @Id", plan);
			}
		}

		/// <summary>
		/// Создает новый учебный план.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		/// <returns>Идентификатор созданного учебного плана.</returns>
		public int Create(PlanItem plan)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into TrainingPlan.specialty_plan
(
	name,
	specialty_detail,
	semester,
	lesson_type,
	discipline,
	auditory
)
values
(
	@Name,
	@SpecialtyDetail,
	@Semester,
	@LessonType,
	@Discipline,
	@Auditory
)

select scope_identity()", plan);
			}
		}

		/// <summary>
		/// Удаляет учебный план.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from TrainingPlan.specialty_plan
where specialty_plan = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех учебных планов.
		/// </summary>
		/// <returns>Список учебных планов.</returns>
		public List<PlanItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<PlanItem>(@"
select
	s.specialty_plan Id,
	s.name Name,
	s.specialty_detail SpecialtyDetail,
	s.semester Semester,
	s.lesson_type LessonType,
	s.discipline Discipline,
	s.auditory Auditory
from TrainingPlan.specialty_plan s");
			}
		}
	}
}
