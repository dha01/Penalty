using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Cathedra;
using IS.Model.Item.Faculty;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Specialty;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Faculty;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Specialty
{
	/// <summary>
	/// Тесты для репозитория учбных курсов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class SpecialtyDetailRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий курсов.
		/// </summary>
		private SpecialtyDetailRepository _specialtyDetailRepository;
		private SpecialtyRepository _specialtyRepository;
		private CathedraRepository _cathedraRepository;
		private FacultyRepository _facultyRepository;

		private SpecialtyItem _specialty;
		private SpecialtyItem _specialtyNew;
		private SpecialtyDetailItem _specialtyDetail;
		private SpecialtyDetailItem _specialtyDetailNew;
		private CathedraItem _cathedra;
		private FacultyItem _faculty;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_specialtyRepository = new SpecialtyRepository();
			_specialtyDetailRepository = new SpecialtyDetailRepository();
			_cathedraRepository = new CathedraRepository();
			_facultyRepository = new FacultyRepository();

			_faculty = new FacultyItem()
			{
				FullName = "Информационный",
				ShortName = "И",
			};

			_cathedra = new CathedraItem()
			{
				FullName = "Информациионных систем и технологий",
				ShortName = "ИСиТ",
				FacultyId = _facultyRepository.Create(_faculty)
			};

			_specialty = new SpecialtyItem()
			{
				FullName = "Программное обеспечение вычислительной техники и автоматизированных систем",
				ShortName = "Ифн",
				Code = "230105",
				CathedraId = _cathedraRepository.Create(_cathedra)
			};

			_specialtyNew = new SpecialtyItem()
			{
				FullName = "Экономика и технология производства",
				ShortName = "ЭТП",
				Code = "230221",
				CathedraId = _cathedraRepository.Create(_cathedra)
			};

			_specialtyDetail = new SpecialtyDetailItem()
			{
				ActualDate = new DateTime(2015,01,01),
				SpecialtyId = _specialtyRepository.Create(_specialty),
				SemestrCount = 1,
				TrainingPeriod = 1,
				Qualification = Qualification.Bachelor,
				FormStudy = FormStudy.Distance,
				PaySpace = 15,
				LowcostSpace = 4,
			};
			_specialtyDetailNew = new SpecialtyDetailItem()
			{
				ActualDate = new DateTime(2015,01,02),
				SpecialtyId = _specialtyRepository.Create(_specialtyNew),
				SemestrCount = 2,
				TrainingPeriod = 2,
				Qualification = Qualification.Master,
				FormStudy = FormStudy.Fulltime,
				PaySpace = 30,
				LowcostSpace = 6,
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
		/// Проверяет эквивалентны ли два учебных курса.
		/// </summary>
		/// <param name="first_specialty_detail">Первый учебный курс</param>
		/// <param name="second_specialty_detail">Второй учебный курс</param>
		private void AreEqualSpecialtyDetails(SpecialtyDetailItem first_specialty_detail, SpecialtyDetailItem second_specialty_detail)
		{
			Assert.AreEqual(first_specialty_detail.Id, second_specialty_detail.Id);
			Assert.AreEqual(first_specialty_detail.ActualDate, second_specialty_detail.ActualDate);
			Assert.AreEqual(first_specialty_detail.SemestrCount, second_specialty_detail.SemestrCount);
			Assert.AreEqual(first_specialty_detail.TrainingPeriod, second_specialty_detail.TrainingPeriod);
			Assert.AreEqual(first_specialty_detail.PaySpace, second_specialty_detail.PaySpace);
			Assert.AreEqual(first_specialty_detail.LowcostSpace, second_specialty_detail.LowcostSpace);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает учебный курс.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_specialtyDetail.Id = _specialtyDetailRepository.Create(_specialtyDetail);
			var result = _specialtyDetailRepository.Get(_specialtyDetail.Id);
			AreEqualSpecialtyDetails(result, _specialtyDetail);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры учебного курса.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedSpecialtyDetail()
		{
			_specialtyDetail.Id = _specialtyDetailRepository.Create(_specialtyDetail);
			var result = _specialtyDetailRepository.Get(_specialtyDetail.Id);
			AreEqualSpecialtyDetails(result, _specialtyDetail);

			_specialtyDetailNew.Id = _specialtyDetail.Id;
			_specialtyDetailRepository.Update(_specialtyDetailNew);
			result = _specialtyDetailRepository.Get(_specialtyDetail.Id);
			AreEqualSpecialtyDetails(result, _specialtyDetailNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет курс.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_specialtyDetail.Id = _specialtyDetailRepository.Create(_specialtyDetail);
			var result = _specialtyDetailRepository.Get(_specialtyDetail.Id);
			AreEqualSpecialtyDetails(result, _specialtyDetail);

			_specialtyDetailRepository.Delete(_specialtyDetail.Id);
			result = _specialtyDetailRepository.Get(_specialtyDetail.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех учебных курсов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithSpecialtyDetails()
		{
			_specialtyDetail.Id = _specialtyDetailRepository.Create(_specialtyDetail);
			var result = _specialtyDetailRepository.GetList().Find(x => x.Id == _specialtyDetail.Id);
			AreEqualSpecialtyDetails(result, _specialtyDetail);
		}

		#endregion
	}
}
