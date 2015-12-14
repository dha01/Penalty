using System;
using System.Transactions;
using IS.Model.Item.Calendar;
using IS.Model.Repository.Calendar;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Calendar
{
	/// <summary>
	/// Тесты для репозитория семестров.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class SemesterRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий семестров.
		/// </summary>
		private SemesterRepository _semesterRepository;

		private SemesterItem _semester;
		private SemesterItem _semesterNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_semesterRepository = new SemesterRepository();

			_semester = new SemesterItem()
			{
				FromDate = DateTime.Now.Date,
				TrimDate = DateTime.Now.AddDays(120).Date
			};
			_semesterNew = new SemesterItem()
			{
				FromDate = DateTime.Now.Date,
				TrimDate = DateTime.Now.AddDays(121).Date
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
		/// Проверяет еквивалентны ли два семестра.
		/// </summary>
		/// <param name="first_semester">Первый семестр.</param>
		/// <param name="second_semester">Второй семестр.</param>
		private void AreEqualSemesters(SemesterItem first_semester, SemesterItem second_semester)
		{
			Assert.AreEqual(first_semester.Id, second_semester.Id);
			Assert.AreEqual(first_semester.FromDate, second_semester.FromDate);
			Assert.AreEqual(first_semester.TrimDate, second_semester.TrimDate);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает семестр.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_semester.Id = _semesterRepository.Create(_semester);
			var result = _semesterRepository.Get(_semester.Id);
			AreEqualSemesters(result, _semester);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры семестра.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedSemester()
		{
			_semester.Id = _semesterRepository.Create(_semester);
			var result = _semesterRepository.Get(_semester.Id);
			AreEqualSemesters(result, _semester);

			_semesterNew.Id = _semester.Id;
			_semesterRepository.Update(_semesterNew);
			result = _semesterRepository.Get(_semester.Id);
			AreEqualSemesters(result, _semesterNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет семестр.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_semester.Id = _semesterRepository.Create(_semester);
			var result = _semesterRepository.Get(_semester.Id);
			AreEqualSemesters(result, _semester);

			_semesterRepository.Delete(_semester.Id);
			result = _semesterRepository.Get(_semester.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех семестров.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithSemester()
		{
			_semester.Id = _semesterRepository.Create(_semester);
			var result = _semesterRepository.GetList().Find(x => x.Id == _semester.Id);
			AreEqualSemesters(result, _semester);
		}

		#endregion
	}
}
