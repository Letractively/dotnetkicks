using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common;

namespace Incremental.Kick.Dal.Entities {
    public class WeightedTag {

        public WeightedTag() {}

        public WeightedTag(int tagID, string tagIdentifier, int usageCount) {
            this._tagID = tagID;
            this._tagIdentifier = tagIdentifier;
            this._usageCount = usageCount;
        }

        int _tagID;
        public int TagID {
            get { return this._tagID; }
            set { this._tagID = value; }
        }

        string _tagIdentifier;
        public string TagIdentifier {
            get { return this._tagIdentifier; }
            set { this._tagIdentifier = value; }
        }

        public string TagName {
            get {
                List<string> pieces = this.GetPieces();
                return pieces[pieces.Count-1];
                //return _tagIdentifier.Replace(Constants.NAMESPACE_SEPERATOR, " : ");
            }
        }

        int _usageCount;
        public int UsageCount {
            get { return this._usageCount; }
            set { this._usageCount = value; }
        }

        public bool IsInNamespace {
            get { return this.TagIdentifier.Contains(Constants.NAMESPACE_SEPERATOR); }
        }

        public List<string> Namespaces {
            get {                
                List<string> namespaces = new List<string>(this.GetPieces());
                namespaces.RemoveAt(namespaces.Count - 1);
                return namespaces;
            }
        }

        private List<string> GetPieces() {
            return new List<string>(this._tagIdentifier.Split(Constants.NAMESPACE_SEPERATOR.ToCharArray()));
        }
    }
}
