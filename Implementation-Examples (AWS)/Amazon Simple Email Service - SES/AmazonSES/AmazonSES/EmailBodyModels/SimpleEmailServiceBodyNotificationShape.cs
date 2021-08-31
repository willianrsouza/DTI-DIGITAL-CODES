namespace AmazonSES.EmailBodyModels
{
    /* < Implementando a classe abstrata > */
    public class SimpleEmailServiceBodyNotificationShape : SimpleEmailServiceBody
    {
        public SimpleEmailServiceBodyNotificationShape(string[] charTemplate, string[] charBody)
        {
            this.charTemplate = charTemplate;
            this.charBody = charBody;
        }

        /* < Exemplo de aplicação desse modelo de Template/Body. Lembrando que isso não é uma regra, existem varias formas de se implementar > */
        public override string ObterCorpoEmail()
        {
            return $@"<html>
                      <head>
                         <title> Exemplo, {charTemplate[0]}</title>
                      </head>
                      <body class="">
                          Exemplos: {charTemplate[1]} de implemetação, informação: {charTemplate[2]}.
                      </body>
                      </html>";
        }

        public override string ObterTemplateEmail()
        {
            return $@"Exemplo{charBody[1]}"
                    + "Exemplo, exemplo."
                    + "Exemplo.";
        }
    }
}
