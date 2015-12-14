using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Helper;
using IS.Model.Item.Access;
using IS.Model.Item.Task;

namespace IS.Controllers
{
	public class SimpleTaskController : Controller
	{
		public ActionResult Index()
		{
			/*using (SqlHelper sqlh = new SqlHelper(@"
select
	st.simple_task Id,
	st.task_type TaskType,
	st.task_num TaskNum,
	st.header Header,
	st.mem Mem,
	st.executor Executor,
	st.difficult Difficult,
	st.complite Complite
from dbo.simple_task st"))
			{
				var dt = sqlh.ExecTable();

				var list = new List<TaskItem>();

				foreach (DataRow row in dt.Rows)
				{
					list.Add(new TaskItem()
					{
						Id = (int)row["Id"],
						TaskType = (int)row["TaskType"],
						TaskNum = (int)row["TaskNum"],
						Header = (string)row["Header"],
						Mem = (string)row["Mem"],
						Executor = row["Executor"] == DBNull.Value ? null : (string)row["Executor"],
						Difficult = (int)row["Difficult"],
						Complite = (bool)row["Complite"]
					});
				}

				return View(list);
			}*/
			return View();
		}

		public ActionResult Rules()
		{
			return View();
		}
	}
}
