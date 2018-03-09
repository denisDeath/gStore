using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace gs.api.contracts
{
    /// <summary>
    /// Базовый класс для пользовательского исключения.
    /// </summary>
    [DataContract]
    public class ApiException : Exception
    {
        /// <summary>
        /// Признак, что произошло пользовательское исключение.
        /// Вставляется как заголовок в http-ответ.
        /// </summary>
        public const string ApiExceptionHeaderSign = "ApiExceptionType";
        
        public ApiException([CanBeNull] string message = null)
            : base(message)
        {
        }

        /// <summary>
        /// Свойство-обёртка для базового свойства Message. Необходимо для сериализации сообщения. 
        /// </summary>
        [CanBeNull]
        [DataMember]
        public override string Message => base.Message;

//        /// <summary>
//        /// Свойство-обёртка для базового свойства StackTrace. Необходимо для сериализации сообщения. 
//        /// </summary>
//        [CanBeNull]
//        [DataMember]
//        public override string StackTrace => base.StackTrace;
    }
}