namespace CustomerOrders.Services.Customer.Client.Exceptions;

/// <summary>
/// Базовый класс исключений, связанных с сервисом клиентов.
/// </summary>
/// <remarks>
/// Этот класс является базовым для всех исключений, которые могут возникать в процессе работы с сервисом клиентов.
/// Он предоставляет стандартные конструкторы для создания экземпляров исключений с сообщением об ошибке
/// или с указанием внутреннего исключения.
/// </remarks>
public class CustomerServiceException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CustomerServiceException"/> с указанным сообщением об ошибке.
    /// </summary>
    /// <param name="message">
    /// Сообщение, описывающее ошибку.
    /// </param>
    /// <remarks>
    /// Этот конструктор используется для создания исключения с текстовым описанием проблемы.
    /// </remarks>
    protected CustomerServiceException(string message) : base(message) { }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CustomerServiceException"/> с указанным сообщением об ошибке
    /// и ссылкой на внутреннее исключение, которое является причиной данного исключения.
    /// </summary>
    /// <param name="message">
    /// Сообщение, описывающее ошибку.
    /// </param>
    /// <param name="innerException">
    /// Исключение, которое является причиной текущего исключения,
    /// или null, если внутреннее исключение отсутствует.
    /// </param>
    /// <remarks>
    /// Этот конструктор используется для создания исключения с текстовым описанием проблемы
    /// и ссылкой на исходное исключение, которое привело к ошибке.
    /// </remarks>
    public CustomerServiceException(string message, Exception innerException) : base(message, innerException) { }
}