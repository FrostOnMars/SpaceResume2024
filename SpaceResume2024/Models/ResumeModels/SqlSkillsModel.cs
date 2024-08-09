namespace SpaceResume2024.Models.ResumeModels;

[Skills]
public class SqlSkillsModel
{
    #region Public Constructors

    /// <summary>
    /// This class contains properties for the SQL Skills Model.
    /// </summary>
    public SqlSkillsModel()
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public int? AutoId { get; set; }
    public string? ExampleWhereUsed { get; set; }
    public string? Skill { get; set; }
    public string? SkillType { get; set; }

    #endregion Public Properties
}

public class SkillsAttribute : Attribute
{
}