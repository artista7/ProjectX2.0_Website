[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Project_X_2._0.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Project_X_2._0.App_Start.NinjectWebCommon), "Stop")]

namespace Project_X_2._0.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Project_X_2._0.Persistance;
    using System.Data.Entity;
    using Project_X_2._0.Entities;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //GlobalConfiguration
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope(); ;
            //kernel.Bind(typeof(DbContext)).To(typeof(ApplicationDbContext));
            kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork)).InRequestScope();
            kernel.Bind(typeof(ITripRepository)).To(typeof(TripRepository)).InRequestScope();
            kernel.Bind(typeof(IUserTripDetailsRepository)).To(typeof(UserTripDetailsRepository)).InRequestScope();
            kernel.Bind(typeof(IPlaceRepository)).To(typeof(PlaceRepository)).InRequestScope();
            kernel.Bind(typeof(ITripPictureRepository)).To(typeof(TripPictureRepository)).InRequestScope();
        }        
    }
}
