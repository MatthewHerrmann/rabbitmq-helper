﻿using System.IO;
using System.Threading;
using Thycotic.MessageQueueClient;
using Thycotic.Messages.Areas.POC.Request;
using Thycotic.Messages.Common;

namespace Thycotic.SecretServerAgent2.Logic.Areas.POC
{
    /// <summary>
    /// Simple Hello World consumer
    /// </summary>
    public class CreateFileHandler :
        //IConsumer<CreateDirectoryMessage>,
        IRpcConsumer<CreateDirectoryMessage, BlockingConsumerResult>,
        IConsumer<CreateFileMessage>
    {
        private readonly IRequestBus _bus;
        //private readonly ILogWriter _log = Log.Get(typeof(ChainMessage));

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainMessageConsumer"/> class.
        /// </summary>
        /// <param name="bus">The bus.</param>
        public CreateFileHandler(IRequestBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// Consumes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ConsumeBasic(CreateDirectoryMessage request)
        {
            ConsumerConsole.WriteLine("Received directory message but will wait 2 seconds");

            if (!Directory.Exists(request.Path))
            {
                Thread.Sleep(2*1000);
                ConsumerConsole.WriteLine(string.Format("Creating directory {0} in fire-and-forget", request.Path));
                Directory.CreateDirectory(request.Path);
            }

        }

        /// <summary>
        /// Consumes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BlockingConsumerResult Consume(CreateDirectoryMessage request)
        {
            ConsumerConsole.WriteLine("Received directory message but will wait 2 seconds");

            if (!Directory.Exists(request.Path))
            {
                Thread.Sleep(2 * 1000);
                ConsumerConsole.WriteLine(string.Format("Creating directory {0} in RPC", request.Path));
                Directory.CreateDirectory(request.Path);
            }

            return new BlockingConsumerResult { Status = true };
        }


        /// <summary>
        /// Consumes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Consume(CreateFileMessage request)
        {
            ConsumerConsole.WriteLine("Received file message");

            var path = Path.GetDirectoryName(request.Path);

            ConsumerConsole.WriteLine("Posting directory message...");
            //_bus.BasicPublish(new CreateDirectoryMessage {Path = path});
            _bus.BlockingPublish<BlockingConsumerResult>(new CreateDirectoryMessage { Path = path }, 30);

            ConsumerConsole.WriteLine("Posted directory message...");


            ConsumerConsole.WriteLine(string.Format("Creating file {0}", request.Path));
            File.CreateText(request.Path);
            ConsumerConsole.WriteLine("File created");
            
            
        }



    }
}
