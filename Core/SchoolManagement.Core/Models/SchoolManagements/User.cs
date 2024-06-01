using Avalonia.Media.Imaging;
using Prism.Mvvm;
using SchoolManagement.Core.Constants;
using SchoolManagement.Core.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class User : BindableBase
{
    private string? firstName;
    private string? lastName;
    private string? gender;
    private DateTime dateOfBirth = DateTime.Now;
    private string? phoneNumber;
    private string? address;
    private string? email;
    private string? image;
    private string? username;
    private string? password;
    private string? role;
    private byte? activeStatus;
    private DateTime startDate = DateTime.Now;
    private DateTime? endDate = DateTime.Now;
    private Role userRole;
    private Bitmap imageBitmap;
    private bool? lockAccount;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int UserId { get; set; }

    [DisplayName("FirstName_Label")]
    public string? FirstName
    { get => firstName; set { SetProperty(ref firstName, value); } }

    [DisplayName("LastName_Label")]
    public string? LastName
    { get => lastName; set { SetProperty(ref lastName, value); } }

    [Browsable(false)]
    public string FullName => $"{FirstName} {LastName}";

    [DisplayName("Gender_Label")]
    public string? Gender
    { get => gender; set { SetProperty(ref gender, value); } }

    [DisplayName("DateOfBirth_Label")]
    public DateTime DateOfBirth
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

    [DisplayName("PhoneNumber_Label")]
    public string? PhoneNumber
    { get => phoneNumber; set { SetProperty(ref phoneNumber, value); } }

    [DisplayName("Address_Label")]
    public string? Address
    { get => address; set { SetProperty(ref address, value); } }

    [DisplayName("Email_Label")]
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

    [DisplayName("StartDate_Label")]
    [Browsable(false)]
    public DateTime StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    [DisplayName("EndDate_Label")]
    [Browsable(false)]
    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    [Browsable(false)]
    public bool? LockAccount { get => lockAccount; set => SetProperty(ref lockAccount, value); }

    [NotMapped]
    [DisplayName("Role_Label")]
    public Role UserRole
    { get => userRole; set { SetProperty(ref userRole, value); UpdateRole(); } }

    [Browsable(false)]
    [NotMapped]
    public Bitmap ImageBitmap { get => imageBitmap; set => SetProperty(ref imageBitmap, value); }

    [Browsable(false)]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [Browsable(false)]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public User()
    {
        UpdateImage();
    }

    public void UpdateRole()
    {
        Role = UserRole.ToString().ToLower();
    }

    public async void UpdateImage()
    {
        try
        {
            ImageBitmap = await ImageHelper.LoadFromWeb(new Uri(Image));
            if (ImageBitmap == null)
            {
                ImageBitmap = await ImageHelper.LoadImageFromResourse(ImagePath.DefaultUserImage);
                return;
            }
        }
        catch (Exception e)
        {
            ImageBitmap = await ImageHelper.LoadImageFromResourse(ImagePath.DefaultUserImage);
            Debug.WriteLine(e);
        }
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
        UpdateImage();
    }
}