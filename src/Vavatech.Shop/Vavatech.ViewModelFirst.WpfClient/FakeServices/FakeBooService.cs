using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.ViewModelFirst.WpfClient.IServices;

namespace Vavatech.ViewModelFirst.WpfClient.FakeServices
{

    public class FakeBooService : IBoo
    {
        public string Get()
        {
            return "Second View";
        }
    }
}
