// nocopy
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

internal class NetWorkService
{
    internal static void Ping(string adress)
    {
        Ping pingSender = new Ping();
        PingOptions options = new PingOptions();

        // Используем значение Ttl по умолчанию, равное 128,
        
        // поведение фрагментации.
        options.DontFragment = true;

        // Создаем буфер из 32 байт данных для передачи.
        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        byte[] buffer = Encoding.ASCII.GetBytes(data);
       
        int timeout = 120;

        PingReply reply = pingSender.Send(adress ,  timeout, buffer, options);
       
        if (reply.Status == IPStatus.Success)
        {
          
            if (reply.RoundtripTime == 0)
                 Console.WriteLine($"Время запроса: <1мс");
            else
                Console.WriteLine($"Время запроса: {reply.RoundtripTime}" );

            Console.WriteLine($"Адресс: {reply.Address}");

            Console.WriteLine($"TTL: {reply.Options.Ttl}");
            Console.WriteLine($"Потерянные пакеты: {reply.Options.DontFragment}" );
            Console.WriteLine($"Размер фрагмента: {reply.Buffer.Length}" );
        }
        else
        {
            Console.WriteLine("ресурс не ответил");
        }
    }



    internal static  void GetDNS (string domen)
    {
        var googleEntry =  Dns.GetHostEntry(domen);

        Console.WriteLine($"На домене {domen} найдены следующие адрреса:");
        foreach (var ip in googleEntry.AddressList)
        {
            Console.WriteLine(ip);
        }
    }
}