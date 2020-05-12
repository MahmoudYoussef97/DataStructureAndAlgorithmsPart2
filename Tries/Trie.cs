using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    public class Trie
    {
        private Node root = new Node(' ');
        private class Node
        {
            public char value;
            public Node[] children = new Node[26];
            public bool IsEndOfWord;
            public Node(char v)
            {
                value = v;
            }
        }
        public void Insert(string word)
        {
            var current = root;
            
            foreach (var ch in word)
            {
                if (current.children[ch - 'a'] == null)
                    current.children[ch - 'a'] = new Node(ch);

                current = current.children[ch - 'a'];
            }
            current.IsEndOfWord = true;
        }
        public bool Contains(string word)
        {
            var current = root;
            foreach (var ch in word)
            {
                if (current.children[ch - 'a'] == null)
                    return false;

                current = current.children[ch - 'a'];
            }
            return current.IsEndOfWord;
        }
        public bool RecursiveContains(string word)
        {
            return RecursiveContains(root, word, 0);
        } 
        private bool RecursiveContains(Node root, string word, int index)
        {
            var ch = word[index];
            if (index == word.Length - 1)
                return true;
            if (root.children[ch - 'a'] == null)
                return false;

            return RecursiveContains(root.children[ch - 'a'], word, index + 1);
        }
        public void Print(string word)
        {
            var current = root;
            foreach (var ch in word)
            {
                Console.WriteLine(current.children[ch - 'a'].value);
                current = current.children[ch - 'a'];
            }
        }
        public void Remove(string word)
        {
            Remove(root, word, 0);
        }
        private void Remove(Node root, string word, int index)
        {
            if(index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = root.children[ch - 'a'];
            if (child == null)
                return;

            Remove(child, word, index + 1);

            if (GetChildren(child).Count == 0 && !child.IsEndOfWord)
                RemoveChild(ch);

        }
        private void RemoveChild(char ch)
        {
            root.children[ch - 'a'] = null;
        }
        public void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node root)
        {
            Console.WriteLine(root.value);
            foreach (var item in GetChildren(root))
            {
                Traverse(item);
            }
        }
        private List<Node> GetChildren(Node root)
        {
            var list = new List<Node>();
            foreach (var node in root.children)
            {
                if (node != null)
                    list.Add(node);
            }
            return list;
        }
        public List<string> AutoComplete(string word)
        {
            List<string> words = new List<string>();
            var lastNode = FindLastNode(word);
            FindWords(lastNode, words, word);

            return words;
        }
        private void FindWords(Node root, List<string> words, string word)
        {
            if (root.IsEndOfWord)
                words.Add(word);

            foreach (var child in GetChildren(root))
            {
                FindWords(child, words, word + child.value);
            }
        }
        private Node FindLastNode(string word)
        {
            var current = root;
            foreach (var item in word)
            {
                if (current.children[item - 'a'] == null)
                    return null;
                current = current.children[item - 'a'];
            }
            return current;
        }
        public StringBuilder LongestCommonPrefix(string[] words)
        {
            foreach (var item in words)
            {
                Insert(item);
            }
            StringBuilder longestCommonPrefix = new StringBuilder();
            LongestCommonPrefix(root, longestCommonPrefix);
            return longestCommonPrefix;
        }
        private void LongestCommonPrefix(Node root, StringBuilder longestCommonPrefix)
        {
            if (GetChildren(root).Count > 1)
                return;

            foreach (var item in GetChildren(root))
            {
                longestCommonPrefix.Append(item.value);
                LongestCommonPrefix(root.children[item.value - 'a'], longestCommonPrefix);
            }
        }
    }
}
