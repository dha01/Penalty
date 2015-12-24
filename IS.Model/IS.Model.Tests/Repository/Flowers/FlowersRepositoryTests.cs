using System;
using System.Transactions;
using IS.Model.Item.Flowers;
using IS.Model.Repository.Flowers;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Flowers
{
	/// <summary>
	/// Тесты для репозитория цветов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class FlowersRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий цветов.
		/// </summary>
		private FlowersRepository _flowersRepository;

		private FlowersItem _flowers;
		private FlowersItem _flowersNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_flowersRepository = new FlowersRepository();
			_flowers = new FlowersItem()
			{
				Name = "Роза",
				Family = FlowersFamily.Shipownikovie,
				Color = FlowersColor.Red,
				Thorns = "Да",
				LongTerm = "Да",
				Height = 90
			};
			_flowersNew = new FlowersItem()
			{
				Name = "Астра",
				Family = FlowersFamily.Astrovie,
				Color = FlowersColor.White,
				Thorns = "Нет",
				LongTerm = "Нет",
				Height = 20,
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
		/// Проверяет эквивалентны ли два цветка.
		/// </summary>
		/// <param name="first_flowers"></param>
		/// <param name="second_flowers"></param>
		private void AreEqualFaculties(FlowersItem first_flowers, FlowersItem second_flowers)
		{
            Assert.AreEqual(first_flowers.Id, second_flowers.Id);
			Assert.AreEqual(first_flowers.Name, second_flowers.Name);
			Assert.AreEqual(first_flowers.Family, second_flowers.Family);
			Assert.AreEqual(first_flowers.Color, second_flowers.Color);
			Assert.AreEqual(first_flowers.Thorns, second_flowers.Thorns);
			Assert.AreEqual(first_flowers.LongTerm, second_flowers.LongTerm);
			Assert.AreEqual(first_flowers.Height, second_flowers.Height);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает цветок.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_flowers.Id = _flowersRepository.Create(_flowers);
			var result = _flowersRepository.Get(_flowers.Id);
			AreEqualFaculties(result, _flowers);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры цветка.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedFlowers()
		{
			_flowers.Id = _flowersRepository.Create(_flowers);
			var result = _flowersRepository.Get(_flowers.Id);
			AreEqualFaculties(result, _flowers);
			_flowersNew.Id = _flowers.Id;
			_flowersRepository.Update(_flowersNew);
			result = _flowersRepository.Get(_flowers.Id);
			AreEqualFaculties(result, _flowersNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет запись о цветке.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_flowers.Id = _flowersRepository.Create(_flowers);
			var result = _flowersRepository.Get(_flowers.Id);
			AreEqualFaculties(result, _flowers);
			_flowersRepository.Delete(_flowers.Id);
			result = _flowersRepository.Get(_flowers.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех цветов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithFlowers()
		{
			_flowers.Id = _flowersRepository.Create(_flowers);
			var result = _flowersRepository.GetList().Find(x => x.Id == _flowers.Id);
			AreEqualFaculties(result, _flowers);
		}

		#endregion
	}
}
