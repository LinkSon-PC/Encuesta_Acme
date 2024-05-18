﻿using AutoMapper;
using Encuesta_Acme.Models;
using Microsoft.EntityFrameworkCore;

namespace Encuesta_Acme.Servicios
{
    public class EncuestaService : IEncuestaService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public EncuestaService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Encuesta>> Get()
        {
            return await context.Encuestas.ToListAsync();
        }

        public Task<Encuesta> GetById(int id)
        {
            return context.Encuestas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Post(EncuestaDTO encuestaDTO)
        {
            throw new NotImplementedException();
        }
    }
}