namespace Practica.API.Models
{
    public class AlumnoForUpdateDTO
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public int CursoId { get; set; }
        public string Email { get; set; }
    }
}
