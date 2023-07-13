using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Incentives;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    // Simulating datastore
    private List<Product> _products = new()
    {
        { new Product
            { Id = 1, Identifier = "1", Price=100, Uom="foo",
                Incentives = new HashSet<Incentive>() {
                    new AmountPerUom(),
                    new FixedCashAmount(),
                    new FixedRateRebate()
                }
            }
        }, 
    };

    /// <summary>
    /// Any IO should be async
    /// </summary>
    /// <param name="productIdentifier"></param>
    /// <returns></returns>
    public async Task<Product> GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return _products.Where(product => product.Identifier == productIdentifier).FirstOrDefault();
    }
}
