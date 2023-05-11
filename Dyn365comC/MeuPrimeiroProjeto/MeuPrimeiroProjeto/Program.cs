using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var crmService = new Conexao().ObterConexao();
            FetchXML (crmService);
        }

        static void FetchXML(CrmServiceClient crmService) // recebe como parâmetro a conexão
        {
            string query = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                              <entity name='account'>
                                <attribute name='name' />
                                <attribute name='telephone1' />
                                <attribute name='accountid' />
                                <attribute name='emailaddress1' />
                                <order attribute='name' descending='false' />
                              </entity>
                            </fetch>"; // declara variável do tipo String contendo o FechXML da consulta

            EntityCollection colecao = crmService.RetrieveMultiple(new FetchExpression(query)); // declara variável do tipo 	            EntityCollection e executa o método RetrieveMultiple enviando como parâmetro a variável query

            foreach (var item in colecao.Entities) // para cada entidade (registro)  armazenará na variável item
            {
                Console.WriteLine(item["name"]); // exibe o atributo name
                if (item.Attributes.Contains("telephone1")) // verifica se retornou o atributo telephone1
                {
                    Console.WriteLine(item["telephone1"]); // exibe o atributo telephone
                }
            }
            Console.ReadKey(); // aguarda o usuário pressionar qualquer tecla para continuar
        }

    }
}
