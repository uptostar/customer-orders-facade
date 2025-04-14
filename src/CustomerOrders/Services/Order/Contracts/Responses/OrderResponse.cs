namespace CustomerOrders.Services.Order.Contracts.Responses;

/// <summary>
/// Статусы заказа
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Не определено
    /// </summary>
    Undefined = 0,
    
    /// <summary>
    /// Создан
    /// </summary>
    New = 1,
    
    /// <summary>
    /// Отменен
    /// </summary>
    Canceled = 2,
    
    /// <summary>
    /// Доставлен
    /// </summary>
    Delivered = 3
}

/// <summary>
/// Класс, представляющий ответ с информацией о заказе.
/// </summary>
/// <remarks>
/// Этот класс используется для передачи данных о заказе между сервисами или уровнями приложения.
/// Свойства этого класса доступны только для чтения после инициализации.
/// </remarks>
public abstract class OrderResponse
{
    /// <summary>
    /// Уникальный идентификатор заказа.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее идентификатор заказа.
    /// </value>
    public long Id { get; init; }

    /// <summary>
    /// Идентификатор клиента, связанного с заказом.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее идентификатор клиента.
    /// </value>
    public long CustomerId { get; init; }

    /// <summary>
    /// Информация о регионе, связанном с заказом.
    /// </summary>
    /// <value>
    /// Объект типа <see cref="RegionResponse"/>, содержащий данные о регионе.
    /// Не может быть null после инициализации.
    /// </value>
    /// <remarks>
    /// Это свойство инициализируется через конструктор или объектный инициализатор.
    /// Если значение не предоставлено, будет выброшено исключение.
    /// </remarks>
    public RegionResponse Region { get; init; } = null!;

    /// <summary>
    /// Статус заказа.
    /// </summary>
    /// <value>
    /// Значение перечисления <see cref="OrderStatus"/>, представляющее текущий статус заказа.
    /// </value>
    public OrderStatus OrderStatus { get; init; }

    /// <summary>
    /// Комментарий к заказу (опционально).
    /// </summary>
    /// <value>
    /// Строковое значение, представляющее комментарий к заказу.
    /// Может быть null, если комментарий отсутствует.
    /// </value>
    public string? Comment { get; init; }

    /// <summary>
    /// Дата и время создания заказа.
    /// </summary>
    /// <value>
    /// Значение типа <see cref="DateTime"/>, представляющее дату и время создания заказа.
    /// </value>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Общее количество единиц товара в заказе.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее общее количество единиц товара.
    /// </value>
    public long TotalCount { get; init; }
}

/// <summary>
/// Класс, представляющий ответ с информацией о регионе.
/// </summary>
/// <remarks>
/// Этот класс используется для передачи данных о регионе между сервисами или уровнями приложения.
/// Свойства этого класса доступны только для чтения после инициализации.
/// </remarks>
public abstract record RegionResponse
{
    /// <summary>
    /// Уникальный идентификатор региона.
    /// </summary>
    /// <value>
    /// Целочисленное значение, представляющее идентификатор региона.
    /// </value>
    public int Id { get; init; }
    
    /// <summary>
    /// Название региона.
    /// </summary>
    /// <value>
    /// Строковое значение, представляющее название региона.
    /// Не может быть null после инициализации.
    /// </value>
    /// <remarks>
    /// Это свойство инициализируется через конструктор или объектный инициализатор.
    /// Если значение не предоставлено, будет выброшено исключение.
    /// </remarks>
    public string Name { get; init; } = null!;
}