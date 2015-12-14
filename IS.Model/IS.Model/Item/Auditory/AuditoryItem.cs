using System;

namespace IS.Model.Item.Auditory
{
    /// <summary>
    /// Класс для хранения данных по аудиториям.
    /// </summary>
    public class AuditoryItem
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Полное наименование.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// Этаж.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Вместимость.
        /// </summary>
        public int Capacity { get; set; }
    }
}
