using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Lucene.Net.QueryParsers;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Similarity.Net;

using Incremental.Kick.Dal;
using Incremental.Kick.Search.Analyzer;

namespace Incremental.Kick.Search
{
    /// <summary>
    /// Finds similar stories for the given story
    /// </summary>
    /// <remarks>this class uses lucene and morelikethis library to determine
    /// the matching stories</remarks>
    public class SimilarStories
    {
        /// <summary>
        /// defines the number of stories to find that are similar
        /// to the given story
        /// </summary>
        const int NUMBER_OF_RELATED_STORIES_TO_RETURN = 10;

        public StoryCollection Find(int hostId, int storyId)
        {
            int? docId = ConvertStoryIdtoDocId(hostId, storyId);

            if (docId.HasValue)
            {
                IndexSearcher indexSearch = SearchQuery.GetSearcher(hostId);
                IndexReader indexReader = indexSearch.GetIndexReader();

                MoreLikeThis mlt = new MoreLikeThis(indexReader);

                mlt.SetAnalyzer(new DnkAnalyzer());
                //mlt.SetFieldNames(new string[] { "title", "description" });

                //these values control the query used to find related/similar stories
                //
                //-we are only using the title and tags fields, 
                //-the term must appear 1 or more times,
                //-the query will only have 3 terms
                //-a word less than 3 char in len with be ignored
                //-the term must appear at in at least 4 doc
                mlt.SetFieldNames(new string[] { "title", "tags" });
                mlt.SetMinTermFreq(1);
                mlt.SetMaxQueryTerms(5);
                mlt.SetMinWordLen(3);
                mlt.SetMinDocFreq(4);
                mlt.SetStopWords(StopWords());
                mlt.SetBoost(true);
                Query mltQuery = mlt.Like(docId.Value);

                Hits hits = indexSearch.Search(mltQuery);

                List<int> results = new List<int>();


                for (int i = 0; i < hits.Length(); i++)
			    {
                    Document d = hits.Doc(i);
                    int hitStoryId = int.Parse(d.GetField("id").StringValue());
                    
                    if (hitStoryId != storyId)
                    {
                        results.Add(hitStoryId);
                        if (results.Count == NUMBER_OF_RELATED_STORIES_TO_RETURN)
                            break;
                    }
			    } 

                return SearchQuery.LoadStorySearchResults(results);
            }
            else
                return null;
        }

        /// <summary>
        /// Converts storyId as used in the database to the docId as used in lucene
        /// </summary>
        /// <param name="hostId"></param>
        /// <param name="storyId"></param>
        /// <returns>returns the docId for the story from lucene. If the story is not 
        /// found a null value will be returned</returns>
        protected int? ConvertStoryIdtoDocId(int hostId, int storyId)
        {
            QueryParser queryParser = new QueryParser("id", new DnkAnalyzer());
            Query q = queryParser.Parse(storyId.ToString());

            IndexSearcher searcher = SearchQuery.GetSearcher(hostId);
            Hits hits = searcher.Search(q);

            if (hits.Length() > 0)
            {
                return hits.Id(0);
            }

            return null;
        }

        /// <summary>
        /// returns a list of stop words which are ignored, add to this
        /// to remove any results which are picking up noise words
        /// </summary>
        /// <returns></returns>
        private static Hashtable StopWords()
        {
            Hashtable stopWords = new Hashtable();

            //standard stop words
            string[] english_stop_words = new string[] { "a", "an", "and", "are", "as", "at", "be", "but", "by", "for", "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the", "their", "then", "there", "these", "they", "this", "to", "was", "will", "with" };

            //MM: add any custom words here to filter out poor similar results
            //maybe this should be moved to some admin interface/db table to that a admin
            //can tweak these values without coding

            string[] dnk_stop_words = new string[] {"form", "must", "where", "when"};

            foreach (string s in english_stop_words)
            {
                stopWords.Add(s, string.Empty);
            }

            foreach (string s in dnk_stop_words)
            {
                if(!stopWords.Contains(s))
                    stopWords.Add(s, string.Empty);
            }

            return stopWords;
        }
    }
}
