// nocopy
using System.Net;

// приветствие 
Console.WriteLine("Привет  я  программа  которая работает  с  сетью");
// меню

while (true)
{
    PrintComand();

    // заготовка на  будущее - вдруг  будет  много  инструментов 

    switch (Console.ReadLine().ToLower())
    {
        case "ping": PingCommand(); break;  // пока что  только  одна команда 
        case "dns": DNSCommand(); break;  // пока что  только  одна команда 
        default: Console.WriteLine("Команда не распоздана, попробуйте  еще раз");
            break;
    }

}

// список команд
void PrintComand()
{
    Console.WriteLine("Для пинга ресурса ввидите команду \"ping\""); // возможны  расширения команд

    Console.WriteLine("что бы  получить  ип  адресса хоста введите команду  \"dns\""); // возможны  расширения команд
}


//
void PingCommand()
{
    Console.WriteLine("Введите адресс ресурса:");
    string adress  = Console.ReadLine();

    for (int i = 0; i < 5; i++) // будет  5 попыток 
    {
        try
        {
     // !!этот класс придумал  я   в нем метод
            NetWorkService.        Ping(adress); // вынисим  логику  в  отдельный класс 
        }
        catch (Exception ex) // если ошибка
        {
            Console.WriteLine($"eror {ex.Message}");
            return; //выйти  из  метода 
        }
        finally //  в любом случае выдержать паузу 
        {
            Console.WriteLine("____________");
            Thread.Sleep(1000); // пауза
        }
    }

}


void DNSCommand()
{
    Console.WriteLine("Введите доменное  имя:");
    string adress = Console.ReadLine();
    try
    {
        // !!этот класс придумал  я   в нем метод
        NetWorkService.GetDNS(adress); // вынисим  логику  в  отдельный класс 
    }
    catch (Exception ex) // если ошибка
    {
        Console.WriteLine($"eror {ex.Message}");
        return; //выйти  из  метода 
    }
    finally //  в любом случае выдержать паузу 
    {
        Console.WriteLine("____________");
        Thread.Sleep(1000); // пауза
    }

}

