using System;
using System.Net;
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
        
        public ApiException(string message = null, HttpStatusCode? exceptionStatusCode = null)
            : base(message)
        {
            ExceptionStatusCode = exceptionStatusCode ?? HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// Свойство-обёртка для базового свойства Message. Необходимо для сериализации сообщения. 
        /// </summary>
        [CanBeNull]
        [DataMember]
        public override string Message => base.Message;
        
        /// <summary>
        /// Http-код, с которым должен возвращаться ответ при текущем исключении.
        /// По умолчанию 400.
        /// </summary>
        public HttpStatusCode ExceptionStatusCode { get; }
    }
}