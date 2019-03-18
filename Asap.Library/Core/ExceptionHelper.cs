﻿using Asap.Library.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Services.Protocols;

namespace Asap.Library.Core
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// 检查对象是否为空，如果为空，抛出ArgumentNullException
        /// </summary>
        /// <param name="data">被检查的对象</param>
        /// <param name="message">参数的名称</param>
        public static void NullCheck(this object data, string message)
        {
            NullCheck<ArgumentNullException>(data, message);
        }

        /// <summary>
        /// 检查对象是否为空，如果为空，抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="messageParams"></param>
        public static void NullCheck<T>(this object data, string message, params object[] messageParams) where T : System.Exception
        {
            (data == null).TrueThrow<T>(message, messageParams);
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出strMessage指定的错误信息
        /// </summary>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息参数</param>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出strMessage指定的错误信息
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs"  lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="FalseThrow"/>
        /// <seealso cref="MCS.Library.Compression.ZipReader"/>
        /// </remarks>
        /// <example>
        /// <code>
        /// ExceptionTools.TrueThrow(name == string.Empty, "对不起，名字不能为空！");
        /// </code>
        /// </example>
        public static void TrueThrow(this bool parseExpressionResult, string message, params object[] messageParams)
        {
            TrueThrow<SystemSupportException>(parseExpressionResult, message, messageParams);
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出strMessage指定的错误信息
        /// </summary>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息的参数</param>
        /// <typeparam name="T">异常的类型</typeparam>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为真(true)，则抛出message指定的错误信息
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region = "TrueThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="FalseThrow"/>
        /// <seealso cref="MCS.Library.Logging.LogEntity"/>
        /// </remarks>
        public static void TrueThrow<T>(this bool parseExpressionResult, string message, params object[] messageParams) where T : System.Exception
        {
            Type exceptionType = typeof(T);

            if (parseExpressionResult)
            {
                if (message == null)
                    throw new ArgumentNullException("message");

                Object obj = Activator.CreateInstance(exceptionType);

                Type[] types = new Type[1];
                types[0] = typeof(string);

                ConstructorInfo constructorInfoObj = exceptionType.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public, null,
                    CallingConventions.HasThis, types, null);

                Object[] args = new Object[1];

                args[0] = string.Format(message, messageParams);

                constructorInfoObj.Invoke(obj, args);

                throw (Exception)obj;
            }
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出strMessage指定的错误信息
        /// </summary>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息参数</param>
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region = "FalseThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="TrueThrow"/>
        /// <seealso cref="MCS.Library.Logging.LoggerFactory"/>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出message指定的错误信息
        /// </remarks>
        /// <example>
        /// <code>
        /// ExceptionTools.FalseThrow(name != string.Empty, "对不起，名字不能为空！");
        /// </code>
        /// </example>
        public static void FalseThrow(this bool parseExpressionResult, string message, params object[] messageParams)
        {
            TrueThrow(false == parseExpressionResult, message, messageParams);
        }

        /// <summary>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出message指定的错误信息
        /// </summary>
        /// <typeparam name="T">异常的类型</typeparam>
        /// <param name="parseExpressionResult">条件表达式</param>
        /// <param name="message">错误信息</param>
        /// <param name="messageParams">错误信息参数</param>
        /// <remarks>
        /// 如果条件表达式boolExpression的结果值为假（false），则抛出strMessage指定的错误信息
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region="FalseThrowTest" lang="cs" title="通过判断条件表达式boolExpression的结果值而判断是否抛出指定的异常信息" />
        /// <seealso cref="TrueThrow"/>
        /// <seealso cref="MCS.Library.Core.EnumItemDescriptionAttribute"/>
        /// </remarks>
        /// <example>
        /// <code>
        /// ExceptionTools.FalseThrow(name != string.Empty, typeof(ApplicationException), "对不起，名字不能为空！");
        /// </code>
        /// </example>
        public static void FalseThrow<T>(this bool parseExpressionResult, string message, params object[] messageParams) where T : System.Exception
        {
            TrueThrow<T>(false == parseExpressionResult, message, messageParams);
        }

        /// <summary>
        /// 检查字符串参数是否为Null或空串，如果是，则抛出异常
        /// </summary>
        /// <param name="data">字符串参数值</param>
        /// <param name="paramName">字符串名称</param>
        /// <remarks>
        /// 若字符串参数为Null或空串，抛出ArgumentException异常
        /// <code source="..\Framework\TestProjects\DeluxeWorks.Library.Test\Core\ExceptionsTest.cs" region="CheckStringIsNullOrEmpty" lang="cs" title="检查字符串参数是否为Null或空串，若是，则抛出异常" />
        /// </remarks>
        public static void CheckStringIsNullOrEmpty(this string data, string paramName)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException(string.Format(Resource.StringParamCanNotBeNullOrEmpty, paramName));
        }

        /// <summary>
        /// 检查字符串参数是否为Null或空串，如果是，则抛出异常
        /// </summary>
        /// <typeparam name="T">异常的类型</typeparam>
        /// <param name="data">检查字符串参数是否为Null或空串，如果是，则抛出异常</param>
        /// <param name="message"></param>
        public static void CheckStringIsNullOrEmpty<T>(this string data, string message) where T : System.Exception
        {
            (string.IsNullOrEmpty(data)).TrueThrow(message);
        }

        /// <summary>
        /// 从Exception对象中，获取真正发生错误的错误对象。
        /// </summary>
        /// <param name="ex">Exception对象</param>
        /// <returns>真正发生错误的错误对象</returns>
        public static Exception GetRealException(this Exception ex)
        {
            System.Exception lastestEx = ex;

            if (ex is SoapException)
            {
                lastestEx = new SystemSupportException(GetSoapExceptionMessage(ex), ex);
            }
            else
            {
                while (ex != null &&
                    (ex is System.Web.HttpUnhandledException || ex is System.Web.HttpException || ex is TargetInvocationException))
                {
                    if (ex.InnerException != null)
                        lastestEx = ex.InnerException;
                    else
                        lastestEx = ex;

                    ex = ex.InnerException;
                }
            }

            return lastestEx;
        }

        /// <summary>
        /// 得到SoapException中的错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetSoapExceptionMessage(Exception ex)
        {
            string strNewMsg = ex.Message;

            if (ex is SoapException)
            {
                int i = strNewMsg.LastIndexOf("--> ");

                if (i > 0)
                {
                    strNewMsg = strNewMsg.Substring(i + 4);
                    i = strNewMsg.IndexOf(": ");

                    if (i > 0)
                    {
                        strNewMsg = strNewMsg.Substring(i + 2);

                        i = strNewMsg.IndexOf("\n   ");

                        strNewMsg = strNewMsg.Substring(0, i);
                    }
                }
            }

            return strNewMsg;
        }

        /// <summary>
        /// 执行一个不抛出异常的操作
        /// </summary>
        /// <param name="action"></param>
        public static void DoSilentAction(Action action)
        {
            if (action != null)
            {
                try
                {
                    action();
                }
                catch (System.Exception)
                {
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ex"></param>
        public static void WriteToEventLog(this System.Exception ex, string source)
        {
            source.CheckStringIsNullOrEmpty("source");
            ex.NullCheck("ex");

            DoSilentAction(() => EventLog.WriteEntry(source, BuildExceptionWithEnvironmentInfo(ex)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entryType"></param>
        /// <param name="ex"></param>
        public static void WriteToEventLog(this System.Exception ex, string source, EventLogEntryType entryType)
        {
            source.CheckStringIsNullOrEmpty("source");
            ex.NullCheck("ex");

            DoSilentAction(() => EventLog.WriteEntry(source, BuildExceptionWithEnvironmentInfo(ex), entryType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="entryType"></param>
        /// <param name="eventID"></param>
        /// <param name="ex"></param>
        public static void WriteToEventLog(this System.Exception ex, string source, EventLogEntryType entryType, int eventID)
        {
            source.CheckStringIsNullOrEmpty("source");
            ex.NullCheck("ex");

            DoSilentAction(() => EventLog.WriteEntry(source, BuildExceptionWithEnvironmentInfo(ex), entryType, eventID));
        }

        private static string BuildExceptionWithEnvironmentInfo(System.Exception ex)
        {
            StringBuilder strB = new StringBuilder();

            using (StringWriter sw = new StringWriter(strB))
            {
                sw.WriteLine(GetEnvironmentInfo());
                sw.WriteLine(ex.ToString());
            }

            return strB.ToString();
        }

        private static string GetEnvironmentInfo()
        {
            string envInfo = string.Empty;

            if (HostingEnvironment.IsHosted)
                envInfo = HostingEnvironment.ApplicationVirtualPath;
            else
                envInfo = AppDomain.CurrentDomain.SetupInformation.ApplicationName;

            return envInfo;
        }
    }
}
