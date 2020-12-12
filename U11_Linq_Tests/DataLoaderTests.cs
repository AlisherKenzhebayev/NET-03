namespace U11_Linq_Tests
{
    using NUnit.Framework;
    using U11_Linq;
    using System.IO;
    using System.Collections.Generic;

    public class DataLoaderTests
    {
        private string fileName;
        private DataLoader dataLoader;
        private BinaryWriter binaryWriter;
        private List<string> arrayNames;
        
        [SetUp]
        public void Setup()
        {
            fileName = "Test.txt";
            arrayNames = new List<string>();
            arrayNames.Add("Bob");
            arrayNames.Add("Lena");
        }

        [Test]
        public void Test1()
        {
            // Create file and write into file
            dataLoader = new DataLoader();
            binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));

            binaryWriter.Write(arrayNames[0]);
            binaryWriter.Write("Math");
            binaryWriter.Write("12 Feb 2020");
            binaryWriter.Write("4.5");

            binaryWriter.Write(arrayNames[1]);
            binaryWriter.Write("Chem");
            binaryWriter.Write("13.08.2020");
            binaryWriter.Write("3.5");
            binaryWriter.Close();
            // Use DataLoader to load the created file
            dataLoader.LoadFile(fileName);

            // Test on Linq completion
            var ret = dataLoader.RequestData();

            var counter = 0;
            foreach (var item in ret)
            {
                Assert.AreEqual(arrayNames[counter], item.StudentName);
                counter++;
            }
        }
    }
}