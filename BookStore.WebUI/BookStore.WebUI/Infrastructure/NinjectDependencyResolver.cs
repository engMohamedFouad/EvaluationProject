using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Ninject;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.concrete;
namespace BookStore.WebUI.Infrastructure
{
    //public class NinjectDependencyResolver:IDependencyResolver
    //{
        //private IKernel kernel;
        //public NinjectDependencyResolver(IKernel kernelparam)
        //{
        //    kernel = kernelparam;
        //    AddBindings();
        //}

        //public object GetService(Type serviceType)
        //{
        //    kernel.TryGet(serviceType);
        //}

        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    kernel.GetAll(serviceType);
        //}
        //private void AddBindings()
        //{
        //    //we add binding here who interact with and that will know the kernel who implement the interfaces etc;
        //    //its only method we work of it.
        //    //Mock<IbookReporisitory> mock = new Mock<IbookReporisitory>();
        //    //mock.Setup(b => b.Books).Returns(
        //    //    new List<Books> {  new Books{ISBN=1,title="oliver twist",Price=50},
        //    //                       new Books{ISBN=1,title="Guliver advantage",Price=60},
        //    //                       new Books{ISBN=1,title="presented one",Price=40},
        //    //                       new Books{ISBN=1,title="last hero",Price=70},
        //    //    }
        //    //    );
        //    kernel.Bind<IbookReporisitory>().To(EFBookContext);

        //}
    //}
}