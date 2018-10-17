using System;
using System.Collections.Generic;

namespace restfulaspnetcore.api.Model
{
   public class Autor
   {
       /// <summary>
       /// Identificação do Autor
       /// </summary>
       /// <example>F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4</example>
       public Guid Id { get; set; }
       /// <summary>
       /// Nome do Autor
       /// </summary>
       /// <example>Spencer</example>
       public string Nome { get; set; }
       /// <summary>
       /// Sobrenome do Autor
       /// </summary>
       /// <example>Johnson</example>
       public string Sobrenome { get; set; }
       /// <summary>
       /// Livros escritos pelo Autor
       /// </summary>
       public IEnumerable<Livro> Livros { get; set; }
   }
}
