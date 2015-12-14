using System;
using System.Collections.Generic;
using IS.Model.Item.Team;
using IS.Model.Repository.Team;
using IS.Model.Service;
using Moq;
using NUnit.Framework;
using IS.Mvc.Models.Service;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса групп.
	/// </summary>
	class TeamServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис групп.
		/// </summary>
		private TeamService _teamService;

		/// <summary>
		/// Репозиторий групп.
		/// </summary>
		private ITeamRepository _teamRepository;

		/// <summary>
		/// Тестовая группа.
		/// </summary>
		private TeamItem _team;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_teamRepository = Mock.Of<ITeamRepository>();
			_teamService = new TeamService(_teamRepository);

			_team = new TeamItem()
			{
				Id = 1,
				Name = "Назване группы",
				CreateDate = DateTime.Now.Date,
				SpecialtyDetailId = 1
			};
		}

		#endregion

		#region TeamService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void TeamService_Void_Success()
		{
			var s = new TeamService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<TeamItem>() { _team };

			Mock.Get(_teamRepository).Setup(x => x.Create(_team)).Returns(_team.Id);
			Mock.Get(_teamRepository).Setup(x => x.GetList()).Returns(list);

			var result = _teamService.Create(_team);
			Assert.AreEqual(result, _team.Id);
		}

		/// <summary>
		/// Создает группу с пустым названием.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Create_EmptyCode_ReturnException()
		{
			_team.Name = null;
			_teamService.Create(_team);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о группе.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_teamRepository).Setup(x => x.Get(_team.Id)).Returns(_team);
			_teamService.Update(_team);
		}

		/// <summary>
		/// Изменяет название на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Update_EmptyName_ReturnException()
		{
			_team.Name = null;
			_teamService.Update(_team);
		}

		/// <summary>
		/// Изменяет не существующую группу.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Группа не найдена.")]
		[Test]
		public void Update_RecordNotExists_ReturnException()
		{
			Mock.Get(_teamRepository).Setup(x => x.Get(_team.Id)).Returns((TeamItem)null);
			_teamService.Update(_team);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_teamService.Delete(_team.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список групп.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTeamList()
		{
			var list = new List<TeamItem> { _team };

			Mock.Get(_teamRepository).Setup(x => x.GetList()).Returns(list);
			var result = _teamService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}