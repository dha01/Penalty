namespace IS.Model.Item.Person
{
    /// <summary>
    /// Класс для хранения данных о сущности студентов.
    /// </summary>
    public class StudentItem : PersonItem
    {
        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        public int TeamId { get; set; }
    }
}