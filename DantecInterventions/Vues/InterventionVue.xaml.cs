using DantecInterventions_.VuesModeles;

namespace DantecInterventions_.Vues;

public partial class InterventionVue : ContentPage
{
	public InterventionVue()
	{
		InitializeComponent();
        BindingContext = new InterventionVueModele();
    }
}