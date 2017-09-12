using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using StoreDomain.Abstract;
using StoreDomain.Concrete;
using System.Data.Entity;

namespace StoreWebUI.DI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IRoot>().To<EFRoot>();
            kernel.Bind<IContext>().To<EFContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>));

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}