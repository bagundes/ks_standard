using System;
using System.Collections.Generic;
using System.Text;

namespace KS_Standard
{
    public class KSException : Exception
    {
        private int code;
        private string message;

        //enum SAPMessage { StatusBar, MessageBox, All }

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public override string Message
        {
            get { return message; }
        }

        /// <summary>
        /// Código do erro
        /// </summary>
        public int Code
        {
            get { return code; }
        }
        public string MsgExcepstion { get; set; }



        public KSException(string message, params object[] args) : base(message)
        {
            this.message = String.Format(message, args);
        }

        public KSException(Exception ex, string message, params object[] args) : base(message)
        {
            var oMethodBase = ex.TargetSite;
            var oType = oMethodBase.DeclaringType;
        }

        public KSException(System.Reflection.MethodBase oMb, string message, params object[] args) : base(message)
        {
            var oMethodBase = System.Reflection.MethodBase.GetCurrentMethod();
            var oType = oMethodBase.DeclaringType;
        }

        public KSException(Exception ex)
        {
            
        }
    }
}
