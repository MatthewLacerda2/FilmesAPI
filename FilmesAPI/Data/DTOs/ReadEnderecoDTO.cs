﻿using Microsoft.EntityFrameworkCore.Proxies;

namespace FilmesAPI.Data.Dtos {

    public class ReadEnderecoDTO {

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

    }
}