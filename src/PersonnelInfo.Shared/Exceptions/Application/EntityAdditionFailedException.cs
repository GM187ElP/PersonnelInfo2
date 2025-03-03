using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Shared.Exceptions.Application;

public class EntityAdditionFailedException : Exception
{
    public EntityAdditionFailedException()
    {
    }

    public EntityAdditionFailedException(string? message) : base(message)
    {
    }

    public EntityAdditionFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityAdditionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
