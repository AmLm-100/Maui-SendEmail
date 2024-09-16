using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendEmail
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            await SendEmailAsync();
            // Display an alert to the user after the email is sent
            await DisplayAlert("Email Sent", "Your email has been sent successfully.", "OK");
        }

        public async Task SendEmailAsync()
        {
            if (Email.Default.IsComposeSupported)
            {
                string subject = "Hello from .NET MAUI!";
                string body = "This is a test email sent from a .NET MAUI application.";
                string[] recipients = new[] { "emailexample@example.com" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await Email.Default.ComposeAsync(message);
            }
        }
    }
}
