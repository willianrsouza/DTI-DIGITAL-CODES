using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AmazonSES.EmailBodyModels;
using System;
using System.Collections.Generic;

/* < Lembre-se de instalar os pacotes Nugets referentes ao serviço SES > */

namespace AmazonSES
{
    public class SimpleEmailService : ISimpleEmailService
    {
        /* < E-mail responsável pelo envio das mensagens. É necessário autenticar e autorizar o uso deste e-mail dentro da AWS. > */
        public string emailRemetente;
        private AmazonSimpleEmailServiceClient _client;

        public SimpleEmailService(AmazonSimpleEmailServiceClient client)
        {
            /* < É necessário seguir os padrões de boas práticas ao implementar o serviço SES, o e-mail responsável pelo envio das mensagens deve estar nas suas configurações não localmente (HardCode). > */
            this.emailRemetente = "example@gmail.com";
            /* < Dependendo do seu contexto, é preferível que você não referencie o RegionEnpoint localmente. Se você for utilizar mais um serviço da AWS, por exemplo, é preferível que opte por criar uma camada responsável pelo gerenciamento dessas configurações/credenciais. > */
            _client = new AmazonSimpleEmailServiceClient(RegionEndpoint.SAEast1);
        }

        /* < A maioria dos serviços da AWS é async > */
        public async System.Threading.Tasks.Task SendRequestAsync(string emailReceptor, string assunto, SimpleEmailServiceBody simpleEmailServiceBody)
        {
            /* < É importante implementar um Logger, não utilize "WriteLine" > */
            Console.WriteLine("Preparando mensagem para envio.");

            var sendRequest = new SendEmailRequest
            {

                Source = emailRemetente,
                Destination = new Destination
                {
                    ToAddresses =
                new List<string> { emailReceptor }
                },
                Message = new Message
                {
                    Subject = new Content(assunto),
                    Body = new Body
                    {
                        /* < Chamando o Template e o Body do e-mail. > */
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = simpleEmailServiceBody.ObterTemplateEmail()
                        },
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = simpleEmailServiceBody.ObterCorpoEmail()
                        }
                    }
                },
            };
            try
            {
                var response = await _client.SendEmailAsync(sendRequest);

                /* < É importante implementar um Logger, não utilize "WriteLine" > */
                Console.WriteLine("Mensagem Enviada com Sucesso!");
            }
            catch (Exception ex)
            {
                /* < É importante implementar um Logger, não utilize "WriteLine" > */
                Console.WriteLine("Não foi possivel enviar a mensagem: " + ex.Message);
            }
        }
    }
}

