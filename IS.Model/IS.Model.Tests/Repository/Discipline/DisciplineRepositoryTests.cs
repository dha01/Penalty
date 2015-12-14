using System;
using System.Transactions;
using IS.Model.Item.Discipline;
using IS.Model.Repository.Discipline;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Discipline
{
	/// <summary>
	/// Тесты для репозитория дисциплин.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class DisciplineRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий дисциплин.
		/// </summary>
		private DisciplineRepository _disciplineRepository;

		private DisciplineItem _discipline;
		private DisciplineItem _disciplineNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_disciplineRepository = new DisciplineRepository();

			_discipline = new DisciplineItem()
			{
				Id = 1,
				FullName = "full_name",
				ShortName = "short_name",
				Mem = "Описание"
			}; 
			_disciplineNew = new DisciplineItem()
			{
				Id = 2,
				FullName = "full_name_test",
				ShortName = "short_name_test",
				Mem = "Описание2"
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
		/// Проверяет, эквивалентны ли две дисциплины.
		/// </summary>
		/// <param name="first_discipline"></param>
		/// <param name="second_discipline"></param>
		private void AreEqualDiscipline(DisciplineItem first_discipline, DisciplineItem second_discipline)
		{
			Assert.AreEqual(first_discipline.Id, second_discipline.Id);
			Assert.AreEqual(first_discipline.FullName, second_discipline.FullName);
			Assert.AreEqual(first_discipline.ShortName, second_discipline.ShortName);
			Assert.AreEqual(first_discipline.Mem, second_discipline.Mem);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает дисциплину.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_discipline.Id = _disciplineRepository.Create(_discipline);
			var result = _disciplineRepository.Get(_discipline.Id);
			AreEqualDiscipline(result, _discipline);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры дисциплины.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedDiscipline()
		{
			_discipline.Id = _disciplineRepository.Create(_discipline);
			var result = _disciplineRepository.Get(_discipline.Id);
			AreEqualDiscipline(result, _discipline);

			_disciplineNew.Id = _discipline.Id;
			_disciplineRepository.Update(_disciplineNew);
			result = _disciplineRepository.Get(_discipline.Id);
			AreEqualDiscipline(result, _disciplineNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет дисциплину.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_discipline.Id = _disciplineRepository.Create(_discipline);
			var result = _disciplineRepository.Get(_discipline.Id);
			AreEqualDiscipline(result, _discipline);

			_disciplineRepository.Delete(_discipline.Id);
			result = _disciplineRepository.Get(_discipline.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех дисциплин.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithDiscipline()
		{
			_discipline.Id = _disciplineRepository.Create(_discipline);
			var result = _disciplineRepository.GetList().Find(x => x.Id == _discipline.Id);
			AreEqualDiscipline(result, _discipline);
		}

		#endregion
	}
}
