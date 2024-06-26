﻿using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Models
{
    public class EncuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<CampoDTO> Campos { get; set; }
    }
}
