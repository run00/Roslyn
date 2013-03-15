﻿using Roslyn.Compilers.Common;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public static class NamespaceSymbolExtensions
	{
		public static IEnumerable<INamespaceOrTypeSymbol> GetTypes(this INamespaceSymbol namespaceSymbol)
		{
			var result = new List<INamespaceOrTypeSymbol>();

			foreach (var type in namespaceSymbol.GetTypeMembers())
				result.Add(type);

			foreach (var childNamespace in namespaceSymbol.GetNamespaceMembers())
				result.AddRange(GetTypes(childNamespace));

			return result;
		}
	}

}