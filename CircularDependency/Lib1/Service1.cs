using System;
using CommonLib;

namespace Lib1
{
	public class Service1 : IService1
	{
		private readonly Lazy<IHelperInterface> _helper;
		public Service1(Lazy<IHelperInterface> helper) //Если вместо Lazy инжектить просто интерфейс, всё зависнет
		{
			_helper = helper;
		}

		public string SomeString() => $"Service1 calls interface: {_helper.Value.SomeString()}";
	}

	public interface IService1
	{
		string SomeString();
	}
}
