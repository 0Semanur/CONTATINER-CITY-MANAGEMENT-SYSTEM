using System;

namespace UserLogin
{
    internal class Form1
    {
        public Form1()
        {
        }

        public System.Action<object, object> FormClosed { get; internal set; }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}