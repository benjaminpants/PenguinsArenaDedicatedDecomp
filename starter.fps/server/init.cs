function initServer()
{
	echo("
--------- Initializing MOD: FPS Starter Kit: Server ---------");
	$Server::Status = "Unknown";
	$Server::TestCheats = 0;
	$Server::MissionFileSpec = "*/missions/*.mis";
	initBaseServer();
	exec("./scripts/commands.cs");
	exec("./scripts/centerPrint.cs");
	exec("./scripts/game.cs");
	compile("./scripts/dedicated_server.cs");
}

function initDedicated()
{
	enableWinConsole(1);
	echo("
--------- Starting Dedicated Server ---------");
	exec("./scripts/dedicated_server.cs");
	exec("./scripts/dedicated_server_official.cs");
	if ($Server::MissionType $= "")
	{
		if (getRandom(1, 2) == 1.0)
		{
			$Server::MissionType = "Classic";
		}
		else
		{
			$Server::MissionType = "Unlimited";
		}
	}
	if ($dedicatedServerName !$= "")
	{
		$Pref::Server::Name = $dedicatedServerName;
	}
	else
	{
		$Pref::Server::Name = "PA Server";
	}
	if ($dedicatedServerSlots >= 1.0 && $dedicatedServerSlots <= 4.0)
	{
		$Pref::Server::PlayersSlots = $dedicatedServerSlots;
	}
	else
	{
		$Pref::Server::PlayersSlots = 4;
	}
	if ($dedicatedServerAIlevel)
	{
		$pref::Server::AI_level = $dedicatedServerAIlevel;
	}
	else
	{
		$pref::Server::AI_level = getRandom(5, 8);
	}
	$Pref::Server::Info = $pref::Server::AI_level;
	if ($Pref::Server::PlayersSlots == 2.0)
	{
		$pref::Server::nbTeams2 = 1;
		$pref::Server::nbTeams3 = 0;
		$pref::Server::nbTeams4 = 0;
		$Pref::Server::MaxPlayers = 2;
	}
	else
	{
		if ($Pref::Server::PlayersSlots == 3.0)
		{
			$pref::Server::nbTeams2 = 0;
			$pref::Server::nbTeams3 = 1;
			$pref::Server::nbTeams4 = 0;
			$Pref::Server::MaxPlayers = 3;
		}
		else
		{
			if ($Pref::Server::PlayersSlots == 4.0)
			{
				$pref::Server::nbTeams2 = 0;
				$pref::Server::nbTeams3 = 0;
				$pref::Server::nbTeams4 = 1;
				$Pref::Server::MaxPlayers = 4;
			}
			else
			{
				$pref::Server::nbTeams2 = 0;
				$pref::Server::nbTeams3 = 0;
				$pref::Server::nbTeams4 = 1;
				$Pref::Server::MaxPlayers = 4;
			}
		}
	}
	echo("CREATING SERVER:" SPC $Pref::Server::Name SPC "- type:" SPC $Server::MissionType SPC "slots:" SPC $Pref::Server::PlayersSlots SPC "ailevel:" SPC $Pref::Server::Info);
	$Server::Dedicated = 1;
	if ($missionArg !$= "")
	{
		createServer("MultiPlayer", $missionArg);
	}
	else
	{
		%i = 0;
		%file = findFirstFile($Server::MissionFileSpec);
		while(%file !$= "")
		{
			if (strstr(%file, "/CVS/") == -1.0)
			{
				%map_list[%i] = %file;
				%i = %i + 1.0;
			}
			%file = findNextFile($Server::MissionFileSpec);
		}
		%map_list_count = %i;
		%aleat = getRandom(%map_list_count - 1.0);
		%mission = %map_list[%aleat];
		createServer("MultiPlayer", %mission);
	}
	schedule(30.0 * 1000.0, 0, "dedicatedAIconnect");
	checkAI();
}

function dedicatedAIconnect()
{
	%ai_names[0] = "SUPERBOT MasterT";
	%ai_names[1] = "SUPERBOT MEAGAIN";
	%ai_names[2] = "SUPERBOT Lorenzo";
	%ai_names[3] = "SUPERBOT jpp";
	%ai_names[4] = "SUPERBOT TodaH";
	%ai_names[5] = "SUPERBOT Iylararel";
	%ai_names[6] = "SUPERBOT faKe";
	%ai_names[7] = "SUPERBOT qwertqwry";
	%ai_names[8] = "SUPERBOT H H H H H";
	%ai_names[9] = "SUPERBOT Kem";
	%ai_names[10] = "SUPERBOT Noam";
	%aleat = getRandom(0, 10);
	%name = %ai_names[%aleat];
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		if (%cl.isAIControlled())
		{
			return;
		}
		%clientIndex = %clientIndex + 1.0;
	}
	if ($Server::PlayerCount < $Pref::Server::MaxPlayers - 1.0)
	{
		echo("=[SUPERAI] Nouveau bot : " SPC %name);
		%botConnection = aiConnect(%name);
		schedule(25.0 * 60.0 * 1000.0, 0, "dedicatedAIdisconnect", %botConnection);
	}
	else
	{
		schedule(3.0 * 60.0 * 1000.0, 0, "dedicatedAIconnect");
	}
}

function dedicatedAIdisconnect(%client)
{
	if (isObject())
	{
		echo("=[SUPERAI] byebye SUPER AI");
		%client.delete();
	}
	schedule(5.0 * 60.0 * 1000.0, 0, "dedicatedAIconnect");
}

function checkAI()
{
	while(ClientGroup.getCount() >= $Pref::Server::MaxPlayers)
	{
		%clientIndex = 0;
		if (%clientIndex < ClientGroup.getCount())
		{
			%cl = ClientGroup.getObject(%clientIndex);
			if (%cl.isAIControlled())
			{
				%cl.delete();
				echo("=[SUPERAI] plus de place on vire les bots");
			}
			%clientIndex = %clientIndex + 1.0;
		}
	}
	schedule(3.0 * 1000.0, 0, "checkAI");
}

