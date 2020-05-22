using System;

namespace Mesi.Io.Api.User.Except
{
    public class EmailAlreadyRegisteredException : Exception
    {
    }
    
    public class UserNameAlreadyRegisteredException : Exception
    {
    }

    public class InvalidInputException : Exception {}
}