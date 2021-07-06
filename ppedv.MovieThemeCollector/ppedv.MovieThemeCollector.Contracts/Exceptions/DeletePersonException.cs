using System;

namespace ppedv.MovieThemeCollector.Contracts.Exceptions
{
    public class DeletePersonException : Exception
    {
        public Person Person { get; }

        public DeletePersonException(Person person, string message) : base(message)
        {
            Person = person;
        }
    }
}
