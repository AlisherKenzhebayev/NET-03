// <copyright file="CustomerFormatProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable enable
namespace U07_Fundamentals.T_01
{
    using System;
    using System.Globalization;
    using System.IO;

    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider _parent;

        public CustomerFormatProvider()
            : this(CultureInfo.CurrentCulture)
        {
        }

        public CustomerFormatProvider(IFormatProvider parent)
        {
            this._parent = parent;
        }

        public object? GetFormat(Type? formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            var retstr = string.Empty;

            if (!(arg is Customer) || (format is null))
            {
                return string.Empty;
            }

            var customer = (Customer)arg;

            for (var i = 0; i < format.Length; i++)
            {
                var c = char.ToUpper(format[i]);
                switch (c)
                {
                    case 'N':
                        retstr += customer.Name;
                        break;
                    case 'C':
                        retstr += customer.ContactPhone;
                        break;
                    case 'F':
                        var f = new NumberFormatInfo();
                        f.NumberGroupSeparator = ",";
                        retstr += double.Parse(customer.Revenue).ToString("N2", f);
                        break;
                    case 'R':
                        retstr += customer.Revenue;
                        break;
                }

                if (i == format.Length - 1)
                {
                    break;
                }

                retstr += ", ";
            }

            return "Customer record: " + retstr;
        }
    }
}