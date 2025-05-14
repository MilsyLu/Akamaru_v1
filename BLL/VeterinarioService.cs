﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class VeterinarioService : IService<Veterinario>
    {
        private readonly IRepository<Veterinario> repoVeterinario;

        public VeterinarioService()
        {
            repoVeterinario = new VeterinarioDbRepository();
        }

        public List<Veterinario> Consultar()
        {
            return repoVeterinario.Consultar();
        }

        public string Guardar(Veterinario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el veterinario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Nombre))
                {
                    throw new ArgumentException("Error... el nombre no puede estar vacío");
                }

                return repoVeterinario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar veterinario: {ex.Message}";
            }
        }

        public string Modificar(Veterinario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el veterinario no puede ser nulo");
                }

                return repoVeterinario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar veterinario: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoVeterinario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar veterinario: {ex.Message}";
            }
        }

        public Veterinario BuscarId(int id)
        {
            var veterinarioBuscado = Consultar().FirstOrDefault<Veterinario>(x => x.Id == id);
            return veterinarioBuscado;
        }
    }
}