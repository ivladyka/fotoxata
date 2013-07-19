using System;
using System.Globalization;
using System.Web.UI.WebControls;
using MyGeneration.dOOdads;
using Telerik.Web.UI;
using VikkiSoft_BLL;
using Appointment=Telerik.Web.UI.Appointment;

public partial class Schedule : ControlBase
{
    public Schedule()
	{
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
        BackURL = "~/Office/Office.aspx?content=ScheduleList";
	}

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        RadScheduler1.SelectedDate = DateTime.Now;
        RadScheduler1.Culture = new CultureInfo("uk-UA");
        RebindSheduler();
    }

    private void RebindSheduler()
    {
        VikkiSoft_BLL.Appointment a = new VikkiSoft_BLL.Appointment();
        DateTime startDate = new DateTime(RadScheduler1.SelectedDate.Year, RadScheduler1.SelectedDate.Month,
            1);
        DateTime endDate = startDate.AddMonths(1);
        startDate = startDate.AddDays(-1);
        a.LoadByUserID(UserID, startDate, endDate);
        RadScheduler1.DataSource = a.DefaultView.Table;
    }

    private int UserID
    {
        get
        {
            if(Request.Params["uid"] != null)
            {
                return int.Parse(Request.Params["uid"]);
            }
            return 0;
        }
    }

    private string GetUserName()
    {
        VikkiSoft_BLL.User u = new VikkiSoft_BLL.User();
        u.Where.UserID.Value = UserID;
        if(u.Query.Load())
        {
            string photographerName = "";
            if (!u.IsColumnNull(User.ColumnNames.FirstName))
            {
                photographerName = u.s_FirstName;
            }
            if (!u.IsColumnNull(User.ColumnNames.LastName))
            {
                if (photographerName != "")
                {
                    photographerName += " ";
                }
                photographerName += u.s_LastName;
            }
            if (photographerName == "")
            {
                photographerName = u.s_CellPhone;
            }
            return photographerName;
        }
        return "";
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.m_Name = "Планування роботи фотографа " + GetUserName();
    }

    protected void RadScheduler1_AppointmentInsert(object sender, Telerik.Web.UI.SchedulerCancelEventArgs e)
    {
        VikkiSoft_BLL.Appointment a = new VikkiSoft_BLL.Appointment();
        a.AddNew();
        a.UserID = UserID;
        a.AssignedBy = UserSession.UserID;
        a.AssignedDate = DateTime.Now;
        SaveAppointment(a, e.Appointment);
        RebindSheduler();
    }

    protected void RadScheduler1_AppointmentDelete(object sender, Telerik.Web.UI.SchedulerCancelEventArgs e)
    {
        VikkiSoft_BLL.Appointment a = new VikkiSoft_BLL.Appointment();
        if (a.LoadByPrimaryKey(int.Parse(e.Appointment.ID.ToString())))
        {
            a.DeleteAll();
            a.Save();
        }
    }

    private void SaveAppointment(VikkiSoft_BLL.Appointment a, Appointment radAppointment)
    {
        a.StartTime = radAppointment.Start;
        a.EndTime = radAppointment.End;   
        a.Subject = radAppointment.Subject;
        if (radAppointment.Attributes["PhotoSalonID"] == null
            || radAppointment.Attributes["PhotoSalonID"].ToString() == "")
        {
            a.SetColumnNull(PhotoSalon.ColumnNames.PhotoSalonID);
        }
        else
        {
            a.PhotoSalonID = int.Parse(radAppointment.Attributes["PhotoSalonID"].ToString());
        }
        if (radAppointment.Attributes["MoneyAdvance"] == null
            || radAppointment.Attributes["MoneyAdvance"].ToString() == "")
        {
            a.SetColumnNull(VikkiSoft_BLL.Appointment.ColumnNames.MoneyAdvance);
        }
        else
        {
            a.MoneyAdvance = Convert.ToDecimal((radAppointment.Attributes["MoneyAdvance"].ToString()));
        }
        if (radAppointment.Attributes["PhoneNumber"] == null
            || radAppointment.Attributes["PhoneNumber"].ToString() == "")
        {
            a.SetColumnNull(VikkiSoft_BLL.Appointment.ColumnNames.PhoneNumber);
        }
        else
        {
            a.PhoneNumber = (radAppointment.Attributes["PhoneNumber"].ToString());
        }
        a.Save();
    }

    protected void RadScheduler1_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
    {
        VikkiSoft_BLL.Appointment a = new VikkiSoft_BLL.Appointment();
        if (a.LoadByPrimaryKey(int.Parse(e.Appointment.ID.ToString())))
        {
            SaveAppointment(a, e.ModifiedAppointment);
            RebindSheduler();
        }
    }

    protected void RadScheduler1_NavigationComplete(object sender, Telerik.Web.UI.SchedulerNavigationCompleteEventArgs e)
    {
        RebindSheduler();
    }

    protected void RadScheduler1_FormCreated(object sender, Telerik.Web.UI.SchedulerFormCreatedEventArgs e)
    {
        if (e.Container.Mode == SchedulerFormMode.AdvancedInsert ||
            e.Container.Mode == SchedulerFormMode.AdvancedEdit)
        {
            TextBox subjectBox = (TextBox)e.Container.FindControl("TitleTextBox");
            subjectBox.Text = e.Appointment.Subject;

            RadDatePicker startDate = (RadDatePicker)e.Container.FindControl("StartDate");
            startDate.DateInput.DateFormat = RadScheduler1.AdvancedForm.DateFormat;
            startDate.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);

            RadDatePicker startTime = (RadDatePicker)e.Container.FindControl("StartTime");
            startTime.DateInput.DateFormat = RadScheduler1.AdvancedForm.TimeFormat;
            startTime.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);

            RadDatePicker endDate = (RadDatePicker)e.Container.FindControl("EndDate");
            endDate.DateInput.DateFormat = RadScheduler1.AdvancedForm.DateFormat;
            endDate.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);

            RadDatePicker endTime = (RadDatePicker)e.Container.FindControl("EndTime");
            endTime.DateInput.DateFormat = RadScheduler1.AdvancedForm.TimeFormat;
            endTime.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);

            RadComboBox ddlPhotoSalon = (RadComboBox)e.Container.FindControl("ddlPhotoSalon");
            PhotoSalon ps = new PhotoSalon();
            ps.Query.AddOrderBy(PhotoSalon.ColumnNames.Address, WhereParameter.Dir.ASC);
            if (ps.Query.Load())
            {
                ddlPhotoSalon.DataTextField = PhotoSalon.ColumnNames.Address;
                ddlPhotoSalon.DataValueField = PhotoSalon.ColumnNames.PhotoSalonID;
                ddlPhotoSalon.DataSource = ps.DefaultView.Table;
                ddlPhotoSalon.DataBind();
            }
            if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
            {
                if (e.Appointment.Attributes["PhotoSalonID"] != null &&
                    e.Appointment.Attributes["PhotoSalonID"].ToString() != "")
                {
                    ddlPhotoSalon.SelectedValue = e.Appointment.Attributes["PhotoSalonID"].ToString();
                }

                if (e.Appointment.Attributes["MoneyAdvance"] != null &&
                    e.Appointment.Attributes["MoneyAdvance"].ToString() != "")
                {
                    RadNumericTextBox rntbMoneyAdvance = e.Container.FindControl("rntbMoneyAdvance") as RadNumericTextBox;
                    if (rntbMoneyAdvance != null)
                    {
                        rntbMoneyAdvance.Value = Convert.ToDouble(e.Appointment.Attributes["MoneyAdvance"].ToString());
                    }
                }

                if (e.Appointment.Attributes["PhoneNumber"] != null &&
                    e.Appointment.Attributes["PhoneNumber"].ToString() != "")
                {
                    RadMaskedTextBox rmtbPhoneNumber = e.Container.FindControl("rmtbPhoneNumber") as RadMaskedTextBox;
                    if (rmtbPhoneNumber != null)
                    {
                        rmtbPhoneNumber.Text = e.Appointment.Attributes["PhoneNumber"].ToString();
                    }
                }

                if (e.Appointment.Attributes["AssignedUserName"] != null &&
                    e.Appointment.Attributes["AssignedUserName"].ToString() != "")
                {
                    Label lbAssigned = e.Container.FindControl("lbAssigned") as Label;
                    if (lbAssigned != null)
                    {
                        lbAssigned.Text = e.Appointment.Attributes["AssignedUserName"].ToString();
                    }
                }
            }
        }
    }

    protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
            case "Update":
                RadComboBox ddlPhotoSalon = e.Container.FindControl("ddlPhotoSalon") as RadComboBox;
                if (ddlPhotoSalon != null)
                {
                    e.Container.Appointment.Attributes["PhotoSalonID"] = ddlPhotoSalon.SelectedValue;
                }
                RadNumericTextBox rntbMoneyAdvance = e.Container.FindControl("rntbMoneyAdvance") as RadNumericTextBox;
                if (rntbMoneyAdvance != null)
                {
                    e.Container.Appointment.Attributes["MoneyAdvance"] = rntbMoneyAdvance.Value.ToString();
                }
                RadMaskedTextBox rmtbPhoneNumber = e.Container.FindControl("rmtbPhoneNumber") as RadMaskedTextBox;
                if (rmtbPhoneNumber != null)
                {
                    e.Container.Appointment.Attributes["PhoneNumber"] = rmtbPhoneNumber.Text;
                }
                RadDatePicker StartDate = e.Container.FindControl("StartDate") as RadDatePicker;
                RadTimePicker StartTime = e.Container.FindControl("StartTime") as RadTimePicker;
                e.Container.Appointment.Start = new DateTime(StartDate.SelectedDate.Value.Year,
                                                             StartDate.SelectedDate.Value.Month,
                                                             StartDate.SelectedDate.Value.Day,
                                                             StartTime.SelectedDate.Value.Hour,
                                                             StartTime.SelectedDate.Value.Minute, 0);
                RadDatePicker EndDate = e.Container.FindControl("EndDate") as RadDatePicker;
                RadTimePicker EndTime = e.Container.FindControl("EndTime") as RadTimePicker;
                e.Container.Appointment.End = new DateTime(EndDate.SelectedDate.Value.Year,
                                                             EndDate.SelectedDate.Value.Month,
                                                             EndDate.SelectedDate.Value.Day,
                                                             EndTime.SelectedDate.Value.Hour,
                                                             EndTime.SelectedDate.Value.Minute, 0);
                if (e.Container.Appointment.End < e.Container.Appointment.Start)
                {
                    e.Container.Appointment.End = e.Container.Appointment.Start;
                }
                break;
        }
    }

    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        string photosalonID = e.Appointment.Attributes["PhotoSalonID"];
        switch(photosalonID)
        {
            case "1":
                e.Appointment.CssClass = "rsCategoryGreen";
                break;
            case "2":
                e.Appointment.CssClass = "rsCategoryBlue";
                break;
            case "3":
                e.Appointment.CssClass = "rsCategoryOrange";
                break;
            case "4":
                e.Appointment.CssClass = "rsCategoryRed";
                break;
            case "5":
                e.Appointment.CssClass = "rsCategoryYellow";
                break;
        }
    }
}
