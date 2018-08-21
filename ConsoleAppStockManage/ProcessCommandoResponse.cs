namespace ConsoleAppStockManage
{
    public class ProcessCommandoResponse
    {
        public bool Success { get; }
        public int? Saldo { get; }
        public string ErrorMessage { get; }
        public ProcessCommandoResponse(bool success) => this.Success = success;
        public ProcessCommandoResponse(bool success, int saldo) : this(success) => this.Saldo = saldo;
        public ProcessCommandoResponse(bool success, string errorMessage) : this(success) => this.ErrorMessage = errorMessage;
    }
}