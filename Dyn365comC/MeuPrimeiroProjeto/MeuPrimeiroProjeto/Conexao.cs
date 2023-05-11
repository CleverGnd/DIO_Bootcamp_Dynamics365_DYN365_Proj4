using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroProjeto
{
    internal class Conexao
    {
        private static CrmServiceClient crmServiceClientTrinamento; // variável do tipo CrmServiceCliente

        public CrmServiceClient ObterConexao() // método que devolve uma CrmServiceCliente
        {
            // variável contendo a ConnectionString
            var connectionStringCRM = @"AuthType=OAuth;
            Username = UserSvc1@1v0cst.onmicrosoft.com;
            Password = Zav80536; SkipDiscovery = True;
            AppId = 23364d1d-28e2-ed11-a80b-002248de5ce3;
            RedirectUri = app://16b1e39a-5e1d-e40a-8bbc-69aa68e762ed;
            Url = https://org04894b71.crm2.dynamics.com/main.aspx;";


            if (crmServiceClientTrinamento == null) // verifica se a variável crmServiceClientTrinamento está vazia
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // define o protocolo segurança
                crmServiceClientTrinamento = new CrmServiceClient(connectionStringCRM); // executa a conexão
            }
            return crmServiceClientTrinamento; // retorna a conexão para o método chamador
        }

    }
}
