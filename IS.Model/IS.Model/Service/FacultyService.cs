using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Faculty;
using IS.Model.Repository.Faculty;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с факультетами.
	/// </summary>
	public class FacultyService
	{
		#region Fields

		/// <summary>
		/// Репозиторий факультетов.
		/// </summary>
		private IFacultyRepository _facultyRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public FacultyService()
		{
			_facultyRepository = new FacultyRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="faculty_repository">Интерфейс репозитория факультетов.</param>
		public FacultyService(IFacultyRepository faculty_repository)
		{
			_facultyRepository = faculty_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает факультет по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		public FacultyItem GetById(int id)
		{
			return _facultyRepository.Get(id);
		}

		/// <summary>
		/// Создает Факультет.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		/// <returns>Идентификаторо созданного факультета.</returns>
		public int Create(FacultyItem faculty)
		{
			if (string.IsNullOrEmpty(faculty.FullName))
			{
				throw new Exception("Поле 'FullName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(faculty.ShortName))
			{
				throw new Exception("Поле 'ShortName' не должно быть пустым.");
			}

			return _facultyRepository.Create(faculty);
		}

		/// <summary>
		/// Измененяет данные о факультете.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		public void Update(FacultyItem faculty)
		{

			if (string.IsNullOrEmpty(faculty.FullName))
			{
				throw new Exception("Поле 'FullName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(faculty.ShortName))
			{
				throw new Exception("Поле 'ShortName' не должно быть пустым.");
			}

			if (GetById(faculty.Id) == null)
			{
				throw new Exception("Факультет не найден.");
			}

			_facultyRepository.Update(faculty);
		}

		/// <summary>
		/// Удаляет факультет.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_facultyRepository.Delete(id);
		}

		/// <summary>
		/// Получает список факультетов.
		/// </summary>
		public List<FacultyItem> GetList()
		{
			return _facultyRepository.GetList();
		}

		#endregion
	}
}
