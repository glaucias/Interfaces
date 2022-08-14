using System;
using System.Globalization;
using TrabaComArquivos.Entites;
using TrabaComArquivos.Services;


namespace TrabaComArquivos
{
    class Program
    {
        static void Main(string[] args) {

            Console.WriteLine("Enter rental data ");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:ss): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy HH:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per Day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new vehicle(model));
            // Com o CarRental eu tenho os dados do aluguel.

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());
            //com o RentalService eu salvo nas variaveis horas e dias

            rentalService.ProcessInvoice(carRental);
            //

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
