using System;
using System.Collections.Generic;
using System.Text;

namespace KS_Standard
{
    public class Messages
    {
        public const char CHAR_OPEN = '[';
        public const char CHAR_CLOSE = ']';

        public class Message
        {
            public int code;
            public string message;
            public Type type;
        }

        public enum Type
        {
            Success,
            Error,
            Warning,
            Undefined,
        }

        /// <summary>
        /// Transforma a mensagem no objeto message.
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <returns></returns>
        public static Message Values(string message)
        {
            return new Message
            {
                code = GetCode(message),
                message = GetMessage(message),
                type = GetType(message)
            };
        }

        private static Type CharToType(char letter)
        {
            switch(letter)
            {
                case 'E': return Type.Error;
                case 'S': return Type.Success;
                case 'W': return Type.Warning;
                default: return Type.Undefined;
            }
        }

        private static string GetMessage(string message)
        {
            var posini = message.IndexOf(CHAR_OPEN);
            var posfin = message.IndexOf(CHAR_CLOSE);

            return message.Substring(posfin);
        }

        private static Type GetType(string message)
        {
            var posini = message.IndexOf(CHAR_OPEN);
            var posfin = message.IndexOf(CHAR_CLOSE);

            var foo = char.Parse(message.Substring(posini, 1));

            return CharToType(foo);
        }

        private static int GetCode(string message)
        {
            var posini = message.IndexOf(CHAR_OPEN);
            var posfin = message.IndexOf(CHAR_CLOSE);

            var foo = new To(message.Substring(posini, posini - posfin));

            return int.Parse(foo.OnlyNumbers());
        }
    }
}
