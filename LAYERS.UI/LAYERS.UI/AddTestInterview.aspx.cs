﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//additional
using LAYERS.BLLFACTORY;
using LAYERS.BOFACTORY;
using LAYERS.TYPES;

namespace LAYERS.UI
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        //Global variable
        int error = 0;
        int WrittenTestDate_error = 0;
        int ctr = 0;
        int TID = 0;
        int HID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Visible = false;
            if (DropDownList1.SelectedItem.Text == "Select")
            {
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;

            }
            else
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;

            }
            if (!Page.IsPostBack)
            {
                FillDropDownList1();

            }
        }

        //fetch vacancy id and TestAdminid and display on dropdowlist and label
        private void FillDropDownList1()
        {
            ICandidateTestScheduleManager view = CandidateTestScheduleManagerFactory.displayVacancyId();
            List<ICandidateTestSchedule> testlist = view.displayVacancyId();
            DropDownList1.DataSource = testlist;
            DropDownList1.DataTextField = "VacancyId";
            DropDownList1.DataValueField = "TestAdminId";
            DropDownList1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DropDownList1.SelectedItem.Value;
            Label1.Text = id;
        }

        //display autopopup date 
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime WrittenTestDate = Convert.ToDateTime(TextBox1.Text);
            string TechinterviewDate = WrittenTestDate.AddDays(2).ToShortDateString();
            TextBox2.Text = TechinterviewDate;
            string HRInterviewDate = WrittenTestDate.AddDays(4).ToShortDateString();
            TextBox3.Text = HRInterviewDate;
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int VacancyId = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                int TestAdminId = Convert.ToInt32((Label1.Text).ToString());
                DateTime WrittenTestDate = Convert.ToDateTime(TextBox1.Text);
                DateTime TechinterviewDate = Convert.ToDateTime(TextBox2.Text);
                DateTime HRInterviewDate = Convert.ToDateTime(TextBox3.Text);

                ICandidateTestSchedule test = CandidateTestScheduleFactory.updateTest(VacancyId, TestAdminId, WrittenTestDate, TechinterviewDate, HRInterviewDate);

                ICandidateTestScheduleManager testmanager = CandidateTestScheduleManagerFactory.Updatetestmanager();
                if (error == 0 && WrittenTestDate_error == 0 && ctr == 0 && TID == 0 && HID == 0)
                {
                    bool isSaved = testmanager.Save(test);


                    Label1.Text = string.Empty;

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    Label7.Visible = true;


                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime today = System.DateTime.Today;
            DateTime WrittenTestDate = Convert.ToDateTime(TextBox1.Text);
            if (WrittenTestDate < today)
            {
                WrittenTestDate_error = 1;
                args.IsValid = false;
            }


        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ICandidateTestScheduleManager i = CandidateTestScheduleManagerFactory.displayRequiredByDate();
            int vacid = Convert.ToInt32(DropDownList1.SelectedItem.Text);
            ICandidateTestSchedule obj = CandidateTestScheduleFactory.createVacancyId(vacid);
            ICandidateTestSchedule date = i.displayRequiredByDate(obj);
            DateTime reqDate = date.RequiredByDate;

            DateTime hrDate = Convert.ToDateTime(TextBox3.Text);

            {
                if (hrDate <= reqDate.AddDays(-7) && hrDate <= reqDate)
                {
                    args.IsValid = true;
                }
                else
                {
                    ctr = 1;
                    args.IsValid = false;

                }

            }
        }

        protected void CustomValidator3_ServerValidate1(object source, ServerValidateEventArgs args)
        {

        }
        // validate technicalTestDate within 2 days of writtenTestdate
        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime writtenTestdate = Convert.ToDateTime(TextBox1.Text);
            DateTime technicalTestDate = Convert.ToDateTime(TextBox2.Text);

            if (technicalTestDate >= writtenTestdate.AddDays(3))
            {
                TID = 1;
                args.IsValid = false;
            }
            else
                if (technicalTestDate <= writtenTestdate)
                {
                    TID = 1;
                    args.IsValid = false;
                }
                else
                {

                    args.IsValid = true;
                }

        }
        // validate HRInterviewDate within 2 days of technicalTestDate
        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime HRInterviewDate = Convert.ToDateTime(TextBox3.Text);
            DateTime technicalTestDate = Convert.ToDateTime(TextBox2.Text);

            if (HRInterviewDate >= technicalTestDate.AddDays(3))
            {
                HID = 1;
                args.IsValid = false;
            }
            else
                if (HRInterviewDate <= technicalTestDate)
                {
                    HID = 1;
                    args.IsValid = false;
                }
                else
                {

                    args.IsValid = true;


                }
        }


    }
}