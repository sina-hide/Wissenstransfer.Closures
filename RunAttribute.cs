using System;

namespace Closures
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RunAttribute : Attribute
    {
        public int Priority { get; }

        public RunAttribute(int priority) => Priority = priority;
    }
}