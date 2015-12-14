using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Auditory;

namespace IS.Model.Repository.Auditory
{
	/// <summary>
	/// Интерфейс репозитория аудиторий.
	/// </summary>
	public interface IAuditoryRepository : IRepository<AuditoryItem>
	{
		/// <summary>
		/// Получает аудиторию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Аудитория.</returns>
		AuditoryItem Get(int id);

		/// <summary>
		/// Обновляет данные по аудитории.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		void Update(AuditoryItem auditory);

		/// <summary>
		/// Создает новую аудиторию.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		/// <returns>Идентификатор созданной аудитории.</returns>
		int Create(AuditoryItem auditory);

		/// <summary>
		/// Удаляет аудиторию.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех аудиторий.
		/// </summary>
		/// <returns>Список аудиторий.</returns>
		List<AuditoryItem> GetList();
	}
}
