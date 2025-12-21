namespace APIrest.Models
{
    public class Response<T>
    {
        public T? Dados { get; set; }
        public string Menssagem { get; set; }
        public bool Status { get; set; }
    }
}
