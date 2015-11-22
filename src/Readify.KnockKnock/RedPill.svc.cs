using Microsoft.ApplicationInsights;
using Readify.KnockKnock.Services;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Readify.KnockKnock
{
  /// <summary>
  /// Represent the Red Pill service.
  /// </summary>
  [ServiceBehavior(Namespace = "http://readify-knockknock.azurewebsites.net/", IncludeExceptionDetailInFaults = true)]
  public class RedPill : IRedPill
  {
    // The Readify token associated with the oleg.burov@outlook.com email.
    protected Guid token = new Guid("3d9c5943-dcf9-41da-9acc-53f10c723a51");

    protected TelemetryClient telemetry = new TelemetryClient();

    /// <summary>
    /// Whats the is your token.
    /// </summary>
    /// <returns>The Readify token.</returns>
    public Guid WhatIsYourToken()
    {
      var properties = new Dictionary<string, string> { { "Token", this.token.ToString() } };
      telemetry.TrackEvent("WhatIsYourToken", properties);

      return this.token;
    }

    /// <summary>
    /// Generate the Fibonacci Number.
    /// </summary>
    /// <param name="n">Index in the sequence.</param>
    /// <returns>The number at n position in the Fibonacci sequence.</returns>
    public long FibonacciNumber(long n)
    {
      if (n > 92)
      {
        throw new ArgumentOutOfRangeException(nameof(n), "Value cannot be greater than 92, since the result will cause a 64-bit integer overflow.");
      }

      if (n < -92)
      {
        throw new ArgumentOutOfRangeException(nameof(n), "Value cannot be less than 92, since the result will cause a 64-bit integer overflow.");
      }

      var properties = new Dictionary<string, string> { { "Argument 'n'", n.ToString() } };
      telemetry.TrackEvent("FibonacciNumber", properties);

      long result = 0;

      try
      {
        result = new FibonacciNumberService().Calculate(n);
      }
      catch(Exception exception)
      {
        telemetry.TrackException(exception);
      }

      return result;
    }

    /// <summary>
    /// Reverses the words.
    /// </summary>
    /// <param name="s">The source string.</param>
    /// <returns>The source string where words are reversed.</returns>
    public string ReverseWords(string s)
    {
      if (s == null)
      {
        throw new ArgumentNullException(nameof(s), "Value cannot be null.");
      }

      var properties = new Dictionary<string, string> { { "Argument 's'", string.Format("'{0}'", s) } };
      telemetry.TrackEvent("ReverseWords", properties);          

      string result = string.Empty;

      try
      {
        result = new StringReverseService().ReverseWords(s);
      }
      catch (Exception exception)
      {
        telemetry.TrackException(exception);
      }

      return result;
    }

    /// <summary>
    /// Classify the type of a triangle.
    /// </summary>
    /// <param name="a">Length of side 'a'.</param>
    /// <param name="b">Length of side 'b'.</param>
    /// <param name="c">Length of side 'c'.</param>
    /// <returns>The <see cref="TriangleType"/> type.</returns>
    public TriangleType WhatShapeIsThis(int a, int b, int c)
    {
      var properties = new Dictionary<string, string> { { "Argument 'a'", a.ToString() }, { "Argument 'b'", b.ToString() }, { "Argument 'c'", c.ToString() } };
      telemetry.TrackEvent("WhatShapeIsThis", properties);

      TriangleType result = TriangleType.Error;

      try
      {
        result = new ShapeService().ClassifyTriangleType(a, b, c);
      }
      catch (Exception exception)
      {
        telemetry.TrackException(exception);
      }

      return result;
    }
  }
}