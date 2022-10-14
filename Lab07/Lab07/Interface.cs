using System;
using System.Collections.Generic;
using System.Text;

namespace Lab07
{
    interface Interface<T>
    {
        void Push(T s);
        void Pop();
        void CheckList();
    }
}
