using OficinaCore.Enums;
using OficinaCore.Resources;
using System;

namespace OficinaCore.Exceptions
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class OficinaCoreException : System.Exception
  {
    /// <summary>
        /// Construtor simples desta Exception.
        /// </summary>
        public OficinaCoreException()
        {
        }

        /// <summary>
        /// Construtor passando a mensagem de erro.
        /// </summary>
        /// <param name="message">Mensagem desta Exception.</param>
        public OficinaCoreException(string message) : base(message)
        {
        }

        /// <summary>
        /// Construtor passando a mensagem de erro e uma Exception interna..
        /// </summary>
        /// <param name="message">Mensagem desta Exception.</param>
        /// <param name="innerException">Exception interna.</param>
        public OficinaCoreException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Construtor passando o Domínio de Erro.
        /// </summary>
        /// <param name="srcoEnumErro">Dominio de Erro utilizado para lançar essa Exception.</param>
        public OficinaCoreException(EnumOficinaCoreErro enumOficinaCoreErro)
          : this(RecuperaMensagemErro(enumOficinaCoreErro))
        {
        }

        /// <summary>
        /// Construtor passando o Domínio de Erro.
        /// </summary>
        /// <param name="srcoEnumErro">Dominio de Erro utilizado para lançar essa Exception.</param>
        /// <param name="descricaoErro">Campo de Validação.</param>
        public OficinaCoreException(EnumOficinaCoreErro enumOficinaCoreErro, string descricaoErro)
          : this(RecuperaMensagemErro(enumOficinaCoreErro, descricaoErro))
        {   
        }

        /// <summary>
        /// Construtor passando o Domínio de Erro e outra Exception.
        /// </summary>
        /// <param name="srcoEnumErro">Dominio de Erro utilizado para lançar essa Exception.</param>
        /// <param name="innerException">Exception interna.</param>
        public OficinaCoreException(EnumOficinaCoreErro enumOficinaCoreErro, System.Exception innerException)
          : this(RecuperaMensagemErro(enumOficinaCoreErro), innerException)
        {
        }

        /// <summary>
        /// Construtor passando o Domínio de Erro e outra Exception.
        /// </summary>
        /// <param name="srcoEnumErro">Dominio de Erro utilizado para lançar essa Exception.</param>
        /// <param name="descricaoErro">Campo de Validação.</param>
        /// <param name="innerException">Exception interna.</param>
        public OficinaCoreException(EnumOficinaCoreErro enumOficinaCoreErro, string descricaoErro, System.Exception innerException)
          : this(RecuperaMensagemErro(enumOficinaCoreErro, descricaoErro), innerException)
        {
        }

        /// <summary>
        /// Recupera a descrição do Domínio de Erro.
        /// </summary>
        /// <param name="value">DominioErro para recuperar a descrição.</param>
        /// <returns>Descrição do Domínio de Erro.</returns>
        private static string RecuperaMensagemErro(Enum value)
        {
            return MensagensErro.ResourceManager.GetString(Enum.GetName(typeof(EnumOficinaCoreErro), value));
        }

        /// <summary>
        /// Recupera a descrição do Domínio de Erro.
        /// </summary>
        /// <param name="value">DominioErro para recuperar a descrição.</param>
        /// <param name="descricaoErro">Campo de Validação.</param>
        /// <returns>Descrição do Domínio de Erro.</returns>
        private static string RecuperaMensagemErro(Enum value, string descricaoErro)
        {
            return MensagensErro.ResourceManager.GetString(Enum.GetName(typeof(EnumOficinaCoreErro), value)) + " : " + descricaoErro;
        }
  }
}
