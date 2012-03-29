using System;
using System.Configuration;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Bti.Databridge.Feeds.Data;
using Bti.Databridge.Feeds.Domain;

namespace Bti.Databridge.RestService
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string dsstring = ConfigurationManager.ConnectionStrings["DataServicesContext"].ConnectionString;
            
            container.Register(
                Component
                    .For<ICustomerService>()
                    .ImplementedBy<CustomerService>()
                    .LifeStyle.PerWcfSession()
            );

            container.Register(
                Component
                    .For<CustomerRepository>()
                    .ImplementedBy<SqlCustomerRepository>()
                    .LifeStyle.PerWcfSession()
                    .DependsOn((new
                    {
                        dataServicesConnString = dsstring
                    }))
            );
        }
    }
}
