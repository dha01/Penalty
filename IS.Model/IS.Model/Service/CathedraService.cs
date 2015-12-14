using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Cathedra;
using IS.Model.Repository.Cathedra;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с кафедры.
	/// </summary>
	public class CathedraService
	{
		#region Fields

		/// <summary>
		/// Репозиторий кафедр.
		/// </summary>
		private ICathedraRepository _cathedraRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public CathedraService()
		{
			_cathedraRepository = new CathedraRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="cathedra_repository">Интерфейс репозитория кафедр.</param>
		public CathedraService(ICathedraRepository cathedra_repository)
		{
			_cathedraRepository = cathedra_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает кафедру по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Кафедра.</returns>
		public CathedraItem GetById(int id)
		{
			return _cathedraRepository.Get(id);
		}

		/// <summary>
		/// Создает кафедру.
		/// </summary>
		/// <param name="cathedra">Кафедра.</param>
		/// <returns>Идентификатор созданной кафедры.</returns>
		public int Create(CathedraItem cathedra)
		{
			if (string.IsNullOrEmpty(cathedra.FullName))
			{
				throw new Exception("Поле 'FullName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(cathedra.ShortName))
			{
				throw new Exception("Поле 'ShortName' не должно быть пустым.");
			}

			return _cathedraRepository.Create(cathedra);
		}

		/// <summary>
		/// Измененяет данные о кафедре.
		/// </summary>
		/// <param name="cathedra">Кафедра.</param>
		public void Update(CathedraItem cathedra)
		{
			if (string.IsNullOrEmpty(cathedra.FullName))
			{
				throw new Exception("Поле 'FullName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(cathedra.ShortName))
			{
				throw new Exception("Поле 'ShortName' не должно быть пустым.");
			}

			if (GetById(cathedra.Id) == null)
			{
				throw new Exception("Кафедра не найдена.");
			}

			_cathedraRepository.Update(cathedra);
		}

		/// <summary>
		/// Удаляет кафедру.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_cathedraRepository.Delete(id);
		}

		/// <summary>
		/// Получает список кафедр.
		/// </summary>
		public List<CathedraItem> GetList()
		{
			return _cathedraRepository.GetList();
		}

		#endregion
	}
}
