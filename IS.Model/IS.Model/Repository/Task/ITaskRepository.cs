using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Task;

namespace IS.Model.Repository.Task
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public interface ITaskRepository : IRepository<TaskItem>
	{
		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		TaskItem Get(int id);

		/// <summary>
		/// Обновляет данные по задаче.
		/// </summary>
		/// <param name="task">Задача.</param>
		void Update(TaskItem task);

		/// <summary>
		/// Создает новую задачу.
		/// </summary>
		/// <param name="task">Задача.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		int Create(TaskItem task);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		List<TaskItem> GetList();
	}
}