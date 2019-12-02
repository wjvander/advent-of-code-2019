using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CodeKata.Day02
{
    public class AdventOfCodeDay02
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AdventOfCodeDay02(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        [InlineData(new[] {2, 3, 0, 3, 99}, new[] {2, 3, 0, 6, 99})]
        [InlineData(new[] {2, 4, 4, 5, 99, 0}, new[] {2, 4, 4, 5, 99, 9801})]
        [InlineData(new[] {1, 1, 1, 4, 99, 5, 6, 0, 99}, new[] {30, 1, 1, 4, 2, 5, 6, 0, 99})]
        [InlineData(
            new[]
            {
                1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 19, 9, 23, 1, 23, 9, 27, 1, 10, 27, 31, 1, 13, 31, 35, 1, 35, 10, 39, 2, 39, 9, 43, 1, 43, 13, 47, 1, 5, 47, 51, 1, 6,
                51, 55, 1, 13, 55, 59, 1, 59, 6, 63, 1, 63, 10, 67, 2, 67, 6, 71, 1, 71, 5, 75, 2, 75, 10, 79, 1, 79, 6, 83, 1, 83, 5, 87, 1, 87, 6, 91, 1, 91, 13, 95, 1, 95, 6, 99, 2, 99, 10, 103, 1,
                103, 6, 107, 2, 6, 107, 111, 1, 13, 111, 115, 2, 115, 10, 119, 1, 119, 5, 123, 2, 10, 123, 127, 2, 127, 9, 131, 1, 5, 131, 135, 2, 10, 135, 139, 2, 139, 9, 143, 1, 143, 2, 147, 1, 5,
                147, 0, 99, 2, 0, 14, 0
            }, new[]
            {
                5534943, 12, 2, 2, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 24, 1, 19, 9, 27, 1, 23, 9, 30, 1, 10, 27, 34, 1, 13, 31, 39, 1, 35, 10, 43, 2, 39, 9, 129, 1, 43, 13, 134, 1, 5, 47,
                135, 1, 6, 51, 137, 1, 13, 55, 142, 1, 59, 6, 144, 1, 63, 10, 148, 2, 67, 6, 296, 1, 71, 5, 297, 2, 75, 10, 1188, 1, 79, 6, 1190, 1, 83, 5, 1191, 1, 87, 6, 1193, 1, 91, 13, 1198, 1,
                95, 6, 1200, 2, 99, 10, 4800, 1, 103, 6, 4802, 2, 6, 107, 9604, 1, 13, 111, 9609, 2, 115, 10, 38436, 1, 119, 5, 38437, 2, 10, 123, 153748, 2, 127, 9, 461244, 1, 5, 131, 461245, 2, 10,
                135, 1844980, 2, 139, 9, 5534940, 1, 143, 2, 5534942, 1, 5, 147, 0, 99, 2, 0, 14, 0
            })]
        public void Run_GivenInstruction_ReturnsResult(int[] instruction, int[] expectedOutput)
        {
            var intOpRunner = new InstructionProcessor();
            var result = intOpRunner.Process(instruction);
            result.Should().Equal(expectedOutput);
        }

        [Fact]
        public void GivenResult_Should_CalculateInstruction()
        {
            var instruction = new[]
            {
                1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 19, 9, 23, 1, 23, 9, 27, 1, 10, 27, 31, 1, 13, 31, 35, 1, 35, 10, 39, 2, 39, 9, 43, 1, 43, 13, 47, 1, 5, 47, 51, 1, 6,
                51, 55, 1, 13, 55, 59, 1, 59, 6, 63, 1, 63, 10, 67, 2, 67, 6, 71, 1, 71, 5, 75, 2, 75, 10, 79, 1, 79, 6, 83, 1, 83, 5, 87, 1, 87, 6, 91, 1, 91, 13, 95, 1, 95, 6, 99, 2, 99, 10, 103, 1,
                103, 6, 107, 2, 6, 107, 111, 1, 13, 111, 115, 2, 115, 10, 119, 1, 119, 5, 123, 2, 10, 123, 127, 2, 127, 9, 131, 1, 5, 131, 135, 2, 10, 135, 139, 2, 139, 9, 143, 1, 143, 2, 147, 1, 5,
                147, 0, 99, 2, 0, 14, 0
            };

            var nouns = Enumerable.Range(0, 99);
            var verbs = Enumerable.Range(0, 99);

            foreach (var noun in nouns)
            {
                foreach (var verb in verbs)
                {
                    var iterationInstruction = new int[instruction.Length];
                    instruction.CopyTo(iterationInstruction, 0);
                    iterationInstruction[1] = noun;
                    iterationInstruction[2] = verb;

                    var instructionRunner = new InstructionProcessor();
                    var output = instructionRunner.Process(iterationInstruction);
                    if (output[0] == 19690720)
                    {
                        _testOutputHelper.WriteLine($"Result: {string.Join(",", iterationInstruction)}");
                        _testOutputHelper.WriteLine($"Verb: {verb}");
                        _testOutputHelper.WriteLine($"Noun: {noun}");
                        _testOutputHelper.WriteLine($"Answer: {100 * noun + verb}");
                    }
                }
            }
        }
    }
}
