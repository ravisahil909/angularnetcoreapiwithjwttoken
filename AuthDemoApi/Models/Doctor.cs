using System;

namespace AuthDemoApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }

    public class LabTest
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int Testname { get; set; }
        public DateTime Date { get; set; }
    }
    

}
