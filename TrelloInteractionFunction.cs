using DiscordBotInteractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TrelloInteractionFunction
{
    public static class TrelloInteractionFunction
    {
        public const string ED25519_HEADER = "X-Signature-Ed25519";
        public const string TIMESTAMP_HEADER = "X-Signature-Timestamp";
        public const string APPLICATION_PUBLIC_KEY = "a88b9732426cc21d4fd58f79d4df1cba006a03d8807c41b4206473731fba7607";

        [FunctionName("TrelloFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var signature = req.Headers[ED25519_HEADER];
            log.LogInformation($"Signature: {signature}");
            var timestamp = req.Headers[TIMESTAMP_HEADER];
            log.LogInformation($"Timestamp: {timestamp}");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation($"Request Body: {requestBody}");

            if (!ValidateSignature(APPLICATION_PUBLIC_KEY, $"{timestamp}{requestBody}", signature))
                return new UnauthorizedResult();

            var data = JsonConvert.DeserializeObject<InteractionRequest>(requestBody);

            var response = data.Type switch
            {
                InteractionType.PING => new InteractionResponse { Type = InteractionCallbackType.PONG },
                InteractionType.APPLICATION_COMMAND => new InteractionResponse
                {
                    Type = InteractionCallbackType.CHANNEL_MESSAGE_WITH_SOURCE,
                    Data = new InteractionCallbackData { Content = $"I have received your message!\n{requestBody}" }
                },
                InteractionType.MESSAGE_COMPONENT => throw new NotImplementedException(),
                InteractionType.APPLICATION_COMMAND_AUTOCOMPLETE => throw new NotImplementedException(),
                InteractionType.MODAL_SUBMIT => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };

            return new OkObjectResult(response);
        }

        private static bool ValidateSignature(string publicKey, string dataToVerify, string signature)
        {
            //return true;
            var publicKeyParam = new Ed25519PublicKeyParameters(Hex.DecodeStrict(publicKey));
            var dataToVerifyBytes = Encoding.UTF8.GetBytes(dataToVerify);
            var signatureBytes = Convert.FromHexString(signature);

            var verifier = new Ed25519Signer();
            verifier.Init(false, publicKeyParam);
            verifier.BlockUpdate(dataToVerifyBytes, 0, dataToVerifyBytes.Length);
            var isVerified = verifier.VerifySignature(signatureBytes);
            return isVerified;
        }
    }
}
