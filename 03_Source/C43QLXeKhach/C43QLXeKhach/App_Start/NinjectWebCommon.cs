[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(C43QLXeKhach.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(C43QLXeKhach.App_Start.NinjectWebCommon), "Stop")]

namespace C43QLXeKhach.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Services.NHANVIENsService;
    using Services.LOAIXEsService;
    using Services.KHAOSATsService;
    using Services.TINHTHANHsService;
    using Services.TRAMXEsService;
    using Services.KHACHHANGsService;
    using Services.DOITACsService;
    using Services.HOPDONGsService;

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
            kernel.Bind<INhanVienService>().To<NhanVienService>();
            kernel.Bind<ILoaiXeService>().To<LoaiXeService>();
            kernel.Bind<IKhaoSatService>().To<KhaoSatService>();
            kernel.Bind<ITinhThanhService>().To<TinhThanhService>();
            kernel.Bind<ITramXeService>().To<TramXeService>();
            kernel.Bind<IKhachHangService>().To<KhachHangService>();
            kernel.Bind<IDoiTacService>().To<DoiTacService>();
            kernel.Bind<IHopDongService>().To<HopDongService>();
        }
    }
}
