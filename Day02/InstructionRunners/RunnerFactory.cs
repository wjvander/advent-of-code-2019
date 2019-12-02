namespace CodeKata.Day02.InstructionRunners
{
    public static class RunnerFactory
    {
        public static InstructionRunner Create(int[] instruction, int instructionPointer)
        {
            const int numberOfValuesInInstruction = 4;
            var opCodeAddress = instructionPointer * numberOfValuesInInstruction;
            var opCode = instruction[opCodeAddress];

            switch (opCode)
            {
                case 1:
                    return new AdditionInstructionRunner(instruction, opCodeAddress);
                case 2:
                    return new MultiplicationInstructionRunner(instruction, opCodeAddress);
                default:
                    return null;
            }
        }
    }
}
