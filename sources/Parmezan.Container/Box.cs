using System;
using System.Collections.Generic;
using System.Reflection;
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

		public void Register<TInterface, TImplementation>()
		{
			types.Add(typeof(TInterface), typeof(TImplementation));
		}

		public T Resolve<T>()
		{
			var type = typeof(T);
			var obj = (T)Resolve(type);

			return obj;
		}

		#endregion Methods

		#region Helpers

		private object Resolve(Type type)
		{
			if (!types.ContainsKey(type))
			{
				throw new TypeNotFoundException(string.Format(Resources.TypeNotFoundExceptionMessage, type));
			}

			var implType = types[type];
			var constructors = implType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
			if (constructors.Length == 0)
			{
				throw new InvalidOperationException(string.Format(Resources.NoConstructorsFound, implType));
			}

			// Use the first constructor by default.
			var constructor = constructors[0];
			var formalParameters = constructors[0].GetParameters();
			var actualParameters = new object[formalParameters.Length];
			for (var i = 0; i < formalParameters.Length; i++)
			{
				var parameterValue = Resolve(formalParameters[i].ParameterType);
				actualParameters[i] = parameterValue;
			}
			var obj = constructor.Invoke(actualParameters);

			return obj;
		}

		#endregion Helpers
	}
}