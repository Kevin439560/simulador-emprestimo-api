using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorEmprestimo.Application.Interfaces {
    public interface IEventHubService {
        Task EnviarEventoAsync(string eventoJson);

    }
}
