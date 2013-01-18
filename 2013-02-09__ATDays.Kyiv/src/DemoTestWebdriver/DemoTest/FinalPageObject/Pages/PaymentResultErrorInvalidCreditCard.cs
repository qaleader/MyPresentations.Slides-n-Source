using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTest.FinalPageObject.Pages
{
    public class PaymentResultErrorInvalidCreditCard: PaymentResultPage, IInvokable
    {
        public void Invoke()
        {
            if (Exists() == false)
            {
                var paymentsForm = MyPages.DonationPaymentsForm;
                paymentsForm.Invoke();
                paymentsForm.FillDonationForm
                (
                    firstName: "Vasya",
                    lastName: "Pupkin",
                    street: "Blah blah blah street",
                    postalCode: "8577",
                    city: "My City",
                    emailAddress: "valid@example.com",
                    cardNumber: "4556767453966453",
                    expirationDateMonth: "05",
                    expirationDateYear: "15",
                    securityCode: "555"

                );
                this.WaitUntilExists();
            }
        }

        public bool Exists()
        {
            return Driver.Title.Contains("Donate-error - Payments");
        }
    }
}
