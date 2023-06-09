﻿using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Dto.Response
{
    public class CarroResponseDto : BaseResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int Status { get; set; }
        public double? Preco { get; set; }
        public string? Quilometragem { get; set; }
        public List<ArquivoResponseDto>? Fotos { get; set; }
    }
}
