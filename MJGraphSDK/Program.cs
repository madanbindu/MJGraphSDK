using Azure.Core;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJGraphSDK
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
          
            string[] scopes = new[] { "https://graph.microsoft.com/.default" };
            ClientSecretCredential cred = new ClientSecretCredential("3dc046f7-1af1-4578-a5b7-4fbadfe4814b", "ba53050f-8a43-4e81-a9b5-394f90656f2e", "Qcg8Q~TcnTi2NQ3Fen7rUEDVXYdfSd2dj24qLdm3");

            var tokenRequestContext = new TokenRequestContext(scopes);
            AccessToken token = cred.GetToken(tokenRequestContext);
            Console.WriteLine(token.Token);

            //UsernamePasswordCredential cred2 = new UsernamePasswordCredential("madan@mmjhome.onmicrosoft.com", "CheckThisOut0#", "3dc046f7-1af1-4578-a5b7-4fbadfe4814b", "ba53050f-8a43-4e81-a9b5-394f90656f2e");

            GraphServiceClient graphClient = new GraphServiceClient(cred, scopes);
            Site s = await graphClient.Sites["c65dbdcc-8ccc-43cf-af93-ba6379ed3fe7"].GetAsync();

            Console.WriteLine(s.DisplayName);


            Console.ReadLine();

        }
    }
}
