using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class VagaModel
    {
        public Guid Id { get; set; }
        public EmpresaModel? Empresa { get; set; }
        public Guid Empresa_id { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public Guid Categoria_id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo_contrato { get; set; }
        public string? Modalidade { get; set; }
        public decimal Salario_min { get; set; }
        public decimal Salario_max { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public bool Ativa { get; set; }
        public DateTime ExpiraOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<CandidaturaModel> Candidaturas { get; set; }
    }
}
