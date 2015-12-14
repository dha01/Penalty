using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Specialty;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для учебных курсов.
	/// </summary>
	public class SpecialtyDetailService
	{
		private ISpecialtyDetailRepository _specialtydetailRepository;

		/// <summary>
		/// Конструктор устанавливает репозиторий по умолчанию.
		/// </summary>
		public SpecialtyDetailService()
		{
			_specialtydetailRepository = new SpecialtyDetailRepository();
		}

		/// <summary>
		/// Конструктор класса.
		/// </summary>
		/// <param name="specialty_detail_repository">Интерфейс пользовательского репозитория.</param>
		public SpecialtyDetailService(ISpecialtyDetailRepository specialty_detail_repository)
		{
			_specialtydetailRepository = specialty_detail_repository;
		}

		/// <summary>
		/// Создает новый учебный курс.
		/// </summary>
		/// <param name="specialty_detail">Учебный курс.</param>
		/// <returns>Идентификатор созданного учебного курса.</returns>
		public int Create(SpecialtyDetailItem specialty_detail)
		{
			return _specialtydetailRepository.Create(specialty_detail);
		}

		/// <summary>
		/// Получает группу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный курс.</returns>
		public SpecialtyDetailItem GetById(int Id)
		{
			return _specialtydetailRepository.Get(Id);
		}

		/// <summary>
		/// Обновляет данные по учебному курсу.
		/// </summary>
		/// <param name="specialty_detail">Учебный курс.</param>
		public void Update(SpecialtyDetailItem specialty_detail)
		{
			if (GetById(specialty_detail.Id) == null)
			{
				throw new Exception("Учебный курс не найден.");
			}
			_specialtydetailRepository.Update(specialty_detail);
		}

		/// <summary>
		/// Удаляет учебный курс.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int Id)
		{
			_specialtydetailRepository.Delete(Id);
		}

		/// <summary>
		/// Получает список всех учебных курсов.
		/// </summary>
		/// <returns>Список учебных курсов.</returns>
		public List<SpecialtyDetailItem> GetList()
		{
			return _specialtydetailRepository.GetList();
		}
	}
}
