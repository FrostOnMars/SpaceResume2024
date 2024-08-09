using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.Models.ResumeModels;

[Skills]
public class SqlSkillsModel
{
    public int? AutoId { get; set; }
    public string? SkillType { get; set; }
    public string? Skill { get; set; }
    public string? ExampleWhereUsed { get; set; }

    /// <summary>
    ///  This class contains properties for the SQL Skills Model.
    /// </summary>
    public SqlSkillsModel()
    {

    }
}

public class SkillsAttribute : Attribute
{
}