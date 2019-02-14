# RabbitMQ Helper

The RabbitMQ Helper is a tool whose purpose is to assist with installing [RabbitMQ](https://www.rabbitmq.com)

RabbitMQ is not a Thycotic product and we do not receive revenue for it. We built the RabbitMQ Helper to help our customers more easily install RabbitMQ (RabbitMQ is an important component of Secret Server’s on-premises environment).

## What can the Helper do for Me?

*The RabbitMQ Helper currently, and for the forseeable future, only works on Windows OS.*

- Online and offline install of RabbitMQ with or without TLS
- Convert certificates for use with RabbitMQ
- Establish RabbitMQ clusters and streamline cluster policies
- Establish RabbitMQ federations and streamline federation policies
- Enable management UI
- Create basic users
- View/manage the RabbitMQ log 

## Getting Started

### Prerequisites

- Download and install the latest RabbitMQ Helper
    - Stable:
        - [Thycotic Updates - Alias to the Thycotic CDN](https://updates.thycotic.net/links.ashx?RabbitMqInstaller)
        - [Directly from Thycotic CDN](https://thycocdn.azureedge.net/engineinstallerfiles-master/rabbitMqSiteConnector/grmqh.msi)
    - Pre-release
        - [Pre-release drop](https://thycodevstorage.blob.core.windows.net/engineinstallerfiles-qa/rabbitMqSiteConnector/grmqh.msi)

- Start the Helper. This will prepare and run a PowerShell instance that is pre-configured to use the Helper PowerShell module.
    - Use the Start Menu shortcut for "Thycotic RabbitMQ Helper PowerShell Host"
    - Or navigate to the installation folder in "%PROGRAMFILES%\Thycotic Software Ltd\RabbitMq Helper"
- Run PowerShell commandlets directly or use any of the example scripts provided.

 
#### For Offline Installs:
   - [Preparing for Installation on a Computer NOT Connected to the Internet](usecases/installation/prepare-offline.md)


### Walk-throughs

#### Installation
   - [Installation Overview](usecases/installation/README.md)

#### Clustering
   - [Clustering Overview](usecases/clustering/README.md)

### Troubleshooting and Maintenence
   - [RabbitMq Node Diagnostics](usecases/management/node-diagnostics.md)
   - [Messaging Troubleshooting / Enabling Rabbit Firehose](EnablingRabbitFirehose.md)
   - [Remove All Queues on a RabbitMq Node](usecases/management/remove-all-queues.md)
   - [Review Common Troubleshooting Tips](troubleshooting.md)
   - [Get-Help Output for all cmdlets](https://github.com/thycotic/rabbitmq-helper/tree/master/docs/get-help)
   - If you are still having difficulties, [submit an issue on Github](https://github.com/thycotic/rabbitmq-helper/issues)


### Miscellaneous

#### Certificates 
(Install-Connector workflow normally converts certificates without needing to use the below)
- [Convert a CA Certificate to PFX to PEM File](usecases/certificate/convert-cacerttopem.md)
- [Convert a Host PFX to PEM File](usecases/certificate/convert-pfxtopem.md)

#### Federation
- [Federation Overview](usecases/federation/README.md)
