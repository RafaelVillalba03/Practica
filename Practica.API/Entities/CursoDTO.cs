namespace Practica.API.Entities
{
    public class CursoDTO
    {
        public CursoDTO(int CursoId, string Nombre)
        {
            this.CursoId = CursoId;
            this.Nombre = Nombre;
        }

        public int CursoId { get; set; }
        public string Nombre { get; set; }
    }
}
