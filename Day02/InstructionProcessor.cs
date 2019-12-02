using CodeKata.Day02.InstructionRunners;

namespace CodeKata.Day02
{
    public class InstructionProcessor
    {
        public int[] Process(int[] instruction, int instructionPointer = 0)
        {
            var instructionRunner = RunnerFactory.Create(instruction, instructionPointer);
            if (instructionRunner == null)
                return instruction;

            var instructionResult = instructionRunner.Run();
            return Process(instructionResult, ++instructionPointer);
        }
    }
}
