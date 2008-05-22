using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal {
    public class PagedCollection<T> {
        private T _items;
        private int _total;

        public T Items {
            get { return this._items; }
            set { this._items = value; }
        }
        public int Total {
            get { return this._total; }
            set { this._total = value; }
        }
    }
}