using Practica.API.Models;

namespace Practica.Web.ViewModel
{
    //public class CursosViewModel
    //{
    //    List<Curso> Cursos { get; }

    //    public CursosViewModel (List<Curso> cursos)
    //    {
    //        Cursos = cursos;
    //    }
    //}

    public class CursosViewModel
    {
        public List<Curso> Cursos { get; set; }

        public void SetCursos(List<Curso> cursos)
        {
            Cursos = cursos;
        }
    }
}
