using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readify.KnockKnock.Services;
using System;

namespace Readify.KnockKnock.Tests.Services
{
  [TestClass]
  public class FibonacciNumberServiceTest
  {
    [TestMethod]
    public void Calculate()
    {
      // Arrange
      var service = new FibonacciNumberService();

      // Act
      var test1 = service.Calculate(-4);
      var test2 = service.Calculate(-5);
      var test3 = service.Calculate(0);
      var test4 = service.Calculate(1);
      var test5 = service.Calculate(-6);
      var test6 = service.Calculate(3);
      var test7 = service.Calculate(4);
      var test8 = service.Calculate(5);
      var test9 = service.Calculate(6);
      var test10 = service.Calculate(7);
      var test11 = service.Calculate(46);
      var test12 = service.Calculate(47);
      var test13 = service.Calculate(47);

      long? test14 = null;
      try
      {
        test14 = service.Calculate(93);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be greater than 92, since the result will cause a 64-bit integer overflow."))
      {
        // Silently catch the expected exception.
      }

      long? test15 = null;
      try
      {
        test15 = service.Calculate(-93);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be less than -92, since the result will cause a 64-bit integer overflow."))
      {
        // Silently catch the expected exception.
      }

      // Assert
      Assert.IsTrue(test1 == -3);
      Assert.IsTrue(test2 == 5);
      Assert.IsTrue(test3 == 0);
      Assert.IsTrue(test4 == 1);
      Assert.IsTrue(test5 == -8);
      Assert.IsTrue(test6 == 2);
      Assert.IsTrue(test7 == 3);
      Assert.IsTrue(test8 == 5);
      Assert.IsTrue(test9 == 8);
      Assert.IsTrue(test10 == 13);
      Assert.IsTrue(test11 == 1836311903);
      Assert.IsTrue(test12 == 2971215073);
      Assert.IsTrue(test13 == 2971215073);
      Assert.IsTrue(test14 == null);
      Assert.IsTrue(test15 == null);
    }
  }
}