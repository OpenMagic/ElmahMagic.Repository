using System;
using System.Collections.Generic;
using EmptyStringGuard;
using NullGuard;
using ValidationFlags = NullGuard.ValidationFlags;

namespace ElmahMagic.Repository
{
    [NullGuard(ValidationFlags.None)]
    [EmptyStringGuard(EmptyStringGuard.ValidationFlags.None)]
    public class ErrorRecord
    {
        public ErrorRecord(DateTime whenUtc, string message, string applicationName, IReadOnlyCollection<KeyValueItem> cookies, string detail, IReadOnlyCollection<KeyValueItem> data, IReadOnlyCollection<KeyValueItem> form, string hostName, IReadOnlyCollection<KeyValueItem> queryString, IReadOnlyCollection<KeyValueItem> serverVariables, string source, int statusCode, string type, string user, string webHostHtmlMessage)
        {
            ApplicationName = applicationName;
            Cookies = cookies;
            WhenUtc = whenUtc;
            Detail = detail;
            Data = data;
            Form = form;
            HostName = hostName;
            Message = message;
            QueryString = queryString;
            ServerVariables = serverVariables;
            Source = source;
            StatusCode = statusCode;
            Type = type;
            User = user;
            WebHostHtmlMessage = webHostHtmlMessage;
        }

        public string ApplicationName { get; private set; }
        public IReadOnlyCollection<KeyValueItem> Cookies { get; private set; }
        public DateTime WhenUtc { get; private set; }
        public string Detail { get; private set; }
        public IReadOnlyCollection<KeyValueItem> Data { get; private set; }
        public IReadOnlyCollection<KeyValueItem> Form { get; private set; }
        public string HostName { get; private set; }
        public string Message { get; private set; }
        public IReadOnlyCollection<KeyValueItem> QueryString { get; private set; }
        public IReadOnlyCollection<KeyValueItem> ServerVariables { get; private set; }
        public string Source { get; private set; }
        public int StatusCode { get; private set; }
        public string Type { get; private set; }
        public string User { get; private set; }
        public string WebHostHtmlMessage { get; set; }
    }
}