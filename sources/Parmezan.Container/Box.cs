using System;
using System.Collections.Generic;
using System.Reflection;
using Parmezan.Container.Exceptions;
using Parmezan.Container.Helpers;
using Parmezan.Container.Properties;

namespace Parmezan.Container
{
	public class Box
	{
		#region Fields

		private readonly Dictionary<Type, ImplementationInformation> types = new Dictionary<Type, ImplementationInformation>();

		#endregion Fields

		#region Methods

		public void Register<T>(LifeStyle lifeStyle = LifeStyle.SingleForContainer)
		{
			var type = typeof(T);
			var implInfo = new ImplementationInformation(type, lifeStyle);
			types.Add(type, implInfo);
		}

		public void Register<TInterface, TImplementation>(LifeStyle lifeStyle = LifeStyle.SingleForContainer)
		{
			var impleInfo = new ImplementationInformation(typeof(TImplementation), lifeStyle);
			types.Add(typeof(TInterface), impleInfo);
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

			var implTypeInfo = types[type];
			object obj;
			switch (implTypeInfo.LifeStyle)
			{
				case LifeStyle.NewPerResolve:
					obj = ConstructNewInstance(implTypeInfo.Type);
					break;
				case LifeStyle.SingleForContainer:
					if (implTypeInfo.Instance == null)
					{
						implTypeInfo.Instance = ConstructNewInstance(implTypeInfo.Type);
					}
					obj = implTypeInfo.Instance;
					break;
				default:
					throw new ArgumentOutOfRangeException(string.Format(Resources.UnknownEnumerationValue, implTypeInfo.LifeStyle));
			}

			return obj;
		}

		private object ConstructNewInstance(Type type)
		{
			var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
			if (constructors.Length == 0)
			{
				throw new InvalidOperationException(string.Format(Resources.NoConstructorsFound, type));
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