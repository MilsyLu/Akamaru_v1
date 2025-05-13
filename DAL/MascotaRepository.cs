using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class MascotaRepository : FileRepository<Mascota>
    {
        private RazaRepository razaRepository;
        private PropietarioRepository propietarioRepository;

        public MascotaRepository(string ruta) : base(ruta)
        {
            razaRepository = new RazaRepository(Archivos.ARC_RAZA);
            propietarioRepository = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
        }

        public override List<Mascota> Consultar()
        {
            try
            {
                List<Mascota> lista = new List<Mascota>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(Mappear(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MascotaDto> ConsultarDTO()
        {
            try
            {
                List<MascotaDto> lista = new List<MascotaDto>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(MappearDTO(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private MascotaDto MappearDTO(string datos)
        {
            string[] campos = datos.Split(';');
            MascotaDto mascota = new MascotaDto();
            mascota.Id = int.Parse(campos[0]);
            mascota.Nombre = campos[1];
            mascota.Edad = int.Parse(campos[2]);

            int razaId = int.Parse(campos[3]);
            Raza raza = razaRepository.Consultar().FirstOrDefault(r => r.Id == razaId);
            mascota.Raza = raza.Nombre;
            mascota.Especie = raza.Especie.Nombre;

            int propietarioId = int.Parse(campos[4]);
            Propietario propietario = propietarioRepository.Consultar().FirstOrDefault(p => p.Id == propietarioId);
            mascota.Propietario = propietario.Nombre;
            mascota.propietarioId = propietario.Id;

            return mascota;
        }

        public override Mascota Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            Mascota mascota = new Mascota();
            mascota.Id = int.Parse(campos[0]);
            mascota.Nombre = campos[1];
            mascota.Edad = int.Parse(campos[2]);

            int razaId = int.Parse(campos[3]);
            Raza raza = razaRepository.Consultar().FirstOrDefault(r => r.Id == razaId);
            if (raza != null)
            {
                mascota.AsignarRaza(raza);
            }

            int propietarioId = int.Parse(campos[4]);
            Propietario propietario = propietarioRepository.Consultar().FirstOrDefault(p => p.Id == propietarioId);
            if (propietario != null)
            {
                mascota.AsignarPropietario(propietario);
            }

            return mascota;
        }

        public List<Mascota> ConsultarPorPropietario(int propietarioId)
        {
            return Consultar().Where(m => m.propietario.Id == propietarioId).ToList();
        }

        public List<MascotaDto> ConsultarDTOPorPropietario(int propietarioId)
        {
            return ConsultarDTO().Where(m => m.propietarioId == propietarioId).ToList();
        }

    }
}