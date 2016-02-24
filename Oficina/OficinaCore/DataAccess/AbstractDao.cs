using OficinaCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OficinaCore.DataAccess
{
    public abstract class AbstractDao
    {
        /// <summary>
        /// Preenche uma lista de entidade com os registros do DataReader.
        /// </summary>
        /// <param name="reader">DataReader com os dados.</param>
        /// <returns>Lista de entidade preenchida com os dados do DataReader.</returns>
        protected IList<T> CarregarListaEntidade<T>(IDataReader reader)
        {
            var list = new List<T>();

            while (reader.Read())
            {
                T entity = Activator.CreateInstance<T>();

                this.CarregarAtributos(entity, reader);

                list.Add(entity);
            }

            return list;
        }

        /// <summary>
        /// Retorna o tipo especificado preenchido.
        /// </summary>
        /// <param name="reader">Datareader preenchido com o registro do banco de dados.</param>
        /// <returns>Entidade preenchida com os dados do Datareader.</returns>
        protected T CarregarEntidade<T>(IDataReader reader)
        {
            T entity = Activator.CreateInstance<T>();

            if (reader.Read())
            {
                this.CarregarAtributos(entity, reader);
            }

            return entity;
        }

        /// <summary>
        /// Preenche os atributos na entidade com os dados do DataReader.
        /// </summary>
        /// <param name="entity">Entidade a ser preenchida.</param>
        /// <param name="reader">DataReader com os dados.</param>
        protected void CarregarAtributos(object entity, IDataReader reader)
        {
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                try
                {
                    MappingAttribute[] attributes = prop.GetCustomAttributes(typeof(MappingAttribute), true) as MappingAttribute[];
                    if (attributes.Length > 0)
                    {
                        if (attributes[0].Column != null)
                        {
                            if (this.ExisteColuna(reader, attributes[0].Column) && !reader[attributes[0].Column].Equals(DBNull.Value))
                            {
                                var targetType = this.IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;

                                prop.SetValue(entity, Convert.ChangeType(reader[attributes[0].Column], targetType), null);

                                /*
                                //Returns an System.Object with the specified System.Type and whose value is
                                //equivalent to the specified object.
                                propertyVal = Convert.ChangeType(propertyVal, targetType);

                                //Set the value of the property
                                prop.SetValue(entity, propertyVal, null);
                                */
                            }
                        }
                        else if (attributes[0].ForeignKey != null)
                        {
                            var foreingEntity = Activator.CreateInstance(prop.PropertyType);
                            this.CarregarAtributos(foreingEntity, reader);
                            prop.SetValue(entity, foreingEntity, null);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Verifica se existe a coluna no DataReader.
        /// </summary>
        /// <param name="reader">DataReader a ser verificado.</param>
        /// <param name="columnName">Nome da coluna.</param>
        /// <returns>Boleano indicando de existe.</returns>
        protected bool ExisteColuna(IDataReader reader, string columnName)
        {
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + columnName + "'";
            return (reader.GetSchemaTable().DefaultView.Count > 0);
        }

        /// <summary>
        /// Verifica se o variabel é Nullable.
        /// </summary>
        /// <param name="type">Tipo da variavel.</param>
        /// <returns>True ou False.</returns>
        protected bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
