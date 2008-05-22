using System;
using System.Collections.Generic;
using System.Text;

using Lucene.Net.Analysis;

namespace Incremental.Kick.Search.Analyzer
{
    /// <summary>
    /// Custom analyzer for Lucene that will tokenize the stories for use within
    /// the index. This analyzer will allow some symbol characters such as # and +
    /// to be included in the tokens, this will allow searches for c# and c++ to return the
    /// correct results.
    /// </summary>
    public class DnkAnalyzer : Lucene.Net.Analysis.Analyzer
    {
        public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
        {
            return new DnkTokenizer(reader);
        }
    }
}
