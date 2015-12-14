using System;
using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с ролями.
	/// </summary>
	public class RoleService
	{
		#region Fields

		/// <summary>
		/// Репозиторий ролей.
		/// </summary>
		private IRoleRepository _roleRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public RoleService()
		{
			_roleRepository = new RoleRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="role_repository">Интерфейс репозитория ролей.</param>
		public RoleService(IRoleRepository role_repository)
		{
			_roleRepository = role_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает роль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Роль.</returns>
		public RoleItem GetById(int id)
		{
			return _roleRepository.Get(id);
		}

		/// <summary>
		/// Создает роль.
		/// </summary>
		/// <param name="task">Роль.</param>
		/// <returns>Идентификаторо созданной роли.</returns>
		public int Create(RoleItem role)
		{
			if (string.IsNullOrEmpty(role.Code))
			{
				throw new Exception("Поле 'Code' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(role.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			return _roleRepository.Create(role);
		}

		/// <summary>
		/// Измененяет данные о роли.
		/// </summary>
		/// <param name="role">Роль.</param>
		public void Update(RoleItem role)
		{
			if (string.IsNullOrEmpty(role.Code))
			{
				throw new Exception("Поле 'Code' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(role.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			if (GetById(role.Id) == null)
			{
				throw new Exception("Роль не найдена.");
			}

			_roleRepository.Update(role);
		}

		/// <summary>
		/// Удаляет роль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_roleRepository.Delete(id);
		}

		/// <summary>
		/// Получает список ролей.
		/// </summary>
		public List<RoleItem> GetList()
		{
			return _roleRepository.GetList();
		}

		#endregion
	}
}
