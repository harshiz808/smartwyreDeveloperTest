using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives;

/// <summary>
/// Base class.  If you need to add a new incentive, create a new class and and inherit this class
/// </summary>
public abstract class Incentive : IIncentive
{
    public virtual decimal CalculateRebate(Product product, Rebate rebate, RebateRequest request)
    {
        throw new NotImplementedException();
    }
}
