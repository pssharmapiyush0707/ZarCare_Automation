namespace ZarCare_Automation.Test.PageValidations
{
    public class OurProviderWorkflow
    {
        public static string classname = "OurProvider";
        public static string appointmentDetail = "BookAppointments";

        public static void Search_Provider_By_Name()
        {
            var json = Json_Reader.GetDataFromJson(classname);
            string doctorName = json["Doctor_Name"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate Provider Search By Name");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Search and Validate Provider List By Name");
            Home_Page.NavigateToOurProvider();  
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.Search_Doctor(doctorName);
            Our_Providers_Page.Get_and_Validate_Doctor_Name(doctorName);
            Our_Providers_Page.NavigateToCloseButton();

            Reports.childLog.Log(Status.Info, "=================================================");
        
        }

        public static void Search_Provider_By_Category()
        {
            var json = Json_Reader.GetDataFromJson(classname);
            string doctorSpecialty = json["Doctor_Specialty"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate Provider Search By Category");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Search and Validate Provider List By Category");
            Home_Page.NavigateToOurProvider();
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.Search_Category(doctorSpecialty);
            Our_Providers_Page.Get_and_Validate_Doctor_Specialty(doctorSpecialty);
            Our_Providers_Page.NavigateToCloseButton();

            Reports.childLog.Log(Status.Info, "=================================================");

        }

        public static void Search_Provider_By_Location()
        {
            var json = Json_Reader.GetDataFromJson(classname);
            string doctorLocation = json["Doctor_Location"].ToString();
            string getLocation = json["Get_Doctor_Location"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate Provider Search By Location");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Search and Validate Provider List By Location");
            Home_Page.NavigateToOurProvider();
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.Search_Location(doctorLocation);
            Our_Providers_Page.Get_and_Validate_Doctor_Location(getLocation);
            Our_Providers_Page.NavigateToCloseButton();

            Reports.childLog.Log(Status.Info, "=================================================");
        }

        public static void Verify_Register_Page_Title_Through_Doctor_Profile()
        {
            var json = Json_Reader.GetDataFromJson(appointmentDetail);
            string doctorName = json["Doctor_Name"].ToString();
            string appointmentDate = json["Appointment_Date"].ToString();
            string appointmentTime = json["Appointment_Time"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate Register Page Title from DoctorProfile Page");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Search and Fetch Provider from the List");
            Home_Page.NavigateToOurProvider();
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.Search_Doctor(doctorName);
            Our_Providers_Page.FetchDoctorFromList(doctorName);

            Reports.childLog.Log(Status.Info, "Step 3: Validate Doctor Profile Page and Validate Register Title ");
            Doctor_Profile_Page.ValidateDoctorProfile();
            Doctor_Profile_Page.BookAppointment(appointmentDate, appointmentTime);
            Register_Page.Validate_RegisterPage();

            Reports.childLog.Log(Status.Info, "=================================================");
        }

        public static void Validate_Register_Page_Through_BookAppointmentButton()
        {
            var json = Json_Reader.GetDataFromJson(appointmentDetail);
            string Doctorsname = json["Doctor_Name"].ToString();
            string Appoint_Date = json["Appointment_Date"].ToString();
            string Appointment_time = json["Appointment_Time"].ToString();


            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate Register Page Title Through Book Appointment Button in Our Provider");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Validate Register Title from Register Page ");
            Home_Page.NavigateToOurProvider();
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.ClickOnBookAppointmentButton(Doctorsname);
            Our_Providers_Page.ClickOnProviderSlotAndNavigateToRegisterPage(Appoint_Date, Appointment_time);
            Register_Page.Validate_RegisterPage();

            Reports.childLog.Log(Status.Info, "=================================================");
        }

        public static void Validate_AppointmentSlot_With_TotalCount_On_OurProviderPage()
        {
            var json = Json_Reader.GetDataFromJson(appointmentDetail);
            string Doctorsname = json["Doctor_Name"].ToString();
            string Appoint_Date = json["Appointment_Date"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Validate AppointmentSlot With TotalCount");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();

            Reports.childLog.Log(Status.Info, "Step 2: Validate Our Provider Page and Validate Slot Count");
            Home_Page.NavigateToOurProvider();
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.ClickOnBookAppointmentButton(Doctorsname);
            Our_Providers_Page.GetSlotCountAndValidateWithTotalCount(Appoint_Date);

            Reports.childLog.Log(Status.Info, "=================================================");
        }

        public static void Verify_Slot_Visible_On_OurProvider_Page_After_Cancellation()
        {
            var appointment = Json_Reader.GetDataFromJson(appointmentDetail);
            string email = appointment["Email"].ToString();
            string password = appointment["Password"].ToString();
            string providerName = appointment["Doctor_Name"].ToString();
            string appointmentDate = appointment["Appointment_Date"].ToString();
            string appointmentTime = appointment["Appointment_Time"].ToString();

            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Verify Slot Enabled in Our Provider after the Cancellation ");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the HomePage");
            Home_Page.Validate_HomePage();
            Home_Page.NavigateToLoginPage();

            Reports.childLog.Log(Status.Info, "Step 2: Validate the login page and Patient Login into the website");
            Login_Page.Validate_LoginPage();
            Login_Page.Patient_Login(email, password);
           
            Reports.childLog.Log(Status.Info, "Step 3: Navigate the Patient Profile page and Validate the page");
            Patient_Profile_Page.ValidatePatientProfile();
            Patient_Profile_Page.NavigateToActiveAppointment();

            Reports.childLog.Log(Status.Info, "Step 4: Navigate the Active Appointment page and Validate the page");
            ActiveAppointment_Page.Validate_Active_Appointment_Page();
            ActiveAppointment_Page.NavigateToViewDetailPage();

            Reports.childLog.Log(Status.Info, "Step 5: Navigate the View Detail page and Appointment Cancellation");
            ViewDetail_Page.Validate_ViewDetailPage();
            ViewDetail_Page.CancelAppointment();
 
            Reports.childLog.Log(Status.Info, "Step 6: Navigate the Our Provider page and Search Provider");
            Our_Providers_Page.Validate_OurProviderPage();
            Our_Providers_Page.Search_Doctor(providerName);
            Our_Providers_Page.FetchDoctorFromList(providerName);
            
            Reports.childLog.Log(Status.Info, "Step 7: Navigate the Doctor Profile page and check slot visible");
            Doctor_Profile_Page.ValidateDoctorProfile();
            Doctor_Profile_Page.Verify_Slot_Availability_On_Doctor_Profile(appointmentDate, appointmentTime);
   
            Reports.childLog.Log(Status.Info, "=================================================");

        }

        public void Verify_And_Clear_Top_Provider_Category()
        {
            var json = Json_Reader.GetDataFromJson(classname);
            string doc_category = json["doc_category"].ToString();
            string Original_Category_Title = json["OriginalCategoryTitle"].ToString();
            string Top_Category_Title = json["Doctor_Top_Category"].ToString();
            Generic_Utils.Initilize_URL(Properties.environment.ToLower(), "Platform");

            Reports.childLog.Log(Status.Info, "Verify the List of Top Provider Category ");

            Reports.childLog.Log(Status.Info, "Step 1: Validate the Top Provider Category List ");
            Wait.implicitWait(2000);
            Our_Providers_Page.ValidateAllCategory_And_Click_Category(doc_category);
            Our_Providers_Page.ValidateSelectedCategory(Original_Category_Title);
            Reports.FlushNode(Reports.childLog);

            Reports.childLog = Reports.CreateNode("Step 3: Clear the Category Filter  ");
            //Our_Providers_Page.RemoveCategory();
            //Our_Providers_Page.Validate_Top_Category(Top_Category_Title);
            Reports.FlushNode(Reports.childLog);

        }


    }
}
