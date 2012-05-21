using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using PlayEv.Model.Concrete;
using PlayEv.Model.Abstract;
using PlayEv.WebUI.Infrastructure.Abstract;
using PlayEv.WebUI.Infrastructure.Concrete;

namespace PlayEv.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
            ninjectKernel.Bind<IGameRepository>().To<EFGameRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<SimpleAuthProvider>();
            ninjectKernel.Bind<ISecurePass>().To<SHASecurePass>();
        }


    }
}