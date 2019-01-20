using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Director : AbstractEmployee
    {
        public Director(string title = "Director") : base(title)
        {
            Random rnd = new Random();
            this._processingTime += rnd.Next(_processingTime, _processingTime);
        }
    }
}
