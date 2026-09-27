using Microsoft.EntityFrameworkCore;
using Student_Managmet.Models;


namespace Student_Managmet.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Departmant> Dapartmant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Departments
            modelBuilder.Entity<Departmant>().HasData(
                new Departmant { Id = 1, Name = "Artificial Intelligence" },
                new Departmant { Id = 2, Name = "Cyber Security" },
                new Departmant { Id = 3, Name = "Digital Marketing" },
                new Departmant { Id = 4, Name = "Software Engineering" },
                new Departmant { Id = 5, Name = "Data Science" }
            );

            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Omar Khaled", Email = "omar.khaled@example.com", DataOfBirth = new DateTime(2002, 2, 14), DapartmantId = 1 },
                new Student { Id = 2, Name = "Laila Mahmoud", Email = "laila.mahmoud@example.com", DataOfBirth = new DateTime(2003, 6, 18), DapartmantId = 2 },
                new Student { Id = 3, Name = "Khaled Samir", Email = "khaled.samir@example.com", DataOfBirth = new DateTime(2001, 4, 9), DapartmantId = 3 },
                new Student { Id = 4, Name = "Fatma Adel", Email = "fatma.adel@example.com", DataOfBirth = new DateTime(2002, 12, 2), DapartmantId = 4 },
                new Student { Id = 5, Name = "Mostafa Ahmed", Email = "mostafa.ahmed@example.com", DataOfBirth = new DateTime(2000, 8, 30), DapartmantId = 5 }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Python Basics", Credits = 3 },
                new Course { Id = 2, Name = "Machine Learning", Credits = 4 },
                new Course { Id = 3, Name = "Cybersecurity Fundamentals", Credits = 3 },
                new Course { Id = 4, Name = "Software Testing", Credits = 2 },
                new Course { Id = 5, Name = "Data Visualization", Credits = 3 }
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Dr. Heba Youssef", Email = "heba.youssef@example.com", HireDate = new DateTime(2020, 10, 10) },
                new Instructor { Id = 2, Name = "Dr. Karim Nabil", Email = "karim.nabil@example.com", HireDate = new DateTime(2018, 2, 5) },
                new Instructor { Id = 3, Name = "Dr. Salma Fathy", Email = "salma.fathy@example.com", HireDate = new DateTime(2019, 11, 22) },
                new Instructor { Id = 4, Name = "Dr. Ehab Hassan", Email = "ehab.hassan@example.com", HireDate = new DateTime(2021, 6, 1) },
                new Instructor { Id = 5, Name = "Dr. Rasha Emad", Email = "rasha.emad@example.com", HireDate = new DateTime(2022, 4, 12) }
            );

            // Office Assignments
            modelBuilder.Entity<OfficeAssignment>().HasData(
                new OfficeAssignment { InstructorId = 1, Location = "Room F101" },
                new OfficeAssignment { InstructorId = 2, Location = "Room G202" },
                new OfficeAssignment { InstructorId = 3, Location = "Room H303" },
                new OfficeAssignment { InstructorId = 4, Location = "Room I404" },
                new OfficeAssignment { InstructorId = 5, Location = "Room J505" }
            );

            // Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Grade = "B+" },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 2, Grade = "A" },
                new Enrollment { Id = 3, StudentId = 3, CourseId = 3, Grade = "B" },
                new Enrollment { Id = 4, StudentId = 4, CourseId = 4, Grade = "C+" },
                new Enrollment { Id = 5, StudentId = 5, CourseId = 5, Grade = "A-" }
            );

            // Attendance
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { Id = 1, StudentId = 1, CourseId = 1, Date = new DateTime(2025, 9, 2), IsPresent = true },
                new Attendance { Id = 2, StudentId = 2, CourseId = 2, Date = new DateTime(2025, 9, 2), IsPresent = true },
                new Attendance { Id = 3, StudentId = 3, CourseId = 3, Date = new DateTime(2025, 9, 2), IsPresent = false },
                new Attendance { Id = 4, StudentId = 4, CourseId = 4, Date = new DateTime(2025, 9, 2), IsPresent = true },
                new Attendance { Id = 5, StudentId = 5, CourseId = 5, Date = new DateTime(2025, 9, 2), IsPresent = false }
            );
        }

    }
}
