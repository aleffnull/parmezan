using System;
using System.Collections.Generic;
using Parmezan.Container.Exceptions;
using Parmezan.Container.Properties;

namespace Parmezan.Container
{
	public class Box
	{
		#region Fields

		private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();

		#endregion Fields

		#region Methods

		public void Register<T>()
		{
			var type = typeof(T);
			types.Add(type, type);
		}

		public T Resolve<T>()
		{
			var type = typeof(T);
			if (!types.ContainsKey(type))
			{
				throw new TypeNotFoundException(string.Format(Resources.TypeNotFoundExceptionMessage, type));
			}

			var implType = types[type];
			var obj = (T)Activator.CreateInstance(implType);

			return obj;
		}

		#endregion Methods
	}
}