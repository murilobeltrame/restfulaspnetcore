using System;

namespace restfulaspnetcore.api.Model
{
    /// <summary>
    /// Define um livro
    /// </summary>
   public class Livro
   {
       /// <summary>
       /// Identificação do Livro
       /// </summary>
       /// <example>F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4</example>
       public Guid Id { get; set; }
       /// <summary>
       /// Titulo do Livro
       /// </summary>
       /// <example>Who Moved My Cheese?</example>
       public string Titulo { get; set; }
       /// <summary>
       /// Número de páginas
       /// </summary>
       /// <example>96</example>
       public int Paginas { get; set; }
       /// <summary>
       /// Escritor do Livro
       /// </summary>
       public Autor Autor { get; set; }
   }
}
