#if NET5_0_OR_GREATER
using HarmonyLib;
using Il2Cpp;
using NUnit.Framework;
using System;

namespace HarmonyLibTests.Patching
{
	[TestFixture, NonParallelizable]
	public class GenericsFromIl2Cpp : TestLogger
	{
		[Test]
		public void Test_Generics_Other()
		{
			var harmony = new Harmony("test");
			Assert.NotNull(harmony);

			// this call will crash
			var processor = new PatchClassProcessor(harmony, typeof(Patch));
		}

		// MyGameScreen resides in Assembly-CSharp.dll
		[HarmonyPatch(typeof(MyGameScreen), "SetSomething", new Type[] { typeof(int) })]
		public static class Patch
		{
			private static void Prefix()
			{
				// The code inside this method will run before 'PrivateMethod' is executed
			}

			private static void Postfix()
			{
				// The code inside this method will run after 'PrivateMethod' has executed
			}
		}
	}
}
#endif
