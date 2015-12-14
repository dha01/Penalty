using System;
using System.Collections.Generic;
using IS.Model.Service;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Specialty;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса учебных курсов.
	/// </summary>
	class SpecialtyDetailServiceTest
	{
		#region Fields

		/// <summary>
		/// Сервис учебных курсов.
		/// </summary>
		private SpecialtyDetailService _specialtyDetailService;

		/// <summary>
		/// Репозиторий учебных курсов.
		/// </summary>
		private ISpecialtyDetailRepository _specialtyDetailRepository;

		/// <summary>
		/// Тестовый учебный курс.
		/// </summary>
		private SpecialtyDetailItem _specialtyDetail;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_specialtyDetailRepository = Mock.Of<ISpecialtyDetailRepository>();
			_specialtyDetailService = new SpecialtyDetailService(_specialtyDetailRepository);

			_specialtyDetail = new SpecialtyDetailItem()
			{
				ActualDate = new DateTime(2015, 01, 01),
				SpecialtyId = 1,
				SemestrCount = 1,
				TrainingPeriod = 1,
				Qualification = Qualification.Bachelor,
				FormStudy = FormStudy.Distance,
				PaySpace = 15,
				LowcostSpace = 4,
			};
		}

		#endregion

		#region SpecialtyDetailService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void SpecialtyDetailService_Void_Success()
		{
			var s = new SpecialtyDetailService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает учебный курс.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<SpecialtyDetailItem>() { _specialtyDetail };

			Mock.Get(_specialtyDetailRepository).Setup(x => x.Create(_specialtyDetail)).Returns(_specialtyDetail.Id);
			Mock.Get(_specialtyDetailRepository).Setup(x => x.GetList()).Returns(list);

			var result = _specialtyDetailService.Create(_specialtyDetail);
			Assert.AreEqual(result, _specialtyDetail.Id);
		}

		/// <summary>
		/// Создает учебный курс для теста.
		/// </summary>
		[Test]
		public void Create_EmptyCode_ReturnException()
		{
			_specialtyDetailService.Create(_specialtyDetail);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные об учебном курсе.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_specialtyDetailRepository).Setup(x => x.Get(_specialtyDetail.Id)).Returns(_specialtyDetail);
			_specialtyDetailService.Update(_specialtyDetail);
		}

		/// <summary>
		/// Изменяет не существующий учебный курс.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Учебный курс не найден.")]
		[Test]
		public void Update_RecordNotExists_ReturnException()
		{
			Mock.Get(_specialtyDetailRepository).Setup(x => x.Get(_specialtyDetail.Id)).Returns((SpecialtyDetailItem)null);
			_specialtyDetailService.Update(_specialtyDetail);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет учебный курс.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_specialtyDetailService.Delete(_specialtyDetail.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список учебных курсов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnSpecialtyDetailList()
		{
			var list = new List<SpecialtyDetailItem> { _specialtyDetail };

			Mock.Get(_specialtyDetailRepository).Setup(x => x.GetList()).Returns(list);
			var result = _specialtyDetailService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
