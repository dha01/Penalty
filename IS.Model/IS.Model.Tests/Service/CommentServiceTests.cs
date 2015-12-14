using System;
using System.Collections.Generic;
using IS.Model.Item.Comment;
using IS.Model.Repository.Comment;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса комментариев.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class CommentServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис комментариев.
		/// </summary>
		private CommentService _commentService;

		/// <summary>
		/// Репозиторий комментариев.
		/// </summary>
		private ICommentRepository _commentRepository;

		/// <summary>
		/// Тестовый комментарий.
		/// </summary>
		private CommentItem _comment;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_commentRepository = Mock.Of<ICommentRepository>();
			_commentService = new CommentService(_commentRepository);

			_comment = new CommentItem()
			{
				Id = 1,
				AddDate = DateTime.Now.AddYears(-1).Date,
				PersonId = 1,
				Text = "Тестовая задача номер 1",
				TaskId = 2
			};
		}

		#endregion

		#region CommentService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void CommentService_Void_Success()
		{
			var s = new CommentService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает комментарий.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<CommentItem>() { _comment };

			Mock.Get(_commentRepository).Setup(x => x.Create(_comment)).Returns(_comment.Id);
			Mock.Get(_commentRepository).Setup(x => x.GetListByTaskId(_comment.TaskId)).Returns(list);

			var result = _commentService.Create(_comment);
			Assert.AreEqual(result, _comment.Id);
		}

		/// <summary>
		/// Создает комментарий с пустым текстом.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Text' не должно быть пустым.")]
		[Test]
		public void Create_EmptyText_ReturnException()
		{
			_comment.Text = null;
			_commentService.Create(_comment);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о комментарии.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_commentRepository).Setup(x => x.Get(_comment.Id)).Returns(_comment);
			_commentService.Update(_comment);
		}

		/// <summary>
		/// Изменяет текст на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Text' не должно быть пустым.")]
		[Test]
		public void Update_EmptyText_ReturnException()
		{
			_comment.Text = null;
			_commentService.Update(_comment);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Комментарий не найден.")]
		[Test]
		public void Update_CommentNotExists_ReturnException()
		{
			Mock.Get(_commentRepository).Setup(x => x.Get(_comment.Id)).Returns((CommentItem)null);
			_commentService.Update(_comment);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_commentService.Delete(_comment.Id);
		}

		#endregion

		#region GetListByTaskId

		/// <summary>
		/// Получает список комментариев по идентификатору задачи.
		/// </summary>
		[Test]
		public void GetListByTaskId_Void_ReturnCommentList()
		{
			var list = new List<CommentItem> { _comment };

			Mock.Get(_commentRepository).Setup(x => x.GetListByTaskId(_comment.TaskId)).Returns(list);
			var result = _commentService.GetListByTaskId(_comment.TaskId);

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
