using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Discipline;
using IS.Model.Repository.Discipline;

namespace IS.Model.Service
{
    /// <summary>
    /// Сервис для работы с дисциплинами.
    /// </summary>
    public class DisciplineService
    {
        #region Fields

        /// <summary>
        /// Репозиторий дисциплин.
        /// </summary>
        private IDisciplineRepository _disciplineRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public DisciplineService()
        {
            _disciplineRepository = new DisciplineRepository();
        }

        /// <summary>
        /// Конструктор класс.
        /// </summary>
        /// <param name="discipline_repository">Интерфейс репозитория дисциплин.</param>
        public DisciplineService(IDisciplineRepository discipline_repository)
        {
            _disciplineRepository = discipline_repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Получает дисциплину по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Дисциплина.</returns>
        public DisciplineItem GetById(int id)
        {
            return _disciplineRepository.Get(id);
        }

        /// <summary>
        /// Создает дисциплину.
        /// </summary>
        /// <param name="discipline">Дисциплина.</param>
        /// <returns>Идентификатор созданной дисциплины.</returns>
        public int Create(DisciplineItem discipline)
        {
            if (string.IsNullOrEmpty(discipline.FullName))
            {
                throw new Exception("Поле 'FullName' не должно быть пустым.");
            }

            if (string.IsNullOrEmpty(discipline.ShortName))
            {
                throw new Exception("Поле 'ShortName' не должно быть пустым.");
            }

            if (string.IsNullOrEmpty(discipline.Mem))
            {
                throw new Exception("Поле 'Mem' не должно быть пустым.");
            }

            return _disciplineRepository.Create(discipline);
        }

        /// <summary>
        /// Измененяет данные о дисциплине.
        /// </summary>
        /// <param name="discipline">Дисциплина.</param>
        public void Update(DisciplineItem discipline)
        {
            if (string.IsNullOrEmpty(discipline.FullName))
            {
                throw new Exception("Поле 'FullName' не должно быть пустым.");
            }

            if (string.IsNullOrEmpty(discipline.ShortName))
            {
                throw new Exception("Поле 'ShortName' не должно быть пустым.");
            }

            if (string.IsNullOrEmpty(discipline.Mem))
            {
                throw new Exception("Поле 'Mem' не должно быть пустым.");
            }

            if (GetById(discipline.Id) == null)
            {
                throw new Exception("Дисциплина не найдена.");
            }

            _disciplineRepository.Update(discipline);
        }

        /// <summary>
        /// Удаляет дисциплину.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            _disciplineRepository.Delete(id);
        }

        /// <summary>
        /// Получает список дисциплин.
        /// </summary>
        public List<DisciplineItem> GetList()
        {
            return _disciplineRepository.GetList();
        }

        #endregion
    }
}
