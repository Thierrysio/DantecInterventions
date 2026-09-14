using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DantecInterventions_.Modeles;
using System.Collections.ObjectModel;


namespace DantecInterventions_.VuesModeles
{
    public partial class InterventionVueModele : ObservableObject
    {
         private string titre = "DantecInterventions";
        [ObservableProperty]
        private string nouveauTitre = string.Empty;
        [ObservableProperty]
        private Intervention? interventionSelectionnee;

        private int prochainId = 4;
        private string message = string.Empty;
        public ObservableCollection<Intervention> Interventions { get; } = new();

        public InterventionVueModele()
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

        [RelayCommand]
        private void AjouterIntervention()
        {
            string titre = NouveauTitre.Trim();
            if (string.IsNullOrWhiteSpace(titre))
            {
                message = "Saisissez un titre.";
                return;
            }
            Intervention nouvelle = new()
            {
                Id = prochainId++,
                Titre = titre,
                Description = "Demande saisie localement",
                Priorite = "Normale",
                EstTerminee = false
            };
            Interventions.Add(nouvelle);
            NouveauTitre = string.Empty;
            InterventionSelectionnee = nouvelle;
            message = "Intervention ajoutée.";
        }

        private void TerminerIntervention()
        {
            if (InterventionSelectionnee == null)
            {
                message = "Sélectionnez une intervention.";
                return;
            }
            InterventionSelectionnee.EstTerminee = true;
            message = "Intervention terminée.";
        }
    }
}