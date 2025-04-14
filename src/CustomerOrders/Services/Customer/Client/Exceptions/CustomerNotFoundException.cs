namespace CustomerOrders.Services.Customer.Client.Exceptions;

/// <summary>
/// Исключение, возникающее, когда покупатель с указанным идентификатором не найден.
/// </summary>
/// <remarks>
/// Это исключение используется для обработки случаев, когда запрос на поиск покупателя по идентификатору
/// завершается неудачей из-за отсутствия соответствующего покупателя в системе.
/// </remarks>
public class CustomerNotFoundException : CustomerServiceException
{
    /// <summary>
    /// Идентификатор покупателя, который не был найден.
    /// </summary>
    /// <value>
    /// Целочисленное значение типа <see cref="long"/>, представляющее идентификатор покупателя.
    /// </value>
    public long CustomerId { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CustomerNotFoundException"/>.
    /// </summary>
    /// <param name="customerId">
    /// Идентификатор покупателя, который не был найден.
    /// </param>
    /// <remarks>
    /// Сообщение об ошибке формируется автоматически на основе переданного идентификатора.
    /// </remarks>
    public CustomerNotFoundException(long customerId) : base($"Покупатель с идентификатором {customerId} не был найден.")
    {
        CustomerId = customerId;
    }
}