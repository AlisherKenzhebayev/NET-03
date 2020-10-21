// <copyright file="AddOrChangeUrlParameter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals.T_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class UrlUtility
    {
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            Tuple<string, string> searchKey = SplitKeyVals(keyValueParameter);
            var splitUrl = url.Split('?').ToList();
            url = splitUrl[0];
            if (splitUrl.Count > 1)
            {
                var keyVals = splitUrl[1];
                splitUrl = keyVals.Split('&').ToList();
                for (var i = 0; i < splitUrl.Count; i++)
                {
                    var temp = SplitKeyVals(splitUrl[i]);
                    if (temp.Item1 == searchKey.Item1)
                    {
                        splitUrl[i] = RetFromTuple(searchKey);
                        searchKey = null;
                    }
                }

                if (searchKey != null)
                {
                    splitUrl.Add(RetFromTuple(searchKey));
                }
            }
            else {
                splitUrl = new List<string>();
                splitUrl.Add(RetFromTuple(searchKey));
            }

            return RestoreFromUrlAndPairs(url, splitUrl);
        }

        private static string RestoreFromUrlAndPairs(string url, List<string> splitUrl)
        {
            string fullPairs = string.Empty;
            for (var i = 0; i < splitUrl.Count; i++)
            {
                fullPairs += splitUrl[i];
                if (i < splitUrl.Count - 1)
                {
                    fullPairs += "&";
                }
            }

            return $"{url}?{fullPairs}";
        }

        private static Tuple<string, string> SplitKeyVals(string keyValueParameter)
        {
            var splitUrl = keyValueParameter.Split('=');
            return new Tuple<string, string>(splitUrl[0], splitUrl[1]);
        }

        private static string RetFromTuple(Tuple<string, string> keyVal)
        {
            return $"{keyVal.Item1}={keyVal.Item2}";
        }
    }
}
