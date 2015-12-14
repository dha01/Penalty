using System;
using System.Transactions;
using IS.Model.Item.Cathedra;
using IS.Model.Repository.Cathedra;
using NUnit.Framework;
using IS.Model.Repository.Faculty;
using System.Linq;
using IS.Model.Item.Faculty;

namespace IS.Model.Tests.Repository.Cathedra
{
	/// <summary>
	/// Тесты для репозитория кафедр.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class CathedraRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий кафедр.
		/// </summary>
		private CathedraRepository _cathedraRepository;
		private FacultyRepository _facultyRepository;

		private CathedraItem _cathedra;
		private CathedraItem _cathedraNew;

		private FacultyItem _faculty;
		private FacultyItem _facultyNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_facultyRepository = new FacultyRepository();
			_cathedraRepository = new CathedraRepository();

			_faculty = new FacultyItem()
			{
				FullName = "Информационный",
				ShortName = "И",
			};

			_facultyNew = new FacultyItem()
			{
				FullName = "Экономический",
				ShortName = "Э",
			};

			_cathedra = new CathedraItem()
			{
				FullName = "Информациионных систем и технологий",
				ShortName = "ИСиТ",
				FacultyId = _facultyRepository.Create(_faculty)
			};

			_cathedraNew = new CathedraItem()
			{
				FullName = "Экономики и управления",
				ShortName = "ЭиЭ",
				FacultyId = _facultyRepository.Create(_facultyNew)
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
		/// Проверяет эквивалентны ли две кафедры.
		/// </summary>
		/// <param name="first_cathedra"></param>
		/// <param name="second_cathedra"></param>
		private void AreEqualCathedra(CathedraItem first_cathedra, CathedraItem second_cathedra)
		{
			Assert.AreEqual(first_cathedra.Id, second_cathedra.Id);
			Assert.AreEqual(first_cathedra.FullName, second_cathedra.FullName);
			Assert.AreEqual(first_cathedra.ShortName, second_cathedra.ShortName);
			Assert.AreEqual(first_cathedra.FacultyId, second_cathedra.FacultyId);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает кафедру.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()

		{
			_cathedra.Id = _cathedraRepository.Create(_cathedra);
			var result = _cathedraRepository.Get(_cathedra.Id);
			AreEqualCathedra(result, _cathedra);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры кафедры.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedCathedra()
		{
			_cathedra.Id = _cathedraRepository.Create(_cathedra);
			var result = _cathedraRepository.Get(_cathedra.Id);
			AreEqualCathedra(result, _cathedra);
			_cathedraNew.Id = _cathedra.Id;
			_cathedraRepository.Update(_cathedraNew);
			result = _cathedraRepository.Get(_cathedra.Id);
			AreEqualCathedra(result, _cathedraNew);
		}
		#endregion

		#region Delete

		/// <summary>
		/// Удаляет кафедру.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_cathedra.Id = _cathedraRepository.Create(_cathedra);
			var result = _cathedraRepository.Get(_cathedra.Id);
			AreEqualCathedra(result, _cathedra);
			_cathedraRepository.Delete(_cathedra.Id);
			result = _cathedraRepository.Get(_cathedra.Id);
			Assert.IsNull(result);
		}
		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех кафедр.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithСathedra()
		{
			_cathedra.Id = _cathedraRepository.Create(_cathedra);

			var p = _cathedraRepository.GetList();
			var result = _cathedraRepository.GetList().Find(x => x.Id == _cathedra.Id);
			AreEqualCathedra(result, _cathedra);
		}

		#endregion
	}
}
