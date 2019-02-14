# Enabling Rabbit Firehose

### Overview
When using Rabbit it is important to understand where messages are being processed and consumed from. This article will describe how to enable Rabbit tracing and how to analyze the logs provided by the Rabbit trace.

- Open CMD as admin and navigate to sbin folder in Rabbit install directory in Program Files and run the following commands:
```dos
rabbitmq-plugins enable rabbitmq_tracing
rabbitmqctl trace_on
rabbitmq-service stop
rabbitmq-service start
```
![CommandLine](images/CommandLinePicture.PNG "CommandLine")

### More Steps
Log into the management console
Go to Admin
Go to Tracing (on right)
Enter a name
Username and Password can be blank
Leaving pattern as # will trace all messages. Specifying ‘deliver.[queue name]’ will show messages going into a particular queue

![Tracing](images/Tracing.PNG "Tracing")

Click ‘Add Trace’

![AddTrace](images/AddTrace.PNG "AddTrace")

Logs will be accumulated at [systemdriveletter]:/var/tmp/rabbitmq-tracing

![Logs](images/LogFiles.PNG "Logs")

This is an excerpt of a trace of a message publish.

![Publish](images/MessagePublished.PNG "Publish")

The Connection field shows where the message originated from. The IP address on the right is the address of the Rabbit. The user is the user who published the message.

![Received](images/MessageReceived.PNG "Received")

This entry shows the message being consumed. The payload is the same as the one above. The IP address shows the IP address of the machine doing the consuming. Some configuration may be necessary to get the IP address of machines if load balancers are involved.

This technique is helpful in understanding the messaging flow of your applications.
