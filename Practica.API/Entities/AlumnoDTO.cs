namespace Practica.API.Entities
{
    public class AlumnoDTO
    {
        public AlumnoDTO(int Id, string Nombre, string Apellido1, string Apellido2,
        DateTime FechaNacimiento, char Sexo, string Direccion, string Provincia,
        string Localidad, string Telefono, int CursoId, string Email)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido1 = Apellido1;
            this.Apellido2 = Apellido2;
            this.FechaNacimiento = FechaNacimiento;
            this.Sexo = Sexo;
            this.Direccion = Direccion;
            this.Provincia = Provincia;
            this.Localidad = Localidad;
            this.Telefono = Telefono;
            this.CursoId = CursoId;
            this.Email = Email;
        }
        public int Id { get; set; }
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
