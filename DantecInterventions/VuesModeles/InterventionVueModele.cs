using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DantecInterventions_.Modeles;
using System.Collections.ObjectModel;


namespace DantecInterventions_.VuesModeles
{
    public partial class InterventionVueModele : ObservableObject
    {
        [ObservableProperty]
        public partial string NouveauTitre { get; set; }
        [ObservableProperty]
        public partial string NomTechnicien { get; set; }
        [ObservableProperty]
        public partial Intervention? InterventionSelectionnee { get; set; }
        [ObservableProperty]
        public partial string Message { get; set; }

        private int prochainId = 4;
        public ObservableCollection<Intervention> Interventions { get; } = new();

        public InterventionVueModele()
        {
            NouveauTitre = string.Empty;
            NomTechnicien = string.Empty;
            Message = string.Empty;
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
                Message = "Saisissez un titre.";
                return;
            }
            Intervention nouvelle = new()
            {
                Id = prochainId++,
                Titre = titre,
                Description = "Demande saisie localement",
                Priorite = "Normale",
                NomTechnicien = NomTechnicien.Trim(),
                EstTerminee = false
            };
            Interventions.Add(nouvelle);
            NouveauTitre = string.Empty;
            NomTechnicien = string.Empty;
            InterventionSelectionnee = nouvelle;
            Message = "Intervention ajoutée.";
        }
        [RelayCommand]
        private void TerminerIntervention()
        {
            if (InterventionSelectionnee == null)
            {
                Message = "Sélectionnez une intervention.";
                return;
            }
            InterventionSelectionnee.EstTerminee = true;
            Message = "Intervention terminée.";
        }
    }
}
