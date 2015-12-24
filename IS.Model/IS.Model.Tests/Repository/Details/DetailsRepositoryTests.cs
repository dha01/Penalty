using System;
using System.Transactions;
using IS.Model.Item.Details;
using IS.Model.Repository.Details;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Details
{
	/// <summary>
	/// Тесты для репозитория деталей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class DetailsRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий деталей.
		/// </summary>
		private DetailsRepository _detailsRepository;

		private DetailsItem _details;
		private DetailsItem _detailsNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_detailsRepository = new DetailsRepository();

			_details = new DetailsItem()
			{
				Name = "testName1",
				ReleaseDate = DateTime.Now.Date,
				Width = 100,
				Lenght = 100,
				Height = 100,
				Mass = 1000,
				Material = DetailsMaterial.Glass,
				Mem = "Стекло"
			};
			_detailsNew = new DetailsItem()
			{
				Name = "testName2",
				ReleaseDate = DateTime.Now.Date,
				Width = 100,
				Lenght = 100,
				Height = 100,
				Mass = 1000,
				Material = DetailsMaterial.Wood,
				Mem = "Дерево"
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
		/// Проверяет еквивалентны ли две детали.
		/// </summary>
		/// <param name="first_details">Первая деталь.</param>
		/// <param name="second_details">Вторая деталь.</param>
		private void AreEqualDetails(DetailsItem first_details, DetailsItem second_details)
		{
			Assert.AreEqual(first_details.Id, second_details.Id);
			Assert.AreEqual(first_details.Name, second_details.Name);
			Assert.AreEqual(first_details.ReleaseDate, second_details.ReleaseDate);
			Assert.AreEqual(first_details.Width, second_details.Width);
			Assert.AreEqual(first_details.Lenght, second_details.Lenght);
			Assert.AreEqual(first_details.Height, second_details.Height);
			Assert.AreEqual(first_details.Mass, second_details.Mass);
			Assert.AreEqual(first_details.Material, second_details.Material);
			Assert.AreEqual(first_details.Mem, second_details.Mem);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает Деталь.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_details.Id = _detailsRepository.Create(_details);
			var result = _detailsRepository.Get(_details.Id);
			AreEqualDetails(result, _details);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры детали.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedDetails()
		{
			_details.Id = _detailsRepository.Create(_details);
			var result = _detailsRepository.Get(_details.Id);
			AreEqualDetails(result, _details);

			_detailsNew.Id = _details.Id;
			_detailsRepository.Update(_detailsNew);
			result = _detailsRepository.Get(_details.Id);
			AreEqualDetails(result, _detailsNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет деталь.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_details.Id = _detailsRepository.Create(_details);
			var result = _detailsRepository.Get(_details.Id);
			AreEqualDetails(result, _details);

			_detailsRepository.Delete(_details.Id);
			result = _detailsRepository.Get(_details.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех деталей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithDetails()
		{
			_details.Id = _detailsRepository.Create(_details);
			var result = _detailsRepository.GetList().Find(x => x.Id == _details.Id);
			AreEqualDetails(result, _details);
		}

		#endregion
	}
}