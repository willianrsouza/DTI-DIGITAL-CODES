namespace AmazonSES.EmailBodyModels
{
    public abstract class SimpleEmailServiceBody
    {
        protected string[] charTemplate;
        protected string[] charBody;

        public abstract string ObterTemplateEmail();
        public abstract string ObterCorpoEmail();

    }
}
