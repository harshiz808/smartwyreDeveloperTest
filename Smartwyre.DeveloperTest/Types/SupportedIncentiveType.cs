using System;

namespace Smartwyre.DeveloperTest.Types;

[Obsolete("This has been deprecated")]
public enum SupportedIncentiveType
{
    FixedRateRebate = 1 << 0,
    AmountPerUom = 1 << 1,
    FixedCashAmount = 1 << 2,
}
