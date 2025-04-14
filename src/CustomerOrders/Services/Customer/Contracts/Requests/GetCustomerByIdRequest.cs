using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Services.Customer.Contracts.Requests;

/// <summary>
/// Класс запроса для получения информации о клиенте по его идентификатору.
/// </summary>
/// <remarks>
/// Этот класс используется для передачи данных в методы, которые выполняют поиск клиента по уникальному идентификатору.
/// Свойство <see cref="Id"/> является обязательным и должно быть установлено перед выполнением запроса.
/// </remarks>
public class GetCustomerByIdRequest
{
    /// <summary>
    /// Уникальный идентификатор клиента.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее идентификатор клиента.
    /// </value>
    /// <remarks>
    /// Это свойство помечено атрибутом <see cref="RequiredAttribute"/>, что делает его обязательным для заполнения.
    /// Если значение не предоставлено, запрос может быть отклонён или вызвано исключение валидации.
    /// </remarks>
    [Required]
    public long Id { get; set; }
}