using System;

namespace gs.api.contracts
{
    /// <summary>
    /// Атрибут, указывающий, что метод, к которому атрибут прикреплён, может вызывать
    /// исключение типа <see cref="PossibleExceptionType"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method, AllowMultiple = true)] 
    public class ThrowsAttribute : Attribute
    {
        public ThrowsAttribute(Type possibleExceptionType)
        {
            PossibleExceptionType = possibleExceptionType;
        }

        public Type PossibleExceptionType { get; }
    }
}