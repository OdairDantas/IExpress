namespace IExpress.Core.ValueObjects
{
    public struct Cartao
    {
        public string Titular { get; set; }
        public string Numero { get; set; }
        public string Expiracao { get; set; }
        public int Cvv { get; set; }
    }
}
