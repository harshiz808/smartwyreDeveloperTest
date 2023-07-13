using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives;

public class FixedRateRebate : Incentive
{
    public override decimal CalculateRebate(Product product, Rebate rebate, RebateRequest request)
    {
        if (product == null || rebate == null || request == null || rebate.Percentage == 0
            || product.Price == 0 || request.Volume == 0) return 0;

        if (product.Incentives.Where(c => c.GetType() == rebate.Incentive.GetType()).Any()) return product.Price * rebate.Percentage * request.Volume;

        return 0;
    }
}
