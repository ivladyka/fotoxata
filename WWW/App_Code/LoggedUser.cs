using VikkiSoft_BLL;

	/// <summary>
	/// Summary description for LoggedUser.
	/// </summary>
    public enum UserTypeEnum
    {
        Admin = 1,
        Photographer = 2,
        Employee = 3,
        User = 4
    }

    public class LoggedUser
    {
        public LoggedUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool IsUserType(int userTypeID)
        {
            UserUserType uut = new UserUserType();
            if (uut.IsUserType(UserSession.UserID, userTypeID))
            {
                return true;
            }
            return false;
        }

        static public bool IsAdmin()
        {
            return IsUserType((int)UserTypeEnum.Admin);
        }

        static public bool IsPhotographer()
        {
            return IsUserType((int)UserTypeEnum.Photographer);
        }

        static public bool IsEmployee()
        {
            return IsUserType((int)UserTypeEnum.Employee);
        }

        static public string CellPhone
        {
            get
            {
                VikkiSoft_BLL.User u = new VikkiSoft_BLL.User();
                if (u.LoadByPrimaryKey(UserSession.UserID))
                {
                    return u.s_CellPhone;
                }
                return "";
            }
        }
    }
