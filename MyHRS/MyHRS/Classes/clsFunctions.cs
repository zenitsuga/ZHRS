using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace MyHRS.Classes
{
    public class clsFunctions
    {
        clsDatabase cd = new clsDatabase();

        public Form frm;
        public SqlConnection SQLConn;

        #region SaveRecords

        public bool SaveApplicant(List<PersonalProfile> PP)
        {
            bool result = false;
            try
            {
                string SQLQuery = "declare @p6 int " +
                                  "  set @p6=1 " +
                                  "  exec spApplicantInfo_SaveUpdate " +
                                  "  @FormAction=N'Add', " +
                                  "  @id=N'', " +
                                  "  @LastName=N'Santos', " +
                                  "  @FirstName=N'Erwan', " +
                                  "  @MiddleName=N'Lacsamana', " +
                                  "  @Suffix=18, " +
                                  "  @EmailAddress=N'test@test.com', " +
                                  "  @CivilStatus=1, " +
                                  "  @gender=1, " +
                                  "  @Nationality=1, " +
                                  "  @BirthDate=N'01 Jan 86', " +
                                  "  @BirthPlace=N'Muntinlupa', " +
                                  "  @MobileNumber1=N'09123456789', " +
                                  "  @MobileNumber2=N'', " +
                                  "  @MobileNumber3=N'', " +
                                  "  @PhoneNumber=N'', " +
                                  "  @religion=1, " +
                                  "  @Height=N'', " +
                                  "  @Weight=N'', " +
                                  "  @BloodType=1, " +
                                  "  @MarriageDate=N'22 Jun 2005', " +
                                  "  @MarriagePlace=N'Alabang', " +
                                  "  @PresentAddressStreet=N'123 Rizal St.', " +
                                  "  @PresentAddressBrgy=N'Brgy. San Juan', " +
                                  "  @PresentAddressCity=N'Muntinlupa', " +
                                  "  @PresentAddressPostal=N'1808', " +
                                  "  @PermanentAddressStreet=N'123 Rizal St.', " +
                                  "  @PermanentAddressBrgy=N'Brgy. San Juan', " +
                                  "  @PermanentAddressCity=N'Muntinlupa', " +
                                  "  @PermanentAddressPostal=N'1808', " +
                                  "  @ApplicationDate=N'04 Mar 18', " +
                                  "  @Application_Type=1, " +
                                  "  @Applicant_Status=1, " +
                                  "  @CreatedBy=N'layla', " +
                                  "  @ModifiedDate=N'20 Nov 18', " +
                                  "  @ModifyBy=N'layla', " +
                                  "  @newID=@p6 output " +
                                  "  select @p6";
               DataTable dtResult = cd.ExecuteQuery(SQLQuery);
               if (isInteger(dtResult.Rows[0][0].ToString()))
               {
                   int ResultID = int.Parse(dtResult.Rows[0][0].ToString());
                   if (ResultID > 0)
                   {
                       result = true;
                   }
               }
            }
            catch
            {
            }
            return result;
        }

        #endregion

        #region Generics

        public int GetComboID(ComboBox cmb)
        {
            int result = 0;
            try
            {
                DataRowView drv = (DataRowView)cmb.SelectedItem;
                result = isInteger(drv["id"].ToString()) ? int.Parse(drv["id"].ToString()):0;
            }
            catch
            {
            }
            return result;
        }

        public DataTable dtGetSelectRecord(string SPName)
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteSP(SPName);
            }
            catch
            {
            }
            return dtResult;
        }

        public DataTable dtGetSelectRecord(string SPName,string SQLQuery)
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteSP(SPName + "\"" + SQLQuery + "\"");
            }
            catch
            {
            }
            return dtResult;
        }

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

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Yellow;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            string[] NotEmpty = new string[] {"tbLastName","tbFirstName"};
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            if (NotEmpty.Contains(tb.Name))
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.BackColor = Color.Red;
                    tb.Focus();
                }
            }
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
                                            tb.Enter += new EventHandler(tb_Enter);
                                            tb.Leave += new EventHandler(tb_Leave);
                                            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                                            tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                                        }
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "combobox")
                                        {
                                            ComboBox cb = (ComboBox)TbCtrl;
                                            cb.Enabled = status;
                                            cb.Enter += new EventHandler(cb_Enter);
                                            cb.Leave += new EventHandler(cb_Leave);
                                            cb.KeyPress += new KeyPressEventHandler(cb_KeyPress);
                                            cb.KeyDown += new KeyEventHandler(cb_KeyDown);
                                        }
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "datetimepicker")
                                        {
                                            DateTimePicker dtpick = (DateTimePicker)TbCtrl;
                                            dtpick.Enabled = status;
                                            dtpick.Enter += new EventHandler(dtpick_Enter);
                                        }
                                        if (TbCtrl.GetType().Name.ToString().ToLower() == "groupbox")
                                        {
                                            GroupBox gb = (GroupBox)TbCtrl;
                                            foreach (Control ctrlGB in gb.Controls)
                                            {
                                                if (ctrlGB.GetType().Name.ToString().ToLower() == "textbox")
                                                {
                                                    TextBox tbGB = (TextBox)ctrlGB;
                                                    tbGB.Enabled = status;
                                                    tbGB.Enter += new EventHandler(tb_Enter);
                                                    tbGB.Leave += new EventHandler(tb_Leave);
                                                    tbGB.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                                                    tbGB.KeyDown +=new KeyEventHandler(tb_KeyDown);
                                                }
                                            }
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

        void dtpick_Enter(object sender, EventArgs e)
        {
            
        }

        void cb_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = Color.White;
        }

        void cb_Enter(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = Color.Yellow;
        }

        void cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                ComboBox cb = (ComboBox)sender;
                frm.SelectNextControl(cb, false, true, true, true);
            }
        }

        void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ComboBox cb = (ComboBox)sender;
                frm.SelectNextControl(cb, true, true, true, true);
            }
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    TextBox tb = (TextBox)sender;
                    frm.SelectNextControl(tb, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    TextBox tb = (TextBox)sender;
                    frm.SelectNextControl(tb, false, true, true, true);
                }
                else
                    return;
            }
            else
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    frm.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    frm.SelectNextControl(ctrl, false, true, true, true);
                }
                else
                    return;
            }

        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
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
