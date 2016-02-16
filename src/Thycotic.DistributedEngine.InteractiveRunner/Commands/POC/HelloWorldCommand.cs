﻿using System;
using Thycotic.CLI.Commands;
using Thycotic.DistributedEngine.InteractiveRunner.ConsoleCommands;
using Thycotic.Logging;
using Thycotic.MessageQueue.Client;
using Thycotic.MessageQueue.Client.QueueClient;
using Thycotic.Messages.DE.Areas.POC.Request;

namespace Thycotic.DistributedEngine.InteractiveRunner.Commands.POC
{
    class HelloWorldCommand : CommandBase
    {
        private readonly IRequestBus _bus;
        private readonly ILogWriter _log = Log.Get(typeof(HelloWorldCommand));

        public override string Area {
            get { return CommandAreas.Poc; }
        }

        public override string Description
        {
            get { return "Posts a hello world message to the exchange"; }
        }

        public HelloWorldCommand(IRequestBus bus, IExchangeNameProvider exchangeNameProvider)
        {
            _bus = bus;

            Action = parameters =>
            {
                _log.Info("Posting message to exchange");

                string content;
                if (!parameters.TryGet("content", out content)) return 1;

                int count = 1;
                string countString;
                if (parameters.TryGet("count", out countString))
                {
                    count = Int32.Parse(countString);
                }

                var message = new HelloWorldMessage
                {
                    Content = content
                };

                for (int i = 0; i < count; i++)
                {
                    _bus.BasicPublish(exchangeNameProvider.GetCurrentExchange(), message);
                }

                _log.Info("Posting completed");

                return 0;

            };
        }
    }
}
