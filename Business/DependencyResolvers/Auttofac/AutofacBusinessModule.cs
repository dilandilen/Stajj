using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Intercepter;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.EntityFramework.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Auttofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>();

            builder.RegisterType<PersonelService>().As<IPersonelService>();
            builder.RegisterType<PersonelDal>().As<IPersonelDal>();

            builder.RegisterType<SaleTransService>().As<ISaleTransService>();
            builder.RegisterType<SaleTransDal>().As<ISaleTransDal>();

            builder.RegisterType<TodoListService>().As<ITodoListService>();
            builder.RegisterType<TodoListDal>().As<ITodoListDal>();

            builder.RegisterType<InvoiceService>().As<IInvoiceService>();
            builder.RegisterType<InvoiceItemService>().As<IInvoiceItemService>();
            builder.RegisterType<InvoiceItemDal>().As<IInvoiceItemDal>();
            builder.RegisterType<InvoinceDal>().As<IInvoiceDal>();
            builder.RegisterType<CartDal>().As<ICartRepository>();
            builder.RegisterType<CartManager>().As<ICartService>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();
            builder.RegisterType<OrderService>().As<IOrderService>();


			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }

}






