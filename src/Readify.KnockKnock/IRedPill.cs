using Readify.KnockKnock.Services;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Readify.KnockKnock
{
  /// <summary>
  /// Represents the Red Pill service contract.
  /// </summary>
  [ServiceContract(Namespace = "http://readify-knockknock.azurewebsites.net/", Name = "IRedPill")]
  public interface IRedPill
  {
    [OperationContract]
    Guid WhatIsYourToken();

    [OperationContract]
    long FibonacciNumber(long n);

    [OperationContract]
    string ReverseWords(string s);

    [OperationContract]
    TriangleType WhatShapeIsThis(int a, int b, int c);
  }

  [DataContract]
  public enum TriangleType
  {
    [EnumMember]
    Error,
    [EnumMember]
    Equilateral,
    [EnumMember]
    Isosceles,
    [EnumMember]
    Scalene
  }
}
