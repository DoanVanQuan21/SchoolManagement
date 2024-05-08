using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class SchoolManagementContext : DbContext
{
    private readonly string _connectionString;
    public SchoolManagementContext()
    {
    }
    public SchoolManagementContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EducationProgram> EducationPrograms { get; set; }

    public virtual DbSet<GradeSheet> GradeSheets { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A0F99E032F");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ClassName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Class__TeacherID__398D8EEE");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.SubjectId }).HasName("PK__Course__51D89D988DE1D0D9");

            entity.ToTable("Course");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Semester).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Course__TeacherI__3A81B327");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD45C91226");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FoundingDate).HasColumnType("datetime");
        }).UseIdentityColumns(1,1);

        modelBuilder.Entity<EducationProgram>(entity =>
        {
            entity.HasKey(e => e.EducationProgramId).HasName("PK__Educatio__FDEFCDF5D2234B49");

            entity.ToTable("EducationProgram");

            entity.Property(e => e.EducationProgramId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EducationProgramID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.EducationName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EducationProgramCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Class).WithMany(p => p.EducationPrograms)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Education__Class__4316F928");

            entity.HasOne(d => d.Subject).WithMany(p => p.EducationPrograms)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__Subje__440B1D61");
        });

        modelBuilder.Entity<GradeSheet>(entity =>
        {
            entity.HasKey(e => e.GradeSheetId).HasName("PK__GradeShe__3D3F1211A9EA5696");

            entity.ToTable("GradeSheet");

            entity.Property(e => e.GradeSheetId)
                .ValueGeneratedOnAdd()
                .HasColumnName("GradeSheetID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.FinalScore).HasColumnType("float");
            entity.Property(e => e.FirstRegularScore).HasColumnType("float");
            entity.Property(e => e.FourRegularScore).HasColumnType("float");
            entity.Property(e => e.MidtermScore).HasColumnType("float");
            entity.Property(e => e.SecondRegularScore).HasColumnType("float");
            entity.Property(e => e.SemesterAverage).HasColumnType("float");
            entity.Property(e => e.PromotionDecision).HasColumnType("bool");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.ThirdRegularScore).HasColumnType("float");

            entity.HasOne(d => d.Class).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeShee__Class__3B75D760");

            entity.HasOne(d => d.Student).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeShee__Stude__3C69FB99");

            entity.HasOne(d => d.Subject).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeShee__Subje__3D5E1FD2");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Lesson__B084ACB022E0AFB4");

            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("LessonID");
            entity.Property(e => e.EducationProgramId).HasColumnName("EducationProgramID");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.LessonCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LessonName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VideoUrl).IsUnicode(false);

            entity.HasOne(d => d.EducationProgram).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.EducationProgramId)
                .HasConstraintName("FK__Lesson__Educatio__44FF419A");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69566E3AE3");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ScheduleID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.Day).HasColumnType("datetime");
            entity.Property(e => e.End).HasColumnType("datetime");
            entity.Property(e => e.ScheduleCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Start).HasColumnType("datetime");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Class).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Schedule__ClassI__3E52440B");

            entity.HasOne(d => d.Subject).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__Subjec__3F466844");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79855CA479");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassID__37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Student__UserID__38996AB5");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA388E90E1897");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SubjectID");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF25944D698EAB3");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TeacherID");
            entity.Property(e => e.AdditionalBenifits)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrentHealthStatus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Degree)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Expertise)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Expertise_");
            entity.Property(e => e.GraduationYear).HasColumnType("datetime");
            entity.Property(e => e.HealthInsuranceInfo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HealthInsuranceInfo_");
            entity.Property(e => e.LeaderId).HasColumnName("LeaderID");
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OtherCertifications)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OtherCertifications_");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SelfIntroduction)
                .HasColumnType("text")
                .HasColumnName("SelfIntroduction_");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.University)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teacher__Departm__45F365D3");

            entity.HasOne(d => d.Subject).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Teacher__Subject__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teacher__UserID__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC10F8FF71");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
