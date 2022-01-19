using System;
using CommonLib;
using Lib1;
using Lib2;
using Microsoft.Extensions.DependencyInjection;

namespace CircularDependency
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var services = new ServiceCollection();

			services.AddSingleton<Service2>();
			services.AddSingleton<IService2>(ctx => ctx.GetRequiredService<Service2>());
			services.AddSingleton<IHelperInterface>(ctx => ctx.GetRequiredService<Service2>());
			services.AddSingleton(ctx => new Lazy<IHelperInterface>(ctx.GetRequiredService<IHelperInterface>));
			services.AddSingleton<IService1, Service1>();

			var provider = services.BuildServiceProvider();
			

			var service1 = provider.GetRequiredService<IService1>();
			var service2 = provider.GetRequiredService<IService2>();

			Console.WriteLine(service1.SomeString());
			Console.WriteLine(service2.Service2String());
		}
	}
}
