using System;
using IS.Model.Item.Team;
using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Team;
using IS.Model.Repository.Team;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для групп.
	/// </summary>
	public class TeamService
	{
		private ITeamRepository _teamRepository;

		/// <summary>
		/// Конструктор устанавливает репозиторий по умолчанию.
		/// </summary>
		public TeamService()
		{
			_teamRepository = new TeamRepository();
		}

		/// <summary>
		/// Конструктор класса.
		/// </summary>
		/// <param name="team_repository">Интерфейс пользовательского репозитория.</param>
		public TeamService(ITeamRepository team_repository)
		{
			_teamRepository = team_repository;
		}

		/// <summary>
		/// Создает новую группу.
		/// </summary>
		/// <param name="team">Группа.</param>
		/// <returns>Идентификатор созданной группы.</returns>
		public int Create(TeamItem team)
		{
			if (string.IsNullOrWhiteSpace(team.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			return _teamRepository.Create(team);
		}

		/// <summary>
		/// Получает группу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Группа.</returns>
		public TeamItem GetById(int Id)
		{
			return _teamRepository.Get(Id);
		}

		/// <summary>
		/// Обновляет данные по группе.
		/// </summary>
		/// <param name="team">Группа.</param>
		public void Update(TeamItem team)
		{
			if (string.IsNullOrWhiteSpace(team.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}
			if (GetById(team.Id) == null)
			{
				throw new Exception("Группа не найдена.");
			}
			_teamRepository.Update(team);
		}

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int Id)
		{
			_teamRepository.Delete(Id);
		}

		/// <summary>
		/// Получает список всех групп.
		/// </summary>
		/// <returns>Список групп.</returns>
		public List<TeamItem> GetList()
		{
			return _teamRepository.GetList();
		}
	}
}