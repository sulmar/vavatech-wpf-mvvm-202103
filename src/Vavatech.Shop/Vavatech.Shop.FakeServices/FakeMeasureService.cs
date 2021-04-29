using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.FakeServices
{
    public class FakeMeasureService : IMeasureService
    {
        private Random random = new Random();

        public double Get()
        {
            return random.NextDouble() * 100d;
        }
    }
}
