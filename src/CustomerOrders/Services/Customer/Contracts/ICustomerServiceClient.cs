using CustomerOrders.Services.Customer.Contracts.Requests;
using CustomerOrders.Services.Customer.Contracts.Responses;

namespace CustomerOrders.Services.Customer.Contracts;

/// <summary>
/// Интерфейс для взаимодействия с сервисом клиентов.
/// Предоставляет методы для получения информации о клиентах по различным критериям.
/// </summary>
public interface ICustomerServiceClient
{
    /// <summary>
    /// Получение информации о клиенте по его идентификатору.
    /// </summary>
    /// <param name="request">
    /// Объект запроса типа <see cref="GetCustomerByIdRequest"/>, содержащий параметры для поиска клиента.
    /// Обязательные поля: <see cref="GetCustomerByIdRequest.Id"/>.
    /// </param>
    /// <returns>
    /// Асинхронная операция, возвращающая объект типа <see cref="CustomerResponse"/>,
    /// представляющий информацию о клиенте.
    /// Если клиент не найден, может быть возвращён null или выброшено исключение.
    /// </returns>
    public Task<CustomerResponse> GetCustomerByIdAsync(GetCustomerByIdRequest request);
    
    /// <summary>
    /// Получение списка всех клиентов.
    /// </summary>
    /// <returns>
    /// Асинхронная операция, возвращающая коллекцию объектов типа <see cref="CustomerResponse"/>,
    /// представляющих информацию о клиентах.
    /// Если клиенты не найдены, возвращается пустая коллекция.
    /// </returns>
    public Task<IReadOnlyList<CustomerResponse>> GetCustomerListAsync();

    /// <summary>
    /// Получение списка клиентов по идентификатору региона.
    /// </summary>
    /// <param name="request">
    /// Объект запроса типа <see cref="GetCustomerListByRegionIdRequest"/>, содержащий параметры для фильтрации клиентов по региону.
    /// Обязательные поля: <see cref="GetCustomerListByRegionIdRequest.Id"/>.
    /// </param>
    /// <returns>
    /// Асинхронная операция, возвращающая коллекцию объектов типа <see cref="CustomerResponse"/>,
    /// представляющих информацию о клиентах, связанных с указанным регионом.
    /// Если клиенты не найдены, возвращается пустая коллекция.
    /// </returns>
    public Task<IReadOnlyList<CustomerResponse>> GetCustomerListByRegionIdAsync(GetCustomerListByRegionIdRequest request);
}