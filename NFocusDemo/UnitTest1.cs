namespace NFocusDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Hi");
            Assert.Pass();
        }
    }
}