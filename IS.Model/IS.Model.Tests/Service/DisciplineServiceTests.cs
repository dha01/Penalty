using System;
using System.Collections.Generic;
using IS.Model.Item.Discipline;
using IS.Model.Repository.Discipline;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
    /// <summary>
    /// Тесты для сервиса дисциплин.
    /// </summary>
    [Category("Unit")]
    [TestFixture]
    public class DisciplineServiceTests
    {
        #region Fields

        /// <summary>
        /// Сервис дисциплин.
        /// </summary>
        private DisciplineService _disciplineService;

        /// <summary>
        /// Репозиторий дисциплин.
        /// </summary>
        private IDisciplineRepository _disciplineRepository;

        /// <summary>
        /// Тестовая дисциплина.
        /// </summary>
        private DisciplineItem _discipline;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _disciplineRepository = Mock.Of<IDisciplineRepository>();
            _disciplineService = new DisciplineService(_disciplineRepository);

            _discipline = new DisciplineItem()
            {
                Id = 1,
                ShortName = "test",
                FullName = "test_full",
                Mem = "Описание"
            };
        }

        #endregion

        #region DisciplineService

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        [Test]
        public void DisciplineService_Void_Success()
        {
            var s = new DisciplineService();
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает дисциплину.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            var list = new List<DisciplineItem>() { _discipline };

            Mock.Get(_disciplineRepository).Setup(x => x.Create(_discipline)).Returns(_discipline.Id);
            Mock.Get(_disciplineRepository).Setup(x => x.GetList()).Returns(list);

            var result = _disciplineService.Create(_discipline);
            Assert.AreEqual(result, _discipline.Id);
        }

        /// <summary>
        /// Создает дисциплину с пустым полем "FullName".
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
        [Test]
        public void Create_EmptyFullName_ReturnException()
        {
            _discipline.FullName = null;
            _disciplineService.Create(_discipline);
        }

        /// <summary>
        /// Создает дисциплину с пустым полем "ShortName".
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
        [Test]
        public void Create_EmptyShortName_ReturnException()
        {
            _discipline.ShortName = null;
            _disciplineService.Create(_discipline);
        }

        /// <summary>
        /// Создает дисциплину с пустым описанием.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
        [Test]
        public void Create_EmptyMem_ReturnException()
        {
            _discipline.Mem = null;
            _disciplineService.Create(_discipline);
        }

        #endregion

        #region Update

        /// <summary>
        /// Изменяет данные о дисциплине.
        /// </summary>
        [Test]
        public void Update_Void_Success()
        {
            Mock.Get(_disciplineRepository).Setup(x => x.Get(_discipline.Id)).Returns(_discipline);
            _disciplineService.Update(_discipline);
        }

        /// <summary>
        /// Изменяет поле "FullName" на пустое.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
        [Test]
        public void Update_EmptyFullName_ReturnException()
        {
            _discipline.FullName = null;
            _disciplineService.Update(_discipline);
        }

        /// <summary>
        /// Изменяет поле "ShortName" на пустое.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
        [Test]
        public void Update_EmptyShortName_ReturnException()
        {
            _discipline.ShortName = null;
            _disciplineService.Update(_discipline);
        }

        /// <summary>
        /// Изменяет описание на пустое.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
        [Test]
        public void Update_EmptyMem_ReturnException()
        {
            _discipline.Mem = null;
            _disciplineService.Update(_discipline);
        }

        /// <summary>
        /// Изменяет описание на пустое.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Дисциплина не найдена.")]
        [Test]
        public void Update_DisciplineNotExists_ReturnException()
        {
            Mock.Get(_disciplineRepository).Setup(x => x.Get(_discipline.Id)).Returns((DisciplineItem)null);
            _disciplineService.Update(_discipline);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляет дисциплину.
        /// </summary>
        [Test]
        public void Delete_Void_Success()
        {
            _disciplineService.Delete(_discipline.Id);
        }

        #endregion

        #region GetList

        /// <summary>
        /// Получает список дисциплин.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnTaskList()
        {
            var list = new List<DisciplineItem> { _discipline };

            Mock.Get(_disciplineRepository).Setup(x => x.GetList()).Returns(list);
            var result = _disciplineService.GetList();

            Assert.AreEqual(result.Count, list.Count);
        }

        #endregion
    }
}
