Console.Write("Input number of month: ");
int month = Convert.ToInt32(Console.ReadLine());

if (month > 48) {
    Console.WriteLine("n/a");            
} else if (month < 0) {
    Console.WriteLine("n/a");
} else {
    int  zero = 0;
    int first = 1;
    int sum = 0;
    int j = 2;
    
    if (month == 0) {
        Console.WriteLine($"In the end of the {month} month there were 0 pair"); 
    } else if (month == 1 || month == 2) {
        Console.WriteLine($"In the end of the {month} month there were 1 pair"); 
    } else if (month > 2) {
        while (j <= month) {
            sum = zero + first;
            zero = first;
            first = sum;
            j++;
        }
    Console.WriteLine($"In the end of the {month} month there were {first} pairs"); 
    }
}


//0 1 2 3 4 5 6   7   8    9
//0 1 1 2 3 5 8   13  21   34