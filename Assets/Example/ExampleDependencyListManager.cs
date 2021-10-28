
public class ExampleDependencyListManager : AbstractDependencyListManager
{

	public ExampleDependencyListNode getVersionData;
	public ExampleDependencyListNode login;
	public ExampleDependencyListNode getLeaderboardData;
	public ExampleDependencyListNode getPlayerData;
	public ExampleDependencyListNode getTitleData;
	public ExampleDependencyListNode parseLeaderboardData;
	public ExampleDependencyListNode parsePlayerData;
	public ExampleDependencyListNode parseTitleData;

	void Start()
    {
		login.addDependency(getVersionData);

		getLeaderboardData.addDependency(login);
		getPlayerData.addDependency(login);
		getTitleData.addDependency(login);

		parseLeaderboardData.addDependency(getLeaderboardData);
		parsePlayerData.addDependency(getPlayerData);
		parseTitleData.addDependency(getTitleData);

		addNode(getVersionData);
		addNode(login);
		addNode(getLeaderboardData);
		addNode(getPlayerData);
		addNode(getTitleData);
		addNode(parseLeaderboardData);
		addNode(parsePlayerData);
		addNode(parseTitleData);
	}
}
