using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class ConsultaVeterinariaRepository : FileRepository<ConsultaVeterinaria>
    {
        private MascotaRepository mascotaRepository;
        private VeterinarioRepository veterinarioRepository;

        public ConsultaVeterinariaRepository(string ruta) : base(ruta)
        {
            mascotaRepository = new MascotaRepository(Archivos.ARC_MASCOTA);
            veterinarioRepository = new VeterinarioRepository(Archivos.ARC_VETERINARIO);
        }

        public override List<ConsultaVeterinaria> Consultar()
        {
            try
            {
                List<ConsultaVeterinaria> lista = new List<ConsultaVeterinaria>();

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

        public List<ConsultaVeterinariaDto> ConsultarDTO()
        {
            try
            {
                List<ConsultaVeterinariaDto> lista = new List<ConsultaVeterinariaDto>();

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

        private ConsultaVeterinariaDto MappearDTO(string datos)
        {
            string[] campos = datos.Split(';');
            ConsultaVeterinariaDto consulta = new ConsultaVeterinariaDto();
            consulta.Id = int.Parse(campos[0]);
            consulta.Fecha = campos[1];

            int mascotaId = int.Parse(campos[2]);
            Mascota mascota = mascotaRepository.Consultar().FirstOrDefault(m => m.Id == mascotaId);
            consulta.Mascota = mascota.Nombre;

            int veterinarioId = int.Parse(campos[3]);
            Veterinario veterinario = veterinarioRepository.Consultar().FirstOrDefault(v => v.Id == veterinarioId);
            consulta.Veterinario = veterinario.Nombre;

            consulta.Diagnostico = campos[4];
            consulta.Tratamiento = campos[5];

            return consulta;
        }

        public override ConsultaVeterinaria Mappear(string datos)
        {
            string[] campos = datos.Split(';');
            ConsultaVeterinaria consulta = new ConsultaVeterinaria();
            consulta.Id = int.Parse(campos[0]);
            consulta.Fecha = DateTime.Parse(campos[1]);

            int mascotaId = int.Parse(campos[2]);
            Mascota mascota = mascotaRepository.Consultar().FirstOrDefault(m => m.Id == mascotaId);
            if (mascota != null)
            {
                consulta.AsignarMascota(mascota);
            }

            int veterinarioId = int.Parse(campos[3]);
            Veterinario veterinario = veterinarioRepository.Consultar().FirstOrDefault(v => v.Id == veterinarioId);
            if (veterinario != null)
            {
                consulta.AsignarVeterinario(veterinario);
            }

            consulta.Diagnostico = campos[4];
            consulta.Tratamiento = campos[5];

            return consulta;
        }

        public List<ConsultaVeterinaria> ConsultarPorMascota(int mascotaId)
        {
            return Consultar().Where(c => c.Mascota.Id == mascotaId).ToList();
        }
    }
}