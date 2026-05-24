using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class CandidaturaModel
    {
        public Guid Id { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public Guid Usuario_id { get; set; }
        public VagaModel? Vaga { get; set; }
        public Guid? Vaga_id { get; set; }
        public string? Status { get; set; }
        public string? Carta_apresentacao { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
