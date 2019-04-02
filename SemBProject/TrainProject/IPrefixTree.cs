using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB
{
    public interface IPrefixTree<T>
    {
        bool AddValue(string key, T element);
        T Find(string key);
        bool Remove(string key);

    }
}
