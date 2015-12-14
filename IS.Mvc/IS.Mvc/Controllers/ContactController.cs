using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Contact;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
    /// <summary>
    /// Контролер для работы с контактами.
    /// </summary>
    public class ContactController : Controller
    {
        private ContactService _contactService;
		
		/// <summary>
		/// Конструктор контроллера контактов.
		/// </summary>
		public ContactController()
		{
			_contactService = new ContactService();
		}

        /// <summary>
        /// Список контактов.
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            Access.CheckAccess("Contact.Reader");
            return View("List", _contactService.GetList());
        }

        /// <summary>
        /// Страница с контактом. Если идентификатор не указан перенаправляет на список контактов.
        /// </summary>
        /// <param name="id">Идентификатор контакта.</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            Access.CheckAccess("Contact.Reader");
            if (id.HasValue)
            {
                return View("Index", _contactService.GetById(id.Value));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Создает новый контакт.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Create(ContactItem contact)
        {
            Access.CheckAccess("Contact.Creator");
            return RedirectToAction("Index", new { id = _contactService.Create(contact) });
        }

        /// <summary>
        /// Интерфейс для создания контакта.
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            Access.CheckAccess("Contact.Creator");
            var default_item = new ContactItem
            {
                Value = ""
            };
            return View(default_item);
        }

        /// <summary>
        /// Сохраняет измменения у контакта.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Update(ContactItem contact)
        {
            Access.CheckAccess("Contact.Updater");
            _contactService.Update(contact);
            return RedirectToAction("Index", new { id = contact.Id });
        }

        /// <summary>
        /// Интерфейс для редактирования контакта.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Access.CheckAccess("Contact.Updater");
            return View(_contactService.GetById(id));
        }

        /// <summary>
        /// Удаление контакта.
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Access.CheckAccess("Contact.Deleter");
            _contactService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}