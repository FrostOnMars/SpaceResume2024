using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.Models.ResumeModels;

[Header]
public class SqlHeaderModel
{
    public Guid AutoId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? PortfolioLink { get; set; }
    public string? ElevatorPitch { get; set; }

    /// <summary>
    ///  This class contains properties for the SQL Header information (model).
    /// </summary>
    public SqlHeaderModel()
    {

    }
}

public class HeaderAttribute : Attribute
{
}