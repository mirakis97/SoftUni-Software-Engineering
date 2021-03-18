using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
