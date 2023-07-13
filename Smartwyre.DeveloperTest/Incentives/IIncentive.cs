using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Incentives;

public interface IIncentive
{
    decimal CalculateRebate(Product product, Rebate rebate, RebateRequest request);
}