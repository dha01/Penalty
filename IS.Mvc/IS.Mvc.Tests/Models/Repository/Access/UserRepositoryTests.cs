using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using NUnit.Framework;

namespace IS.Mvc.Tests.Models.Repository.Access
{
	/// <summary>
	/// Класс тестирования репозитория пользователей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class UserRepositoryTests
	{
		#region Fields

		private TransactionScope _transactionScope;
		private UserRepository _userRepository;

		#endregion

		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";
		

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_userRepository = new UserRepository();
		}

		/// <summary>
		/// Выполняется после каждого теста.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			_transactionScope.Dispose();
		}

		#region Create

		/// <summary>
		/// Создание пользователя.
		/// </summary>
		[Test]
		public void Create_IsCreated_ReturnCreatedUser()
		{
			var user = new UserItem()
			{
				Login = LOGIN,
				Password = PASSWORD
			};

			int id = _userRepository.Create(user);

			var result = _userRepository.Get(id);

			Assert.AreEqual(result.Id, id);
			Assert.AreEqual(result.Login, user.Login);
			Assert.AreEqual(result.Password, user.Password);
		}

		#endregion

	}
}
