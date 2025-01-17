﻿using SeedDatabaseConsoleApplication.Enums;

namespace SeedDatabaseConsoleApplication.Models
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public Name Name { get; set; }
        public Gender? Gender { get; set; }

        public DateTime? BirthDate { get; set; }
        public bool? Active { get; set; }
    }
}
