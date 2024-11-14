using System;
using System.Collections.Generic;
using API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Database;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdaptationEvent> AdaptationEvents { get; set; }

    public virtual DbSet<AdaptationProgram> AdaptationPrograms { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProgram> EmployeePrograms { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleAgreed> ModuleAgreeds { get; set; }

    public virtual DbSet<ModuleEvent> ModuleEvents { get; set; }

    public virtual DbSet<ModuleMentoring> ModuleMentorings { get; set; }

    public virtual DbSet<ModulePosition> ModulePositions { get; set; }

    public virtual DbSet<ModuleQuestion> ModuleQuestions { get; set; }

    public virtual DbSet<ModuleTest> ModuleTests { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<ProgramModule> ProgramModules { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<TestingResult> TestingResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=localhost;Database=postgres;Username=postgres;Password=root");
        dataSourceBuilder.MapEnum<ModuleStatus>();
        var dataSource = dataSourceBuilder.Build();

        optionsBuilder.UseNpgsql(dataSource).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum<ModuleStatus>()
            .HasPostgresEnum("event_type", new[] { "practice", "theory" })
            .HasPostgresEnum("progress_type", new[] { "noob", "hard_worker", "master" })
            .HasPostgresEnum("report_type", new[] { "quarterly", "department", "position" })
            .HasPostgresEnum("testing_type", new[] { "initial", "final" });

        modelBuilder.Entity<AdaptationEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("adaptation_event_pkey");

            entity.ToTable("adaptation_event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descrition).HasColumnName("descrition");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<AdaptationProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("adaptation_program_pkey");

            entity.ToTable("adaptation_program");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreation).HasColumnName("date_creation");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.IsMentor).HasColumnName("is_mentor");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_department_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_position_id_fkey");
        });

        modelBuilder.Entity<EmployeeProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_program_pkey");

            entity.ToTable("employee_program");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeePrograms)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_program_employee_id_fkey");

            entity.HasOne(d => d.Program).WithMany(p => p.EmployeePrograms)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_program_program_id_fkey");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_pkey");

            entity.ToTable("module");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DateRelease).HasColumnName("date_release");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.InfoSource).HasColumnName("info_source");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ParentModuleId).HasColumnName("parent_module_id");
            entity.Property(e => e.ResponsiblePerson).HasColumnName("responsible_person");

            entity.HasOne(d => d.ResponsiblePersonNavigation).WithMany(p => p.Modules)
                .HasForeignKey(d => d.ResponsiblePerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_responsible_person_fkey");
        });

        modelBuilder.Entity<ModuleAgreed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_agreed_pkey");

            entity.ToTable("module_agreed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.ModuleAgreeds)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_agreed_employee_id_fkey");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleAgreeds)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_agreed_module_id_fkey");
        });

        modelBuilder.Entity<ModuleEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_event_pkey");

            entity.ToTable("module_event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");

            entity.HasOne(d => d.Event).WithMany(p => p.ModuleEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_event_event_id_fkey");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleEvents)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_event_module_id_fkey");
        });

        modelBuilder.Entity<ModuleMentoring>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_mentoring_pkey");

            entity.ToTable("module_mentoring");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.MentorId).HasColumnName("mentor_id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.ModuleMentoringEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_mentoring_employee_id_fkey");

            entity.HasOne(d => d.Mentor).WithMany(p => p.ModuleMentoringMentors)
                .HasForeignKey(d => d.MentorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_mentoring_mentor_id_fkey");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleMentorings)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_mentoring_module_id_fkey");
        });

        modelBuilder.Entity<ModulePosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_position_pkey");

            entity.ToTable("module_position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Module).WithMany(p => p.ModulePositions)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_position_module_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.ModulePositions)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_position_position_id_fkey");
        });

        modelBuilder.Entity<ModuleQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_question_pkey");

            entity.ToTable("module_question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.QuestionText).HasColumnName("question_text");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Test).WithMany(p => p.ModuleQuestions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_question_test_id_fkey");
        });

        modelBuilder.Entity<ModuleTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("module_test_pkey");

            entity.ToTable("module_test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleTests)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_test_module_id_fkey");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_pkey");

            entity.ToTable("position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ProgramModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("program_module_pkey");

            entity.ToTable("program_module");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            entity.HasOne(d => d.Module).WithMany(p => p.ProgramModules)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("program_module_module_id_fkey");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramModules)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("program_module_program_id_fkey");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_pkey");

            entity.ToTable("report");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompletionRate).HasColumnName("completion_rate");
            entity.Property(e => e.DateGeneration).HasColumnName("date_generation");
            entity.Property(e => e.MistakeQuantity).HasColumnName("mistake_quantity");
        });

        modelBuilder.Entity<TestingResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("testing_result_pkey");

            entity.ToTable("testing_result");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateComletion).HasColumnName("date_comletion");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.MistakeQuantity).HasColumnName("mistake_quantity");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.TestingResults)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("testing_result_employee_id_fkey");

            entity.HasOne(d => d.Test).WithMany(p => p.TestingResults)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("testing_result_test_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
