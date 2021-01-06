using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.Domain.Dtos
{
    public class FuncionarioPLRDto
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string valor_da_participação { get; set; }
    }
}
