
namespace Prenommer.My
{
    // Les événements suivants sont disponibles pour MyApplication :
    // Startup : Déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    // Shutdown : Déclenché après la fermeture de tous les formulaires de l'application.  Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    // UnhandledException : Déclenché si l'application rencontre une exception non gérée.
    // StartupNextInstance : Déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    // NetworkAvailabilityChanged : Déclenché quand la connexion réseau est connectée ou déconnectée.
    internal partial class MyApplication
    {

        protected override bool OnInitialize(System.Collections.ObjectModel.ReadOnlyCollection<string> commandLineArgs)
        {
            // Set the display time to 5000 milliseconds (5 seconds). 
            MinimumSplashScreenDisplayTime = 2000;
            return base.OnInitialize(commandLineArgs);
        }

    }
}