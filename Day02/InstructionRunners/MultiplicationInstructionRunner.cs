namespace CodeKata.Day02.InstructionRunners
{
    public class MultiplicationInstructionRunner : InstructionRunner
    {
        private readonly int[] _instruction;
        private readonly int _opCodeAddress;

        public MultiplicationInstructionRunner(int[] instruction, int opCodeAddress)
        {
            _instruction = instruction;
            _opCodeAddress = opCodeAddress;
        }

        public override int[] Run()
        {
            var instructionParameterAddressToRead1 = _instruction[_opCodeAddress + 1];
            var instructionParameterAddressToRead2 = _instruction[_opCodeAddress + 2];
            var instructionParameterAddressToStoreValue = _instruction[_opCodeAddress + 3];

            var valueAtAddress1 = _instruction[instructionParameterAddressToRead1];
            var valueAtAddress2 = _instruction[instructionParameterAddressToRead2];

            _instruction[instructionParameterAddressToStoreValue] = valueAtAddress1 * valueAtAddress2;
            return _instruction;
        }
    }
}