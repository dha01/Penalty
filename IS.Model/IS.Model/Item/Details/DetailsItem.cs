using System;

namespace IS.Model.Item.Details
{
    /// <summary>
    /// Класс для хранения данных детали.
    /// </summary>
    public class DetailsItem
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата выпуска.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Длинна.
        /// </summary>
        public float Lenght { get; set; }


        /// <summary>
        /// Идентификатор материала.
        /// </summary>
        public DetailsMaterial Material { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Mem { get; set; }

    }

    /// <summary>
    /// Материалы деталей.
    /// </summary>
    public enum DetailsMaterial
    {
        /// <summary>
        /// Дерево.
        /// </summary>
        Wood,
        /// <summary>
        /// Камень.
        /// </summary>
        Stone
    }
}