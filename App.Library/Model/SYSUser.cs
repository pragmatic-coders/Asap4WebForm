using System;

namespace App.Library.Model
{
    public class SYS_User
    {
        #region Properties


        public int UserID { get; set; }


        public string LogonID { get; set; }

        public string DisplayName { get; set; }

        public string Domain { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public string Designation { get; set; }


        public string Department { get; set; }


        public string PhysicalLocation { get; set; }


        public string PhysicalRegion { get; set; }


        public string ReportToManager { get; set; }


        public string ManagerEmail { get; set; }


        public string Function { get; set; }


        public string Description { get; set; }


        public int Status { get; set; }


        public int UserType { get; set; }

        #region Request Access

        public string UserRoleID { get; set; }


        public string RoleID { get; set; }


        public string[] Permissions { get; set; }


        public DateTime ValidFrom { get; set; }


        public DateTime ValidTill { get; set; }


        public int RoleStatus { get; set; }


        public bool IsCustom { get; set; }




        #endregion

        #endregion
    }
}
