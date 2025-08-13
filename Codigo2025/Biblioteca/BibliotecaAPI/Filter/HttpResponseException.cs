namespace BibliotecaAPI.Filter
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 400;

        public object Value { get; set; }

        public string Message { get; set; }

        public HttpResponseException(string value)
        {
            this.Value = value;
        }
    }
}
