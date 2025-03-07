using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NLog;

namespace RepositoryLayer.Helper
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
            
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public bool SendPasswordResetEmail(string email, string token, string baseUrl)
        {
            try
            {
                var resetLink = $"{baseUrl}/api/UserRegistration/reset-password?token={token}";

                var mail = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = "Password Reset Request",
                    Body = $@"
                        <html>
                        <body>
                            <h2>Password Reset Request</h2>
                            <p>Hello,</p>
                            <p>We received a request to reset your password. Click the link below to reset your password:</p>
                            <p><a href='{resetLink}'>Reset Password</a></p>
                            <p>If you did not request a password reset, please ignore this email.</p>
                            <p>This link will expire in 1 hour.</p>
                            <p>Thank you,</p>
                            <p>Your Application Team</p>
                        </body>
                        </html>",
                    IsBodyHtml = true
                };

                mail.To.Add(email);

                using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    client.Send(mail);
                    logger.Info($"Password reset email sent to {email}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed to send password reset email to {email}");
                return false;
            }
        }
    }
}
