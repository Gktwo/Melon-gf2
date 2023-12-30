﻿using Cpp2IL.Core.Analysis.Actions.Base;
using Cpp2IL.Core.Analysis.ResultModels;
using Mono.Cecil.Cil;
using Instruction = Iced.Intel.Instruction;

namespace Cpp2IL.Core.Analysis.Actions.x86
{
    public class StackToRegCopyAction : BaseAction<Instruction>
    {
        private IAnalysedOperand beingMoved;
        private ulong stackOffset;
        private string destReg;
        
        public StackToRegCopyAction(MethodAnalysis<Instruction> context, Instruction instruction) : base(context, instruction)
        {
        }

        public override Mono.Cecil.Cil.Instruction[] ToILInstructions(MethodAnalysis<Instruction> context, ILProcessor processor)
        {
            //No-op
            return new Mono.Cecil.Cil.Instruction[0];
        }

        public override string? ToPsuedoCode()
        {
            return null;
        }

        public override string ToTextSummary()
        {
            return $"Copies {beingMoved} from stack offset 0x{stackOffset:X} into {destReg}";
        }
    }
}