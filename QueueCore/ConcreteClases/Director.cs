using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Director : AbstractEmployee
    {
        public Director(string title = "Director") : base(title)
        {
            _processingTimeMin = 0;
            _processingTimeMax = 10000;
            Random rnd = new Random();
            this._processingTimeMin += rnd.Next(_processingTimeMin, _processingTimeMax);
        }
    }
}
