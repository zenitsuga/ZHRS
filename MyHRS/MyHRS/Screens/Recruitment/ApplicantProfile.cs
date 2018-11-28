using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyHRS.Classes;
using System.Data.SqlClient;

namespace MyHRS.Screens.Recruitment
{
    public partial class ApplicantProfile : Form
    {
        clsFunctions cf = new clsFunctions();

        public SqlConnection Sconn;

        public ApplicantProfile()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PanelControl(Button btnPnl,Panel ModulePanel,int HeightMax)
        {
            if (btnPnl.Height != ModulePanel.Height)
            {
                ModulePanel.Height = btnPnl.Height;
            }
            else
            {
                ModulePanel.Height = HeightMax;
            }
        }

        private void btnPersonalProfile_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Application, panel_Applicaation, 55);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInterview_Click(object sender, EventArgs e)
        {
            Interview_Management im = new Interview_Management();
            im.ShowDialog();

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearTextbox()
        {
            foreach (Control ctrlpanel in groupBox2.Controls)
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
                                        tb.Text = string.Empty;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            tbPerAdd_Street.Text = tbPerAdd_Brgy.Text = tbPerAdd_City.Text = tbPerAdd_Postal.Text = string.Empty;
            tbPreAdd_Street.Text = tbPreAdd_Brgy.Text = tbPreAdd_City.Text = tbPreAdd_Postal.Text = string.Empty;
        }

        private void BtnEntry(bool status)
        {
            try
            {
                btnEducationalBackground.Enabled = status;
                btnInterview.Enabled = status;
                btnExamination.Enabled = status;
                btnGovernmentContribution.Enabled = status;
                btnEmploymentHistory.Enabled = status;
                btnEmergency.Enabled = status;
            }
            catch
            {
            }
        }
        private void LoadAllCombos()
        {
            string LAST_SP_Name = string.Empty;
            try
            {
                cf.SQLConn = Sconn;
                #region ID
                tb_ID.Text = "0";
                tb_ID.ReadOnly = true;
                #endregion
                #region Application_Status
                LAST_SP_Name = "sp_GetApplicant_Status";
                cmbApplicantStatus.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbApplicantStatus.DisplayMember = "name";
                cmbApplicantStatus.ValueMember = "id";
                #endregion
                #region ApplicationType
                LAST_SP_Name = "sp_GetApplication_Type";
                cmbApplicationType.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbApplicationType.DisplayMember = "name";
                cmbApplicationType.ValueMember = "id";
                #endregion
                #region Suffix
                LAST_SP_Name = "sp_GetSuffix";
                cmbSuffix.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbSuffix.ValueMember = "code";
                cmbSuffix.DisplayMember = "Name";
                #endregion
                #region CivilStatus
                LAST_SP_Name = "sp_getCivilStatus";
                cmbCivilStatus.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbCivilStatus.ValueMember = "code";
                cmbCivilStatus.DisplayMember = "name";
                #endregion
                #region Gender
                LAST_SP_Name = "sp_getGender";
                cmbGender.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbGender.ValueMember = "code";
                cmbGender.DisplayMember = "name";
                #endregion
                #region Nationality
                LAST_SP_Name = "sp_getNationality";
                cmbNationality.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbNationality.ValueMember = "code";
                cmbNationality.DisplayMember = "name";
                #endregion
                #region Religion
                LAST_SP_Name = "sp_getReligion";
                cmbReligion.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbReligion.ValueMember = "code";
                cmbReligion.DisplayMember = "name";
                #endregion
                #region BloodType
                LAST_SP_Name = "sp_getBloodType";
                cmbBloodType.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbBloodType.ValueMember = "id";
                cmbBloodType.DisplayMember = "name";
                #endregion
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Loading Dropdown List failed :" + LAST_SP_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Educational_Background eb = new Educational_Background();
            eb.ShowDialog();
        }
        private void ApplicantProfile_Load(object sender, EventArgs e)
        {
            cf.frm = this;
            cf.ControlObjects(false,groupBox2);
            LoadAllCombos();
            BtnEntry(false);
        }

        private void loadRecord(DataTable dtSelectedRecords)
        {
            if (dtSelectedRecords.Rows.Count == 1)
            {
                tb_ID.Text = dtSelectedRecords.Rows[0]["id"].ToString();
                tbLastName.Text = dtSelectedRecords.Rows[0]["lastname"].ToString();
                tbFirstName.Text = dtSelectedRecords.Rows[0]["firstname"].ToString();
                tbMiddleName.Text = dtSelectedRecords.Rows[0]["middlename"].ToString();
                cmbApplicantStatus.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["applicant_status"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["applicant_status"].ToString()) -1 :0;
                cmbApplicationType.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["application_type"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["application_type"].ToString()) -1: 0;
                cmbNationality.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["nationality"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["nationality"].ToString()) - 1 : 0;
                cmbGender.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["gender"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["gender"].ToString()) - 1 : 0;
                cmbCivilStatus.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["civil_status"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["civil_status"].ToString()) - 1 : 0;
                cmbSuffix.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["suffix"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["suffix"].ToString()) -2: 0;
                cmbBloodType.SelectedIndex = cf.isInteger(dtSelectedRecords.Rows[0]["blood_type"].ToString()) ? int.Parse(dtSelectedRecords.Rows[0]["blood_type"].ToString()) - 1 : 0;
                tbEmailAddress.Text = dtSelectedRecords.Rows[0]["email_address"].ToString();
                tbBirthPlace.Text = dtSelectedRecords.Rows[0]["birth_place"].ToString();
                tbHeight.Text = dtSelectedRecords.Rows[0]["height"].ToString();
                tbWeight.Text = dtSelectedRecords.Rows[0]["weight"].ToString();
                tbBirthPlace.Text = dtSelectedRecords.Rows[0]["birth_place"].ToString();
                tbMobilePhone1.Text = dtSelectedRecords.Rows[0]["mobile_number1"].ToString();
                tbMobilePhone2.Text = dtSelectedRecords.Rows[0]["mobile_number2"].ToString();
                tbMobilePhone3.Text = dtSelectedRecords.Rows[0]["mobile_number3"].ToString();
                tbPhoneNumber.Text = dtSelectedRecords.Rows[0]["phone_number"].ToString();
                tbPreAdd_Street.Text = dtSelectedRecords.Rows[0]["present_address_street"].ToString();
                tbPreAdd_Brgy.Text = dtSelectedRecords.Rows[0]["present_address_brgy"].ToString();
                tbPreAdd_City.Text = dtSelectedRecords.Rows[0]["present_address_city"].ToString();
                tbPreAdd_Postal.Text = dtSelectedRecords.Rows[0]["present_address_postal"].ToString();
                tbPerAdd_Street.Text = dtSelectedRecords.Rows[0]["permanent_address_street"].ToString();
                tbPerAdd_Brgy.Text = dtSelectedRecords.Rows[0]["permanent_address_brgy"].ToString();
                tbPerAdd_City.Text = dtSelectedRecords.Rows[0]["permanent_address_city"].ToString();
                tbPerAdd_Postal.Text = dtSelectedRecords.Rows[0]["permanent_address_postal"].ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to create a new transaction?", "Create New Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ClearTextbox();
                tb_ID.Text = cf.GetNewID().ToString();
                cf.ControlObjects(true,groupBox2);
                cmbApplicantStatus.Focus();
                BtnEntry(true);
            }
        }

        private void btn_Interview_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Emergency, panel_Emergency, 142);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelControl(btn_PersonalProfile, panel_Personal_Profile, 160);
        }

        private void btn_Address_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Address, panel_Address, 143);
        }

        private void btn_Educational_Background_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Educational_Background, panel_Education_Background, 147);
        }

        private void btn_Employment_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Employment, panel_Employement_History, 132);
        }

        private void btn_Examination_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Interview, panel_Interview, 134);
        }

        private void btn_Emergency_Click(object sender, EventArgs e)
        {
            PanelControl(btn_GovernmentContribution, panel_Government_Contribution, 116);
        }

        private void btn_Government_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Examination, panel_Examination, 133);
        }

        private void btn_Emergency_Click_1(object sender, EventArgs e)
        {
            PanelControl(btn_Examination, panel_Emergency, 128);
        }

        private void cmbSuffix_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmbSuffix.SelectedItem;
            sCode.Text = drv[2].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           DialogResult dr = MessageBox.Show("Are you sure you want to save this details?", "Save Applicant Information?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (dr == DialogResult.Yes)
           {   
                   List<PersonalProfile> PersonalProfile = new List<PersonalProfile>();
                   PersonalProfile pp = new PersonalProfile();
                   pp.applicationDate = dtApplicationDate.Value;
                   pp.applicationStatus = int.Parse(cf.GetComboID(cmbApplicantStatus).ToString());
                   pp.applicationType = int.Parse(cf.GetComboID(cmbApplicationType).ToString());
                   pp.Lastname = tbLastName.Text;
                   pp.Firstname = tbFirstName.Text;
                   pp.Middlename = tbMiddleName.Text;
                   pp.suffix = int.Parse(cf.GetComboID(cmbSuffix).ToString());
                   pp.EmailAddress = tbEmailAddress.Text;
                   pp.CivilStaus = int.Parse(cf.GetComboID(cmbCivilStatus).ToString());
                   pp.Gender = int.Parse(cf.GetComboID(cmbGender).ToString());
                   pp.Nationality = int.Parse(cf.GetComboID(cmbNationality).ToString());
                   pp.BirthDate = dtpBirthday.Value;
                   pp.BirthPlace = tbBirthPlace.Text;
                   pp.MobileNumber1 = tbMobilePhone1.Text;
                   pp.MobileNumber2 = tbMobilePhone2.Text;
                   pp.MobileNumber3 = tbMobilePhone3.Text;
                   pp.PhoneNumber = tbPhoneNumber.Text;
                   pp.Religion = int.Parse(cf.GetComboID(cmbReligion).ToString());
                   pp.Height = tbHeight.Text;
                   pp.Weight = tbWeight.Text;
                   pp.BloodType = int.Parse(cf.GetComboID(cmbBloodType).ToString());
                   pp.Marriage_Date = dtpMarriageDate.Value;
                   pp.Marriage_Place = tbMarriagePlace.Text;
                   pp.Present_Address_brgy = tbPreAdd_Brgy.Text;
                   pp.Present_Address_city = tbPreAdd_City.Text;
                   pp.Present_Address_street = tbPreAdd_Street.Text;
                   pp.Present_Address_postal = tbPreAdd_Postal.Text;
                   pp.Permanent_Address_brgy = tbPerAdd_Brgy.Text;
                   pp.Permanent_Address_city = tbPerAdd_City.Text;
                   pp.Permanent_Address_street = tbPerAdd_Street.Text;
                   pp.Permanent_Address_postal = tbPerAdd_Postal.Text;
                   pp.PhoneNumber = tbPhoneNumber.Text;
                   PersonalProfile.Add(pp);

                   if (PersonalProfile.Count > 0)
                   {
                       if (tbLastName.Text == string.Empty || tbFirstName.Text == string.Empty || tb_ID.Text == "0")
                       {
                           MessageBox.Show("Error: Cannot save information. Please check your entry", "Save Applicant Information Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                       }

                       if (!cf.checkID(int.Parse(tb_ID.Text)))
                       {
                           if (!cf.SaveApplicant(PersonalProfile,"Add"))
                           {   
                               MessageBox.Show("Error: Cannot save information. Please check your entry", "Save Applicant Information Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }
                           else
                           {
                               MessageBox.Show("Application Information successfully Saved.", "Done Save information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               cf.frm = this;
                               cf.ControlObjects(false, groupBox2);
                               LoadAllCombos();
                               BtnEntry(false);
                               ClearTextbox();
                           }
                       }
                       else
                       {
                           if (!cf.SaveApplicant(PersonalProfile, "Edit"))
                           {
                               MessageBox.Show("Error: Cannot save information. Please check your entry", "Save Applicant Information Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }
                           else
                           {
                               MessageBox.Show("Application Information successfully Saved.", "Done Save information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               cf.frm = this;
                               cf.ControlObjects(false, groupBox2);
                               LoadAllCombos();
                               BtnEntry(false);
                               ClearTextbox();
                           }
                       }
                   }
           }
        }

        private void tbPreAdd_Street_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Street.Text = tbPreAdd_Street.Text;
            }
        }

        private void tbPreAdd_Brgy_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Brgy.Text = tbPreAdd_Brgy.Text;
            }
        }

        private void tbPreAdd_City_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_City.Text = tbPreAdd_City.Text;
            }
        }

        private void tbPreAdd_Postal_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Postal.Text = tbPreAdd_Postal.Text;
            }
        }

        private void chkSamePermanent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Street.Text = tbPreAdd_Street.Text;
                tbPerAdd_Brgy.Text = tbPreAdd_Brgy.Text;
                tbPerAdd_City.Text = tbPreAdd_City.Text;
                tbPerAdd_Postal.Text = tbPreAdd_Postal.Text;
            }
        }

        private void tbPreAdd_Street_TextChanged(object sender, EventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Street.Text = tbPreAdd_Street.Text;
            }
        }

        private void tbPreAdd_Brgy_TextChanged(object sender, EventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Brgy.Text = tbPreAdd_Brgy.Text;
            }
        }

        private void tbPreAdd_City_TextChanged(object sender, EventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_City.Text = tbPreAdd_City.Text;
            }
        }

        private void tbPreAdd_Postal_TextChanged(object sender, EventArgs e)
        {
            if (chkSamePermanent.Checked)
            {
                tbPerAdd_Postal.Text = tbPreAdd_Postal.Text;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecord sr = new SearchRecord();
            sr.Sconn = Sconn;
            sr.ShowDialog();
            if (sr.SelectedID != 0)
            {
                DataTable dtSelectedRecords = cf.dtGetApplicantRecord(sr.SelectedID);
                if (dtSelectedRecords.Rows.Count == 1)
                {
                    loadRecord(dtSelectedRecords);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ID.Text))
            {
                MessageBox.Show("Error: No applicant was selected. Please select it first using search button", "No Selected Record found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cf.ControlObjects(true, groupBox2);
            cmbApplicantStatus.Focus();
            BtnEntry(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?", "Confirm to Delete : " + tb_ID.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (tb_ID.Text == "0" || tb_ID.Text == string.Empty)
                {
                    MessageBox.Show("Error: No record to delete. Please search first.", "No Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int ID = cf.isInteger(tb_ID.Text) ? int.Parse(tb_ID.Text) : 0;
                if (cf.checkID(ID))
                {
                    cf.executeSP("sp_DelApplicantByID " + ID);
                    MessageBox.Show("Deleting record successfully.", "Delete Record Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_ID.Text = cf.GetNewID().ToString();
                    cf.ControlObjects(false, groupBox2);
                    cmbApplicantStatus.Focus();
                    BtnEntry(false);
                    ClearTextbox();
                }
            }
        }

        

        

        
    }
}
