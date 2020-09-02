using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    interface IProblem<T>
    {
        public string Question { get; }
        public T Answer();
    }
}
