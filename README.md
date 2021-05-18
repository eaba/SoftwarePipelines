# Software Pipelines Architecture with Akka.Net
I did some research to find out the numbers of tweets per second on Twitter and number of messages sent per second on WhatsApp, because
I believed the numbers will help to paint a clearer image of what am about showing you or what we can achieve with a Pipelines architecture.

For Twitter, according to https://www.internetlivestats.com/one-second/#tweets-band as at the time of writing this, the number of tweets
per second was 9,477. That is 9,477 Transactions per second!

And for WhatsApp, according to https://ng.oberlo.com/blog/whatsapp-statistics, the number of messages sent per second was 750,000.
That is 750,000 Transactions per second!

System performance is measured in TPS(Transaction Per Second), and with Software Pipelines Architecture we can achieve high performance and scalability.

How do systems like Twitter, Facebook, WhatsApp or Banking system handle high traffic efficiently and without high cost?


## What is Software Pipelines Architecture?

From the Book by Cory Isaacson: Software Pipelines and SOA:
> Software Pipelines architecture is an applications architecture designed to
> enable flexible performance improvements and to add scalability to business
> applications. It consists of a proven set of architecture and best practices
> guidelines, which are based on the physical engineering discipline of fluid
> dynamics.

> Software Pipelines architecture is a new architecture that specifically
> addresses the problem of using parallel processing in the multi-core era. It is a
> new approach to the problem. Pipeline technology abstracts the complexities of
> parallel computing and makes it possible to use the power of the new CPUs for
> business applications.

## It is a new approach to the problem, so what is the problem?

Improving application performance!!

Before now, there have been many solutions, like multi-process, multi-threading, writing code for memory and CPU efficiency, 
for improving application performance. With Akka.Net we have the tool to acheive Software Pipelines Architecture, 
and "to create a parallel software environment specifically for business applications".

"The architecture is highly scalable and flexible. It executes business services independent of location, and in such a way as to
maximize throughput on available computing resources, while easily meeting a vast array of complex business application requirements.
You can easily scale your application to any size, you can maximize your resources, and best of all, you can do all this and still
maintain critical business transaction and integrity requirements."

So my duty is to show you how you can, using Akka.Net, create a Pipeline Architecture for your application following the guidelines as written by Cory Isaacson.
Get the book if you can!

## The Benefits of Software Pipelines Architecture(from the book)

* You can decompose business processes into specific tasks, then execute them in parallel.
* It has virtually unlimited peer-to-peer scalability.
* It’s easier on the developer because it provides an easy method for distributing and executing tasks in parallel—on one server, or across many servers.
* It’s specifically designed for business applications, particularly those that use, or can use, SOA.
* It handles a high volume of transactions, both large and small, and is therefore ideal for mixed-workload processing.
* The design gives you control of throughput and task distribution, which means that you can maximize your computing resources.
* You can scale upward by using parallel architecture, while still guaranteeing the order of processing - a key business requirement in many mission critical applications. This is a huge benefit over previous approaches.
* Because the architecture supports so many configurations and patterns, you can create a wide variety of application designs.

# The fundamental component in Software Pipelines(from the book)

The fundamental component in Software Pipelines is the pipeline itself, defined as follows:
> An execution facility for invoking the discrete tasks of a business process in an order-controlled manner. 
> You can control the order by using priority, order of message input (for example, FIFO), or both.

Essentially, a pipeline is a control mechanism that receives and performs delegated tasks, with the option of then delegating tasks in turn to other pipelines in
the system as required. This means you can use pipelines as building blocks to create an unlimited variety of configurations for accomplishing your specific
application objectives.
You can group multiple pipelines into fully distributed, peer-to-peer pools; each pipeline processes a portion of an application or process. And because you
can configure each pool to run on a specific local or remote server, the system can execute tasks anywhere on a network.
A pipeline can route tasks to other pipelines through a Pipeline Distributor,its companion component. 
The Pipeline Distributor is defined as follows:
> A virtual routing facility for distributing a given service request to the appropriate pipeline (which in turn executes the request) 
> within a pipeline pool. The distributor is colocated with its pool of pipelines and effectively front-ends incoming service requests.
> The distributor routes service requests by evaluating message content. Routing is based on configuration rules, which you can easily modify without
> changing individual business services. You can route requests by using priority, order of message input (such as FIFO), or both.

# What is Akka.Net?

Akka.NET is a toolkit and runtime for building highly concurrent, distributed, and fault tolerant event-driven applications on .NET & Mono.
Akka.net is a .NET port of the original Akka framework, *Actor Model* implementation in Java/Scala.

# What is Actor Model?

The Actor Model provides a higher level of abstraction for writing concurrent and distributed systems. 
It alleviates the developer from having to deal with explicit locking and thread management, 
making it easier to write correct concurrent and parallel systems.


With Akka.NET, developers can build powerful concurrent, distributed & Pipelined applications more easily.
