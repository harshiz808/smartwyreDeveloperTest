using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }

    public async Task CalculateRebate(RebateRequest request)
    {
        var rebate = await _rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = await _productDataStore.GetProduct(request.ProductIdentifier);

        var rebateAmount = rebate.Incentive.CalculateRebate(product, rebate, request);

        Console.WriteLine(rebateAmount.ToString());

        await _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
    }
}
