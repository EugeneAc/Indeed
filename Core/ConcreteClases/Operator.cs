using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Operator : AbstractEmployee
    {
        public Operator(string title = "Operator") : base(title)
        {
            Random rnd = new Random();
            this._processingTime += rnd.Next(_processingTime, _processingTime * 3);
        }
    }
}
