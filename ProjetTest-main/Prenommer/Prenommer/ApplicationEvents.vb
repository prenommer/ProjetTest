Imports System.Collections.ObjectModel

Namespace My
    ' Les événements suivants sont disponibles pour MyApplication :
    ' Startup : Déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : Déclenché après la fermeture de tous les formulaires de l'application.  Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : Déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : Déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : Déclenché quand la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication
        Protected Function InInitialize(CommandLineArgs As ReadOnlyCollection(Of String)) As Boolean
            ' Set the display time to 2000 milliseconds (2 seconds). 
            MinimumSplashScreenDisplayTime = 5000
            Return MyBase.OnInitialize(CommandLineArgs)
        End Function
    End Class

End Namespace