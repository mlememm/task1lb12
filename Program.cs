using System;
using System.Linq;
using System.Xml.Linq;
class GroupStudentsByGroup
{
    public static void Run()
    {
        string xmlPath = "students.xml";
        if (!System.IO.File.Exists(xmlPath))
        {
            new XElement("Students",
                new XElement("Student",
                    new XAttribute("name", "Artem"),
                    new XAttribute("group", "A"),
                    new XElement("Math", 90),
                    new XElement("AI", 85)
                ),
                new XElement("Student",
                    new XAttribute("name", "Artur"),
                    new XAttribute("group", "B"),
                    new XElement("Math", 75),
                    new XElement("AI", 80)
                ),
                new XElement("Student",
                    new XAttribute("name", "Bogdan"),
                    new XAttribute("group", "A"),
                    new XElement("Math", 88),
                    new XElement("AI", 92)
                )
            ).Save(xmlPath);
        }

        XElement root = XElement.Load(xmlPath);

        var groups = root.Elements("Student")
                         .GroupBy(s => s.Attribute("group").Value)
                         .Select(g => new { Group = g.Key, Count = g.Count() });

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Group}: {group.Count} students");
        }
    }
}
class Program
{
    static void Main()
    {
        GroupStudentsByGroup.Run();
    }
}
