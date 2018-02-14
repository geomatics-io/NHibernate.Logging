NHibernate Logging Providers
============================
This is a fork of https://github.com/mgernand/NHibernate.Logging. It was updated to NHibernate 4.x and some implementations where adopted.

[![Build status](https://ci.appveyor.com/api/projects/status/dbexo510w4kfg6s2?svg=true)](https://ci.appveyor.com/project/geomatics/nhibernate-logging)
[![NuGet version](https://badge.fury.io/nu/Geomatics.IO.NHibernate.Logging.svg)](https://badge.fury.io/nu/Geomatics.IO.NHibernate.Logging)


Project Description
-------------------
NHibernate Logging Providers makes it possible to use your favourite logger with NHibernate. 
You no longer have to use log4net. The new NHibernate (since NH3) logging abstraction makes 
this possible. The provider is developed in C# using .NET 4.5.

Available Logging Providers
---------------------------
The current release contains log providers for the following logging frameworks.

* [Common.Logging 3.1.0](https://github.com/net-commons/common-logging)

Common.Logging 3.1.0 supports several other logging frameworks. So you can use
each of them with NHibernate via Common.Logging 3.1.0 abstraction.

Review the [NHibernate Wiki](http://nhibernate.info/doc/howto/various/using-nlog-via-common-logging-with-nhibernate.html) for additional informations. Please leave a comment if you 
like it or not. ;-)

Getting Started
---------------
To use the Common.Logging 3.1.0 logging abstraction framework with NHibernate all you have 
to do is to copy the following Assemblies to you projects output directory:

* Common.Logging.dll
* Common.Logging.Core.dll
* NHibernate.Logging.CommonLogging.dll

Needless to say that you have to copy your loggers Assembly and the corresponding 
Common.Logging-Provider Assembly too. To enable the log provider you have to add the 
following lines to your Web.config or App.config:

```xml
<appSettings>
  <add key="nhibernate-logger" 
       value="NHibernate.Logging.CommonLogging.CommonLoggingLoggerFactory, NHibernate.Logging.CommonLogging"/>
</appSettings>
```
