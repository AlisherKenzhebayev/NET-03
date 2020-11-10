// <copyright file="StudentInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U11_Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class StudentInfo : IComparer, IComparable<StudentInfo>
    {
        public StudentInfo()
        {
            this.Comparable = null;
        }

        public StudentInfo(string studentName, string testName, DateTime testDate, double testAssessment, IComparer<StudentInfo> comparable = null)
        {
            this.StudentName = studentName;
            this.TestName = testName;
            this.TestDate = testDate;
            this.TestAssessment = testAssessment;
            this.Comparable = comparable;
        }

        public string StudentName { get; set; }

        public string TestName { get; set; }

        public DateTime TestDate { get; set; }

        public double TestAssessment { get; set; }

        public IComparer<StudentInfo> Comparable { get; set; }

        public int Compare(object x, object y)
        {
            if (!(x is StudentInfo) || !(y is StudentInfo))
            {
                throw new ArgumentException("Objects are not instances of StudentInfo");
            }

            if (this.Comparable is null)
            {
                return x.ToString().CompareTo(y.ToString());
            }
            else
            {
                var vx = x as StudentInfo;
                var vy = y as StudentInfo;
                return this.Comparable.Compare(vx, vy);
            }
        }

        public int CompareTo([AllowNull] StudentInfo other)
        {
            return this.Compare(this, other);
        }
    }
}
