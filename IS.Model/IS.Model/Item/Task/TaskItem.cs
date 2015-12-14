using System;

namespace IS.Model.Item.Task
{
	/// <summary>
	/// Класс для хранения данных по задаче.
	/// </summary>
	public class TaskItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор префикса.
		/// </summary>
		public TaskPrefix Prefix { get; set; }

		/// <summary>
		/// Номер.
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Header { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Mem { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime? Created { get; set; }

		/// <summary>
		/// Срок исполнения.
		/// </summary>
		public DateTime? Deadline { get; set; }

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Исполнитель.
		/// </summary>
		public string Performer { get; set; }

		/// <summary>
		/// Автор.
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// Признак того, что задача выполнена.
		/// </summary>
		public bool IsPerform { get; set; }

		/// <summary>
		/// Признак того, что задача открыта.
		/// </summary>
		public bool IsOpen { get; set; }

		/// <summary>
		/// Сложность задачи.
		/// </summary>
		public int Difficult { get; set; }

		/// <summary>
		/// URL указывающий на пул реквест.
		/// </summary>
		public string PullRequestUrl { get; set; }
	}

	/// <summary>
	/// Префикс задачи.
	/// </summary>
	public enum TaskPrefix
	{
		/// <summary>
		/// Задача.
		/// </summary>
		Task,

		/// <summary>
		/// Демонстрационная.
		/// </summary>
		Demo,

		/// <summary>
		/// Исправление ошибок.
		/// </summary>
		BugFix,

		/// <summary>
		/// Рефакторинг.
		/// </summary>
		Refactoring,

		/// <summary>
		/// Документация.
		/// </summary>
		Doc,

		/// <summary>
		/// Курсовая работа.
		/// </summary>
		CourseWork,

		/// <summary>
		/// Техническое решение.
		/// </summary>
		TechnicalSolution
	}
}
