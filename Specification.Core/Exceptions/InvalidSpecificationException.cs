using System.Runtime.Serialization;

namespace Specification.Core.Exceptions;

[Serializable]
public class InvalidSpecificationException : Exception
{
    public InvalidSpecificationException(string message)
        : base(message)
    {
    }

    protected InvalidSpecificationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}