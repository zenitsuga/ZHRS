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
        public string Username;
        public SqlConnection SQLConn;

        #region ShowApplicant

        public DataTable dtGetApplicantRecord(int ID)
        {
            DataTable dtRecords = new DataTable();
            try
            {
                dtRecords = dtGetSelectRecords("exec sp_GetApplicantListLoadRecord '" + ID + "'");
            }
            catch
            {
            }
            return dtRecords;
        }
        public DataTable dtGetApplicantlist(int ID)
        {
            DataTable dtRecords = new DataTable();
            try
            {
                dtRecords = dtGetSelectRecords("exec sp_GetApplicantList 'ALL'");
                if (ID > 0)
                {
                    DataView dvViewRecord = new DataView(dtRecords);
                    dvViewRecord.RowFilter = "id=" + ID;
                    if (dvViewRecord.ToTable().Rows.Count == 1)
                    {
                        dtRecords = dvViewRecord.ToTable();
                    }
                }
            }
            catch
            {
            }
            return dtRecords;
        }

        #endregion

        #region SaveRecords

        public bool SaveApplicant(List<PersonalProfile> PP,string instruction)
        {
            bool result = false;
            try
            {
                foreach(PersonalProfile PerPro in PP)
                {
                    string SQLQuery = "declare @p6 int " +
                                      "  set @p6=1 " +
                                      "  exec spApplicantInfo_SaveUpdate " +
                                      "  @FormAction=N'"+ instruction +"', " +
                                      "  @id=N'', " +
                                      "  @LastName=N'" + PerPro.Lastname + "', " +
                                      "  @FirstName=N'" + PerPro.Firstname + "', " +
                                      "  @MiddleName=N'" + PerPro.Middlename + "', " +
                                      "  @Suffix=" + PerPro.suffix + ", " +
                                      "  @EmailAddress=N'" + PerPro.EmailAddress + "', " +
                                      "  @CivilStatus=" + PerPro.CivilStaus + ", " +
                                      "  @gender=" + PerPro.Gender + ", " +
                                      "  @Nationality=" + PerPro.Nationality + ", " +
                                      "  @BirthDate=N'" + PerPro.BirthDate + "', " +
                                      "  @BirthPlace=N'" + PerPro.BirthPlace + "', " +
                                      "  @MobileNumber1=N'" + PerPro.MobileNumber1 + "', " +
                                      "  @MobileNumber2=N'" + PerPro.MobileNumber2 + "', " +
                                      "  @MobileNumber3=N'" + PerPro.MobileNumber3 + "', " +
                                      "  @PhoneNumber=N'" + PerPro.PhoneNumber +"', " +
                                      "  @religion="+ PerPro.Religion +", " +
                                      "  @Height=N'"+ PerPro.Height +"', " +
                                      "  @Weight=N'"+ PerPro.Weight +"', " +
                                      "  @BloodType="+ PerPro.BloodType +", " +
                                      "  @MarriageDate=N'"+ PerPro.Marriage_Date +"', " +
                                      "  @MarriagePlace=N'"+ PerPro.Marriage_Place +"', " +
                                      "  @PresentAddressStreet=N'"+ PerPro.Present_Address_street +"', " +
                                      "  @PresentAddressBrgy=N'"+ PerPro.Present_Address_brgy +"', " +
                                      "  @PresentAddressCity=N'"+ PerPro.Present_Address_city +"', " +
                                      "  @PresentAddressPostal=N'"+ PerPro.Present_Address_postal +"', " +
                                      "  @PermanentAddressStreet=N'"+ PerPro.Permanent_Address_street +"', " +
                                      "  @PermanentAddressBrgy=N'"+ PerPro.Permanent_Address_brgy +"', " +
                                      "  @PermanentAddressCity=N'"+ PerPro.Permanent_Address_city +"', " +
                                      "  @PermanentAddressPostal=N'"+ PerPro.Permanent_Address_postal +"', " +
                                      "  @ApplicationDate=N'"+ PerPro.applicationDate +"', " +
                                      "  @Application_Type="+ PerPro.applicationType +", " +
                                      "  @Applicant_Status="+ PerPro.applicationStatus +", " +
                                      "  @CreatedBy=N'" + (string.IsNullOrEmpty(Username) ? Username : "system") + "', " +
                                      "  @ModifiedDate=N'', " +
                                      "  @ModifyBy=N'"+ (string.IsNullOrEmpty(Username) ? Username:"system")  +"', " +
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

        public bool executeSP(string SPName)
        {
            bool result = false;
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                result = cd.ExecuteNonQuery(SPName);
            }
            catch
            {
            }
            return result;
        }

        public DataTable dtGetSelectRecords(string Query)
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteQuery(Query);
            }
            catch
            {
            }
            return dtResult;
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

        public void clearTextboxEvent(Form FrmName)
        {
            try
            {
                foreach (Control ctrl in FrmName.Controls)
                {
                    if (ctrl is GroupBox)
                    {
                        GroupBox gb = (GroupBox)ctrl;
                        foreach (Control cgb in gb.Controls)
                        {
                            if (cgb is TextBox)
                            {
                                TextBox tb = (TextBox)cgb;
                                tb.Text = string.Empty;
                            }
                        }
                    }
                    else if (ctrl is TextBox)
                    {
                        TextBox tb = (TextBox)ctrl;
                        tb.Text = string.Empty;
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Application_Profile
        public bool checkID(int ID)
        {
            bool result = false;
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                DataTable dtResult = cd.ExecuteQuery("exec sp_GetApplicantListLoadRecord '" + ID + "'");
                if (dtResult.Rows.Count == 1)
                {
                    result = true;
                }
            }
            catch
            {
            }
            return result;
        }
        public int GetNewID()
        {
            int result = 0;
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                DataTable dtResult = cd.ExecuteQuery("exec sp_GetapplicantList 'All'");
                if (dtResult.Rows.Count > 0)
                {
                    result = isInteger(dtResult.Rows[dtResult.Rows.Count - 1][0].ToString()) ? int.Parse(dtResult.Rows[dtResult.Rows.Count - 1][0].ToString()) : 0;
                    if (result != 0)
                    {
                        result++;
                    }
                }
                else
                {
                    if(dtResult.Rows.Count == 0)
                    result++;
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

        #region Applicant Search

        public void TextboxEvent(Form FrmName)
        {
            try
            {
                foreach (Control ctrl in FrmName.Controls)
                {
                    if (ctrl is GroupBox)
                    {
                        GroupBox gb = (GroupBox)ctrl;
                        foreach (Control cgb in gb.Controls)
                        {
                            if (cgb is TextBox)
                            {
                                TextBox tb = (TextBox)cgb;
                                tb.Enter +=new EventHandler(tb_Enter);
                                tb.Leave +=new EventHandler(tb_Leave);
                            }
                        }
                    }
                    else if (ctrl is TextBox)
                    {
                        TextBox tb = (TextBox)ctrl;
                        tb.Enter += new EventHandler(tb_Enter);
                        tb.Leave += new EventHandler(tb_Leave);
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Masterlist_employee
        public DataTable dtGetEmployeeStatus()
        {
            DataTable dtResult = new DataTable();
            try
            {
                cd.SQLConn = SQLConn;
                cd.SQLType = "sql";
                dtResult = cd.ExecuteSP("sp_GetEmployeeStatus");
            }
            catch
            {
            }
            return dtResult;
        }
        #endregion
    }
}
