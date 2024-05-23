using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Models.SchoolManagements;

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

    public virtual DbSet<EditGradeSheetForm> EditGradeSheetForms { get; set; }

    public virtual DbSet<EducationProgram> EducationPrograms { get; set; }

    public virtual DbSet<GradeSheet> GradeSheets { get; set; }

    public virtual DbSet<HomeroomAssignment> HomeroomAssignments { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }

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
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A02FCAA1ED");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassCode).HasMaxLength(100);
            entity.Property(e => e.ClassName).HasMaxLength(100);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71878B761C82");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.EducationProgramId).HasColumnName("EducationProgramID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Semester).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Class).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__ClassID__398D8EEE");

            entity.HasOne(d => d.EducationProgram).WithMany(p => p.Courses)
                .HasForeignKey(d => d.EducationProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__Educatio__3C69FB99");

            entity.HasOne(d => d.Subject).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__SubjectI__3B75D760");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__TeacherI__3A81B327");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD113690A9");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentCode).HasMaxLength(20);
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.FoundingDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(100);
        });

        modelBuilder.Entity<EditGradeSheetForm>(entity =>
        {
            entity.HasKey(e => e.EditGradeSheetFormId).HasName("PK__EditGrad__31DF283E44048D36");

            entity.ToTable("EditGradeSheetForm");

            entity.Property(e => e.EditGradeSheetFormId).HasColumnName("EditGradeSheetFormID");
            entity.Property(e => e.GradeSheetId).HasColumnName("GradeSheetID");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.GradeSheet).WithMany(p => p.EditGradeSheetForms)
                .HasForeignKey(d => d.GradeSheetId)
                .HasConstraintName("FK__EditGrade__Grade__47DBAE45");

            entity.HasOne(d => d.Teacher).WithMany(p => p.EditGradeSheetForms)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EditGrade__Teach__48CFD27E");
        });

        modelBuilder.Entity<EducationProgram>(entity =>
        {
            entity.HasKey(e => e.EducationProgramId).HasName("PK__Educatio__FDEFCDF501C9D36C");

            entity.ToTable("EducationProgram");

            entity.Property(e => e.EducationProgramId).HasColumnName("EducationProgramID");
            entity.Property(e => e.EducationName).HasMaxLength(100);
            entity.Property(e => e.EducationProgramCode).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(100);
        });

        modelBuilder.Entity<GradeSheet>(entity =>
        {
            entity.HasKey(e => e.GradeSheetId).HasName("PK__GradeShe__3D3F1211A5223DAC");

            entity.ToTable("GradeSheet");

            entity.Property(e => e.GradeSheetId).HasColumnName("GradeSheetID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeShee__Cours__3F466844");

            entity.HasOne(d => d.Student).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GradeShee__Stude__403A8C7D");
        });

        modelBuilder.Entity<HomeroomAssignment>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.TeacherId }).HasName("PK__Homeroom__95C602344B40E136");

            entity.ToTable("HomeroomAssignment");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Lesson__B084ACB0C2C34A59");

            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.EducationProgramId).HasColumnName("EducationProgramID");
            entity.Property(e => e.LessonCode).HasMaxLength(100);
            entity.Property(e => e.LessonName).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(100);

            entity.HasOne(d => d.EducationProgram).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.EducationProgramId)
                .HasConstraintName("FK__Lesson__Educatio__44FF419A");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B693FAC1F2A");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("ScheduleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Day).HasColumnType("datetime");
            entity.Property(e => e.End).HasColumnType("datetime");
            entity.Property(e => e.ScheduleCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Start).HasColumnType("datetime");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79B6E206F7");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentCode).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Student__UserID__286302EC");
        });

        modelBuilder.Entity<StudentAssignment>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__StudentA__2E74B8038C29E732");

            entity.ToTable("StudentAssignment");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3887F0594B6");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectCode).HasMaxLength(15);
            entity.Property(e => e.SubjectName).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF25944644BEE67");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.AdditionalBenifits).HasMaxLength(100);
            entity.Property(e => e.CurrentHealthStatus).HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(200);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Expertise).HasMaxLength(100);
            entity.Property(e => e.GraduationYear).HasColumnType("datetime");
            entity.Property(e => e.HealthInsuranceInfo).HasMaxLength(100);
            entity.Property(e => e.Major).HasMaxLength(100);
            entity.Property(e => e.OtherCertifications).HasMaxLength(200);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SelfIntroduction).HasColumnType("text");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherCode).HasMaxLength(100);
            entity.Property(e => e.University).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teacher__Departm__2D27B809");

            entity.HasOne(d => d.Subject).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teacher__Subject__2F10007B");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teacher__UserID__2E1BDC42");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC1E4AFB13");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(12);
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
