using System;
using System.Transactions;
using IS.Model.Item.Cathedra;
using IS.Model.Item.Faculty;
using IS.Model.Item.Specialty;
using IS.Model.Item.Team;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Faculty;
using IS.Model.Repository.Specialty;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Team
{
	/// <summary>
	/// Тесты для репозитория групп.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class TeamRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий групп.
		/// </summary>
		private TeamRepository _teamRepository;

		private SpecialtyDetailRepository _specialtyDetailRepository;
		private SpecialtyRepository _specialtyRepository;
		private CathedraRepository _cathedraRepository;
		private FacultyRepository _facultyRepository;

		private TeamItem _team;
		private TeamItem _teamNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_teamRepository = new TeamRepository();
			_specialtyDetailRepository = new SpecialtyDetailRepository();
			_specialtyRepository = new SpecialtyRepository();
			_cathedraRepository = new CathedraRepository();
			_facultyRepository = new FacultyRepository();

			var specialty_detail = new SpecialtyDetailItem()
				{
					SpecialtyId =_specialtyRepository.Create(new SpecialtyItem()
					{
						CathedraId = _cathedraRepository.Create(new CathedraItem()
						{
							FacultyId = _facultyRepository.Create(new FacultyItem()),
							FullName = "Кафедра",
							ShortName = "K"
						}),
						FullName = "Специальность",
						ShortName = "С",
						Code = "1"
					}),
					ActualDate = DateTime.Now
				};
			_team = new TeamItem()
			{
				Name = "ПЕ-22б",
				CreateDate = DateTime.Now.Date,
				SpecialtyDetailId = _specialtyDetailRepository.Create(specialty_detail)
			}; 
			_teamNew = new TeamItem()
			{
				Name = "ПЕ-21б",
				CreateDate = DateTime.Now.AddYears(-1).Date,
				SpecialtyDetailId = _specialtyDetailRepository.Create(specialty_detail)
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
		/// Проверяет эквивалентны ли две группы.
		/// </summary>
		/// <param name="first_team">Первая группа для сравнения.</param>
		/// <param name="second_team">Вторая группа для сравнения.</param>
		private void AreEqualTeams(TeamItem first_team, TeamItem second_team)
		{
			Assert.AreEqual(first_team.Id, second_team.Id);
			Assert.AreEqual(first_team.Name, second_team.Name);
			Assert.AreEqual(first_team.CreateDate, second_team.CreateDate);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _team);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры группы.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedTeam()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _team);

			_teamNew.Id = _team.Id;
			_teamRepository.Update(_teamNew);
			result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _teamNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _team);

			_teamRepository.Delete(_team.Id);
			result = _teamRepository.Get(_team.Id);
			Assert.IsNull(result);
		}
		#endregion

		#region GetList


		/// <summary>
		/// Получает список всех групп.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTeam()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.GetList().Find(x => x.Id == _team.Id);
			AreEqualTeams(result, _team);
		}

		#endregion
	}
}
