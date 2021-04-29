using Vavatech.ViewModelFirst.WpfClient.IServices;

namespace Vavatech.ViewModelFirst.WpfClient.FakeServices
{
    public class FakeFooService : IFoo
    {
        public string Get()
        {
            return "First View";
        }
    }
}
