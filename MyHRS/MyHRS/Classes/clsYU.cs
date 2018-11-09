
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using Licensing;
using MyHRS.Classes;
using System.Management;
using System.Data.SqlClient;
using System.Data;

namespace MyHRS.Classes
{
    public class clsYU
    {
        clsDatabase cd = new clsDatabase();
        clsIni ci;

        string m_ExePath;
        string m_LogName;

        public DataTable GetDTRecords(string Query,SqlConnection sqlconn)
        {
            DataTable result = new DataTable();
            try
            {
                cd.SQLConn = sqlconn;
                cd.SQLType = "sql";
                result = cd.ExecuteQuery(Query);
            }
            catch
            {
            }
            return result;
        }

        public bool WriteIniValue(string IniFields,string FieldValue, string SectionName)
        {
            bool result = false;
            try
            {
                ci = new clsIni(Environment.CurrentDirectory + "\\Settings.ini");
                ci.Write(IniFields, FieldValue, SectionName);
                result = true;
            }
            catch
            {
            }
            return result;
        }
        public string IniValue(string IniFields,string SectionName)
        {
            string result = string.Empty;
            try
            {
                ci = new clsIni(Environment.CurrentDirectory + "\\Settings.ini");
                result = ci.Read(IniFields, SectionName);
            }
            catch(Exception ex)
            {
                LogWrite(ex.Message, "Read Ini Value:(" + IniFields + ")", "Error");
            }
            return result;
        }

        public bool CheckEvalFile(bool isCheck)
        {
            bool result = false;
            try
            {
                string FileEval = Environment.CurrentDirectory + "\\" + GetEncryptWord("Eval");
                if (!File.Exists(FileEval))
                {
                    File.Create(FileEval);
                    result = true;
                }
            }
            catch (Exception)
            {
                
            }
            return result;
        }

        public string GetMachineID()
        {
            string result = string.Empty;
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (result == "")
                    {
                        //Get only the first CPU's ID
                        result = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }
                return result ;
            }
            catch
            {
            }
            return result;
        }
        public string GetDecryptWord(string StrVal)
        {
            string result = string.Empty;
            try
            {
                string Keys = Licensing.CryptoEngine.Key();
                result = Licensing.CryptoEngine.Decrypt(StrVal, Keys);
            }
            catch
            {
            }
            return result;
        }
        public string GetEncryptWord(string StrVal)
        {
            string result = string.Empty;
            try
            {
              string Keys = Licensing.CryptoEngine.Key();
              result = Licensing.CryptoEngine.Encrypt(StrVal, Keys);
            }
            catch
            {
            }
            return result;
        }

        public bool CheckDatabaseConnection(string ServerName, string Databasename, string Username, string Password)
        {
            bool result = false;
            string ErrMsg = string.Empty;
            try
            {
                cd.SQLType = "sql";
                result = cd.TestConnection(ServerName, Databasename, Username, Password, ref ErrMsg);
                if (!string.IsNullOrEmpty(ErrMsg))
                {
                    LogWrite(ErrMsg, "CheckDatabaseConnection", "Error");
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message.ToString();
                LogWrite(ErrMsg, "CheckDatabaseConnection", "Error");
            }
            return result;
        }

        public bool CheckDatabaseConnection(string ServerName,string Databasename,string Username,string Password,ref SqlConnection sqlconn)
        {
            bool result = false;
            string ErrMsg = string.Empty;
            try
            {
                cd.SQLType = "sql";
                result = cd.TestConnection(ServerName, Databasename, Username, Password,ref ErrMsg,ref sqlconn);
                if (!string.IsNullOrEmpty(ErrMsg))
                {
                    LogWrite(ErrMsg, "CheckDatabaseConnection", "Error");
                }
            }
            catch(Exception ex)
            {
                ErrMsg = ex.Message.ToString();
                LogWrite(ErrMsg, "CheckDatabaseConnection", "Error");
            }
            return result;
        }

        public bool isValidLicense(ref string SerialKey,string AccessCode,ref int daysRemain)
        {
            bool result = false;
            try
            {
                string GetIniSerialKey = IniValue("SerialKey", "Codes");
                if (!string.IsNullOrEmpty(GetIniSerialKey))
                {
                    string DecryptKey = GetDecryptWord(GetIniSerialKey);
                    if (DecryptKey.Contains("_"))
                    {
                        if (DecryptKey.Split('_').Count() == 3)
                        {
                            if (AccessCode == DecryptKey.Split('_')[0].Trim())
                            {
                                DateTime dtLast = DateTime.Parse(DecryptKey.Split('_')[2].Trim());
                                daysRemain = dtLast.Subtract(DateTime.Now).Days;
                                result = true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public void Control_TextboxError(TextBox tb)
        {
            try
            {
                tb.BackColor = Color.Red;
            }
            catch
            {
            }
        }

        public void LogWrite(string logMessage,string ModuleName,string TypeLog)
        {
            m_ExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs";

            if (!Directory.Exists(m_ExePath))
            {
                Directory.CreateDirectory(m_ExePath);
            }

            if (TypeLog == "Error")
            {
                m_LogName = "Err_" + DateTime.Now.ToString("MMddyyyy");
            }
            else
            {
                m_LogName = "Log_" + DateTime.Now.ToString("MMddyyyy");
            }
            try
            {
                using (StreamWriter w = File.AppendText(m_ExePath + "\\" + m_LogName))
                {
                    Log(TypeLog,logMessage,ModuleName, w);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Log(string LogType,string logMessage,string ModuleName, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0}:\t{1}:\t{2}:\t{3}", LogType, DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"), ModuleName, logMessage);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
