using System;
using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса ролей.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class RoleServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис ролей.
		/// </summary>
		private RoleService _roleService;

		/// <summary>
		/// Репозиторий ролей.
		/// </summary>
		private IRoleRepository _roleRepository;

		/// <summary>
		/// Тестовая ролей.
		/// </summary>
		private RoleItem _role;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_roleRepository = Mock.Of<IRoleRepository>();
			_roleService = new RoleService(_roleRepository);

			_role = new RoleItem()
			{
				Id = 1,
				Code = "IT",
				Mem = "IT about"
			};
		}

		#endregion

		#region RoleService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void RoleService_Void_Success()
		{
			var s = new RoleService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает роль.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<RoleItem>() { _role };

			Mock.Get(_roleRepository).Setup(x => x.Create(_role)).Returns(_role.Id);
			Mock.Get(_roleRepository).Setup(x => x.GetList()).Returns(list);

			var result = _roleService.Create(_role);
			Assert.AreEqual(result, _role.Id);
		}

		/// <summary>
		/// Создает роль с пустым кодом.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Code' не должно быть пустым.")]
		[Test]
		public void Create_EmptyCode_ReturnException()
		{
			_role.Code = null;
			_roleService.Create(_role);
		}

		/// <summary>
		/// Создает роль с пустым описанием.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMem_ReturnException()
		{
			_role.Mem = null;
			_roleService.Create(_role);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о роли.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_roleRepository).Setup(x => x.Get(_role.Id)).Returns(_role);
			_roleService.Update(_role);
		}

		/// <summary>
		/// Изменяет код на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Code' не должно быть пустым.")]
		[Test]
		public void Update_EmptyCode_ReturnException()
		{
			_role.Code = null;
			_roleService.Update(_role);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMem_ReturnException()
		{
			_role.Mem = null;
			_roleService.Update(_role);
		}

		/// <summary>
		/// Изменяет не существующую роль.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Роль не найдена.")]
		[Test]
		public void Update_RoleNotExists_ReturnException()
		{
			Mock.Get(_roleRepository).Setup(x => x.Get(_role.Id)).Returns((RoleItem)null);
			_roleService.Update(_role);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет роль.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_roleService.Delete(_role.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список ролей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnRoleList()
		{
			var list = new List<RoleItem> { _role };

			Mock.Get(_roleRepository).Setup(x => x.GetList()).Returns(list);
			var result = _roleService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
