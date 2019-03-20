using Asap.Library.Core;
using System;
using System.Net;
namespace Asap.Library.Model
{
    [Serializable]
    [XElementSerializable]
    public class LogOnIdentity
    {
        private string logOnName = string.Empty;
        private string logOnNameWithoutDomain = string.Empty;
        private string domain = string.Empty;
        private string password = string.Empty;

    
        public LogOnIdentity()
        {
        }

     
        public LogOnIdentity(string logonName)
        {
            LogOnName = logonName;
        }

      
        public LogOnIdentity(string logonUserName, string pwd)
        {
            LogOnName = logonUserName;

            this.password = pwd;
        }

       
        public LogOnIdentity(string logonUserName, string pwd, string logonDomain)
        {
            LogOnName = logonUserName;

            this.password = pwd;
            if (string.IsNullOrEmpty(logonDomain) == false)
                this.domain = logonDomain;
        }

      
        public string LogOnName
        {
            get
            {
                return this.logOnName;
            }
            set
            {
                this.logOnName = value;
                AnalysisLogOnName(this.logOnName);
            }
        }

       
        public string LogOnNameWithoutDomain
        {
            get
            {
                return this.logOnNameWithoutDomain;
            }
        }

       
        public string LogOnNameWithDomain
        {
            get
            {
                string result = this.logOnNameWithoutDomain;

                if (string.IsNullOrEmpty(this.domain) == false)
                {
                    if (this.domain.IndexOf(".") >= 0)
                        result = this.logOnNameWithoutDomain + "@" + this.domain;
                    else
                        result = this.domain + "\\" + this.logOnNameWithoutDomain;
                }

                return result;
            }
        }

       
        public string Domain
        {
            get
            {
                return this.domain;
            }
        }

      
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

       
        public NetworkCredential ToNetworkCredentials()
        {
            return new NetworkCredential(this.LogOnNameWithoutDomain, this.Password, this.Domain);
        }

        private void AnalysisLogOnName(string strLogOnName)
        {
            this.logOnNameWithoutDomain = string.Empty;
            this.domain = string.Empty;

            if (string.IsNullOrEmpty(strLogOnName) == false)
            {
                string[] nameParts = strLogOnName.Split('/', '\\');

                string strNameWithoutDomain = string.Empty;

                if (nameParts.Length > 1)
                {
                    this.domain = nameParts[0];
                    strNameWithoutDomain = nameParts[1];
                }
                else
                    strNameWithoutDomain = nameParts[0];

                string[] nameParts2 = strNameWithoutDomain.Split('@');

                this.logOnNameWithoutDomain = nameParts2[0];

                if (nameParts2.Length > 1)
                    if (string.IsNullOrEmpty(this.domain))
                        this.domain = nameParts2[1];
            }
        }
    }
}
