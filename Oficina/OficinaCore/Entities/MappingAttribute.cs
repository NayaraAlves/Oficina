using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OficinaCore.Entities
{
    /// <summary>
    /// Atributos personalidados para mapear as colunas de uma tabela com os objetos de negócio.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [Serializable]
    public class MappingAttribute : Attribute
    {
        /// <summary>
        /// Nome da coluna da tabela no banco de dados.
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// Nome da coluna que representa uma Foreign Key.
        /// </summary>
        public string ForeignKey { get; set; }
    }
}
