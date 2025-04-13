using CustomerOrders.Models.External.Customer;

namespace CustomerOrders.Facades.Interfaces;

public interface ICustomerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<List<CustomerDto>> GetAll();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<CustomerDto> GetById(long id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="regionId"></param>
    /// <returns></returns>
    public  Task<List<CustomerDto>> GetCustomerListByRegionId(long regionId);
}