namespace U13_StreamsIO
{
    using System;
    using System.IO;
    using System.Text;

    public static class StreamsExtension
    {
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            var retVal = 0;
            InputValidation(sourcePath, destinationPath);

            using var fileStreamIn = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using var fileStreamOut = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

            var bufSize = 10;
            byte[] bufferBytes = new byte[bufSize];

            var offset = 0;

            int bytesRead;
            
            while ((bytesRead = fileStreamIn.Read(bufferBytes, offset, bufSize)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    fileStreamOut.WriteByte(bufferBytes[i]);
                    retVal++;
                }

                offset += bytesRead;
            }

            return retVal;
        }

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var streamIn = new StreamReader(sourcePath);

            var stringContent = streamIn.ReadToEnd();

            var bytes = Encoding.Default.GetBytes(stringContent);

            using var memoryStream = new MemoryStream();
            foreach (var b in bytes)
            {
                memoryStream.WriteByte(b);
            }
            
            memoryStream.Seek(0, SeekOrigin.Begin);
            
            bytes = new byte[memoryStream.Length];
            var readLength = memoryStream.Read(bytes);

            var charArray = Encoding.Default.GetChars(bytes, 0, bytes.Length);

            using var streamWriter = new StreamWriter(destinationPath);
            streamWriter.Write(charArray);
            
            return readLength;
        }

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var streamIn = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using var streamOut = new FileStream(destinationPath, FileMode.Open, FileAccess.Write);
            
            var bytes = new byte[streamIn.Length];

            var readBytes = streamIn.Read(bytes, 0, (int)streamIn.Length);
            streamOut.Write(bytes, 0, readBytes);

            return readBytes;
        }
        
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var streamIn = new StreamReader(sourcePath);

            var stringContent = streamIn.ReadToEnd();

            var bytes = Encoding.Default.GetBytes(stringContent);

            using var memoryStream = new MemoryStream();
            memoryStream.Write(bytes, 0, bytes.Length);

            memoryStream.Seek(0, SeekOrigin.Begin);
            
            bytes = new byte[1000];
            var readLength = 0;

            int add;
            while ((add = memoryStream.Read(bytes, readLength, bytes.Length)) > 0)
            {
                var charArray = Encoding.Default.GetChars(bytes, 0, bytes.Length);

                using var streamWriter = new StreamWriter(destinationPath);
                streamWriter.Write(charArray);

                readLength += add;
            }
            
            return readLength;
        }

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fileStreamIn = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using var bufferedStreamIn = new BufferedStream(fileStreamIn);
            using var fileStreamOut = new FileStream(destinationPath, FileMode.Open, FileAccess.Write);
            using var bufferedStreamOut = new BufferedStream(fileStreamOut);

            var bytes = new byte[1000];
            var readLength = 0;

            int add;
            while ((add = bufferedStreamIn.Read(bytes, readLength, bytes.Length)) > 0)
            {
                bufferedStreamOut.Write(bytes);
                readLength += add;
            }

            return readLength;
        }
        
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fileStreamIn = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using var fileStreamOut = new FileStream(destinationPath, FileMode.Open, FileAccess.Write);

            using var streamReader = new StreamReader(fileStreamIn);
            using var streamWriter = new StreamWriter(fileStreamOut);

            var retVal = 0;
            string readLine;
            while ((readLine = streamReader.ReadLine()) != null)
            {
                streamWriter.WriteLine(readLine);
                retVal++;
            }

            return retVal;
        }

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            var retVal = true;
            
            InputValidation(sourcePath, destinationPath);
            using var binaryReaderIn = new BinaryReader(new FileStream(sourcePath, FileMode.Open), Encoding.Default);
            using var binaryReaderOut = new BinaryReader(new FileStream(destinationPath, FileMode.Open), Encoding.Default);

            byte readIn;
            byte readOut;

            do
            {
                try
                {
                    readIn = binaryReaderIn.ReadByte();
                    readOut = binaryReaderOut.ReadByte();
                    if (readIn != readOut)
                    {
                        retVal = false;
                        break;
                    }
                }
                catch(EndOfStreamException e)
                {
                    break;
                }
            } while (readOut == readIn);
        
            return retVal;
        }

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            CheckSource(sourcePath);
            CheckCreateDestination(destinationPath);
        }
        
        /// <summary>
        /// Checks sourcePath, throws exceptions if something's wrong.
        /// </summary>
        private static void CheckSource(string sourcePath)
        {
            var dir = Path.GetDirectoryName(sourcePath);
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException($"{dir} not found");
            }
            
            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"{sourcePath} not found");
            }
        }
        
        /// <summary>
        /// Checks destinationPath and creates if not exists.
        /// </summary>
        private static void CheckCreateDestination(string destinationPath)
        {
            var dir = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            
            if (!File.Exists(destinationPath))
            {
                File.Create(destinationPath);
            }
        }
    }
}