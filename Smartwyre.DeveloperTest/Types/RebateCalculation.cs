using System;

namespace Smartwyre.DeveloperTest.Types;

[Obsolete("This class isn't used.  Could probably be refactored to be placed to be placed in the rebateDataStore")]
public class RebateCalculation
{
    public int Id { get; set; }
    public string Identifier { get; set; }
    public string RebateIdentifier { get; set; }
    public IncentiveType IncentiveType { get; set; }
    public decimal Amount { get; set; }
}
