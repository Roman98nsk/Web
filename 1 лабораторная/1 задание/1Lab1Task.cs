Console.Write("Input value to degree: ");
double degree = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"{degree}");

Console.Write("Input name current scale: ");
string Current_Scale = Console.ReadLine();
Console.WriteLine($"{Current_Scale}");

Console.Write("Input name target scale: ");
string Target_Scale = Console.ReadLine();
Console.WriteLine($"{Target_Scale}");

if (Current_Scale == "c") {
    if(Target_Scale == "c") {
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "k") {
        degree += 273.15;
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "f") {
        degree = degree * 1.8 + 32;
        Console.WriteLine($"Result: {degree}");
    }
}

if (Current_Scale == "f") {
    if(Target_Scale == "c") {
        degree = (degree - 32) * 0.6;
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "k") {
        degree = (degree + 459.67) * 0.6;
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "f") {
        Console.WriteLine($"Result: {degree}");
    }
}

if (Current_Scale == "k") {
    if(Target_Scale == "c") {
        degree -= 273.15;
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "k") {
        Console.WriteLine($"Result: {degree}");
    } else if(Target_Scale == "f") {
        degree = (degree - 273.15) * 1.8 + 32;
        Console.WriteLine($"Result: {degree}");
    }
}
