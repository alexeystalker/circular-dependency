using System;
using CommonLib;
using Lib1;

namespace Lib2
{
	public class Service2 : IService2, IHelperInterface
	{
		private readonly IService1 _service1;

		public Service2(IService1 service1)
		{
			_service1 = service1;
		}
		public string SomeString() => "Helper Interface realization: Service2";
		public string Service2String() => $"Service2 calls Service1: {_service1.SomeString()}";
	}

	public interface IService2
	{
		string Service2String();
	}
}
