﻿using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Cpp2IL.Core.Analysis.ResultModels
{
    public class ComparisonDirectPropertyAccess : IComparisonArgument
    {
        public LocalDefinition localAccessedOn;
        public PropertyDefinition propertyAccessed;

        public override string ToString()
        {
            return $"{{Property {propertyAccessed} on {localAccessedOn}}}";
        }
        
        public string GetPseudocodeRepresentation()
        {
            return $"{localAccessedOn.Name}.{propertyAccessed.Name}";
        }

        public Instruction[] GetILToLoad<TAnalysis>(MethodAnalysis<TAnalysis> context, ILProcessor processor)
        {
            var ret = new List<Instruction>();
            
            ret.AddRange(localAccessedOn.GetILToLoad(context, processor));
            ret.Add(processor.Create(OpCodes.Call, processor.ImportReference(propertyAccessed.GetMethod)));

            return ret.ToArray();
        }
    }
}