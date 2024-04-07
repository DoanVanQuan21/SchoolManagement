using Prism.Mvvm;
using System;
using System.Collections.Generic;

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
    private DateTime? startDate;
    private DateTime? endDate;

    public int UserId { get; set; }

    public string? FirstName
    { get => firstName; set { SetProperty(ref firstName, value); } }

    public string? LastName
    { get => lastName; set { SetProperty(ref lastName, value); } }

    public string? Gender
    { get => gender; set { SetProperty(ref gender, value); } }

    public DateTime? DateOfBirth
    { get => dateOfBirth; set { SetProperty(ref dateOfBirth, value); } }

    public string? PhoneNumber
    { get => phoneNumber; set { SetProperty(ref phoneNumber, value); } }

    public string? Address
    { get => address; set { SetProperty(ref address, value); } }

    public string? Email
    { get => email; set { SetProperty(ref email, value); } }

    public string? Image
    { get => image; set { SetProperty(ref image, value); } }

    public string? Username
    { get => username; set { SetProperty(ref username, value); } }

    public string? Password
    { get => password; set { SetProperty(ref password, value); } }

    public string? Role
    { get => role; set { SetProperty(ref role, value); } }

    public byte? ActiveStatus
    { get => activeStatus; set { SetProperty(ref activeStatus, value); } }

    public DateTime? StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}