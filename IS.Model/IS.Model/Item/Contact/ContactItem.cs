using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Contact
{
	/// <summary>
	/// Класс для хранения данных по контакту.
	/// </summary>
	public class ContactItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор типа контакта.
		/// </summary>
		public ContactType Type { get; set; }

		/// <summary>
		/// Значение.
		/// </summary>
		public string Value { get; set; }
	}
	
	/// <summary>
	/// Тип контакта.
	/// </summary>
	public enum ContactType
	{
		/// <summary>
		/// Мобильный телефон.
		/// </summary>
		MobilePhone,

		/// <summary>
		/// Городской телефон/
		/// </summary>
		CityPhone,

		/// <summary>
		/// Скайп/
		/// </summary>
		Skype,

		/// <summary>
		/// Фейсбук.
		/// </summary>
		Facebook,

		/// <summary>
		/// ВКонтакте.
		/// </summary>
		VK,

		/// <summary>
		/// Стим.
		/// </summary>
		Steam,

		/// <summary>
		/// Твиттер.
		/// </summary>
		Twitter,

		/// <summary>
		/// Инстаграм.
		/// </summary>
		Instagram
	}
}
