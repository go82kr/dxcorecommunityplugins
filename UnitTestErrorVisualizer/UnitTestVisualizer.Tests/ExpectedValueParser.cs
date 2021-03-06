using System;
using Xunit;
using UnitTestErrorVisualizer;

namespace UnitTestVisualizer.Tests
{
	public class ExpectedValueParser
	{
		[Fact]
		public void TestResultParser_NStringMessageVb_Who()
		{
			string message = "Expected string length 3 but was 4. Strings differ at index 2.\n  Expected: \"who\"\n  But was:  \"what\"\n  -------------^\n\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("\"who\"", expected);
		}

		[Fact]
		public void TestResultParser_XStringMessage_Who()
		{
			string message = "Assert.Equal() Failure\nPosition: First difference is at position 6\r\nExpected: who's there\r\nActual:   who's where";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("who's there", expected);
		}

		[Fact]
		public void TestResultParser_MbStringMessage_Who()
		{
			string message = "Expected values to be equal.\n\nExpected Value : \"who\'s there\"\nActual Value   : \"who\'s where\"\n\n   at RedGreenPlayground.MbUnitTests.AlwaysFails() in C:\\Users\\JAARGERO.WRPWI\\Documents\\Visual Studio 2005\\Projects\\RedGreenPlayground\\RedGreenPlayground\\MbUnitTests.cs:line 21\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.InvokeMethod(Object instance, MethodInfo methodInfo, Int32 testTimeout, Object[] parameters)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout, Object[] parameters, Object expectedResult)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, TestMethod test, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(TestMethodCollection tests, Boolean needToFilterByAssembly)\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("\"who's there\"", expected);
		}

		[Fact]
		public void TestResultParser_NIntMessage_Zero()
		{
			string message = "Expected: 0\n  But was:  1\n\nVoid That(System.Object, NUnit.Framework.Constraints.Constraint, System.String, System.Object[])\nVoid AreEqual(Int32, Int32, System.String, System.Object[])\nVoid AreEqual(Int32, Int32)\nC:\\Users\\JAARGERO.WRPWI\\Documents\\Visual Studio 2005\\Projects\\RedGreenPlayground\\RedGreenPlayground\\NUnitTests.cs(417, 4) : Void IntFail9()\n\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("0", expected);
		}

		[Fact]
		public void TestResultParser_MbIntMessage_Zero()
		{
			string message = "Expected values to be equal.\n\nExpected Value : 0\nActual Value   : 1\n\n   at RedGreenPlayground.MbUnitTests.IntFail() in C:\\Users\\JAARGERO.WRPWI\\Documents\\Visual Studio 2005\\Projects\\RedGreenPlayground\\RedGreenPlayground\\MbUnitTests.cs:line 28\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.InvokeMethod(Object instance, MethodInfo methodInfo, Int32 testTimeout, Object[] parameters)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout, Object[] parameters, Object expectedResult)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, TestMethod test, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(TestMethodCollection tests, Boolean needToFilterByAssembly)\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("0", expected);
		}

		[Fact]
		public void TestResultParser_XIntMessage_Zero()
		{
			string message = "Assert.Equal() Failure\nExpected: 0\r\nActual:   1\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("0", expected);
		}

		[Fact]
		public void TestResultParser_NNotNullMessage_Zero()
		{
			string message = "  Expected: not null\n  But was:  null\n\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("not null", expected);
		}

		[Fact]
		public void TestResultParser_MbNotNullMessage_Zero()
		{
			string message = "Expected value to be non-null.\n\nActual Value : null\n\n   at RedGreenPlayground.MbUnitTests.NotNull() in C:\\Users\\JAARGERO.WRPWI\\Documents\\Visual Studio 2005\\Projects\\RedGreenPlayground\\RedGreenPlayground\\MbUnitTests.cs:line 41\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.InvokeMethod(Object instance, MethodInfo methodInfo, Int32 testTimeout, Object[] parameters)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout, Object[] parameters, Object expectedResult)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(Object instance, TestMethod test, MethodInfo methodInfo, List`1 tasks, Int32 testTimeout)\n   at DevExpress.CodeRush.Core.Testing.UnitTestDomain.Execute(TestMethodCollection tests, Boolean needToFilterByAssembly)\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal("non-null", expected);
		}

		[Fact]
		public void TestResultParser_XNullMessage_Zero()
		{
			string message = "Test has failed.\nAssert.NotNull() Failure\n";

			string expected = TestResultParser.Expected(message);

			Assert.Equal(String.Empty, expected);
		}

	}
}
