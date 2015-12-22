using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Details;
using IS.Model.Repository.Details;

namespace IS.Model.Service
{
    /// <summary>
    /// Сервис для работы с Деталями.
    /// </summary>
    public class DetailsService
    {
        #region Fields
        /// <summary>
        /// Репозиторий деталей.
        /// </summary>
        private IDetailsRepository _detailsRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public DetailsService()
        {
            _detailsRepository = new DetailsRepository();
        }

        /// <summary>
        /// Конструктор класс.
        /// </summary>
        /// <param name="details_repository">Интерфейс репозитория деталей.</param>
        public DetailsService(IDetailsRepository details_repository)
        {
            _detailsRepository = details_repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Получает деталь по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Деталь.</returns>
        public DetailsItem GetById(int id)
        {
            return _detailsRepository.Get(id);
        }

        /// <summary>
        /// Создает деталь.
        /// </summary>
        /// <param name="details">Деталь.</param>
        /// <returns>Идентификатор созданной детали.</returns>
        public int Create(DetailsItem details)
        {
            if (string.IsNullOrEmpty(details.Name))
            {
                throw new Exception("Поле 'Mem' не должно быть пустым.");
            }

            return _detailsRepository.Create(details);
        }

        /// <summary>
        /// Измененяет данные детали.
        /// </summary>
        /// <param name="details">Деталь.</param>
        public void Update(DetailsItem details)
        {
            if (string.IsNullOrEmpty(details.Name))
            {
                throw new Exception("Поле 'Mem' не должно быть пустым.");
            }

            if (GetById(details.Id) == null)
            {
                throw new Exception("Деталь не найден.");
            }

            _detailsRepository.Update(details);
        }

        /// <summary>
        /// Удаляет деталь.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            _detailsRepository.Delete(id);
        }

        /// <summary>
        /// Получает список задач.
        /// </summary>
        public List<DetailsItem> GetList()
        {
            return _detailsRepository.GetList();
        }

        #endregion
    }
}