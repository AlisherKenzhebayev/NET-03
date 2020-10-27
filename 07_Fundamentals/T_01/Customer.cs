// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals.T_01
{
    public class Customer
    {
        public Customer(string n, string r, string c)
        {
            this.Name = n;
            this.Revenue = r;
            this.ContactPhone = c;
        }

        public string Name { get; set; }

        public string Revenue { get; set; }

        public string ContactPhone { get; set; }
    }
}
