using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;
        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactroy();
        }

        public string Read(string args)
        {
            string[] parts = args.Split();
            string commandType = parts[0];
            string[] comandArgs = parts.Skip(1).ToArray();

            ICommand command = this.commandFactory.CreateCommand(commandType);

            return command.Execute(comandArgs);
        }
    }
}
