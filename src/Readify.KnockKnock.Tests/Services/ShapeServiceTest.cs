using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readify.KnockKnock.Services;

namespace Readify.KnockKnock.Tests.Services
{
  [TestClass]
  public class ShapeServiceTest
  {
    [TestMethod]
    public void WhatShapeIsThis()
    {
      // Arrange
      var service = new ShapeService();

      // Act
      var test1 = service.ClassifyTriangleType(0, 0, 0);
      var test2 = service.ClassifyTriangleType(1, 1, 2);
      var test3 = service.ClassifyTriangleType(-1, 0, 1);
      var test4 = service.ClassifyTriangleType(-1, -1, -1);
      var test5 = service.ClassifyTriangleType(-1, 1, 1);
      var test6 = service.ClassifyTriangleType(1, -1, 1);
      var test7 = service.ClassifyTriangleType(1, 1, -1);
      var test8 = service.ClassifyTriangleType(3, 3, 5000);
      var test9 = service.ClassifyTriangleType(1, 1, 2147483647);
      var test10 = service.ClassifyTriangleType(-2147483648, -2147483648, -2147483648);

      var test11 = service.ClassifyTriangleType(1, 1, 1);
      var test12 = service.ClassifyTriangleType(2147483647, 2147483647, 2147483647);

      var test13 = service.ClassifyTriangleType(3, 3, 5);
      var test14 = service.ClassifyTriangleType(10, 10, 5);
      var test15 = service.ClassifyTriangleType(15, 1, 15);

      var test16 = service.ClassifyTriangleType(3, 4, 5);
      var test17 = service.ClassifyTriangleType(5, 3, 4);
      var test18 = service.ClassifyTriangleType(4, 5, 3);
      var test19 = service.ClassifyTriangleType(2147483647, 2147483647, 2147483647);

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
    }      
  }
}