using Core.Abstracts;
using System;

namespace Core.ConcreteClases
{
    class Manager : AbstractEmployee
    {
        public Manager(string title = "Manager") : base(title)
        {
            Random rnd = new Random();
            this._processingTime += rnd.Next(_processingTime, _processingTime * 2);
        }
    }
}
