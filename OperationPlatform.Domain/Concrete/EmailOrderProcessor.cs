using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using OperationPlatform.Domain.Abstract;
using OperationPlatform.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace OperationPlatform.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "sikong1986@gmail.com";
        public string MailFromAddress = "zhanggb@iwooo.com";
        public bool UseSsl = true;
        public string Username = "zhanggb@iwooo.com";
        public string Password = "finkle1986819";
        public string Servername = "smtp.iwooo.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"F:\sports_store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.Servername;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} * {1} (subtotal: {2:C})", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:C}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                        emailSettings.MailFromAddress,
                        emailSettings.MailToAddress,
                        "New Order submitted!",
                        body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);

            }
        }
    }
}
