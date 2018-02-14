/**
 * Licensed under the LGPL. See License.txt
 * The software is provided AS IS.
 * 
 * Copyright © Matthias Gernand 2010 - 2013
 * https://github.com/mgernand/nhibernate-logging
 * 
 * Please keep this header intact if you use this code.
 */
namespace NHibernate.Logging.CommonLogging
{
	using System;
	using Common.Logging;

	/// <summary>
	/// <para>Implementation of the <see cref="ILoggerFactory"/> interface 
	/// to allow the usage of Common.Logging 2.1 with the NHibernate 
	/// logging infrastructure.</para>
	/// <para>To use this logger factory with NHibernate add the following
	/// to your App/Web.config:</para>
	/// 
	/// &lt;appSettings&gt;
	///	&lt;add key="nhibernate-logger" value="NHibernate.Logging.CommonLogging.CommonLoggingLoggerFactory, NHibernate.Logging.CommonLogging"/&gt;
	/// &lt;/appSettings&gt;
	/// </summary>
	public class CommonLoggingLoggerFactory : ILoggerFactory
	{
		public IInternalLogger LoggerFor(string keyName)
		{
			return new CommonLoggingLogger(LogManager.GetLogger(keyName));
		}

		public IInternalLogger LoggerFor(Type type)
		{
			return new CommonLoggingLogger(LogManager.GetLogger(type));
		}
	}
}
