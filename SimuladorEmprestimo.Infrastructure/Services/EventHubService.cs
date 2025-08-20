using SimuladorEmprestimo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Infrastructure.Services {
    public class EventHubService : IEventHubService{

        public Task EnviarEventoAsync(string eventoJson) {
            // Aqui você implementaria a lógica para enviar o evento para o Event Hub.
            // Por exemplo, usando Azure.Messaging.EventHubs ou outra biblioteca de sua escolha.
            Console.WriteLine($"Evento enviado: {eventoJson}");
            return Task.CompletedTask;
        }


    }
}
