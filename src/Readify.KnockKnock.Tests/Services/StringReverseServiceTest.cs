using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readify.KnockKnock.Services;
using System;

namespace Readify.KnockKnock.Tests.Services
{
  [TestClass]
  public class StringReverseServiceTest
  {
    [TestMethod]
    public void ReverseWords()
    {
      // Arrange
      var service = new StringReverseService();

      // Act
      string test1 = null;
      try
      {
        test1 = service.ReverseWords(null);
      }
      catch (Exception ex) when (ex.Message.StartsWith("Value cannot be null."))
      {
        // Silently catch the expected exception.
      }

      var test2 = service.ReverseWords(" ");
      var test3 = service.ReverseWords("cat");
      var test4 = service.ReverseWords("trailing space ");
      var test5 = service.ReverseWords("Bang!");
      var test6 = service.ReverseWords(string.Empty);
      var test7 = service.ReverseWords("cat and dog");
      var test8 = service.ReverseWords("two  spaces");
      var test9 = service.ReverseWords(" leading space");
      var test10 = service.ReverseWords("Capital");
      var test11 = service.ReverseWords("This is a snark: ⸮");
      var test12 = service.ReverseWords("P!u@n#c$t%u^a&t*i(o)n");
      var test13 = service.ReverseWords("detartrated kayak detartrated");
      var test14 = service.ReverseWords("¿Qué?");
      var test15 = service.ReverseWords(" S  P  A  C  E  Y ");
      var test16 = service.ReverseWords("!B!A!N!G!S!");

      // Assert
      Assert.IsTrue(test1 == null);
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
    }
  }
}