using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHRS.Classes
{
    public class Applications
    {
        public int Application_Type { get; set; }
        public int Application_Status { get; set; }
        public DateTime Application_Date { get; set; }
    }
    public class PersonalProfile
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public int suffix { get; set; }
        public string EmailAddress { get; set; }
        public int CivilStaus { get; set; }
        public int Gender { get; set; }
        public int Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }
        public string MobileNumber3 { get; set; }
        public string PhoneNumber { get; set; }
        public int Religion { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int BloodType { get; set; }
        public DateTime Marriage_Date { get; set; }
        public string Marriage_Place { get; set; }
        public string Present_Address_street { get; set; }
        public string Present_Address_brgy { get; set; }
        public string Present_Address_city { get; set; }
        public string Present_Address_postal { get; set; }
        public string Permanent_Address_street { get; set; }
        public string Permanent_Address_brgy { get; set; }
        public string Permanent_Address_city { get; set; }
        public string Permanent_Address_postal { get; set; }
        public int applicationType { get; set; }
        public int applicationStatus { get; set; }
        public DateTime applicationDate { get; set; }
    }
    public class clsVariable
    {

    }
}
