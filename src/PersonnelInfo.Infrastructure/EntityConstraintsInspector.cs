using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PersonnelInfo.Infrastructure
{
    public class EntityConstraintsInspector
    {
        private static string GetDesktopPath() =>
            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        private static string GetProjectName() =>
            Assembly.GetExecutingAssembly().GetName().Name;

        private static string GetFilePath(string fileName) =>
            Path.Combine(GetDesktopPath(), fileName);

        public static void PrintEntityConstraints(DbContext dbContext, Type entityType, bool exportToTextFile = false)
        {
            var model = dbContext.Model;
            var entity = model.FindEntityType(entityType);

            if (entity == null)
            {
                Console.WriteLine($"Entity type '{entityType.Name}' not found in the DbContext.");
                return;
            }

            Console.WriteLine($"Entity: {entityType.Name}");
            Console.WriteLine(new string('-', 50));

            // For text file export
            StreamWriter writer = null;

            if (exportToTextFile)
            {
                // Get the project name and prepend it to the file name
                string projectName = GetProjectName();
                string filePath = GetFilePath($"{projectName}_EntityConstraints_{entityType.Name}.txt");

                writer = new StreamWriter(filePath, append: true);
                writer.WriteLine($"Entity: {entityType.Name}");
                writer.WriteLine(new string('-', 50));
            }

            // Iterate over properties and print information
            foreach (var property in entity.GetProperties().OrderBy(p => p.IsNullable))
            {
                var propertyName = property.Name;
                var isNullable = property.IsNullable;
                var maxLength = property.GetMaxLength();
                var isPrimaryKey = property.IsPrimaryKey();
                var isForeignKey = property.IsForeignKey();
                var columnType = property.GetColumnType();

                // Print to Console
                if (!exportToTextFile)
                {
                    Console.WriteLine($"Property: {propertyName}");
                    Console.WriteLine($"  - Nullable: {isNullable}");
                    Console.WriteLine($"  - Max Length: {(maxLength.HasValue ? maxLength.Value.ToString() : "None")}");
                    Console.WriteLine($"  - Primary Key: {isPrimaryKey}");
                    Console.WriteLine($"  - Foreign Key: {isForeignKey}");
                    Console.WriteLine($"  - Column Type: {columnType ?? "Default"}");
                    Console.WriteLine();
                }
                else
                {
                    // Write to file
                    writer.WriteLine($"Property: {propertyName}");
                    writer.WriteLine($"  - Nullable: {isNullable}");
                    writer.WriteLine($"  - Max Length: {(maxLength.HasValue ? maxLength.Value.ToString() : "None")}");
                    writer.WriteLine($"  - Primary Key: {isPrimaryKey}");
                    writer.WriteLine($"  - Foreign Key: {isForeignKey}");
                    writer.WriteLine($"  - Column Type: {columnType ?? "Default"}");
                    writer.WriteLine();
                }
            }

            // Close the writer if exporting to file
            writer?.Close();
        }

        public static void PrintAllEntitiesConstraints(DbContext dbContext, bool exportToTextFile = false)
        {
            if (!exportToTextFile)
            {
                var entityTypes = dbContext.Model.GetEntityTypes();

                foreach (var entityType in entityTypes)
                {
                    PrintEntityConstraints(dbContext, entityType.ClrType);
                    Console.WriteLine(new string('=', 50));
                }
            }
            else
            {
                string projectName = GetProjectName();
                string filePath = GetFilePath($"{projectName}_All_EntityConstraints.txt");

                using (var writer = new StreamWriter(filePath, append: true))
                {
                    var entityTypes = dbContext.Model.GetEntityTypes();

                    foreach (var entityType in entityTypes)
                    {
                        PrintEntityConstraints(dbContext, entityType.ClrType, true);
                        writer.WriteLine(new string('=', 50));
                    }
                }
            }
        }
    }
}
