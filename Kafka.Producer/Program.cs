using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, object> 
            { 
                { "bootstrap.servers", "localhost:9092" } 
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                for (int i = 0; i < 50000; i++)
                {
                    var dr = Task.Run(async() => await producer.ProduceAsync("my-topic", null, "Mensagem " + i));
                    Console.WriteLine(i);
                }
            }

            Console.ReadKey();
        }
    }
}
