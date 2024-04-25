using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;


public class EnvoyeEmailController : Controller
{
    public IActionResult Index()
    {
        EnvoyerEmail();
        return RedirectToAction("Index", "Besoin");
    }

    public static void EnvoyerEmail()
    {
        // Adresse e-mail de l'expéditeur
        string emailExpediteur = "andriamaherymaela2@gmail.com";

        // Mot de passe de l'expéditeur (utilisé pour l'authentification SMTP)
        string motDePasse = "az#LibwT13?@";

        // Adresse e-mail du destinataire
        string emailDestinataire = "manooandriasat@example.com";

        // Objet du message
        string sujet = "Test";

        // Corps du message
        string corpsMessage = "Vous avez rendez-vous le 16 Octobre 2023";

        // Configuration du client SMTP
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com") // Utilisez le serveur SMTP approprié
        {
            Port = 587, // Port SMTP
            Credentials = new NetworkCredential(emailExpediteur, motDePasse), // Authentification SMTP
            EnableSsl = true // Utilisez SSL pour une communication sécurisée avec le serveur SMTP
        };

        // Créez l'objet MailMessage
        MailMessage message = new MailMessage(emailExpediteur, emailDestinataire)
        {
            Subject = sujet,
            Body = corpsMessage
        };

        try
        {
            // Envoyer l'e-mail
            smtpClient.Send(message);
            // Vous pouvez ajouter un message de succès dans un journal ou une base de données ici
        }
        catch (Exception ex)
        {
            // Gérez l'erreur ici ou enregistrez l'erreur dans des journaux
        }
    }
}





