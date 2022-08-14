using System;
using TrabaComArquivos.Entites;

namespace TrabaComArquivos.Services
{
    class RentalService//serviço de aluguel
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        //dependencia
        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;

        }

        public void ProcessInvoice(CarRental carRental)
        {   //O Criar o TimeSpan para tirar a diferença do horario de entrega e o horario qe foi alugado o carro
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);//aqui eu tinh a duração da minha locação

            double basicPayment = 0.0; // Aqui para calcular meu pagamento basico
            if (duration.TotalHours <= 12.0){
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);//Função para arredondar pra cima Math.Ceillin
            }
            else{// se acima de 12 horas, calcule os dias
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);// Calcular o valor do imposto.

            // tendo na mao ja o pag basico e o imposto, ja posso instanciar o meu INVOICE
            // E associalo ao meu CarRental...
            //------> O invoice irá receber o basicpay e Tax qu éo imposto que calculamos.
            carRental.Invoice = new Invoice(basicPayment, tax);

        }
    }

}
