using Prism.Mvvm;
using SchoolManagement.Core.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class User : BindableBase
{
    private string? firstName;
    private string? lastName;
    private string? gender;
    private DateTime? dateOfBirth;
    private string? phoneNumber;
    private string? address;
    private string? email;
    private string? image;
    private string? username;
    private string? password;
    private string? role;
    private byte? activeStatus;
    private DateTime startDate;
    private DateTime? endDate;
    private Role userRole;

    [Browsable(false)]
    public int UserId { get; set; }

    [DisplayName("Họ đệm")]
    public string? FirstName
    { get => firstName; set { SetProperty(ref firstName, value); } }

    [DisplayName("Tên")]
    public string? LastName
    { get => lastName; set { SetProperty(ref lastName, value); } }

    public string FullName => $"{FirstName} {LastName}";

    [DisplayName("Giới tính")]
    public string? Gender
    { get => gender; set { SetProperty(ref gender, value); } }

    [DisplayName("Ngày sinh")]
    public DateTime? DateOfBirth
    {
        get => dateOfBirth; set
        {
            if (value == null)
            {
                return;
            }
            SetProperty(ref dateOfBirth, value);
        }
    }

    [DisplayName("Số điện thoại")]
    public string? PhoneNumber
    { get => phoneNumber; set { SetProperty(ref phoneNumber, value); } }

    [DisplayName("Địa chỉ")]
    public string? Address
    { get => address; set { SetProperty(ref address, value); } }

    [DisplayName("Email")]
    public string? Email
    { get => email; set { SetProperty(ref email, value); } }

    [Browsable(false)]
    public string? Image
    { get => image; set { SetProperty(ref image, value); } }

    [Browsable(false)]
    public string? Username
    { get => username; set { SetProperty(ref username, value); } }

    [Browsable(false)]
    public string? Password
    { get => password; set { SetProperty(ref password, value); } }

    [Browsable(false)]
    public string? Role
    { get => role; set { SetProperty(ref role, value); } }

    [Browsable(false)]
    public byte? ActiveStatus
    { get => activeStatus; set { SetProperty(ref activeStatus, value); } }

    [DisplayName("Ngày bắt đầu")]
    [Browsable(false)]
    public DateTime StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    [DisplayName("Ngày kết thúc")]
    [Browsable(false)]
    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    [NotMapped]
    public Role UserRole
    { get => userRole; set { SetProperty(ref userRole, value); } }

    [Browsable(false)]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [Browsable(false)]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public User()
    {
    }

    public User(User user)
    {
        if (user == null)
        {
            return;
        }
        UserId = user.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Gender = user.Gender;
        DateOfBirth = user.DateOfBirth;
        PhoneNumber = user.PhoneNumber;
        Address = user.Address;
        Email = user.Email;
        Image = user.Image;
        Username = user.Username;
        Password = user.Password;
        Role = user.Role;
        ActiveStatus = user.ActiveStatus;
        StartDate = user.StartDate;
        EndDate = user.EndDate;
    }
}