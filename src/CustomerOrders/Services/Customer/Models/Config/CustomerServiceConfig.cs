namespace CustomerOrders.Services.Customer.Models.Config;

/// <summary>
/// Класс конфигурации для клиента сервиса клиентов.
/// Содержит настройки, необходимые для взаимодействия с внешним API.
/// </summary>
/// <remarks>
/// Этот класс используется для хранения параметров конфигурации,
/// таких как базовый URL и имя сервиса.
/// Эти параметры обычно загружаются из файла конфигурации (например, appsettings.json).
/// </remarks>
public class CustomerServiceConfig
{
    /// <summary>
    /// Базовый URL внешнего сервиса заказов.
    /// </summary>
    /// <remarks>
    /// Указывает корневой адрес API, к которому будут выполняться HTTP-запросы.
    /// Пример: "https://api.example.com".
    /// </remarks>
    public string BaseUrl { get; init; }
    
    /// <summary>
    /// Имя сервиса заказов.
    /// </summary>
    /// <remarks>
    /// Используется для идентификации сервиса в логах или сообщениях об ошибках.
    /// Пример: "CustomerOrderService".
    /// </remarks>
    public string Name { get; init; }
    
    /// <summary>
    /// Время ожидания (тайм-аут) для выполнения операций.
    /// </summary>
    /// <value>
    /// Значение типа <see cref="long"/>, представляющее максимальное время ожидания в секундах.
    /// По умолчанию может быть установлено значение, например, 30 секунд (<c>TimeSpan.FromSeconds(30)</c>).
    /// </value>
    /// <remarks>
    /// Это свойство используется для настройки времени ожидания при выполнении асинхронных операций,
    /// таких как HTTP-запросы или другие сетевые взаимодействия.
    /// Если время ожидания превышено, операция может завершиться с ошибкой.
    /// </remarks>
    public long Timeout { get; init; } = 30;

    /// <summary>
    /// Возвращает URI базового адреса сервиса заказов.
    /// </summary>
    /// <returns>
    /// Экземпляр <see cref="Uri"/>, представляющий базовый URL сервиса.
    /// </returns>
    /// <remarks>
    /// Метод использует свойство <see cref="BaseUrl"/> для создания объекта <see cref="Uri"/>.
    /// Если <see cref="BaseUrl"/> не задан или имеет некорректное значение, может быть выброшено исключение.
    /// </remarks>
    /// <exception cref="UriFormatException">
    /// Выбрасывается, если значение <see cref="BaseUrl"/> не является допустимым URI.
    /// </exception>
    public Uri GetUri()
    {
        return new Uri(BaseUrl);
    }
}