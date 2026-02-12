namespace PocketWarz.Web.Components.Pages;

public partial class Home
{
	private bool? _selectedTeamIsCats;

	private void StartGame()
	{
		Navigation.NavigateTo("/game");
	}

	private void SelectTeam(bool isCats)
	{
		_selectedTeamIsCats = isCats;
		// TODO: Persist team selection when authentication is implemented
		StartGame();
	}
}