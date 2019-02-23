using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Manager : AbstractEmployee
    {
        public Manager(string title = "Manager") : base(title)
        {
            _processingTimeMax = 20000;
            Random rnd = new Random();
            this._processingTimeMin += rnd.Next(_processingTimeMin, _processingTimeMax);
        }
    }
}
