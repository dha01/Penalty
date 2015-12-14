using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace IS.Model.Helper
{
	/// <summary>
	/// Позволяет обращаться к базе данных более простым и наглядным образом
	/// </summary>
	public class SqlHelper : IDisposable
	{
		/// <summary>
		/// Подключение к базе данных
		/// </summary>
		private SqlConnection dbase;

		/// <summary>
		/// Команда для исполнения
		/// </summary>
		private SqlCommand _command;

		public SqlHelper()
		{
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
			dbase = new SqlConnection(settings.ConnectionString);
			dbase.Open();
		}

		/// <summary>
		/// Конструктор класс
		/// </summary>
		/// <param name="command">Запрос</param>
		public SqlHelper(string command)
		{
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
			dbase = new SqlConnection(settings.ConnectionString);
			dbase.Open();

			NewCommand(command);
		}

		/// <summary>
		/// Задает новый запрос, при этом все предыдущие заданные параметры удаляютсся
		/// </summary>
		/// <param name="command">Запрос</param>
		public void NewCommand(string command, object values = null)
		{
			_command = new SqlCommand(command, dbase);
			if (values != null)
			{
				var descrs = TypeDescriptor.GetProperties(values);
				foreach (PropertyDescriptor descr in descrs)
				{
					var type = Type.GetType(descr.PropertyType.FullName);
					if (type.IsEnum)
					{
						AddWithValue(descr.Name, Enum.GetName(type, descr.GetValue(values)));
					}
					else
					{
						AddWithValue(descr.Name, descr.GetValue(values));
					}
				}
			}
		}

		public T RowMapping<T>(DataColumnCollection columns, DataRow row) where T : class, new()
		{
			T item = new T();
			foreach (DataColumn field in columns)
			{
				PropertyDescriptor descr = TypeDescriptor.GetProperties(item)[field.ColumnName];
				if (descr == null)
				{
					continue;
				}

				if (row[field.ColumnName] != DBNull.Value)
				{
					var type = Type.GetType(descr.PropertyType.FullName);
					if (type.IsEnum)
					{
						var st = (string) row[field.ColumnName];
						var va = Enum.Parse(type, st);
						descr.SetValue(item, va);
					}
					else
					{
						descr.SetValue(item, row[field.ColumnName]);
					}
					
				}
			}
			return item;
		}

		/// <summary>
		/// Исполняет запрос с возвращением таблицы
		/// </summary>
		/// <returns>Таблица с результатами запроса</returns>
		public DataTable ExecTable()
		{
			SqlDataAdapter dbAdapter = new SqlDataAdapter(_command);
			DataTable dataTable = new DataTable();
			dbAdapter.Fill(dataTable);
			return dataTable;
		}

		public void ExecNoQuery(string command, object values = null)
		{
			NewCommand(command, values);
			ExecNoQuery();
		}

		public T ExecScalar<T>(string command, object values = null)
		{
			NewCommand(command, values);
			var result = ExecScalar();
			return (T)Convert.ChangeType(result, typeof(T));
		}

		public List<T> ExecMappingList<T>(string command, object values = null) where T : class, new()
		{
			NewCommand(command, values);
			DataTable data_table = ExecTable();

			List<T> list = new List<T>();

			foreach (DataRow row in data_table.Rows)
			{
				list.Add(RowMapping<T>(data_table.Columns, row));
			}

			return list;
		}

		public T ExecMapping<T>(string command, object values = null) where T : class, new()
		{
			NewCommand(command, values);
			DataTable data_table = ExecTable();

			T item = null;
			if (data_table.Rows.Count > 0)
			{
				item = RowMapping<T>(data_table.Columns, data_table.Rows[0]);
			}
			return item;
		}

		/// <summary>
		/// Исполняет запрос с возвращением скалярного значение
		/// </summary>
		/// <returns>Скалярный результат выполнения запроса</returns>
		public object ExecScalar()
		{
			return _command.ExecuteScalar();
		}

		/// <summary>
		/// Исполняет запрос без возвращения результата
		/// </summary>
		public void ExecNoQuery()
		{
			_command.ExecuteNonQuery();
		}

		/// <summary>
		/// Добавляет параметр использмый в запросе
		/// </summary>
		/// <param name="parameter_name">Имя параметра в запросе</param>
		/// <param name="value">Значение параметра</param>
		public void AddWithValue(string parameter_name, object value)
		{
			if (value == null)
				_command.Parameters.AddWithValue(parameter_name, DBNull.Value);
			else
				_command.Parameters.AddWithValue(parameter_name, value);
		}

		/// <summary>
		/// Преобразует объект в nullable значение
		/// </summary>
		/// <typeparam name="T">Тип передаваемого объекта</typeparam>
		/// <param name="value">Передаваемый объект</param>
		/// <returns>Преобразованный в nullable объект</returns>
		public static Nullable<T> CastNull<T>(object value)
			where T : struct
		{
			if (value == null || value == DBNull.Value)
			{
				return null;
			}
			return (T)value;
		}

		/// <summary>
		/// Преобразует класс в nullable значение
		/// </summary>
		/// <typeparam name="T">Класса передаваемого объекта</typeparam>
		/// <param name="value">Передаваемый объект</param>
		/// <returns>Преобразованный в nullable объект</returns>
		public static T CastNullClass<T>(object value)
			where T : class
		{
			if (value == null || value == DBNull.Value)
			{
				return null;
			}
			return (T)value;
		}

		/// <summary>
		/// Отчиска ресурсов системы
		/// </summary>
		public virtual void Dispose()
		{
			this.dbase.Close();
			this.dbase.Dispose();
		}
	}
}
