using System;
using System.Threading;
using System.Transactions;
using IS.Model.Helper;
using IS.Model.Item.Cathedra;
using IS.Model.Item.Faculty;
using IS.Model.Item.Person;
using IS.Model.Item.Specialty;
using IS.Model.Item.Team;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Faculty;
using IS.Model.Repository.Person;
using IS.Model.Repository.Specialty;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Person
{
	/// <summary>
	/// Тесты для репозитория студентов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class StudentRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private StudentRepository _studentRepository;
		private TeamRepository _teamRepository;
		private PersonRepository _personRepository;

		private SpecialtyDetailRepository _specialtyDetailRepository;
		private SpecialtyRepository _specialtyRepository;
		private CathedraRepository _cathedraRepository;
		private FacultyRepository _facultyRepository;

		private StudentItem _student;
		private StudentItem _studentNew;
		private PersonItem _person;
		private PersonItem _personNew;
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
			_studentRepository = new StudentRepository();
			_personRepository = new PersonRepository();
			_teamRepository = new TeamRepository();
			_specialtyDetailRepository = new SpecialtyDetailRepository();
			_specialtyRepository = new SpecialtyRepository();
			_cathedraRepository = new CathedraRepository();
			_facultyRepository = new FacultyRepository();

			_team = new TeamItem()
			{
				CreateDate = DateTime.Now,
				Name = "ПЕ-22б",
				SpecialtyDetailId = _specialtyDetailRepository.Create(new SpecialtyDetailItem()
				{
					SpecialtyId = _specialtyRepository.Create(new SpecialtyItem()
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
				})
			};

			_student = new StudentItem()
			{
				LastName = "Егоров",
				FirstName = "Виталий",
				FatherName = "Игоревич",
				Birthday = DateTime.Now,
				TeamId = _teamRepository.Create(_team)
			};
			_student.Id = _personRepository.Create(_student);

			_studentNew = new StudentItem()
			{
				LastName = "Журавлев",
				FirstName = "Данил",
				FatherName = "Александрович",
				Birthday = DateTime.Now,
				TeamId = _teamRepository.Create(_team)
			};
			_studentNew.Id = _personRepository.Create(_student);
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
		/// Проверяет эквивалентны ли два студента.
		/// </summary>
		/// <param name="first_student">Первый студент для сравнения</param>
		/// <param name="second_student">Второй студент для сравнения</param>
		private void AreEqualStudents(StudentItem first_student, StudentItem second_student)
		{
			Assert.AreEqual(first_student.Id, second_student.Id);
			Assert.AreEqual(first_student.LastName, second_student.LastName);
			Assert.AreEqual(first_student.FirstName, second_student.FirstName);
			Assert.AreEqual(first_student.FatherName, second_student.FatherName);
			Assert.AreEqual(first_student.TeamId, second_student.TeamId);
		}

		#endregion

		#region Create

		/// <summary>
		/// Зачисляет студента в группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Исключает студента.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);

			_studentRepository.Delete(result);
			result = _studentRepository.Get(_student.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		[Test]
		public void GetListByTeam_Void_ReturnNotEmptyListWithStudent()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.GetListByTeam(_student.TeamId).Find(x => x.Id == _student.Id);
			AreEqualStudents(result, _student);
		}

		#endregion
	}
}
