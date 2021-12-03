﻿using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Commands
{
    public class BeepCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Beep {args[0]}";
        }
    }
}
