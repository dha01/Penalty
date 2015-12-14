using System;
using System.Transactions;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;
using NUnit.Framework;
using IS.Model.Repository.Housing;
using IS.Model.Item.Housing;

namespace IS.Model.Tests.Repository.Housing
{
	/// <summary>
	/// Тесты для репозитория корпусов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class HousingRepositoryTest
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий корпусов.
		/// </summary>
		private HousingRepository _housingRepository;

		private HousingItem _housing;
		private HousingItem _housingNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_housingRepository = new HousingRepository();

			_housing = new HousingItem()
			{
				Id = 1,
				Number = 12,
				Name = "Odin",
				Level = 2,
				Memo = "Для уроков рисования"

			};
			_housingNew = new HousingItem()
			{
				Id = 2,
				Number = 13,
				Name = "Tor",
				Level = 3,
				Memo = "Для уроков русского языка"
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
		/// Проверяет эквивалентны ли два корпуса.
		/// </summary>
		/// Описание входных параметров.
		/// <param name="first_housing"></param>
		/// <param name="second_housing"></param>
		private void AreEqualHousing(HousingItem first_housing, HousingItem second_housing)
		{
			Assert.AreEqual(first_housing.Id, second_housing.Id);
			Assert.AreEqual(first_housing.Number, second_housing.Number);
			Assert.AreEqual(first_housing.Name, second_housing.Name);
			Assert.AreEqual(first_housing.Level, second_housing.Level);
			Assert.AreEqual(first_housing.Memo, second_housing.Memo);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает корпус.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры корпуса.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedHousing()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
			_housingNew.Id = _housing.Id;
			_housingRepository.Update(_housingNew);
			result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housingNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет корпус.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
			_housingRepository.Delete(_housing.Id);
			result = _housingRepository.Get(_housing.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех корпусов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithHousing()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.GetList().Find(x => x.Id == _housing.Id);
			AreEqualHousing(result, _housing);
		}

		#endregion
	}
}
