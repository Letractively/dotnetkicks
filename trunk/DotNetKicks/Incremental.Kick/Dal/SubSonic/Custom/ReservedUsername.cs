using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Incremental.Kick.Dal {
    public partial class ReservedUsername {
        //TODO: GJ: refactor to helper class
        public static bool IsColumnValueUnique(string columnName, object value) {
            using (IDataReader reader = ReservedUsername.FetchByParameter(columnName, value))
                return reader.Read();
        }
    }
}
