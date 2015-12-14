using System;

namespace IS.Model.Item.Specialty
{
	/// <summary>
	/// Класс для хранения данных по учебному плану для специальности.
	/// </summary>
	public class PlanItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор учебного курса.
		/// </summary>
		public int SpecialtyDetail { get; set; }

		/// <summary>
		/// Идентификатор семестра.
		/// </summary>
		public int Semester { get; set; }

		/// <summary>
		/// Идентификатор типа занятия.
		/// </summary>
		public int LessonType { get; set; }

		/// <summary>
		/// Идентификатор дисциплины.
		/// </summary>
		public int Discipline { get; set; }

		/// <summary>
		/// Идентификатор аудитории.
		/// </summary>
		public int Auditory { get; set; }
	}
}
