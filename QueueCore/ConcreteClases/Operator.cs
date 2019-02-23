using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Operator : AbstractEmployee
    {
        public Operator(string title = "Operator") : base(title)
        {
            _processingTimeMax = 30000;
            Random rnd = new Random();
            this._processingTimeMin += rnd.Next(_processingTimeMin, _processingTimeMax);
        }
    }
}
