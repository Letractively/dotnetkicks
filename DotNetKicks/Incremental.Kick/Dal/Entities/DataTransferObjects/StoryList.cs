using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities.DataTransferObjects {
    public class StoryList {

        private int _total;
        public int Total {
            get { return _total; }
            set { _total = value; }
        }

        private DateTime _timeStamp = DateTime.Now;
        public DateTime TimeStamp {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }


        public List<Story> Stories = new List<Story>();
       
    }
}
