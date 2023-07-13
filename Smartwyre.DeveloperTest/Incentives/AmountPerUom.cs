using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives;

public class AmountPerUom : Incentive
{
    public override decimal CalculateRebate(Product product, Rebate rebate, RebateRequest request)
    {
        if (product == null || rebate == null || request == null || 
            rebate.Amount == 0 || request.Volume == 0)
        {
            return 0;
        }

        if (product.Incentives.Where(c => c.GetType() == rebate.Incentive.GetType()).Any()) return rebate.Amount * request.Volume;

        return 0;
    }
}
