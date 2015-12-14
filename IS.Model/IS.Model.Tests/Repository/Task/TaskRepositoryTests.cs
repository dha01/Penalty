using System;
using System.Transactions;
using IS.Model.Item.Task;
using IS.Model.Repository.Task;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Task
{
	/// <summary>
	/// Тесты для репозитория задач.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class TaskRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private TaskRepository _taskRepository;

		private TaskItem _task;
		private TaskItem _taskNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_taskRepository = new TaskRepository();

			_task = new TaskItem()
			{
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
				Prefix = TaskPrefix.Refactoring,
				PullRequestUrl = "https://github.com/dha01/IS/pull/1"
			}; 
			_taskNew = new TaskItem()
			{
				Author = "1",
				Deadline = DateTime.Now.AddDays(8).Date,
				Created = DateTime.Now.Date,
				Performer = "2",
				Header = "Тестирование демонстрационной задачи 2",
				IsOpen = false,
				IsPerform = true,
				Mem = "Описание2",
				Number = 2,
				Priority = 5,
				Prefix = TaskPrefix.Demo,
				PullRequestUrl = "https://github.com/dha01/IS/pull/2"
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
		/// Проверяет еквивалентны ли две задачи.
		/// </summary>
		/// <param name="first_task"></param>
		/// <param name="second_task"></param>
		private void AreEqualTasks(TaskItem first_task, TaskItem second_task)
		{
			Assert.AreEqual(first_task.Id, second_task.Id);
			Assert.AreEqual(first_task.Author, second_task.Author);
			Assert.AreEqual(first_task.Deadline, second_task.Deadline);
			Assert.AreEqual(first_task.Performer, second_task.Performer);
			Assert.AreEqual(first_task.Header, second_task.Header);
			Assert.AreEqual(first_task.IsOpen, second_task.IsOpen);
			Assert.AreEqual(first_task.IsPerform, second_task.IsPerform);
			Assert.AreEqual(first_task.Mem, second_task.Mem);
			Assert.AreEqual(first_task.Number, second_task.Number);
			Assert.AreEqual(first_task.Priority, second_task.Priority);
			Assert.AreEqual(first_task.Prefix, second_task.Prefix);
			Assert.AreEqual(first_task.PullRequestUrl, second_task.PullRequestUrl);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает задачу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.Get(_task.Id);
			AreEqualTasks(result, _task);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры задачи.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedTask()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.Get(_task.Id);
			AreEqualTasks(result, _task);

			_taskNew.Id = _task.Id;
			_taskRepository.Update(_taskNew);
			result = _taskRepository.Get(_task.Id);
			AreEqualTasks(result, _taskNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.Get(_task.Id);
			AreEqualTasks(result, _task);

			_taskRepository.Delete(_task.Id);
			result = _taskRepository.Get(_task.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTask()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.GetList().Find(x => x.Id == _task.Id);
			AreEqualTasks(result, _task);
		}

		#endregion
	}
}
