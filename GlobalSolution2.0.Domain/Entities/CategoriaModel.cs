using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class CategoriaModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public string? Icone { get; set; }
        public List<VagaModel> Vagas { get; set; }
    }
}
