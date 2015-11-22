using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readify.KnockKnock.Tests.RedPill;
using System;

namespace Readify.KnockKnock.Tests
{
  /// <summary>
  /// Run the 'Readify.KnockKnock' project in the IIS Express (Debug -> Start Without Debug) before running the tests.
  /// </summary>
  [TestClass]
  public class RedPillTest
  {
    [TestMethod]
    public void WhatIsYourToken()
    {
      // Arrange
      RedPillClient client = new RedPillClient();

      // Act
      var guid = client.WhatIsYourToken();

      // Assert
      Assert.IsTrue(guid.ToString().Equals("3d9c5943-dcf9-41da-9acc-53f10c723a51"));

      // Always close the client.
      client.Close();
    }

    [TestMethod]
    public void FibonacciNumber()
    {
      // Arrange
      RedPillClient client = new RedPillClient();
      client.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(5);

      // Act
      var test1 = client.FibonacciNumber(-4);
      var test2 = client.FibonacciNumber(-5);
      var test3 = client.FibonacciNumber(0);
      var test4 = client.FibonacciNumber(1);
      var test5 = client.FibonacciNumber(-6);
      var test6 = client.FibonacciNumber(3);
      var test7 = client.FibonacciNumber(4);
      var test8 = client.FibonacciNumber(5);
      var test9 = client.FibonacciNumber(6);
      var test10 = client.FibonacciNumber(7);
      var test11 = client.FibonacciNumber(46);
      var test12 = client.FibonacciNumber(47);
      var test13 = client.FibonacciNumber(47);

      // Act
      try
      {
        var test14 = client.FibonacciNumber(93);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be greater than 92, since the result will cause a 64-bit integer overflow."))
      {
        // Silently catch the expected exception.
      }

      try
      {
        var test14 = client.FibonacciNumber(-93);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be less than 92, since the result will cause a 64-bit integer overflow."))
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
      

      // Always close the client.
      client.Close();
    }

    [TestMethod]
    public void ReverseWords()
    {
      // Arrange
      RedPillClient client = new RedPillClient();
      client.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(5);

      // Act
      try
      {
        var test1 = client.ReverseWords(null);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be null."))
      {
        // Silently catch the expected exception.
      }
            
      var test2 = client.ReverseWords(" ");
      var test3 = client.ReverseWords("cat");
      var test4 = client.ReverseWords("trailing space ");
      var test5 = client.ReverseWords("Bang!");
      var test6 = client.ReverseWords(string.Empty);
      var test7 = client.ReverseWords("cat and dog");
      var test8 = client.ReverseWords("two  spaces");
      var test9 = client.ReverseWords(" leading space");
      var test10 = client.ReverseWords("Capital");
      var test11 = client.ReverseWords("This is a snark: ⸮");
      var test12 = client.ReverseWords("P!u@n#c$t%u^a&t*i(o)n");
      var test13 = client.ReverseWords("detartrated kayak detartrated");
      var test14 = client.ReverseWords("¿Qué?");
      var test15 = client.ReverseWords(" S  P  A  C  E  Y ");
      var test16 = client.ReverseWords("!B!A!N!G!S!");

      // Assert
      Assert.IsTrue(test2.Equals(" "));
      Assert.IsTrue(test3.Equals("tac"));
      Assert.IsTrue(test4.Equals("gniliart ecaps "));
      Assert.IsTrue(test5.Equals("!gnaB"));
      Assert.IsTrue(test6.Equals(string.Empty));
      Assert.IsTrue(test7.Equals("tac dna god"));
      Assert.IsTrue(test8.Equals("owt  secaps"));
      Assert.IsTrue(test9.Equals(" gnidael ecaps"));
      Assert.IsTrue(test10.Equals("latipaC"));
      Assert.IsTrue(test11.Equals("sihT si a :krans ⸮"));
      Assert.IsTrue(test12.Equals("n)o(i*t&a^u%t$c#n@u!P"));
      Assert.IsTrue(test13.Equals("detartrated kayak detartrated"));
      Assert.IsTrue(test14.Equals("?éuQ¿"));
      Assert.IsTrue(test15.Equals(" S  P  A  C  E  Y "));
      Assert.IsTrue(test16.Equals("!S!G!N!A!B!"));

      // Always close the client.
      client.Close();
    }

    [TestMethod]
    public void WhatShapeIsThis()
    {
      // Arrange
      RedPillClient client = new RedPillClient();
      client.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(5);

      // Act
      var test1 = client.WhatShapeIsThis(0, 0, 0);
      var test2 = client.WhatShapeIsThis(1, 1, 2);
      var test3 = client.WhatShapeIsThis(-1, 0, 1);      
      var test4 = client.WhatShapeIsThis(-1, -1, -1);
      var test5 = client.WhatShapeIsThis(-1, 1, 1);
      var test6 = client.WhatShapeIsThis(1, -1, 1);
      var test7 = client.WhatShapeIsThis(1, 1, -1);
      var test8 = client.WhatShapeIsThis(3, 3, 5000);
      var test9 = client.WhatShapeIsThis(1, 1, 2147483647);
      var test10 = client.WhatShapeIsThis(-2147483648, -2147483648, -2147483648);

      var test11 = client.WhatShapeIsThis(1, 1, 1);
      var test12 = client.WhatShapeIsThis(2147483647, 2147483647, 2147483647);

      var test13 = client.WhatShapeIsThis(3, 3, 5);
      var test14 = client.WhatShapeIsThis(10, 10, 5);
      var test15 = client.WhatShapeIsThis(15, 1, 15);

      var test16 = client.WhatShapeIsThis(3, 4, 5);
      var test17 = client.WhatShapeIsThis(5, 3, 4);
      var test18 = client.WhatShapeIsThis(4, 5, 3);
      var test19 = client.WhatShapeIsThis(2147483647, 2147483647, 2147483647);

      // Assert
      Assert.IsTrue(test1 == TriangleType.Error);
      Assert.IsTrue(test2 == TriangleType.Error);
      Assert.IsTrue(test3 == TriangleType.Error);
      Assert.IsTrue(test4 == TriangleType.Error);
      Assert.IsTrue(test5 == TriangleType.Error);
      Assert.IsTrue(test6 == TriangleType.Error);
      Assert.IsTrue(test7 == TriangleType.Error);
      Assert.IsTrue(test8 == TriangleType.Error);
      Assert.IsTrue(test9 == TriangleType.Error);
      Assert.IsTrue(test10 == TriangleType.Error);

      Assert.IsTrue(test11 == TriangleType.Equilateral);
      Assert.IsTrue(test12 == TriangleType.Equilateral);

      Assert.IsTrue(test13 == TriangleType.Isosceles);
      Assert.IsTrue(test14 == TriangleType.Isosceles);
      Assert.IsTrue(test15 == TriangleType.Isosceles);

      Assert.IsTrue(test16 == TriangleType.Scalene);
      Assert.IsTrue(test17 == TriangleType.Scalene);
      Assert.IsTrue(test18 == TriangleType.Scalene);
      Assert.IsTrue(test19 == TriangleType.Equilateral);

      // Always close the client.
      client.Close();
    }
  }
}
