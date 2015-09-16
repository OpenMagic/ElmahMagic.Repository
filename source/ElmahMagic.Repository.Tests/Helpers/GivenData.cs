using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Elmah;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public class GivenData
    {
        public IDictionary Dictionary { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
        public TypeCode TypeCode { get; set; }
        public NameValueCollection NameValueCollection { get; set; }
        public Error Error { get; set; }
        public string ErrorId { get; set; }
        public IErrorRepository ErrorRepository { get; set; }
        public RepositoryErrorLog ErrorLog { get; set; }
        public int TotalErrorCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<ErrorLogEntry> ErrorEntryList { get; set; }
        public int ExpectedErrorCount { get; set; }
    }
}