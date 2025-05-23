using Primenumbers;

namespace PrimenumbersTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void IsPrimenumber_InputIs2_ReturnsTrue()
        {
            // Arrange
            int number = 2;

            // Act
            bool result = Program.IsPrimenumber($"{number}");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(11)]
        [DataRow(13)]
        [DataRow(17)]
        [DataRow(19)]
        [DataRow(23)]
        [DataRow(97)]
        public void IsPrimenumber_InputIsPrime_ReturnsTrue(int number)
            => Assert.IsTrue(Program.IsPrimenumber($"{number}"));

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(100)]
        [DataRow(-7)]
        public void IsPrimenumber_InputIsNotPrime_ReturnsFalse(int number)
            => Assert.IsFalse(Program.IsPrimenumber($"{number}"));

        [TestMethod]
        public void IsPrimenumber_Null_ThrowsArgumentNullException()
            => Assert.ThrowsException<ArgumentNullException>(() => Program.IsPrimenumber(null));

        [TestMethod]
        public void IsPrimenumber_Negative_ThrowsArgumentException()
            => Assert.ThrowsException<ArgumentException>(() => Program.IsPrimenumber("-1"));

        [TestMethod]
        public void IsPrimenumber_String_ThrowsFormatException()
            => Assert.ThrowsException<FormatException>(() => Program.IsPrimenumber("Hello World"));

        [TestMethod]
        public void IsPrimenumber_String_ThrowsOverflowException()
            => Assert.ThrowsException<OverflowException>(() => Program.IsPrimenumber(long.MaxValue.ToString()));
    }
}