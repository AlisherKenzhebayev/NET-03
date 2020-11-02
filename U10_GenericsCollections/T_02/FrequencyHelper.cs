// <copyright file="FrequencyHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_02
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public static class FrequencyHelper
    {
        public static async Task<IDictionary<string, int>> Frequency(FileStream fileStream)
        {
            var retVal = new Dictionary<string, int>();
            var result = new byte[fileStream.Length];
            await fileStream.ReadAsync(result, 0, (int)fileStream.Length);
            var text = System.Text.Encoding.ASCII.GetString(result);
            var arrString = text.Split(' ');
            foreach (var i in arrString)
            {
                if (retVal.TryGetValue(i, out var current))
                {
                    retVal[i] = current + 1;
                }
                else
                {
                    retVal.Add(i, 1);
                }
            }

            return retVal;
        }
    }
}