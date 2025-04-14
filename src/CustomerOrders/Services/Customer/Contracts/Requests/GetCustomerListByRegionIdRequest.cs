using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Services.Customer.Contracts.Requests;

/// <summary>
/// Класс запроса для получения списка клиентов по идентификатору региона.
/// </summary>
/// <remarks>
/// Этот класс используется для передачи данных в методы, которые выполняют фильтрацию клиентов по региону.
/// Свойство <see cref="Id"/> является обязательным и должно быть установлено перед выполнением запроса.
/// </remarks>
public abstract class GetCustomerListByRegionIdRequest
{
    /// <summary>
    /// Идентификатор региона.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее идентификатор региона.
    /// </value>
    /// <remarks>
    /// Это свойство помечено атрибутом <see cref="RequiredAttribute"/>, что делает его обязательным для заполнения.
    /// Если значение не предоставлено, запрос может быть отклонён или вызвано исключение валидации.
    /// </remarks>
    [Required]
    public long Id { get; set; }
}