using System;
using System.Collections.Generic;
using System.Text;

using Lucene.Net.Search;
using Lucene.Net.QueryParsers;

using Incremental.Kick.Search.Analyzer;

namespace Incremental.Kick.Search
{

    /// <summary>
    /// Creates Lucene queries that can be executed against the index. Allows
    /// global search as well as restricted search on categories or users.
    /// </summary>
    /// <remarks>The returned query is multi field query and will search
    /// across <code>title</code>,<code>tags</code> and <code>description</code>. This
    /// mean that search will be executed across a number of indexed fields
    /// this should give more relevant search results. <para>When the search
    /// is restricted then the user/category must exist in that field for the
    /// result to be included.</para></remarks>
    public class QueryFactory
    {

        QueryType queryType;

        List<string> baseFieldName;
        List<float> baseFieldBoost;
        Lucene.Net.Analysis.Analyzer analyzer;


        /// <summary>
        /// Determines in the type of query to return. Allows 
        /// restricting the scope of the search
        /// </summary>
        public enum QueryType
        {
            /// <summary>
            /// Search all stories
            /// </summary>
            Stories,
            /// <summary>
            /// Search only stories that have been kicked by the
            /// given user
            /// </summary>
            User,
            /// <summary>
            /// Search only stories that are in the given category
            /// </summary>
            Category
        }


        /// <summary>
        /// Cstor
        /// </summary>
        /// <param name="queryType">The type of query the factory should return</param>
        public QueryFactory(QueryType queryType)
        {
            this.queryType = queryType;

            //create the base fields to search against
            baseFieldName = new List<string>();
            baseFieldName.Add("title");
            baseFieldName.Add("description");
            baseFieldName.Add("tags");

            //create the base boost values
            baseFieldBoost = new List<float>();
            baseFieldBoost.Add(8f);
            baseFieldBoost.Add(4f);
            baseFieldBoost.Add(1f);

            analyzer = new DnkAnalyzer();
        }



        /// <summary>
        /// Generate the query based on the queryTerm. The query is a multi field query
        /// </summary>
        /// <param name="queryTerm">queryterm to search the index for</param>
        /// <param name="restrictionTerm">restriction used to limit the search to a given category
        /// or user, this is only required when the <code>QueryType</code> is <code>User</code>
        /// or <code>Category</code></param>
        /// <returns></returns>
        public Query Parse(string queryTerm, string restrictionTerm)
        {
            BooleanQuery bq;

            //Lucene doesnt allow queries that start with a wildcard (*) or single wildcard (?)
            //therefore check to make sure that we aren;t starting with a wildcard
            queryTerm = WildCardStartCheck(queryTerm);

            if (queryTerm.Length == 0)
                return null;

            switch (queryType)
            {
                case QueryType.Category:
                    bq = (BooleanQuery)MultiFieldQuery(queryTerm, baseFieldName, baseFieldBoost, analyzer);
                    return RestrictSearch(bq, "category", restrictionTerm, analyzer);

                case QueryType.User:
                    bq = (BooleanQuery)MultiFieldQuery(queryTerm, baseFieldName, baseFieldBoost, analyzer);
                    return RestrictSearch(bq, "users", restrictionTerm, analyzer);

                case QueryType.Stories:
                default:
                    return MultiFieldQuery(queryTerm, baseFieldName, baseFieldBoost, analyzer);

            }
        }


        /// <summary>
        /// Lucene doesnt allow queries that start with a wildcard (*) or single wildcard (?)
        /// therefore check to make sure that we aren;t starting with a wildcard
        /// </summary>
        /// <param name="queryTerm"></param>
        /// <returns></returns>
        private string WildCardStartCheck(string queryTerm)
        {
            char[] bannedStartingChars = new char[] { '*', '?' };

            foreach (char banned in bannedStartingChars)
            {
                if (queryTerm.Length > 0 && banned == queryTerm[0])
                {
                    queryTerm = queryTerm.Substring(1);
                    queryTerm = WildCardStartCheck(queryTerm);
                }
            }

            return queryTerm;
        }


        /// <summary>
        /// Add a restriction to an existing BooleanQuery
        /// </summary>
        /// <param name="boolQuery"></param>
        /// <param name="field"></param>
        /// <param name="term"></param>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        private Query RestrictSearch(BooleanQuery boolQuery, string field, string term, Lucene.Net.Analysis.Analyzer analyzer)
        {
           
            QueryParser qp = new QueryParser(field, analyzer);
            qp.SetDefaultOperator(QueryParser.Operator.AND);
            Query q = qp.Parse(term);

            BooleanQuery restrictedQuery = new BooleanQuery();
            restrictedQuery.Add(boolQuery, BooleanClause.Occur.MUST);
            restrictedQuery.Add(q, BooleanClause.Occur.MUST);

            return restrictedQuery;
        }


        /// <summary>
        /// Creates the basis query that all QueryTypes use
        /// </summary>
        /// <param name="queryTerm"></param>
        /// <param name="fields"></param>
        /// <param name="weighting"></param>
        /// <param name="analyzer"></param>
        /// <returns></returns>
        private Query MultiFieldQuery(string queryTerm, IList<string> fields, IList<float> weighting, Lucene.Net.Analysis.Analyzer analyzer)
        {
            BooleanQuery combinedQuery = new BooleanQuery();

            for (int i = 0; i < fields.Count; i++)
            {
                QueryParser qp = new QueryParser(fields[i], analyzer);
                qp.SetDefaultOperator(QueryParser.Operator.AND);
                Query fieldQuery = qp.Parse(queryTerm);

                fieldQuery.SetBoost(weighting[i]);

                combinedQuery.Add(fieldQuery, BooleanClause.Occur.SHOULD);
            }

            return combinedQuery;
        }
    }
}
