using System;
using System.Collections.Generic;
using System.Text;

namespace IOSerializeDemo
{
    public class Tree<T> : Visitable<T> where T : IComparable<T>
    {
        private HashSet<Tree<T>> m_children = new HashSet<Tree<T>>();
        private T m_data;

        public void SetChildren(HashSet<Tree<T>> children)
        {
            m_children = children;
        }

        public T GetData()
        {
            return m_data;
        }

        public void SetData(T data)
        {
            m_data = data;
        }

        public Tree(T data)
        {
            m_data = data;
        }

        public void Accept(Visitor<T> visitor)
        {
            visitor.VisitData(this, m_data);

            foreach (var children in m_children)
            {
                Visitor<T> childVisitor = visitor.VistTree(children);
                children.Accept(childVisitor);
            }
        }

        public Tree<T> Child(T data)
        {
            foreach (var children in m_children)
            {
                if (children.m_data.Equals(data))
                {
                    return children;
                }
            }
            return Child(new Tree<T>(data));
        }

        public Tree<T> Child(Tree<T> child)
        {
            m_children.Add(child);
            return child;
        }
    }

    public class TreeVisitor : Visitor<string>
    {
        public void VisitData(Tree<string> parent, string data)
        {

        }

        public Visitor<string> VistTree(Tree<string> tree)
        {
            return new TreeVisitor();
        }
    }

    public interface Visitable<T> where T : IComparable<T>
    {
        void Accept(Visitor<T> visitor);
    }

    public interface Visitor<T> where T : IComparable<T>
    {
        Visitor<T> VistTree(Tree<T> tree);
        void VisitData(Tree<T> parent, T data);
    }
}
