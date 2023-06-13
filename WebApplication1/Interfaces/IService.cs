namespace WebApplication1.Interfaces;

/// <summary>
/// Интерфейс сервиса
/// </summary>
public interface IService<T> 
{
    /// <summary>
    /// Метод для получения экземпляра по ID
    /// </summary>
    public T Get(Guid Id);

    /// <summary>
    /// Установка нового значения
    /// </summary>
    public T Update(Guid id, T newValue);

    /// <summary>
    /// Собирает список объектов
    /// </summary>
    public ICollection<T> Collection();

    /// <summary>
    /// Удаление экземпляра объекта
    /// </summary>
    public T Delete(Guid id);
}