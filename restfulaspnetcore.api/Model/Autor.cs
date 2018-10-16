using System;
using System.Collections.Generic;

namespace restfulaspnetcore.api.Model
{
   public class Autor
   {
       public Guid Id { get; set; }
       public string Nome { get; set; }
       public string Sobrenome { get; set; }
       public IEnumerable<Livro> Livros { get; set; }
   }
}
