function startSoloGame()
{
	if ($Game::Running)
	{
		error("startGame: End the game first!");
		return;
	}
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		%cl.score = 0;
		%cl.ready = 0;
		%clientIndex = %clientIndex + 1.0;
	}
	echo("---- JEU SOLO - rules :");
	echo("time_limit : " @ $rules.time_limit);
	echo("player_droppoint : " @ $rules.player_droppoint);
	echo("player_nb_boulesdeneiges : " @ $rules.player_nb_boulesdeneiges);
	echo("bots_level : " @ $rules.bots_level);
	echo("-----------------------");
	$spawnPointsUsed = 0;
	$nb_joueurs_par_team = 6;
	$Team[1].Player = 1;
	$Team[1].numPlayers = 1;
	%current_player_ID = 1;
	while(%current_player_ID <= $rules.bots_redteam)
	{
		$Team[2].Player = %current_player_ID;
		%current_player_ID = %current_player_ID + 1.0;
	}
	$Team[2].numPlayers = $rules.bots_redteam;
	%current_player_ID = 1;
	while(%current_player_ID <= $rules.bots_yellowteam)
	{
		$Team[3].Player = %current_player_ID;
		%current_player_ID = %current_player_ID + 1.0;
	}
	$Team[3].numPlayers = $rules.bots_yellowteam;
	%current_player_ID = 1;
	while(%current_player_ID <= $rules.bots_greenteam)
	{
		$Team[4].Player = %current_player_ID;
		%current_player_ID = %current_player_ID + 1.0;
	}
	$Team[4].numPlayers = $rules.bots_greenteam;
	if ($rules.bots_redteam)
	{
		$nb_teams = 2;
	}
	if ($rules.bots_yellowteam)
	{
		$nb_teams = 3;
	}
	if ($rules.bots_greenteam)
	{
		$nb_teams = 4;
	}
	debugTeams();
	$Game::Running = 1;
	waitingBeforeSoloRules();
	return AIPlayer::spawn("Green" @ %current_player_ID, pickSpawnPointSolo(), 4, %current_player_ID, $rules.bots_greenteam_levelmodifier);
}

function waitingBeforeSoloRules()
{
	$Game::DecompteFini = 0;
	if (!LocalClientConnection.ready)
	{
		$Game::Schedule = schedule(500, 0, "waitingBeforeCountDown");
	}
	else
	{
		commandToClient(LocalClientConnection, 'SoloGameMapIntro');
	}
	return AIPlayer::spawn("Yellow" @ %current_player_ID, pickSpawnPointSolo(), 3, %current_player_ID, $rules.bots_yellowteam_levelmodifier);
}

function pickSpawnPointSolo()
{
	%groupName = "MissionGroup/PlayerDropPoints";
	%group = nameToID(%groupName);
	if (%group != -1.0)
	{
		$spawnPointsUsed = $spawnPointsUsed + 1.0;
		%index = $spawnPointsUsed + 1.0;
		%spawn = %group.getObject(%index);
		return %spawn.getTransform();
	}
	else
	{
		error("Missing spawn points group " @ %groupName);
	}
	return "0 0 300 1 0 0 0";
	return AIPlayer::spawn("Red" @ %current_player_ID, pickSpawnPointSolo(), 2, %current_player_ID, $rules.bots_redteam_levelmodifier);
}

return AIPlayer::spawn("Blue1", pickSpawnPointSolo(), 1, 1, 0);
