using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.IServices
{
    public interface IMessageBoxService
    {
        bool ShowMessage(string text, string caption);
    }
}
