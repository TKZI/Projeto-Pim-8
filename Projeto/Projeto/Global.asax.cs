using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.AspNet.Mvc;
using Unity;
using Projeto.Interface;
using Projeto.Models;

namespace Projeto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            var container = new UnityContainer();

            // Registre aqui suas interfaces e implementações
            container.RegisterType<IRepository<Carrinho>, CarrinhoRepository>();


            // Configuração da fábrica de controladores para usar o Unity Container
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
