using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyHRS.Classes
{
    public class clsFunctions
    {
        clsDatabase cd = new clsDatabase();

        public SqlConnection SQLConn;

        #region Generics

        public bool isInteger(string IntegerValue)
        {
            bool result = false;
            try
            {
                int value = int.Parse(IntegerValue);
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool isChildFormLoaded(string FormName)
        {
            bool result = false;

            try
            {
                Form fc = Application.OpenForms[FormName];
                if (fc == null)
                    result = true;
            }
            catch
            {
            }
            return result;
        }

        public void ControlObjects(bool status, GroupBox gp)
        {
            try
            {
                foreach (Control ctrlpanel in gp.Controls)
                {
                    if (ctrlpanel.GetType().Name.ToString() == "Panel")
                    {
                        foreach (Control tbPanel in ctrlpanel.Controls)
                        {
                            if (tbPanel.GetType().Name.ToString() == "Panel")
                            {
                                if (tbPanel.Name.Contains("_"))
                                {
                                    foreach (Control TbCtrl in tbPanel.Controls)
                                    {
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "textbox")
                                        {
                                            TextBox tb = (TextBox)TbCtrl;
                                            tb.Enabled = status;
                                        }
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "combobox")
                                        {
                                            ComboBox cb = (ComboBox)TbCtrl;
                                            cb.Enabled = status;
                                        }
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "datetimepicker")
                                        {
                                            DateTimePicker dtpick = (DateTimePicker)TbCtrl;
                                            dtpick.Enabled = status;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Application_Profile
        public int GetNewID()
        {
            int result = 0;
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                DataTable dtResult = cd.ExecuteSP("sp_GetApplicant_Status");
                if (dtResult.Rows.Count > 0)
                {
                    result = isInteger(dtResult.Rows[0][0].ToString()) ? int.Parse(dtResult.Rows[0][0].ToString()):0;
                }
            }
            catch
            {
            }
            return result;
        }

        public DataTable dtGetApplicantStatus()
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteSP("sp_GetApplicant_Status");              
            }
            catch
            {
            }
            return dtResult;
        }
        public DataTable dtGetApplicationType()
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteSP("sp_GetApplication_Type");
            }
            catch
            {
            }
            return dtResult;
        }
        #endregion
    }
}
