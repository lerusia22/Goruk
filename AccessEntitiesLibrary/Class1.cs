
using Microsoft.EntityFrameworkCore;
using System.Windows.Documents;

namespace AccessEntitiesLibrary
{
    public enum Position
    {
        User,
        Admin
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Departament { get; set; } 
        public Position Position { get; set; }
        public bool IsActive { get; set; }
        public override string ToString()
        {
            return $"ФИО: {FullName}\nПодразделение: {Departament}\nПрава: {Position.ToString()}";
        }
    }
    public enum Location
    {
        Корпус, 
        Вход,
        Выход 
    }
    public class Checkpoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool IsActive { get; set; }
        public override string ToString()
        {
            return $"{Name},  {Location}";
        }
    }
    public class AccessLogEntry
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CheckpointId { get; set; }
        public DateTime? EntryTime { get; set; } 
        public DateTime? ExitTime { get; set; }
        public Location Direction { get; set; } 
        public Employee Employee { get; set; }
        public Checkpoint Checkpoint { get; set; }
        public override string ToString()
        {
            return $"{Employee?.FullName} - {Checkpoint?.Name} - {EntryTime}";
        }
    }
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=lera");

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Checkpoint> Checkpoint { get; set; }
        public DbSet<AccessLogEntry> AccessLogEntry { get; set; }
    }
}
