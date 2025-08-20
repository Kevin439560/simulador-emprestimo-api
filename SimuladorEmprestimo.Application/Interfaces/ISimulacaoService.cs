using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorEmprestimo.Application.DTOs;

namespace SimuladorEmprestimo.Application.Interfaces {
    public interface ISimulacaoService {
        Task<SimulacaoResponseDto> SimularEmprestimoAsync(SimulacaoRequestDto requestDto);

    }
}
