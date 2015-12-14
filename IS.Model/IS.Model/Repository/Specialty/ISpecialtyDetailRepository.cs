using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
{
	/// <summary>
	/// Интерфейс репозитория для работы с учебными курсами.
	/// </summary>
	public interface ISpecialtyDetailRepository : IRepository<SpecialtyDetailItem>
	{
		/// <summary>
		/// Получает учебный курс по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный курс.</returns>
		SpecialtyDetailItem Get(int id);

		/// <summary>
		/// Обновляет данные по учебному курсу.
		/// </summary>
		/// <param name="specialty_detail">Учебный курс.</param>
		void Update(SpecialtyDetailItem specialty_detail);

		/// <summary>
		/// Создает новую учебный курс.
		/// </summary>
		/// <param name="specialty_detail">Учеьный курс.</param>
		/// <returns>Идентификатор созданного учебного курса.</returns>
		int Create(SpecialtyDetailItem specialty_detail);

		/// <summary>
		/// Удаляет учебный курс.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех учебных курсов.
		/// </summary>
		/// <returns>Список курсов.</returns>
		List<SpecialtyDetailItem> GetList();
	}
}
