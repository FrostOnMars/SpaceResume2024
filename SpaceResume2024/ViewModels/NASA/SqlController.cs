using SpaceResume2024.Models.PlanetModels;
using SpaceResume2024.Models.ResumeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.ViewModels.NASA;

// This class retrieves resume data from the SQLite database.
// The properties are described in \Model\ResumeModel
namespace SpaceResume.View_Model.NASA;

public class SqlController
{
    private static List<SqlEducationModel> _resumeEducationModels;

    public void Setup()
    {

    }
    //public static List<SqlEducationModel> GetAllResumeEducationModels()
    //{
    //    _resumeEducationModels = new List<SqlEducationModel>();

    //    using var connection = new SQLiteConnection(Resources.SqlDataSource);
    //    connection.Open();
    //    var query = Resources.EducationQuery;

    //    using var command = new SQLiteCommand(query, connection);
    //    using var reader = command.ExecuteReader();
    //    //var test = "";

    //    try
    //    {
    //        while (reader.Read())
    //        {
    //            //test += $"AutoId: {reader[0]} School Name: {reader[1]} StartDateAttended: {reader[2]} {reader[3]}{reader[4]}{reader[5]}"
    //            var resumeEducation = new SqlEducationModel
    //            {
    //                AutoId = reader.GetInt32(0),
    //                SchoolName = reader.IsDBNull(1) ? null : reader.GetString(1),
    //                StartDateAttended = reader.IsDBNull(2) ? null : reader.GetString(2),
    //                EndDateAttended = reader.IsDBNull(3) ? null : reader.GetString(3),
    //                GraduationDate = reader.IsDBNull(4) ? null : reader.GetString(4),
    //                Degree = reader.IsDBNull(5) ? null : reader.GetString(5),
    //                EducationType = reader.IsDBNull(6) ? null : reader.GetString(6),
    //                EducationAchievements = reader.IsDBNull(7) ? null : reader.GetString(7),
    //                CertificationID = reader.IsDBNull(8) ? null : reader.GetString(8)
    //            };
    //            _resumeEducationModels.Add(resumeEducation);
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e.Message);
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }

    //    return _resumeEducationModels;
    //}

    public static List<T> GetResumeData<T>(string query, T model)
    {
        var connection = OpenSqLiteConnection();

        using var command = new SQLiteCommand(query, connection);
        using var reader = command.ExecuteReader();

        try
        {
            GetResumeData(Resources.EducationQuery, new SqlEducationModel());
            while (reader.Read())
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    try
                    {
                        var valueToSet = Convert.ChangeType(GetStringColumn(reader, property.Name),
                            property.PropertyType);
                        property.SetValue(model, valueToSet);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(@$"Error setting property {property.Name}: {ex.Message}");
                    }

                    Console.WriteLine(@$"Property: {property.Name}, Type: {property.PropertyType}");
                }

                //tricky part
                _resumeEducationModels.Add(resumeEducation);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }

        return _resumeEducationModels;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class EducationAttribute : Attribute
    {
        // Your attribute properties, if any
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SkillsAttribute : Attribute
    {
        // Your attribute properties, if any
    }

    public class YourClass
    {
        List<object> educationList = new List<object>();
        List<object> skillsList = new List<object>();
        // Add more lists as needed...

        public void AddModelToList<T>(T newModel)
        {
            var modelType = typeof(T);

            if (modelType.GetCustomAttributes(typeof(EducationAttribute), true).FirstOrDefault() != null)
            {
                educationList.Add(newModel);
            }
            else if (modelType.GetCustomAttributes(typeof(SkillsAttribute), true).FirstOrDefault() != null)
            {
                skillsList.Add(newModel);
            }
            // Add more conditions for other attributes...

            else
            {
                // Handle cases where the model doesn't have any expected attribute.
            }
        }

        private static SQLiteConnection OpenSqLiteConnection()
        {
            using var connection = new SQLiteConnection(Resources.SqlDataSource);
            connection.Open();
            return connection;
        }

        private static bool ColumnExists(SQLiteDataReader reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static string? GetStringColumn(SQLiteDataReader reader, string columnName)
        {
            return ColumnExists(reader, columnName)
                ? !reader.IsDBNull(reader.GetOrdinal(columnName))
                    ? reader[columnName].ToString()
                    : null
                : null;
        }

        public static List<SqlHeaderModel> GetAllResumeHeaders()
        {
            var resumeHeaders = new List<SqlHeaderModel>();

            using var connection = new SQLiteConnection("Data Source=ResumeDataFile.db");
            connection.Open();

            var query = "SELECT * FROM ResumeHeader";
            //    }
            using (var command = new SQLiteCommand(query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var resumeHeader = new SqlHeaderModel
                    {
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Address = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                        PortfolioLink = reader.IsDBNull(6) ? null : reader.GetString(6),
                        ElevatorPitch = reader.GetString(7)
                    };

                    resumeHeaders.Add(resumeHeader);
                }
            }

            connection.Close();

            return resumeHeaders;
        }

        public static List<SqlSkillsModel> GetAllResumeSkills()
        {
            var resumeSkills = new List<SqlSkillsModel>();

            using var connection = new SQLiteConnection("Data Source=ResumeDataFile.db");
            connection.Open();

            var query = "SELECT * FROM ResumeSkills";

            using (var command = new SQLiteCommand(query, connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var resumeSkill = new SqlSkillsModel
                    {
                        AutoId = reader.GetInt32(0),
                        SkillType = reader.GetString(1),
                        Skill = reader.GetString(2),
                        ExampleWhereUsed = reader.IsDBNull(3) ? null : reader.GetString(3)

                    };

                    resumeSkills.Add(resumeSkill);
                }
            }

            connection.Close();

            return resumeSkills;
        }

        public static List<SqlPlanetModel> GetAllPlanetModels()
        {
            var planetModels = new List<SqlPlanetModel>();

            using var connection = new SQLiteConnection("Data Source=ResumeDataFile.db");
            connection.Open();

            var query = "SELECT * FROM PlanetDescriptions";


            using var command = new SQLiteCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var planetDescription = new SqlPlanetModel
                {
                    AutoId = reader.GetInt32(0),
                    PlanetName = reader.GetString(1),
                    PlanetDescription = reader.GetString(2),
                    PlanetOrder = reader.IsDBNull(3) ? null : reader.GetString(3)
                };

                planetModels.Add(planetDescription);
            }

            connection.Close();

            return planetModels;
        }
    }
}