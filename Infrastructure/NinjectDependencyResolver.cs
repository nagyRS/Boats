using BWL.Domain.Abstract;
using BWL.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BWL.WebUI.Infrastructure
{
    public class NinjectDependencyResolver :IDependencyResolver 
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<IBoatRepository>().To<EFBoatRepository>();
        }
    }
}