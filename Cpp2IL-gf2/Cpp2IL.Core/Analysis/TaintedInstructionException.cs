﻿using System;

namespace Cpp2IL.Core.Analysis
{
    public class TaintedInstructionException : Exception
    {
        public readonly string? ActualMessage; 
        public TaintedInstructionException()
        {
            ActualMessage = null;
        }

        public TaintedInstructionException(string? message) : base(message)
        {
            ActualMessage = message;
        }
    }
}