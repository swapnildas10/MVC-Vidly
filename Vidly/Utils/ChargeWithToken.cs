using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimplifyCommerce.Payments;
namespace Vidly.Utils
{
    public class ChargeWithToken
    {
        ChargeWithToken(long amount, string tokenID) {
            PaymentsApi.PublicApiKey = "sbpb_ZDk3OGI3ZmMtZWQ4Yi00ZjZlLTg5NGQtNmM4NGU4MzAxMWQ3";
            PaymentsApi.PrivateApiKey = "PqLo8h66GF68hfoVc41T0bgJR8Zys9+i+HszlmtuOZJ5YFFQL0ODSXAOkNtXTToq";
            Payment payment = new Payment();
            PaymentsApi api = new PaymentsApi();

            payment.Amount = amount;
            payment.Currency = "USD";
            payment.Description = "payment description";
            payment.Token = new CardToken(tokenID).ToString();
            try
            {
                payment = (Payment)api.Create(payment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



    }
}