﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChiangMaiUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}