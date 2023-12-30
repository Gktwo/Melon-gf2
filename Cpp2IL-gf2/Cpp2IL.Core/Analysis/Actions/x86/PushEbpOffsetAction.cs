﻿using Cpp2IL.Core.Analysis.Actions.Base;
using Cpp2IL.Core.Analysis.ResultModels;
using Cpp2IL.Core.Utils;
using Mono.Cecil.Cil;
using Instruction = Iced.Intel.Instruction;

namespace Cpp2IL.Core.Analysis.Actions.x86
{
    public class PushEbpOffsetAction : BaseAction<Instruction>
    {
        private LocalDefinition localBeingPushed;
        public PushEbpOffsetAction(MethodAnalysis<Instruction> context, Instruction instruction) : base(context, instruction)
        {
            localBeingPushed = StackPointerUtils.GetLocalReferencedByEBPRead(context, instruction);
            
            if(localBeingPushed != null)
                context.Stack.Push(localBeingPushed);
        }

        public override Mono.Cecil.Cil.Instruction[] ToILInstructions(MethodAnalysis<Instruction> context, ILProcessor processor)
        {
            throw new System.NotImplementedException();
        }

        public override string? ToPsuedoCode()
        {
            throw new System.NotImplementedException();
        }

        public override string ToTextSummary()
        {
            return $"Pushes {localBeingPushed} to the stack";
        }
    }
}