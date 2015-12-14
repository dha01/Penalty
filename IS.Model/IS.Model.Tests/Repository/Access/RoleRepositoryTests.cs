using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Access
{
	/// <summary>
	/// Тесты для репозитория ролей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	class RoleRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий ролей.
		/// </summary>
		private RoleRepository _roleRepository;

		private RoleItem _role;
		private RoleItem _roleNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_roleRepository = new RoleRepository();

			_role = new RoleItem()
			{
				Code = "test",
				Mem = "tester"
			};
			_roleNew = new RoleItem()
			{
				Code = "test2",
				Mem = "tester2"
			};
		}

		#endregion

		#region TearDown

		/// <summary>
		/// Выполняется после каждого теста.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			_transactionScope.Dispose();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Проверяет эквивалентны ли две роли.
		/// </summary>
		/// <param name="first_role">Первая роль.</param>
		/// <param name="second_role">Вторая роль.</param>
		private void AreEqualRoles(RoleItem first_role, RoleItem second_role)
		{
			Assert.AreEqual(first_role.Id, second_role.Id);
			Assert.AreEqual(first_role.Code, second_role.Code);
			Assert.AreEqual(first_role.Mem, second_role.Mem);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает роль.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_role.Id = _roleRepository.Create(_role);
			var result = _roleRepository.Get(_role.Id);
			AreEqualRoles(result, _role);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры роли.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedRole()
		{
			_role.Id = _roleRepository.Create(_role);
			var result = _roleRepository.Get(_role.Id);
			AreEqualRoles(result, _role);

			_roleNew.Id = _role.Id;
			_roleRepository.Update(_roleNew);
			result = _roleRepository.Get(_role.Id);
			AreEqualRoles(result, _roleNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет роль.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_role.Id = _roleRepository.Create(_role);
			var result = _roleRepository.Get(_role.Id);
			AreEqualRoles(result, _role);

			_roleRepository.Delete(_role.Id);
			result = _roleRepository.Get(_role.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех ролей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithRoles()
		{
			_role.Id = _roleRepository.Create(_role);
			var result = _roleRepository.GetList().Find(x => x.Id == _role.Id);
			AreEqualRoles(result, _role);
		}

		#endregion

		#region GetListByUser

		/// <summary>
		/// Получает список ролей по пользователю.
		/// </summary>
		[Test]
		public void GetListByUser_Void_ReturnNotEmptyListWithRoles()
		{
			UserItem user = new UserItem()
			{
				Id = 2,
				Login = "dha",
				Password = "123"
			};
			RoleItem role = _roleRepository.Get(1);
			var result = _roleRepository.GetListByUser(user);
			AreEqualRoles(result.First(x=>x.Id == role.Id), role);
		}

		#endregion

		#region GetByCode

		/// <summary>
		/// Получает роль по коду.
		/// </summary>
		[Test]
		public void GetByCode_Void_ReturnRole()
		{
			_role.Id = _roleRepository.Create(_role);
			var result = _roleRepository.GetByCode(_role.Code);
			AreEqualRoles(result, _role);
		}

		#endregion
	}
}
