using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Housing;
using IS.Model.Item.Person;
using IS.Model.Repository.Housing;
using IS.Model.Repository.Person;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с людьми.
	/// </summary>
	public class HousingService
	{
		#region Fields

		/// <summary>
		/// Репозиторий корпусов.
		/// </summary>
		private IHousingRepository _housingRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public HousingService()
		{
			_housingRepository = new HousingRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="housing_repository">Интерфейс репозитория корпуса.</param>
		public HousingService(IHousingRepository housing_repository)
		{
			_housingRepository = housing_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает корпус по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Корпус.</returns>
		public HousingItem GetById(int id)
		{
			return _housingRepository.Get(id);
		}

		/// <summary>
		/// Создает корпус.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		/// <returns>Идентификаторо созданного корпуса.</returns>
		public int Create(HousingItem housing)
		{
			if (string.IsNullOrWhiteSpace(housing.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			if (string.IsNullOrWhiteSpace(housing.Memo))
			{
				throw new Exception("Поле 'Memo' не должно быть пустым.");
			}

			return _housingRepository.Create(housing);
		}

		/// <summary>
		/// Измененяет данные о корпусе.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		public void Update(HousingItem housing)
		{

			if (string.IsNullOrWhiteSpace(housing.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			if (string.IsNullOrWhiteSpace(housing.Memo))
			{
				throw new Exception("Поле 'Memo' не должно быть пустым.");
			}


			if (GetById(housing.Id) == null)
			{
				throw new Exception("Корпус не найден.");
			}

			_housingRepository.Update(housing);
		}

		/// <summary>
		/// Удаляет корпус.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_housingRepository.Delete(id);
		}

		/// <summary>
		/// Получает список корпусов.
		/// </summary>
		public List<HousingItem> GetList()
		{
			return _housingRepository.GetList();
		}

		#endregion
	}
}
