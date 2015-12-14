using System;
using System.Collections.Generic;
using IS.Model.Item.Task;
using IS.Model.Repository.Task;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса задач.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class TaskServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис задач.
		/// </summary>
		private TaskService _taskService;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private ITaskRepository _taskRepository;

		/// <summary>
		/// Тестовая задача.
		/// </summary>
		private TaskItem _task;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_taskRepository = Mock.Of<ITaskRepository>();
			_taskService = new TaskService(_taskRepository);

			_task = new TaskItem()
			{
				Id = 1,
				Author = "",
				Deadline = DateTime.Now.AddDays(7).Date,
				Created = DateTime.Now.Date,
				Performer = "",
				Header = "Тестирование демонстрационной задачи",
				IsOpen = true,
				IsPerform = false,
				Mem = "Описание",
				Number = 1,
				Priority = 0,
				Prefix = TaskPrefix.Refactoring
			}; 
		}

		#endregion

		#region TaskService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void TaskService_Void_Success()
		{
			var s = new TaskService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает задачу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<TaskItem>(){ _task };
			
			Mock.Get(_taskRepository).Setup(x => x.Create(_task)).Returns(_task.Id);
			Mock.Get(_taskRepository).Setup(x => x.GetList()).Returns(list);

			var result = _taskService.Create(_task);
			Assert.AreEqual(result, _task.Id);
		}

		/// <summary>
		/// Создает задачу с пустым заголовком.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Header' не должно быть пустым.")]
		[Test]
		public void Create_EmptyHeader_ReturnException()
		{
			_task.Header = null;
			_taskService.Create(_task);
		}

		/// <summary>
		/// Создает задачу с пустым описанием.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMem_ReturnException()
		{
			_task.Mem = null;
			_taskService.Create(_task);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о задаче.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_taskRepository).Setup(x => x.Get(_task.Id)).Returns(_task);
			_taskService.Update(_task);
		}

		/// <summary>
		/// Изменяет заголовок на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Header' не должно быть пустым.")]
		[Test]
		public void Update_EmptyHeader_ReturnException()
		{
			_task.Header = null;
			_taskService.Update(_task);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMem_ReturnException()
		{
			_task.Mem = null;
			_taskService.Update(_task);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Задача не найдена.")]
		[Test]
		public void Update_TaskNotExists_ReturnException()
		{
			Mock.Get(_taskRepository).Setup(x => x.Get(_task.Id)).Returns((TaskItem)null);
			_taskService.Update(_task);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_taskService.Delete(_task.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список задач.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<TaskItem> { _task };

			Mock.Get(_taskRepository).Setup(x => x.GetList()).Returns(list);
			var result = _taskService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
