namespace IS.Model.Repository
{
	/// <summary>
	/// Базовый класс интерфейса репозиториев
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		T Get(int id);
	}
}