using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.Domain.Dtos
{
    public class ParticipacoesDto
    {
        public List<FuncionarioPLRDto> participacoes { get; set; }
        public int total_de_funcionarios { get; set; }
        public string total_distribuido { get; set; }
        public string total_disponibilizado { get; set; }
        public string saldo_total_disponibilizado { get; set; }
        public DateTime data_calculo { get; set; }
    }
}
