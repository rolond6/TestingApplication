using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns>Возращает список сущностей</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Получить записи определённой страницы
        /// </summary>
        /// <param name="predicate">Условие для поиска</param>
        /// <returns>Возращает список сущностей</returns>
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        /// <summary>
        /// Получить запись по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <returns>Возращает конкретную сущность</returns>
        TEntity? Get(long id);
        /// <summary>
        /// Создать сущность
        /// </summary>
        /// <param name="entity">Создаваемая сущность</param>
        /// <returns>Возращает создаваемую сущность</returns>
        void Add(TEntity entity);
        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        void Edit(TEntity entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        void Remove(TEntity entity);
    }
}
