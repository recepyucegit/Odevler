using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

public class EmailSender
{
    private static string _fromAddress;
    private static string _emailPassword;
    private static string _smtpHost;
    private static string _smtpPort;

    //public EmailSender(IConfiguration configuration)
    //{
    //    _fromAddress = configuration["EmailSettings:MailAddress"];
    //    _emailPassword = configuration["EmailSettings:Password"];
    //    _smtpHost = configuration["EmailSettings:Smtp"];
    //    _smtpPort = configuration["EmailSettings:Port"];
    //}

    public EmailSender(string fromAddress, string password, string host, string port)
    {
        _fromAddress = fromAddress;
        _emailPassword = password;
        _smtpHost = host;
        _smtpPort = port;
    }

    // SendEmail metodunu static olmaktan çıkarıyoruz ki, instance fields'lara erişebilelim
    public void SendEmail(string toAddress, string subject, string body)
    {
        try
        {
            // MailMessage oluşturuluyor
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromAddress),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // HTML formatında e-posta gönderme
            };

            // Alıcı adresi
            mailMessage.To.Add(toAddress);

            // SMTP Client ayarları
            using (var smtpClient = new SmtpClient(_smtpHost, int.Parse(_smtpPort)))
            {
                // SMTP ayarları
                smtpClient.Credentials = new NetworkCredential(_fromAddress, _emailPassword);
                smtpClient.EnableSsl = true; // SSL bağlantısı aktif

                // E-posta gönderme işlemi
                smtpClient.Send(mailMessage);
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda uygun loglama yapılabilir
            Console.WriteLine($"Email gönderme hatası: {ex.Message}");
        }
    }
}
