﻿using System;
namespace ChildrensGame.Core
{
  public class Logger
  {
    private static Logger instance;

    private Logger() { }

    public static Logger GetInstance()
    {
      if (instance == null)
      {
        instance = new Logger();
      }
      return instance;
    }

    private const string FORMAT = @"{0} {1}({2}): {3}";

    public void Write(string entity, string message, string type = "info")
    {
      Console.WriteLine(FORMAT, String.Format("{0:HH:mm:ss}", DateTime.Now), entity, type, message);
    }
  }
}
