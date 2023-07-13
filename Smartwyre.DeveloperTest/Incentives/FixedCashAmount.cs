using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives;

public class FixedCashAmount : Incentive
{
    public override decimal CalculateRebate(Product product, Rebate rebate, RebateRequest request)
    {
        if (rebate == null || product == null || request == null || rebate.Amount == 0) return 0;

        if (product.Incentives.Where(c => c.GetType() == rebate.Incentive.GetType()).Any()) return rebate.Amount;

        return 0;
    }
}
