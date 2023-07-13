using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Incentives;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests;

public class IncentivesUnitTests
{
    private Incentive AmountPerUom;
    private Incentive FixedCashAmount;
    private Incentive FixedRateRebate;

    [SetUp]
    public void Setup()
    {
        AmountPerUom = new AmountPerUom();
        FixedCashAmount = new FixedCashAmount();
        FixedRateRebate = new FixedRateRebate();
    }

    public static IEnumerable<TestCaseData> CalculateRebate_ForAmountPerUom_ShouldResultInZero_TestCases
    {
        get
        {
            yield return new TestCaseData(null, null, null);
            yield return new TestCaseData(new Product(), null, null);
            yield return new TestCaseData(null, new Rebate(), new RebateRequest());
            yield return new TestCaseData(new Product(), new Rebate(), new RebateRequest());
            yield return new TestCaseData(new Product() { Incentives = null}, new Rebate() { Incentive = new AmountPerUom()}, new RebateRequest());
        }
    }

    public static IEnumerable<TestCaseData> CalculateRebate_ForAmountPerUom_ShouldPassTestCases
    {
        get
        {
            yield return new TestCaseData(new Product
            {
                Id = 1,
                Identifier = "1",
                Price = 100,
                Uom = "foo",
                Incentives = new HashSet<Incentive>() {
                    new AmountPerUom(),
                    new FixedCashAmount(),
                    new FixedRateRebate()
                }
            },  
                new Rebate() { Amount = 100, Identifier = "1", Percentage = .05m, Incentive = new AmountPerUom() },
                new RebateRequest() { Volume = 100}
            );
        }
    }

    [TestCaseSource(nameof(CalculateRebate_ForAmountPerUom_ShouldResultInZero_TestCases))]
    public void CalculateRebate_ForAmountPerUom_ShouldResultInZero(Product p, Rebate r, RebateRequest request)
    {
        //Act
        var result = AmountPerUom.CalculateRebate(p, r, request);

        //Assert
        Assert.That(result, Is.Zero);
    }

    [TestCaseSource(nameof(CalculateRebate_ForAmountPerUom_ShouldPassTestCases))]
    public void CalculateRebate_ForAmountPerUom_ShouldNotResultInZero(Product p, Rebate r, RebateRequest request)
    {
        var result = AmountPerUom.CalculateRebate(p, r, request);
        var containsClassType = p.Incentives.Where(c => c.GetType() == r.Incentive.GetType()).Any();

        Assert.That(containsClassType, Is.True);
        Assert.That(result, Is.GreaterThan(0));
    }
}
