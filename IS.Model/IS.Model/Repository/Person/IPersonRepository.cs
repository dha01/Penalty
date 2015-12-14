using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
    /// <summary>
    /// Интерфейс репозитория людей.
    /// </summary>
    public interface IPersonRepository : IRepository<PersonItem>
    {
        /// <summary>
        /// Получает человека по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Человек.</returns>
        PersonItem Get(int id);

        /// <summary>
        /// Обновляет данные у человека.
        /// </summary>
        /// <param name="person">Человек.</param>
        void Update(PersonItem person);

        /// <summary>
        /// Создает нового человека.
        /// </summary>
        /// <param name="person">Задача.</param>
        /// <returns>Идентификатор созданного человека.</returns>
        int Create(PersonItem person);

        /// <summary>
        /// Удаляет человека.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        void Delete(int id);

        /// <summary>
        /// Получает список всех людей.
        /// </summary>
        /// <returns>Список людей.</returns>
        List<PersonItem> GetList();
    }
}