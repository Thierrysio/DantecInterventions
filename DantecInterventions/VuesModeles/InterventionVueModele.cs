using CommunityToolkit.Mvvm.ComponentModel;
using DantecInterventions_.Modeles;
using System.Collections.ObjectModel;


namespace DantecInterventions_.VuesModeles
{
    public class InterventionVueModele : ObservableObject
    {
         private string titre = "DantecInterventions";
        [ObservableProperty]
        private string nouveauTitre = string.Empty;
        [ObservableProperty]
        private Intervention? interventionSelectionnee;

        private int prochainId = 4;
        private string message = string.Empty;
        public ObservableCollection<Intervention> Interventions { get; } = new();

        public MainViewModel()
        {
            Interventions.Add(new Intervention
            {
                Id = 1,
                Titre = "Imprimante salle 12",
                Description = "Vérifier le bourrage papier",
                Priorite = "Haute",
                EstTerminee = false
            });
            Interventions.Add(new Intervention
            {
                Id = 2,
                Titre = "Poste accueil",
                Description = "Contrôler le démarrage",
                Priorite = "Normale",
                EstTerminee = false
            });
            Interventions.Add(new Intervention
            {
                Id = 3,
                Titre = "Wi-Fi atelier",
                Description = "Vérifier la connexion du portable",
                Priorite = "Basse",
                EstTerminee = true
            });
        }
    }
}