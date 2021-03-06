﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SharePoint
{
    public abstract class SPCollection<T> : IEnumerable<T> where T : ISPObject
    {
        protected private List<T> _list;

        internal SPCollection() => _list = new List<T>();
        internal SPCollection(int capacity) => _list = new List<T>(capacity);
        internal SPCollection(IEnumerable<T> items) => _list = new List<T>(items);

        public int Count => _list.Count;

        public T this[int index] => _list[index];
        public T this[string name]
        {
            get
            {
                T retItem = default;
                for (int i = 0; i < _list.Count; i++)
                {
                    T item = _list[i];
                    if (item.Name.Equals(name))
                    {
                        retItem = item;
                        break;
                    }
                }
                return retItem;
            }
        }

        protected private void AddItems(IEnumerable<T> items) => _list.AddRange(items);

        public T FindById(object id)
        {
            T retItem = default;
            for (int i = 0; i < _list.Count; i++)
            {
                T item = _list[i];
                if (item.Id.Equals(id))
                {
                    retItem = item;
                    break;
                }
            }
            return retItem;
        }
        public T FindByName(string name, StringComparison comparison)
        {
            T retItem = default;
            for (int i = 0; i < _list.Count; i++)
            {
                T item = _list[i];
                if (item.Name.Equals(name, comparison))
                {
                    retItem = item;
                    break;
                }
            }
            return retItem;
        }

        public bool IsObjectPropertyInstatiated(string propertyName)
        {
            bool result = true;
            for (int i = 0; i < _list.Count; i++)
            {
                if (!_list[i].IsObjectPropertyInstantiated(propertyName))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
