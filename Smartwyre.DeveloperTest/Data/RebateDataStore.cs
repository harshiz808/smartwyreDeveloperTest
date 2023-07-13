using Smartwyre.DeveloperTest.Incentives;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore : IRebateDataStore
{
    // Simulating datastore
    private List<Rebate> _rebates = new List<Rebate>()
    {
        { new Rebate(){ Amount = 1, Identifier = "1", Percentage = .05m, Incentive = new AmountPerUom()} },
        { new Rebate(){ Amount = 2, Identifier = "2", Percentage = .07m, Incentive = new FixedCashAmount()} },
        { new Rebate(){ Amount = 1, Identifier = "3", Percentage = .09m, Incentive = new FixedRateRebate()} }
    };

    private List<decimal> _rebateCalculations = new List<decimal>();

    public async Task<Rebate> GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return _rebates.Where(rebate => rebate.Identifier == rebateIdentifier).FirstOrDefault();
    }

    public async Task StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
        _rebates.Add(account);
        _rebateCalculations.Add(rebateAmount);
    }
}
