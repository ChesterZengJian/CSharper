using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MongoDbTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var alsAssemblyName = @"D:\ServiceName\bin\Debug\ServiceName.dll";
            var defaultAssemblyName = @"D:\MongoDbDemo.dll";

            var assembly = Assembly.LoadFile(alsAssemblyName);
            var modelTypes = assembly.GetTypes();

            foreach (var type in modelTypes)
            {
                Console.WriteLine($"Type name: {type.Name}\nAssemblyQualifiedName: {type.AssemblyQualifiedName}\nModule: {type.Module}\nNamespace: {type.Namespace}");
                PrintModelInfo(type);
                Console.WriteLine();
            }

        }

        private static void PrintModelInfo(Type type)
        {
            var propertyInfos = type.GetProperties();
            IReadOnlyDictionary<Type, string> mongoDbType = new Dictionary<Type, string>()
            {
                {typeof(string), "String"},
                {typeof(int), "Integer"},
                {typeof(bool), "Boolean"},
                {typeof(double), "Double"},
                {typeof(DateTime), "Date"},
                {typeof(object), "Object"},
            };

            foreach (var propertyInfo in propertyInfos)
            {
                try
                {
                    Console.WriteLine($"The {propertyInfo.Name} of {type.Name} is {mongoDbType[propertyInfo.PropertyType]}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("=============================================");
                    Console.WriteLine($"The {propertyInfo.Name} of {type.Name} is {propertyInfo.PropertyType}");
                    Console.WriteLine("=============================================");
                }
            }

        }

        //private static readonly ILogger _logger = GlobalLogger.FromCurrentType();

        //public void GetTypes()
        //{
        //    const string MULTIMEDIA_TRANSFER_SERVICE = "ServiceName";
        //    const string DB_DOCUMENT_ROOT = @"D:\数据库说明\数据库表";
        //    const string ASSEMBLY_ROOT = @"D:\ServiceName\bin\Debug";
        //    const string DB_MODEL_NAMESPACE = "ServiceName.Models.Database";
        //    var excel = Path.Combine(DB_DOCUMENT_ROOT, $"{MULTIMEDIA_TRANSFER_SERVICE}.xlsx");
        //    var etsAssemblyName = Path.Combine(ASSEMBLY_ROOT, $"{MULTIMEDIA_TRANSFER_SERVICE}.dll");
        //    var erTxt = Path.Combine(DB_DOCUMENT_ROOT, $"{MULTIMEDIA_TRANSFER_SERVICE}.txt");
        //    var assembly = Assembly.LoadFile(etsAssemblyName);
        //    var modelTypes = assembly.GetTypes().Where(t => !string.IsNullOrEmpty(t.Namespace) && t.Namespace.Contains(DB_MODEL_NAMESPACE)).ToArray();
        //    var propertyStringBuilder = new StringBuilder();

        //    IWorkbook workbook;
        //    using (var readFileStream = new FileStream(excel, FileMode.Open, FileAccess.ReadWrite))
        //    {
        //        workbook = WorkbookFactory.Create(readFileStream);
        //    }

        //    _logger.Trace($"modelTypes length is {modelTypes.Length}");
        //    for (var i = 0; i < modelTypes.Length - 1; i++)
        //    {
        //        workbook.CloneSheet(0);
        //    }

        //    var typeIndex = 0;
        //    foreach (var type in modelTypes)
        //    {
        //        _logger.Debug($"Type name: {type.Name}\nAssemblyQualifiedName: {type.AssemblyQualifiedName}\nModule: {type.Module}\nNamespace: {type.Namespace}");
        //        workbook.SetSheetName(typeIndex, type.Name);
        //        PrintModelInfo(type, workbook.GetSheetAt(typeIndex), propertyStringBuilder);
        //        _logger.Debug($"Type name: {type.Name} End");
        //        typeIndex++;
        //    }

        //    var stream = new MemoryStream();
        //    workbook.Write(stream);
        //    var buf = stream.ToArray();
        //    using var writeFileStream = new FileStream(excel, FileMode.Create, FileAccess.Write);
        //    writeFileStream.Write(buf, 0, buf.Length);
        //    writeFileStream.Flush();

        //    using var fs = new FileStream(erTxt, FileMode.Create, FileAccess.Write);
        //    using var sw = new StreamWriter(fs);
        //    sw.Write(propertyStringBuilder);
        //}

        //private void PrintModelInfo(Type type, ISheet sheet, StringBuilder propertyStringBuilder)
        //{
        //    IReadOnlyDictionary<Type, string> mongoDbType = new Dictionary<Type, string>()
        //    {
        //        {typeof(string), "String"},
        //        {typeof(int), "Int32"},
        //        {typeof(long), "Int64"},
        //        {typeof(bool), "Boolean"},
        //        {typeof(double), "Double"},
        //        {typeof(DateTime), "Date"},
        //        {typeof(Enum), "Int32"},
        //        {typeof(object), "Object"},
        //    };

        //    var propertyInfos = type.GetProperties();
        //    propertyStringBuilder.AppendLine($"=========={type.Name} BEGIN===========");
        //    var propertyIdx = 1;
        //    foreach (var propertyInfo in propertyInfos)
        //    {
        //        var documentation = new XmlDocument();
        //        documentation.Load(Path.Combine(AppContext.BaseDirectory, $"{type.Namespace?.Split(".")[0]}.xml"));
        //        var xmlPropertyName = $"P:{type.Namespace}.{type.Name}.{propertyInfo.Name}";
        //        var propertyDescription = documentation.SelectSingleNode($"/doc/members/member[@name='{xmlPropertyName}']")?.InnerText.Trim();

        //        var primaryKey = propertyInfo.GetCustomAttribute<BsonIdAttribute>();

        //        IRow row = sheet.GetRow(propertyIdx);
        //        // 字段名称
        //        row.GetCell(0).SetCellValue(primaryKey == null ? propertyInfo.Name : "_id");
        //        // 中文名称
        //        row.GetCell(1).SetCellValue(propertyDescription);
        //        try
        //        {
        //            // 数据类型
        //            row.GetCell(2).SetCellValue(primaryKey == null ? mongoDbType[propertyInfo.PropertyType] : "Object(Id)");
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.Error("=============================================");
        //            _logger.Error($"e.Message:{e.Message}");
        //            _logger.Error($"The {propertyInfo.Name} of {type.Name} is {propertyInfo.PropertyType}");
        //            _logger.Error("=============================================");
        //        }
        //        // 字段长度
        //        row.GetCell(3).SetCellValue("");
        //        // 是否空值
        //        row.GetCell(4).SetCellValue(primaryKey == null ? "Y" : "N");
        //        // 是否主键
        //        row.GetCell(5).SetCellValue(primaryKey == null ? "N" : "Y");
        //        // 说明
        //        row.GetCell(6).SetCellValue(propertyDescription);

        //        var nullable = primaryKey == null ? "NULL" : "NOT NULL";
        //        try
        //        {
        //            var propertyName = primaryKey == null ? propertyInfo.Name : "_id";
        //            var propertyType = primaryKey == null ? mongoDbType[propertyInfo.PropertyType] : "Object(Id)";
        //            propertyStringBuilder.AppendLine(
        //                $"{propertyName} {propertyType} {nullable}");
        //        }
        //        catch (Exception e)
        //        {
        //            propertyStringBuilder.AppendLine($"{propertyInfo.Name} {propertyInfo.PropertyType} {nullable}");
        //        }
        //        propertyIdx++;
        //    }

        //    propertyStringBuilder.AppendLine($"=========={type.Name} END===========");
        //    propertyStringBuilder.AppendLine();
        //    propertyStringBuilder.AppendLine();
        //    propertyStringBuilder.AppendLine();
        //}

    }
}
