using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using IS.Mvc.Models.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты класса UserService
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class UserServiceTests
	{
		#region Fields

		private UserService _userService;

		private IUserRepository _userRepository;

		#endregion

		#region Сonstants

		private const int ID = 1;
		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
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
		public void Create_Void_ReturnId()
		{
			var user = new UserItem()
			{
				Login = LOGIN,
				Password = PASSWORD
			};

			Mock.Get(_userRepository).Setup(x => x.Create(user)).Returns(ID);

			var result = _userService.Create(user);
			Assert.AreEqual(result, ID);
		}

		/// <summary>
		/// Создает пользователя с пустым логином.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Login' не должно быть пустым.")]
		[Test]
		public void Create_EmptyLogin_ReturnException()
		{
			var user = new UserItem()
			{
				Login = null,
				Password = PASSWORD
			};

			_userService.Create(user);
		}

		#endregion
	}
}
