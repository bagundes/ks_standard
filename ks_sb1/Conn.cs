
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SAPbobsCOM;

namespace ks_sb1
{
    public partial class Conn
    { 
        public class ConnParam
        {
            public BoDataServerTypes DServerType;
            public string Server;
            public string LicServer;
            public string DBCompany;
            public string DBUser;
            public string DBPasswd;
            public string Username;
            public string Passwd;
        }

        public SAPbobsCOM.Company DI { get => oCompany; }
        public SAPbouiCOM.Application IU { get => oApplication; }

        private SAPbobsCOM.Company oCompany;
        private SAPbouiCOM.Application oApplication;

        /// <summary>
        /// Criar uma instancia global de conexão.
        /// </summary>
        /// <param name="param"></param>
        public void StartCompany(ConnParam param)
        {
            oCompany = new SAPbobsCOM.Company();
            oCompany.DbServerType = param.DServerType;
            oCompany.Server = param.Server;
            oCompany.LicenseServer = param.LicServer;
            oCompany.CompanyDB = param.DBCompany;
            oCompany.DbPassword = param.DBPasswd;
            oCompany.UserName = param.Username;
            oCompany.Password = param.Passwd;


            if (oCompany.Connect() != 0)
                throw new KS_Standard.KSException(messages.m000001_2, param.Server, oCompany.GetLastErrorDescription());

        }

        /// <summary>
        /// 
        /// </summary>
        public void StartApp()
        {
        }
    }

    public partial class Conn
    {
        
    }
}