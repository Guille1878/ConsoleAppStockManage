using StockManageService;
using System;

namespace ConsoleAppStockManage
{
    public class ServiceStockManage
    {
        public static ProcessCommandoResponse GetSaldo()
        {
            try
            {
                using (var service = new StockManageServiceClient())
                {
                    return new ProcessCommandoResponse(true, service.GetSaldo() ?? 0);
                }
            }
            catch (Exception ex)
            {
                return new ProcessCommandoResponse(false, ex.Message);
            }
        }

        public static ProcessCommandoResponse InsertNewSaldoMovment(int addingSaldo)
        {
            try
            {
                using (var service = new StockManageServiceClient())
                {
                    service.UpdateSaldo(addingSaldo);
                    return new ProcessCommandoResponse(true);
                }
            }
            catch (Exception ex)
            {
                return new ProcessCommandoResponse(false, ex.Message);
            }
        }
    }
}