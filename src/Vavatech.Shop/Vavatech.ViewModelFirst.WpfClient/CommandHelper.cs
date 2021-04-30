using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.ViewModelFirst.WpfClient
{
    public class CommandManager
    {
        private IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public ICommand Bind(Action action, [CallerMemberName] string caller = "")
        {
            ICommand command;

            if (commands.TryGetValue(caller, out command))
            {
                return command;
            }
            else
            {
                command = new DelegateCommand(action);
                commands.Add(caller, command);

                return command;
            }
        }
    }
}
