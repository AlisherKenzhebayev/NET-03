// <copyright file="DataLoader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U11_Linq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using U10_GenericsCollections.T_07;

    public class DataLoader
    {
        private SimpleBst<StudentInfo> myBST;

        // File structure should be like -> st.name, st.exam, st.date, st.score
        public void LoadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileReader = new BinaryReader(File.Open(filePath, FileMode.Open));
                while (fileReader.BaseStream.Position != fileReader.BaseStream.Length)
                {
                    var newBST = new StudentInfo
                    {
                        StudentName = fileReader.ReadString(),
                        TestName = fileReader.ReadString(),
                        TestDate = DateTime.Parse(fileReader.ReadString()),
                        TestAssessment = double.Parse(fileReader.ReadString()),
                    };

                    this.myBST.Add(newBST);
                }
            }
        }

        public IEnumerable<StudentInfo> RequestData(Func<StudentInfo, bool> predicate = null)
        {
            predicate = predicate ?? (t => true);
            var retVal = this.myBST.Where(predicate);
            return retVal;
        }
    }
}
