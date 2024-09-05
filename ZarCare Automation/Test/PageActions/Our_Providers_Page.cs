﻿namespace ZarCare_Automation.Test.PageActions
{
    public class Our_Providers_Page : WebdriverSession
    {
        public static Our_Providers_Page_Locators OurProvidersPage = new Our_Providers_Page_Locators();
        public static Doctor_Profile_Page_Locators DoctorProfilePage = new Doctor_Profile_Page_Locators();
        public static LoginPage_Locators LoginPage = new LoginPage_Locators();

        public static void Validate_OurProviderPage()
        {
            Wait.WaitTillPageLoad();
            Generic_Utils.IsElementDisplayed(OurProvidersPage.By_SearchHeader);

            Reports.childLog.Log(Status.Info, "Our Providers page is displayed");
            Generic_Utils.GetScreenshot("Our Providers screenshot");

        }

        public static void Search_Doctor(string doctorName)
        {
            OurProvidersPage.Web_Doctor_SearchBox.SendKeys(doctorName);
            Wait.GenericWait(1000);
            OurProvidersPage.Web_Doctor_SearchButton.Click();
        }

        public static void FetchDoctorFromList(string doctorName)
        {
            int dr_list = driver.FindElements(OurProvidersPage.By_Doctor_List).Count;

            for (int a = 0; a < dr_list; a++)
            {
                string dr_name = driver.FindElements(OurProvidersPage.By_Doctor_Name)[a].Text;

                if (dr_name.Contains(doctorName))
                {
                    driver.FindElements(OurProvidersPage.By_Doctor_Name)[a].Click();
                    break;
                }
            }
        }
        public static void ValidateBookoptmOpen(string Doctorsname)
        {
           Wait.WaitTillPageLoad();
            Generic_Utils.IsElementDisplayed(OurProvidersPage.By_SearchHeader);
            //Generic_Utils.ScrollToMidOfPage();
             Generic_Utils.ScrollToBottom();  
            //Generic_Utils.ScrollToElement(OurProvidersPage.Web_DrJashan_kumar_Ele);

            int DrList = driver.FindElements(OurProvidersPage.By_Doctor_List).Count;

            for (int i = 0; i < DrList; i++)
            {
                string dr_name = (OurProvidersPage.Web_Doctor_Name)[i].Text;
                
                if (dr_name.Contains(Doctorsname))
                {
                   
                    IWebElement BookOptbtnfnl = (OurProvidersPage.BookOtpbtnList)[i];
                    BookOptbtnfnl.Click();
                    break;
                }
            }

            Reports.childLog.Log(Status.Info, "doctor Detail Page displayed");
            Generic_Utils.GetScreenshot("doctor Detail Page screenshot");

           
        }
        public static void BookOptClickAndSelectSlotNavigateToLoginPage(string appointment_Time)
        {
            
            int slot_count = DoctorProfilePage.Web_BookingSlot_Currentday.Count;

            for (int a = 0; a < slot_count; a++)
            {
                string slot_time = DoctorProfilePage.Web_BookingSlot_Currentday[a].Text;

                if (slot_time.Equals(appointment_Time))
                {
                    DoctorProfilePage.Web_BookingSlot_Currentday[a].Click();
                    break;
                }
               
            }

            Generic_Utils.GetScreenshot("Appointment Date and Time Selected ");

            Wait.WaitTillPageLoad();
            Generic_Utils.IsElementDisplayed(LoginPage.By_LogPageheaderText);
            Reports.childLog.Log(Status.Info, "Register Page displayed");
            Generic_Utils.GetScreenshot("Navigated to Register page");

        }
        public static void Get_and_Validate_OurProvider_Title(string Original_Title)
        {
            string Capture_Title = Generic_Utils.getTitle();
            Assert.That(Original_Title, Is.EqualTo(Capture_Title));
        }

    }
}
