using System;
using Autofac;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        //DI
        var builder = new ContainerBuilder();
        builder.RegisterType<ProductDataStore>().As<IProductDataStore>().SingleInstance();
        builder.RegisterType<RebateDataStore>().As<IRebateDataStore>().SingleInstance();
        builder.RegisterType<RebateService>().As<IRebateService>().SingleInstance();

        var container = builder.Build();
        var pDataStore = container.Resolve<IProductDataStore>();
        var rDataStore = container.Resolve<IRebateDataStore>();
        var rebateService = container.Resolve<IRebateService>();

        //Get product ID
        var request = new RebateRequest() { ProductIdentifier = "1", RebateIdentifier = "1", Volume = 10 };
        rebateService.CalculateRebate(request);
    }
}
