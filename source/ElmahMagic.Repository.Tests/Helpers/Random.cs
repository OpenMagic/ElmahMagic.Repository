using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using Elmah;
using ElmahMagic.Repository.Helpers;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public static class Random
    {
        private static readonly System.Random Rnd = new System.Random();

        public static DateTime When => DateTime;
        public static string Message => String();
        public static string ApplicationName => String();
        public static IReadOnlyCollection<KeyValueItem> Cookies => KeyValueCollection;
        public static string Detail => String();
        public static IReadOnlyCollection<KeyValueItem> Data => KeyValueCollection;
        public static IReadOnlyCollection<KeyValueItem> Form => KeyValueCollection;
        public static string HostName => String();
        public static IReadOnlyCollection<KeyValueItem> QueryString => KeyValueCollection;
        public static IReadOnlyCollection<KeyValueItem> ServerVariables => KeyValueCollection;
        public static string Source => String();

        public static int StatusCode => RandomValue(typeof (HttpStatusCode).GetEnumValues().Cast<int>());

        public static string Type => String();
        public static string User => String();

        public static string WebHostHtmlMessage => String();

        private static DateTime DateTime
        {
            get
            {
                var maximumDays = DateTime.MaxValue.Subtract(DateTime.MinValue).TotalDays;
                var randomDays = RandomDouble(0, maximumDays);

                return DateTime.MinValue.AddDays(randomDays);
            }
        }

        private static IReadOnlyCollection<KeyValueItem> KeyValueCollection
        {
            get
            {
                var itemCount = RandomInteger(0, 100);
                var items = new List<KeyValueItem>();

                for (var i = 0; i < itemCount; i++)
                {
                    items.Add(KeyValueItem);
                }

                return new ReadOnlyCollection<KeyValueItem>(items);
            }
        }

        private static KeyValueItem KeyValueItem => new KeyValueItem(Key, Value);
        private static string Key => String(1, 40);
        private static string Value => String(1, 1000);

        public static ErrorRecord ErrorRecord => new ErrorRecord(
            When,
            Message,
            ApplicationName,
            Cookies,
            Detail,
            Data,
            Form,
            HostName,
            QueryString,
            ServerVariables,
            Source,
            StatusCode,
            Type,
            User,
            WebHostHtmlMessage);

        public static Error ElmahError
        {
            get
            {
                var error = new Error(Exception)
                {
                    ApplicationName = ApplicationName,
                    Source = Source,
                    StatusCode = StatusCode,
                    User = User,
                    WebHostHtmlMessage = WebHostHtmlMessage
                };
                
                error.Cookies.AddKeyValueCollection(Cookies);
                error.Form.AddKeyValueCollection(Form);
                error.QueryString.AddKeyValueCollection(QueryString);
                error.ServerVariables.AddKeyValueCollection(ServerVariables);

                return error;
            }
        }

        public static Exception Exception => new DummyException(Message);

        private static T RandomValue<T>(IEnumerable<T> values)
        {
            var array = values as T[] ?? values.ToArray();

            return array.ToArray()[RandomInteger(0, array.Length)];
        }

        private static int RandomInteger(int inclusiveMinimum, int exclusiveMaximum)
        {
            return Rnd.Next(inclusiveMinimum, exclusiveMaximum);
        }

        private static double RandomDouble(double inclusiveMinimum, double exclusiveMaximum)
        {
            var value = Rnd.NextDouble();

            while (value < inclusiveMinimum || value >= exclusiveMaximum)
            {
                value = Rnd.NextDouble();
            }

            return value;
        }

        private static string String(int maxLength = 1000)
        {
            return String(0, maxLength);
        }

        private static string String(int minLength, int maxLength)
        {
            var randomLength = RandomInteger(minLength, maxLength + 1);

            if (randomLength == 0)
            {
                return null;
            }

            var sb = new StringBuilder();
            const string keyboard = "`1234567890-=~!@#$%^&*()_+qwertyuiop[]\\QWERTYUIOP{}|asdfghjkl;'ASDFGHJKL:\"zxcvbnm,./ZXCVBNM<>?";
            var keyboardLength = keyboard.Length;

            for (var i = 0; i < randomLength; i++)
            {
                sb.Append(keyboard[RandomInteger(0, keyboardLength)]);
            }

            return sb.ToString();
        }
    }
}