using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public interface IRebateDataStore
{
    public Task<Rebate> GetRebate(string rebateIdentifier);
    public Task StoreCalculationResult(Rebate account, decimal rebateAmount);
}
