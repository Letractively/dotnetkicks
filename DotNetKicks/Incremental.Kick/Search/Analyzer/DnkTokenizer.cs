using System;
using System.Collections.Generic;
using System.Text;

using Lucene.Net.Analysis;

namespace Incremental.Kick.Search.Analyzer
{
    public class DnkTokenizer : CharTokenizer
    {
        public DnkTokenizer(System.IO.TextReader in_Renamed)
            : base(in_Renamed)
        {
        }

        /// <summary>
        /// Tokenise on letters and digits, but also allow '#' and '+' since we need this
        /// symbols for c# and c++
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected override bool IsTokenChar(char c)
        {
            if (Char.IsLetterOrDigit(c))
                return true;
            else if (c == '#' | c == '+')
                return true;
            else
                return false;
        }

        protected override char Normalize(char c)
        {
            return Char.ToLower(c);
        }
    }
}
