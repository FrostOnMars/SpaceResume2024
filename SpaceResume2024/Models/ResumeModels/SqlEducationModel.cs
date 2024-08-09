namespace SpaceResume2024.Models.ResumeModels;

[Education]
public class SqlEducationModel
{
    #region Public Constructors

    /// <summary>
    /// This class contains properties for the SQL Education Model.
    /// </summary>
    public SqlEducationModel()
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public int AutoId { get; set; }
    public string? CertificationID { get; set; }
    public string? Degree { get; set; }
    public string? EducationAchievements { get; set; }
    public string? EducationType { get; set; }
    public string? EndDateAttended { get; set; }
    public string? GraduationDate { get; set; }
    public string? SchoolName { get; set; }
    public string? StartDateAttended { get; set; }

    #endregion Public Properties
}

public class EducationAttribute : Attribute
{
}