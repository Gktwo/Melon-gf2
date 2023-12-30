﻿using Cpp2IL.Core.Analysis.Actions.Base;
using Cpp2IL.Core.Analysis.ResultModels;
using Mono.Cecil.Cil;
using Instruction = Iced.Intel.Instruction;

namespace Cpp2IL.Core.Analysis.Actions.x86.Important
{
    public class GoToMarkerAction : BaseAction<Instruction>
    {
        private readonly ulong _dest;

        public GoToMarkerAction(MethodAnalysis<Instruction> context, Instruction instruction, ulong dest) : base(context, instruction)
        {
            _dest = dest;
            context.RegisterGotoDestination(instruction.IP, _dest);
        }

        public override Mono.Cecil.Cil.Instruction[] ToILInstructions(MethodAnalysis<Instruction> context, ILProcessor processor)
        {
            return new Mono.Cecil.Cil.Instruction[0];
        }

        public override string? ToPsuedoCode()
        {
            return $"goto INSN_{_dest:X}\n";
        }

        public override string ToTextSummary()
        {
            return "";
        }

        public override bool IsImportant()
        {
            return true;
        }
    }
}