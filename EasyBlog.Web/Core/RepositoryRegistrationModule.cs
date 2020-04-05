using Autofac;
using EasyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBlog.Web.Core
{
    //Register components with an autofac module
    public class RepositoryRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder) {
            //Register assembly with lambda expression
            builder.RegisterAssemblyTypes(typeof(BlogPostRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .As(t => t.GetInterfaces()?.FirstOrDefault(
                   i => i.Name == "I" + t.Name))
               .InstancePerRequest()
               .WithParameter(new TypedParameter(typeof(string), "easyBlog"));
        }
    }
}