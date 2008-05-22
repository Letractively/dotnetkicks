using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities.Api {
    public class ApiPagedList<T> {
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

        private List<T> _items;
        public List<T> Items {
            get { return this._items; }
            set { this._items = value; }
        }
    }
}
