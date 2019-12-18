using System;
using System.Collections.Generic;
using Instruction = IKVM.Internal.ClassFile.Method.Instruction;

//Do you believe in high-quality code by Female/LGBT programmers? Leave u/jessielesbian a PM on Reddit!

namespace jessielesbian.IKVM
{
    public static class Helper
    {
        public static int optpasses = 0;
        public static bool enableJITPreOptimization = false;
        internal static bool experimentalOptimizations
        {
            get
            {
                return (optpasses > 0);
            }
        }
        private static Instruction GetInstuction(NormalizedByteCode bc)
        {
            Instruction instruction = new Instruction();
            instruction.PatchOpCode(bc);
            return instruction;
        }
        private static Instruction GetInstuction(NormalizedByteCode bc, int arg1)
        {
            Instruction instruction = new Instruction();
            instruction.PatchOpCode(bc, arg1);
            return instruction;
        }
        private static Instruction GetInstuction(NormalizedByteCode bc, int arg1, short arg2)
        {
            Instruction instruction = new Instruction();
            instruction.PatchOpCode(bc, arg1, arg2);
            return instruction;
        }
        internal static Instruction[] Optimize(Instruction[] instructions)
        {
            //Jessie Lesbian's IKVM.NET JIT Optimizer
            //The lesbian had waviered all her rights over this algorigmth.

            instructions = (Instruction[])instructions.Clone();
            int optimizations = 1279738452;
            List<int> brtargets = new List<int>(instructions.Length);
            for (int i = 1; i < instructions.Length; i++)
            {
                switch (instructions[i].NormalizedOpCode)
                {
                    case NormalizedByteCode.__goto:
                    case NormalizedByteCode.__goto_finally:
                    case NormalizedByteCode.__ifeq:
                    case NormalizedByteCode.__ifge:
                    case NormalizedByteCode.__ifgt:
                    case NormalizedByteCode.__ifle:
                    case NormalizedByteCode.__iflt:
                    case NormalizedByteCode.__ifne:
                    case NormalizedByteCode.__ifnonnull:
                    case NormalizedByteCode.__ifnull:
                    case NormalizedByteCode.__if_acmpeq:
                    case NormalizedByteCode.__if_acmpne:
                    case NormalizedByteCode.__if_icmpeq:
                    case NormalizedByteCode.__if_icmpge:
                    case NormalizedByteCode.__if_icmpgt:
                    case NormalizedByteCode.__if_icmple:
                    case NormalizedByteCode.__if_icmplt:
                    case NormalizedByteCode.__if_icmpne:
                        brtargets.Add(instructions[i].TargetIndex);
                        break;
                    default:
                        continue;
                }
            }
            while (optimizations != 0)
            {
                optimizations = 0;
                for (int i = 1; i < instructions.Length; i++)
                {
                    Instruction current = instructions[i];
                    Instruction prev = instructions[i - 1];
                    if (brtargets.Contains(i))
                    {
                        continue;
                    }
                    if (brtargets.Contains(i - 1))
                    {
                        continue;
                    }
                    if (brtargets.Contains(i + 1))
                    {
                        continue;
                    }
                    //peephole optimization: removal of unused arithmethc operations
                    if (current.NormalizedOpCode == NormalizedByteCode.__pop)
                    {
                        switch (prev.NormalizedOpCode)
                        {
                            case NormalizedByteCode.__iadd:
                            case NormalizedByteCode.__isub:
                            case NormalizedByteCode.__imul:
                            case NormalizedByteCode.__idiv:
                            case NormalizedByteCode.__irem:
                            case NormalizedByteCode.__ishl:
                            case NormalizedByteCode.__ishr:
                            case NormalizedByteCode.__iushr:
                            case NormalizedByteCode.__iand:
                            case NormalizedByteCode.__ior:
                            case NormalizedByteCode.__ixor:
                            case NormalizedByteCode.__fadd:
                            case NormalizedByteCode.__fsub:
                            case NormalizedByteCode.__fmul:
                            case NormalizedByteCode.__fdiv:
                            case NormalizedByteCode.__frem:
                            case NormalizedByteCode.__fcmpl:
                            case NormalizedByteCode.__fcmpg:
                            case NormalizedByteCode.__ladd:
                            case NormalizedByteCode.__lsub:
                            case NormalizedByteCode.__lmul:
                            case NormalizedByteCode.__ldiv:
                            case NormalizedByteCode.__lrem:
                            case NormalizedByteCode.__lshl:
                            case NormalizedByteCode.__lshr:
                            case NormalizedByteCode.__lushr:
                            case NormalizedByteCode.__land:
                            case NormalizedByteCode.__lor:
                            case NormalizedByteCode.__lxor:
                            case NormalizedByteCode.__lcmp:
                            case NormalizedByteCode.__dadd:
                            case NormalizedByteCode.__dsub:
                            case NormalizedByteCode.__dmul:
                            case NormalizedByteCode.__ddiv:
                            case NormalizedByteCode.__drem:
                            case NormalizedByteCode.__dcmpl:
                            case NormalizedByteCode.__dcmpg:
                                prev = GetInstuction(NormalizedByteCode.__pop);
                                optimizations = optimizations + 1;
                                break;
                            case NormalizedByteCode.__dup:
                                prev = GetInstuction(NormalizedByteCode.__nop);
                                current = GetInstuction(NormalizedByteCode.__nop);
                                optimizations = optimizations + 1;
                                break;
                            case NormalizedByteCode.__aload:
                                prev = GetInstuction(NormalizedByteCode.__nop);
                                current = GetInstuction(NormalizedByteCode.__nop);
                                break;
                            case NormalizedByteCode.__aaload:
                                prev = GetInstuction(NormalizedByteCode.__pop);
                                current = GetInstuction(NormalizedByteCode.__pop);
                                break;
                            default:
                                break;
                        }
                    }
                    //peephole optimization: removal of self-cancelling operations
                    if (current.NormalizedOpCode == prev.NormalizedOpCode)
                    {
                        switch (instructions[i].NormalizedOpCode)
                        {
                            case NormalizedByteCode.__ineg:
                            case NormalizedByteCode.__lneg:
                            case NormalizedByteCode.__fneg:
                            case NormalizedByteCode.__dneg:
                            case NormalizedByteCode.__swap:
                                current = GetInstuction(NormalizedByteCode.__nop);
                                prev = GetInstuction(NormalizedByteCode.__nop);
                                optimizations = optimizations + 1;
                                break;
                            default:
                                break;
                        }
                    }
                    //peephole optimization: optimize addition and subtraction
                    if((prev.NormalizedOpCode == NormalizedByteCode.__ineg))
                    {
                        if(current.NormalizedOpCode == NormalizedByteCode.__iadd)
                        {
                            current = GetInstuction(NormalizedByteCode.__isub);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                        if (current.NormalizedOpCode == NormalizedByteCode.__isub)
                        {
                            current = GetInstuction(NormalizedByteCode.__iadd);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                    }
                    if (prev.NormalizedOpCode == NormalizedByteCode.__lneg)
                    {
                        if (current.NormalizedOpCode == NormalizedByteCode.__ladd)
                        {
                            current = GetInstuction(NormalizedByteCode.__lsub);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                        if (current.NormalizedOpCode == NormalizedByteCode.__lsub)
                        {
                            current = GetInstuction(NormalizedByteCode.__ladd);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                    }
                    if (prev.NormalizedOpCode == NormalizedByteCode.__fneg)
                    {
                        if (current.NormalizedOpCode == NormalizedByteCode.__fadd)
                        {
                            current = GetInstuction(NormalizedByteCode.__fsub);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                        if (current.NormalizedOpCode == NormalizedByteCode.__fsub)
                        {
                            current = GetInstuction(NormalizedByteCode.__fadd);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                    }
                    if (prev.NormalizedOpCode == NormalizedByteCode.__dneg)
                    {
                        if (current.NormalizedOpCode == NormalizedByteCode.__dadd)
                        {
                            current = GetInstuction(NormalizedByteCode.__dsub);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                        if (current.NormalizedOpCode == NormalizedByteCode.__dsub)
                        {
                            current = GetInstuction(NormalizedByteCode.__dadd);
                            prev = GetInstuction(NormalizedByteCode.__nop);
                            optimizations = optimizations + 1;
                        }
                    }
                    //peephole optimization: remove unnecessary swaps
                    if(prev.NormalizedOpCode == NormalizedByteCode.__swap)
                    {
                        switch (current.NormalizedOpCode)
                        {
                            case NormalizedByteCode.__iadd:
                            case NormalizedByteCode.__ladd:
                            case NormalizedByteCode.__fadd:
                            case NormalizedByteCode.__dadd:
                            case NormalizedByteCode.__imul:
                            case NormalizedByteCode.__lmul:
                            case NormalizedByteCode.__fmul:
                            case NormalizedByteCode.__dmul:
                                prev = GetInstuction(NormalizedByteCode.__nop);
                                optimizations = optimizations + 1;
                                break;
                            default:
                                break;
                        }
                    }
                    if (current.NormalizedOpCode == NormalizedByteCode.__swap && prev.NormalizedOpCode == NormalizedByteCode.__dup)
                    {
                        current = GetInstuction(NormalizedByteCode.__nop);
                        optimizations = optimizations + 1;
                    }
                    //peephole optimization: local variable acession optimization
                    if (current.NormalizedOpCode == prev.NormalizedOpCode && current.NormalizedOpCode == NormalizedByteCode.__aload && current.NormalizedArg1 == prev.NormalizedArg1)
                    {
                        current = GetInstuction(NormalizedByteCode.__dup);
                        optimizations = optimizations + 1;
                    }
                    if (current.NormalizedOpCode == prev.NormalizedOpCode && current.NormalizedOpCode == NormalizedByteCode.__astore && current.NormalizedArg1 == prev.NormalizedArg1)
                    {
                        prev = GetInstuction(NormalizedByteCode.__pop);
                        optimizations = optimizations + 1;
                    }
                    //peephole optimization: return optimization
                    if (current.NormalizedOpCode == NormalizedByteCode.__return)
                    {
                        switch (prev.NormalizedOpCode)
                        {
                            case NormalizedByteCode.__dup:
                                prev = GetInstuction(NormalizedByteCode.__nop);
                                optimizations = optimizations + 1;
                                break;
                            case NormalizedByteCode.__swap:
                                prev = GetInstuction(NormalizedByteCode.__pop);
                                optimizations = optimizations + 1;
                                break;
                            default:
                                break;
                        }
                    }
                    //sorry, I can't implement branch optimizations.
                    instructions[i] = current;
                    instructions[i - 1] = prev;
                }
            }
            return instructions;
        }
    }
}