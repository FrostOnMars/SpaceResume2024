using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.Models.ResumeModels;

[Education]
public class SqlEducationModel
{
    public int AutoId { get; set; }
    public string? SchoolName { get; set; }
    public string? StartDateAttended { get; set; }
    public string? EndDateAttended { get; set; }
    public string? GraduationDate { get; set; }
    public string? Degree { get; set; }
    public string? EducationType { get; set; }
    public string? EducationAchievements { get; set; }
    public string? CertificationID { get; set; }

    /// <summary>
    ///  This class contains properties for the SQL Education Model.
    /// </summary>
    public SqlEducationModel()
    {

    }
}

public class EducationAttribute : Attribute
{

}