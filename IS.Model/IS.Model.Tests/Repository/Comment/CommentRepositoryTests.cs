using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Comment;
using IS.Model.Repository.Comment;
using NUnit.Framework;
using IS.Model.Repository.Person;
using IS.Model.Repository.Task;
using IS.Model.Item.Person;
using IS.Model.Item.Task;

namespace IS.Model.Tests.Repository.Comment
{
	/// <summary>
	/// Тесты для репозитория комментариев.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class CommentRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий комментариев.
		/// </summary>
		private CommentRepository _commentRepository;

		private CommentItem _comment;
		private CommentItem _commentNew;

		/// <summary>
		/// Репозиторий людей.
		/// </summary>
		private PersonRepository _personRepository;

		public PersonItem first_person;
		public PersonItem second_person;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private TaskRepository _taskRepository;

		public TaskItem first_task;
		public TaskItem second_task;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_commentRepository = new CommentRepository();
			_personRepository = new PersonRepository();
			_taskRepository = new TaskRepository();

			first_person = new PersonItem()
			{
				LastName = "Никонов",
				FirstName = "Денис",
				Birthday = DateTime.Now.Date,
				FatherName = "Олегович"
			};

			second_person = new PersonItem()
			{
				LastName = "Кажин",
				FirstName = "Филипп",
				Birthday = DateTime.Now.AddMonths(-3).Date,
				FatherName = "Александрович"
			};

			first_task = new TaskItem()
			{
				Author = "1",
				Deadline = DateTime.Now.AddDays(7).Date,
				Created = DateTime.Now.Date,
				Performer = "1",
				Header = "Тестирование демонстрационной задачи",
				IsOpen = true,
				IsPerform = false,
				Mem = "Описание",
				Number = 1,
				Priority = 0,
				Prefix = TaskPrefix.Refactoring
			};

			second_task = new TaskItem()
			{
				Author = "2",
				Deadline = DateTime.Now.AddDays(8).Date,
				Created = DateTime.Now.Date,
				Performer = "2",
				Header = "Тестирование демонстрационной задачи 2",
				IsOpen = false,
				IsPerform = true,
				Mem = "Описание2",
				Number = 2,
				Priority = 5,
				Prefix = TaskPrefix.Demo
			};

			_comment = new CommentItem()
			{
				AddDate = DateTime.Now.Date, 
				PersonId = _personRepository.Create(first_person),
				Text = "Задача номер 1",
				TaskId = _taskRepository.Create(first_task)
			};
			_commentNew = new CommentItem()
			{
				AddDate = DateTime.Now.AddYears(-1).Date,
				PersonId = _personRepository.Create(second_person),
				Text = "Задача номер 2",
				TaskId = _taskRepository.Create(second_task)
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
		/// Проверяет еквивалентны ли два комментария.
		/// </summary>
		/// Описание входных параметров.
		/// <param name="first_comment">Первый комментарий для сравнения.</param>
		/// <param name="second_comment">Второй комментарий для сравнения.</param>
		private void AreEqualComments(CommentItem first_comment, CommentItem second_comment)
		{
			Assert.AreEqual(first_comment.Id, second_comment.Id);
			Assert.AreEqual(first_comment.AddDate, second_comment.AddDate);
			Assert.AreEqual(first_comment.PersonId, second_comment.PersonId);
			Assert.AreEqual(first_comment.Text, second_comment.Text);
			Assert.AreEqual(first_comment.TaskId, second_comment.TaskId);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает комментарий.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры комментария.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedComment()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);

			_commentNew.Id = _comment.Id;
			_commentRepository.Update(_commentNew);
			result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _commentNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);

			_commentRepository.Delete(_comment.Id);
			result = _commentRepository.Get(_comment.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetListByTaskId

		/// <summary>
		/// Получает список комментариев по идентификатору задачи.
		/// </summary>
		[Test]
		public void GetListByTaskId_Void_ReturnNotEmptyListWithComment()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.GetListByTaskId(_comment.TaskId).Find(x => x.Id == _comment.Id);
			AreEqualComments(result, _comment);
		}

		#endregion
	}
}
