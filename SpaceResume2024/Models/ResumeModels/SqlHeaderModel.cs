namespace SpaceResume2024.Models.ResumeModels;

[Header]
public class SqlHeaderModel
{
    #region Public Constructors

    /// <summary>
    /// This class contains properties for the SQL Header information (model).
    /// </summary>
    public SqlHeaderModel()
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public string? Address { get; set; }
    public Guid AutoId { get; set; }
    public string? ElevatorPitch { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? PortfolioLink { get; set; }

    #endregion Public Properties
}

public class HeaderAttribute : Attribute
{
}