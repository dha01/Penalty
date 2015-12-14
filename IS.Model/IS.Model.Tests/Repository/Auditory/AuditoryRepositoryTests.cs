using System;
using System.Transactions;
using IS.Model.Item.Auditory;
using IS.Model.Repository.Auditory;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Auditory
{
	/// <summary>
	/// Тесты для репозитория задач.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class AuditoryRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private AuditoryRepository _auditoryRepository;

		private AuditoryItem _auditory;
		private AuditoryItem _auditoryNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_auditoryRepository = new AuditoryRepository();

			_auditory = new AuditoryItem()
			{
				Number = 1,
				FullName = "Аудитория информатики",
				Memo = "В аудитории присутствует 16 компьютеров, проектор, интерактивная доска",
				Level = 3,
				Capacity = 15
			};
			_auditoryNew = new AuditoryItem()
			{
				Number = 2,
				FullName = "Аудитория экономики",
				Memo = "В аудитории присутствует 5 компьютеров, проектор, интерактивная доска и много учебной литературы",
				Level = 2,
				Capacity = 20
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
		/// Проверяет эквивалентны ли две аудитории.
		/// </summary>
		/// <param name="first_auditory"></param>
		/// <param name="second_auditory"></param>
		private void AreEqualAuditory(AuditoryItem first_auditory, AuditoryItem second_auditory)
		{
			Assert.AreEqual(first_auditory.Id, second_auditory.Id);
			Assert.AreEqual(first_auditory.Number, second_auditory.Number);
			Assert.AreEqual(first_auditory.FullName, second_auditory.FullName);
			Assert.AreEqual(first_auditory.Memo, second_auditory.Memo);
			Assert.AreEqual(first_auditory.Level, second_auditory.Level);
			Assert.AreEqual(first_auditory.Capacity, second_auditory.Capacity);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает аудиторию.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_auditory.Id = _auditoryRepository.Create(_auditory);
			var result = _auditoryRepository.Get(_auditory.Id);
			AreEqualAuditory(result, _auditory);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры аудитории.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedAuditory()
		{
			_auditory.Id = _auditoryRepository.Create(_auditory);
			var result = _auditoryRepository.Get(_auditory.Id);
			AreEqualAuditory(result, _auditory);
			_auditoryNew.Id = _auditory.Id;
			_auditoryRepository.Update(_auditoryNew);
			result = _auditoryRepository.Get(_auditory.Id);
			AreEqualAuditory(result, _auditoryNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет аудиторию.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_auditory.Id = _auditoryRepository.Create(_auditory);
			var result = _auditoryRepository.Get(_auditory.Id);
			AreEqualAuditory(result, _auditory);

			_auditoryRepository.Delete(_auditory.Id);
			result = _auditoryRepository.Get(_auditory.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList



		#endregion
	}
}