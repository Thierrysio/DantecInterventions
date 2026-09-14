namespace DantecInterventions_
{
    public class Intervention
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priorite { get; set; } = string.Empty;
        public bool EstTerminee { get; set; }
    }
    public partial class MainPage : ContentPage
    {

        private readonly List<Intervention> interventions =
new List<Intervention>();
        private Intervention? selectionnee;
        private int prochainId = 4;

        public MainPage()
        {
            InitializeComponent();
            interventions.Add(new Intervention
            {
                Id = 1,
                Titre = "Imprimante salle 12",
                Description = "Vérifier le bourrage papier",
                Priorite = "Haute",
                EstTerminee = false
            });
            interventions.Add(new Intervention
            {
                Id = 2,
                Titre = "Poste accueil",
                Description = "Contrôler le démarrage",
                Priorite = "Normale",
                EstTerminee = false
            });
            interventions.Add(new Intervention
            {
                Id = 3,
                Titre = "Wi-Fi atelier",
                Description = "Vérifier la connexion du portable",
                Priorite = "Basse",
                EstTerminee = true
            });
            Rafraichir(null);
        }


        private void Selection_Changed(object? sender,
       SelectionChangedEventArgs e)
        {
            selectionnee = e.CurrentSelection.Count > 0
                ? e.CurrentSelection[0] as Intervention : null;
        
        AfficherSelection();
        }
        private void AfficherSelection()
        {
            SelectionLabel.Text = selectionnee == null
                ? "Aucune intervention sélectionnée" : selectionnee.Titre;
        }
        private void Ajouter_Clicked(object? sender, EventArgs e)
        {
            string titre = (NouveauTitreEntry.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(titre))
            {
                MessageLabel.Text = "Saisissez un titre.";
                return;
            }
            Intervention nouvelle = new Intervention
            {
                Id = prochainId++,
                Titre = titre,
                Description = "Demande saisie localement",
                Priorite = "Normale",
                EstTerminee = false
            };
            interventions.Add(nouvelle);
            NouveauTitreEntry.Text = string.Empty;
            Rafraichir(nouvelle);
            MessageLabel.Text = "Intervention ajoutée.";
        }
        private void Terminer_Clicked(object? sender, EventArgs e)
        {
            if (selectionnee == null)
            {
                MessageLabel.Text = "Sélectionnez une intervention.";
                return;
            }
            selectionnee.EstTerminee = true;
            Rafraichir(selectionnee);
            MessageLabel.Text = "Intervention terminée.";
        }

        private void Rafraichir(Intervention? selection)
        {
            // V0 force la reconstruction visuelle après les changements.
            InterventionsView.ItemsSource = null;
            InterventionsView.ItemsSource = interventions;
            InterventionsView.SelectedItem = selection;
            selectionnee = selection;
            AfficherSelection();
        }

    } }
