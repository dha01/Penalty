using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Flowers;
using IS.Model.Repository.Flowers;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с цветами.
	/// </summary>
	public class FlowersService
	{
		#region Fields

		/// <summary>
		/// Репозиторий цветов.
		/// </summary>
		private IFlowersRepository _flowersRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public FlowersService()
		{
			_flowersRepository = new FlowersRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="flowers_repository">Интерфейс репозитория цветов.</param>
		public FlowersService(IFlowersRepository flowers_repository)
		{
			_flowersRepository = flowers_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает цветок по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Цветок.</returns>
		public FlowersItem GetById(int id)
		{
			return _flowersRepository.Get(id);
		}

		/// <summary>
		/// Создает цветок.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		/// <returns>Идентификаторо созданного цветка.</returns>
		public int Create(FlowersItem flowers)
		{
            if (string.IsNullOrEmpty(flowers.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			return _flowersRepository.Create(flowers);
		}

		/// <summary>
		/// Измененяет данные о цветке.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		public void Update(FlowersItem flowers)
		{
            if (string.IsNullOrEmpty(flowers.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}
			if (string.IsNullOrEmpty(flowers.LongTerm))
			{
				throw new Exception("Поле 'LongTerm' не должно быть пустым.");
			}
			if (string.IsNullOrEmpty(flowers.Thorns))
			{
				throw new Exception("Поле 'Thorns' не должно быть пустым.");
			}
			if (GetById(flowers.Id) == null)
			{
				throw new Exception("Цветок не найден.");
			}

			_flowersRepository.Update(flowers);
		}

		/// <summary>
		/// Удаляет цветок.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_flowersRepository.Delete(id);
		}

		/// <summary>
		/// Получает список цветов.
		/// </summary>
		public List<FlowersItem> GetList()
		{
			return _flowersRepository.GetList();
		}

		#endregion
	}
}
