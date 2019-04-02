using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB
{
    class PrefixTree<T> : IPrefixTree<T>
    {
        public PrefixTreeNode<T> root;

        public PrefixTree()
        {
            this.root = new PrefixTreeNode<T>();
        }




        public bool AddValue(string key, T element)
        {
            PrefixTreeNode<T> currentElement = root;


            //key="cat". charElement='c'=>'a'=>'t'
            foreach (char charElement in key)
            {
                if (!currentElement.dictionary.ContainsKey(charElement))
                {
                    currentElement.dictionary[charElement] = new PrefixTreeNode<T>();
                }

                currentElement = currentElement.dictionary[charElement];
            }
            if (currentElement.value.Equals(default(T)))
            {
                currentElement.value = element;
                return true;
            }
            return false;
        }

        public T Find(string key)
        {
            PrefixTreeNode<T> currentElement = root;

            foreach (char charElement in key)
            {
                if (!currentElement.dictionary.ContainsKey(charElement))
                {
                    return default(T);
                }

                currentElement = currentElement.dictionary[charElement];
            }
            return currentElement.value;
        }

        //Выписывать слова при вводе

        public bool Remove(string key)//возвращать T
        {
            PrefixTreeNode<T> currentElement = root;

            foreach (char charElement in key)
            {
                if (!currentElement.dictionary.ContainsKey(charElement))
                {
                    return false;
                }

                currentElement = currentElement.dictionary[charElement];
            }

            if (!currentElement.value.Equals(default(T)))
            {
                currentElement.value = default(T);
                return true;
            }
            
            return false;
        }



    }

    class PrefixTreeNode<T>
    {

        public Dictionary<char, PrefixTreeNode<T>> dictionary = new Dictionary<char, PrefixTreeNode<T>>();
        public T value;


        public PrefixTreeNode()
        {

            dictionary = new Dictionary<char, PrefixTreeNode<T>>();
        }



    }
}
