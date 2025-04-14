using CustomerOrders.Services.Order.Contracts.Requests;
using CustomerOrders.Services.Order.Contracts.Responses;

namespace CustomerOrders.Services.Order.Contracts;

/// <summary>
/// Интерфейс для взаимодействия с сервисом заказов.
/// Предоставляет методы для получения списка заказов по различным критериям.
/// </summary>
public interface IOrderServiceClient
{
    /// <summary>
    /// Получение списка заказов по идентификатору региона.
    /// </summary>
    /// <param name="request">
    /// Объект запроса типа <see cref="GetOrderListByRegionIdRequest"/>, содержащий параметры для фильтрации заказов по региону.
    /// Обязательные поля: <see cref="GetOrderListByRegionIdRequest.RegionId"/>.
    /// </param>
    /// <returns>
    /// Асинхронная операция, возвращающая коллекцию заказов (<see cref="IReadOnlyList{OrderDto}"/>),
    /// связанных с указанным регионом.
    /// Если заказы не найдены, возвращается пустая коллекция.
    /// </returns>
    Task<IReadOnlyList<OrderResponse>> GetOrderListByRegionIdAsync(GetOrderListByRegionIdRequest request);

    /// <summary>
    /// Получение списка заказов по идентификатору покупателя.
    /// </summary>
    /// <param name="request">
    /// Объект запроса типа <see cref="GetOrderListByCustomerIdRequest"/>, содержащий параметры для фильтрации заказов по региону.
    /// Обязательные поля: <see cref="GetOrderListByCustomerIdRequest.CustomerId"/>.
    /// </param>
    /// <returns>
    /// Асинхронная операция, возвращающая коллекцию заказов (<see cref="IReadOnlyList{OrderDto}"/>),
    /// связанных с указанным покупателем.
    /// Если заказы не найдены, возвращается пустая коллекция.
    /// </returns>
    Task<IReadOnlyList<OrderResponse>> GetOrderListByCustomerIdAsync(GetOrderListByCustomerIdRequest request);
}