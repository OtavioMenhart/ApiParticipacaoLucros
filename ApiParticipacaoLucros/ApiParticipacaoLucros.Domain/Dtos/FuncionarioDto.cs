using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.Domain.Dtos
{
    public class FuncionarioDto
    {
        public string matricula { get; set; }
        public string nome{ get; set; }
        public string area{ get; set; }
        public string cargo{ get; set; }
        public string salario_bruto{ get; set; }
        public DateTime data_de_admissao { get; set; }
    }
}
