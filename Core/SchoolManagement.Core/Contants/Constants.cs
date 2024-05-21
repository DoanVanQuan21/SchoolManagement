namespace SchoolManagement.Core.Constants
{
    public class ConnectionString
    {
        public static readonly string DESKTOP_0SMVJQ6 = "Data Source=DESKTOP-0SMVJQ6;Initial Catalog=SchoolManager;Integrated Security=True;Trust Server Certificate=True";
        public static readonly string DESKTOP_NS7SDSM = "Data Source=DESKTOP-NS7SDSM\\SQLEXPRESS;Initial Catalog=SchoolManager;Integrated Security=True";
        public static readonly string DESKTOP_Q183429 = "Data Source=DESKTOP-Q183429\\SQLEXPRESS;Initial Catalog=SchoolManager;Integrated Security=True";
        public static readonly string ADMIN = "Data Source=ADMIN;Initial Catalog=SchoolManagement;Integrated Security=True;Trust Server Certificate=True";
    }
    public enum Languages {
        English_US,
        VietNam_VN
    }
    public class IconPath
    {
        public static readonly string DashboardIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/dashboard_icon_yell.png";
        public static readonly string ListUserIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/user_list_icon_yell.png";
        public static readonly string PatientRecordIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/patient_record_icon_yell.png";
        public static readonly string CalendarIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/calendar_icon_yell.png";
        public static readonly string ReportIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/report_icon_yell.png";
        public static readonly string MedicalExamIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/medical_exam_icon_yell.png";
        public static readonly string MedicineIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/medicine_icon_yell.png";
        public static readonly string ServiceIcon = "pack://application:,,,/Management.Shared;component/Assets/Resources/Images/Icons/service_icon_yell.png";
    }

    public class ImagePath
    {
        public static readonly string DefaultUserImage = "avares://SchoolManagement.UI/Assets/Images/default_user_image.png";
    }

    public enum Role
    {
        Student,
        Teacher,
        Leader,
        Admin
    }

    public class PnpClass
    {
        public static string AUDIO_END_POINT = "AudioEndPoint";
        public static string BATTERY = "Battery";
        public static string BLUETOOTH = "Bluetooth";
        public static string CAMERA = "Camera";
        public static string COMPUTER = "Computer";
        public static string DISK_DRIVE = "DiskDrive";
        public static string DISPLAY = "Display";
        public static string FIRMWARE = "Firmware";
        public static string HID_CLASS = "HIDClass";
        public static string IMAGE = "Image";
        public static string KEYBOARD = "Keyboard";
        public static string MEDIA = "Media";
        public static string PORTS = "Ports";
        public static string PRINTER = "Printer";
        public static string USB = "USB";
    }

    public class Visibility
    {
        public static readonly string HIDDEN = "Hidden";
        public static readonly string COLLAPSED = "Collapsed";
        public static readonly string VISIBLE = "Visible";
    }

    public enum ConnectionStatus
    {
        CONNECTED,
        DISCONNECTED,
    }

    public class Semester
    {
        public string Value { get; set; } = "Kỳ 1";
        public static List<Semester> Semesters = new() { new() { Value = "Kỳ 1" }, new() { Value = "Kỳ 2" } };
    }

    public class FolderPath
    {
        public static string CONFIGURATION => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine("management", "configurations"));
    }

    public class FileName
    {
        public static string APP_CONFIG = "app-config.json";
    }

    public enum DeviceType
    {
        COMPORT,
        VIDEO,
        BTBOX
    }

    public enum AceptFormStatus
    {
        Accept,
        Cancel,
        Waitting
    }
    public enum CommonStatus
    {
        Closed,
        Active
    }
    public enum Theme
    {
        Light = 0,
        Dark = 1
    }

    public enum ModeWrite
    {
        STRING,
        BYTE
    }

    public class Ranked
    {
        public static string Excellent = "Giỏi";
        public static string Good = "Tiên tiến";
        public static string Average = "Trung bình";
        public static string BelowAverage = "Yếu";
        public static string Bad = "Kém";
    }
}