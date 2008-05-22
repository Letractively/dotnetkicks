using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal {
    public partial class Category {
        public static Category UnknownCategory {
            get {
                Category unknownCategory = new Category();
                unknownCategory.CategoryID = 0;
                unknownCategory.CategoryIdentifier = "unknown";
                unknownCategory.Name = "Unknown";
                return unknownCategory;
            }
        }

        public bool IconNameSpecified {
            get { return !String.IsNullOrEmpty(this.IconName); }
        }
    }
}
