﻿namespace Encuesta_Acme.Models
{
    public class EncuestaRespuestaDTO
    {
        public int EncuestaId { get; set; }
        public ICollection<EncuestaCampoRespuestaDTO> CampoRespuestas { get; set; }
    }
}
