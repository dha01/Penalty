using System;

namespace IS.Model.Item.Specialty
{   
	/// <summary>
	/// Класс для хранения данных о сущности образовательной системы.
	/// </summary>
	public class SpecialtyDetailItem
	{
		/// <summary>
		/// Идентификатор образовательной программы.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Текущая дата.
		/// </summary>
		public DateTime ActualDate { get; set; }

		/// <summary>
		/// Идентификатор специальности.
		/// </summary>
		public int SpecialtyId { get; set; }

		/// <summary>
		/// Количество семестров.
		/// </summary>
		public int SemestrCount { get; set; }

		/// <summary>
		/// Период обучения.
		/// </summary>
		public int TrainingPeriod { get; set; }

		/// <summary>
		/// Квалификация.
		/// </summary>
		public Qualification Qualification { get; set; }

		/// <summary>
		/// Форма обучения.
		/// </summary>
		public FormStudy FormStudy { get; set; }

		/// <summary>
		/// Количество платных мест.
		/// </summary>
		public int PaySpace { get; set; }

		/// <summary>
		/// Количество бюджетных мест.
		/// </summary>
		public int LowcostSpace { get; set; }

	}

	/// <summary>
	/// Квалификация.
	/// </summary>
	public enum Qualification
	{
		/// <summary>
		/// Бакалавр.
		/// </summary>
		Bachelor,

		/// <summary>
		/// Магистр.
		/// </summary>
		Master,

		/// <summary>
		/// Специалист.
		/// </summary>
		Expert
	}

	/// <summary>
	/// Форма обучения.
	/// </summary>
	public enum FormStudy
	{
		/// <summary>
		/// Очная.
		/// </summary>
		Fulltime,

		/// <summary>
		/// Заочная.
		/// </summary>
		Distance
	}
}
