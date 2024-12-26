using System.Reflection;

public static class Reflector
{

    public static void WriteInFile(string text)
    {
        string filePath = @"D:\Лабораторные\ООП\11 лаба\Lab11\output.txt";

        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine(text);
        Console.WriteLine("Данные записаны в файл");
        sw.Close();
    }


    public static void GetNameAssembly(string nameOfClass)
    {
        Type? info = Type.GetType(nameOfClass);

        Console.WriteLine($"Тип найден: {info.FullName}");
        Console.WriteLine($"Сборка типа: {info.Assembly.FullName}");
        WriteInFile($"Тип: {info.FullName}, Сборка: {info.Assembly.FullName}");

    }

    public static void GetInfoConstructor(string nameOfClass)
    {
        Type? info = Type.GetType(nameOfClass);

        bool hasPublicConstructors = info.GetConstructors().Length > 0;

        Console.WriteLine($"Есть ли публичные конструкторы: {hasPublicConstructors}");
        WriteInFile($"Есть ли публичные конструкторы: {hasPublicConstructors}");

    }

    public static IEnumerable<string> GetPublicMethodsOfClass(string nameOfClass)
    {
        Type? info = Type.GetType(nameOfClass);

        MethodInfo[] methods = info.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        IEnumerable<string> result = methods.Select(method => method.Name);

        string formattedMethods = "Публичные методы: \n";
        foreach (string methodName in result)
        {
            formattedMethods += methodName + " " + '\n';
        }
        WriteInFile(formattedMethods);
        return result;

    }

    public static IEnumerable<string> GetInfoOfFieldsAndProperties(string nameOfClass)
    {
        Type? info = Type.GetType(nameOfClass);

        FieldInfo[] fields = info.GetFields(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo[] properties = info.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        IEnumerable<string> result = fields.Select(field => "Field: " + field.Name)
                                          .Concat(properties.Select(prop => "Property: " + prop.Name));

        string formattedInfo = "Публичные поля и свойства:\n";

        foreach (var item in result)
        {
            formattedInfo += item + "\n";
        }

        WriteInFile(formattedInfo);
        return result;
    }

    public static IEnumerable<string> GetInterfaces(string nameOfClass)
    {
        Type? info = Type.GetType(nameOfClass);

        Type[] interfaces = info.GetInterfaces();

        IEnumerable<string> result = interfaces.Select(interf => "Interface: " + interf.Name);

        string formattedInfo = "Интерфейсы:\n";
        foreach (var item in result)
        {
            formattedInfo += item + "\n";
        }

        WriteInFile(formattedInfo);

        return result;
    }

    public static string GetNameOfMethodsWithParametr(string nameOfClass, string parametr)
    {
        Type? info = Type.GetType(nameOfClass);

        MethodInfo[] methods = info.GetMethods();

        string methodsByParametrs = $"Методы с параметром - {parametr}: \n";

        foreach (var item in methods)
        {
            foreach (var parameterInfo in item.GetParameters())
            {
                if (parameterInfo.ParameterType.Name == parametr)
                {
                    methodsByParametrs += item.Name + '\n';
                }
            }
        }

        WriteInFile(methodsByParametrs);

        return methodsByParametrs;
    }

    public static void Invoke(Type className, string methodName, string fileWithParametrs)
    {
        string[] lines = File.ReadAllLines(fileWithParametrs);

        /*Type type = Type.GetType(className);*/
        /*    Type type = className.GetType();*/

        MethodInfo method = className.GetMethod(methodName);

        ParameterInfo[] parameterInf = method.GetParameters();
        object[] parameters = new object[parameterInf.Length];

        if (lines.Length < 1)
        {
            Console.WriteLine("Недостаточно параметров в файле, значения сгенерированы");
        }

        for (int i = 0; i < parameterInf.Length; i++)
        {
            if (i < lines.Length)
            {
                parameters[i] = Convert.ChangeType(lines[i], parameterInf[i].ParameterType);
            }
            else
            {
                parameters[i] = GeneratorOfValuesForPArameters(parameterInf[i].ParameterType);
            }
        }

        object classInstance = Activator.CreateInstance(className);

        object invokeMethod = method.Invoke(classInstance, parameters);
        Console.WriteLine($"Результат выполнения метода {methodName} : {invokeMethod}");
    }

    public static object? GeneratorOfValuesForPArameters(Type type)
    {
        if (type == typeof(string))
            return "Строка созданная в генераторе";

        if (type.IsValueType)
            return Activator.CreateInstance(type);

        return null;
    }

    //2
    public static T? Create<T>() where T : class
    {
        var constructor = typeof(T).GetConstructors().FirstOrDefault();

        if (constructor == null)
        {
            Console.WriteLine($"Не найден ни один конструктор для типа {typeof(T).Name}");
            return null;
        }

        var parameters = constructor.GetParameters()
                                    .Select(p => Activator.CreateInstance(p.ParameterType))
                                    .ToArray();

        return constructor.Invoke(parameters) as T;
    }



}
