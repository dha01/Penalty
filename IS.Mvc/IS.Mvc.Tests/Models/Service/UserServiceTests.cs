using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using IS.Mvc.Models.Service;
using Moq;
using NUnit.Framework;

namespace IS.Mvc.Tests.Models.Service
{
	/// <summary>
	/// Тестирование сервиса пользователей.
	/// </summary>
	[TestFixture]
	public class UserServiceTests
	{
		#region Fields

		private UserService _userService;

		private IUserRepository _userRepository;

		#endregion

		#region Constaints

		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";

		#endregion

		#region SetUp

		[SetUp]
		public void SetUp()
		{
			_userRepository = Mock.Of<IUserRepository>();
			_userService = new UserService(_userRepository);
		}

		#endregion
		
		#region Create

		/// <summary>
		/// Создает пользователя.
		/// </summary>
		[Test]
		public void Create_CreateUser_ReturnUserId()
		{
			var id = 1;
			var user = new UserItem()
			{
				Login = LOGIN,
				Password = PASSWORD
			};

			Mock.Get(_userRepository).Setup(x => x.Create(user)).Returns(id);
			var result = _userService.Create(user);
			Assert.AreEqual(id, result);
		}

		#endregion
	}
}
