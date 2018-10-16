using System;

namespace restfulaspnetcore.api.Model
{
   public class Livro
   {
       public Guid Id { get; set; }
       public string Titulo { get; set; }
       public int Paginas { get; set; }
       public Autor Autor { get; set; }
   }
}
