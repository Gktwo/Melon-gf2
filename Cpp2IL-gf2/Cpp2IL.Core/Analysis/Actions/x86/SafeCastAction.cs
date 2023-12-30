﻿using Cpp2IL.Core.Analysis.Actions.Base;
using Cpp2IL.Core.Analysis.ResultModels;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Instruction = Iced.Intel.Instruction;

namespace Cpp2IL.Core.Analysis.Actions.x86
{
    public class SafeCastAction : BaseAction<Instruction>
    {
        private LocalDefinition? castSource;
        private TypeReference? destinationType;
        private ConstantDefinition? _castResult;

        public SafeCastAction(MethodAnalysis<Instruction> context, Instruction instruction) : base(context, instruction)
        {
            var inReg = context.GetOperandInRegister("rcx");
            castSource = inReg is LocalDefinition local ? local : inReg is ConstantDefinition cons && cons.Value is NewSafeCastResult<Instruction> result ? result.original : null;
            var destOp = context.GetOperandInRegister("rdx");
            if (destOp is ConstantDefinition cons2 && cons2.Type == typeof(TypeReference))
                destinationType = (TypeReference) cons2.Value;

            if (destinationType == null || castSource == null) return;

            _castResult = context.MakeConstant(typeof(NewSafeCastResult<Instruction>), new NewSafeCastResult<Instruction>
            {
                castTo = destinationType,
                original = castSource
            }, reg: "rax");
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
            return $"Attempts to safely cast {castSource} to managed type {destinationType?.FullName} and stores the cast result in rax as {_castResult?.Name}";
        }
    }
}