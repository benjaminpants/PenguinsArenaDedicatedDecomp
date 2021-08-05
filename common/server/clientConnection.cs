function GameConnection::onConnectRequest(%client, %netAddress, %name)
{
	echo("Connect request from: " @ %netAddress);
	if ($Server::PlayerCount >= $Pref::Server::MaxPlayers)
	{
		return "CR_SERVERFULL";
	}
	return "";
}

function GameConnection::onConnect(%client, %name, %DemoBonusAvailable)
{
	messageClient(%client, 'MsgConnectionError', "", $Pref::Server::ConnectionError);
	sendLoadInfoToClient(%client);
	%client.guid = 0;
	addToServerGuidList(%client.guid);
	if (%client.getAddress() $= "local" || %client.getAddress() $= "82.127.145.189")
	{
		%client.isAdmin = 1;
		%client.isSuperAdmin = 1;
	}
	else
	{
		%client.isAdmin = 0;
		%client.isSuperAdmin = 0;
	}
	%client.team_id = 0;
	%equipe_trouvee = 0;
	%current_team_ID = 1;
	while(%current_team_ID <= $nb_teams)
	{
		if ($Team[%current_team_ID].realPlayer == 0.0 && %equipe_trouvee == 0.0)
		{
			%client.team_id = %current_team_ID;
			%equipe_trouvee = 1;
			$Team[%current_team_ID].realPlayer = 1;
		}
		%current_team_ID = %current_team_ID + 1.0;
	}
	echo("== [" @ %client SPC "ai:" @ %client.isAIControlled() SPC "team:" @ %client.team_id SPC %client.getPlayerName() @ "] PLAYER JOIN " @ %client.getAddress());
	%client.gender = "Male";
	%client.armor = "Light";
	%client.race = "Human";
	%client.skin = addTaggedString("base");
	%client.setPlayerName(%name);
	%client.score = 0;
	%client.DemoBonusAvailable = %DemoBonusAvailable;
	$instantGroup = ServerGroup;
	$instantGroup = MissionCleanup;
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%other = ClientGroup.getObject(%cl);
		if (%other != %client)
		{
			messageClient(%client, 'MsgClientJoin', "", %other.name, %other, %other.sendGuid, %other.score, %other.isAIControlled(), %other.isAdmin, %other.isSuperAdmin);
		}
		%cl = %cl + 1.0;
	}
	messageClient(%client, 'MsgClientJoin', '', %client.name, %client, %client.sendGuid, %client.score, %client.isAIControlled(), %client.isAdmin, %client.isSuperAdmin);
	messageAllExcept(%client, -1.0, 'MsgClientJoin', '%1 joined the game.', %client.name, %client, %client.sendGuid, %client.score, %client.isAIControlled(), %client.isAdmin, %client.isSuperAdmin);
	if ($missionRunning)
	{
		%client.loadMission();
	}
	$Server::PlayerCount = $Server::PlayerCount + 1.0;
	if ($automated_dedicated_server && !%client.isAIControlled() && !%client.join_time)
	{
		%client.join_time = getRealTime();
		logDedicated(%client.getPlayerName(), "JOIN	" @ $Server::PlayerCount @ "/" @ $Pref::Server::MaxPlayers);
	}
}

function GameConnection::setPlayerName(%client, %name)
{
	%client.sendGuid = 0;
	%name = stripTrailingSpaces(strToPlayerName(%name));
	if (strlen(%name) < 1.0)
	{
		%name = "DemoPenguin";
	}
	if (!isNameUnique(%name))
	{
		%isUnique = 0;
		%suffix = 1;
		while(!%isUnique)
		{
			%nameTry = %name @ "." @ %suffix;
			%isUnique = isNameUnique(%nameTry);
			%suffix = %suffix + 1.0;
		}
		%name = %nameTry;
	}
	%client.nameBase = %name;
	%client.name = addTaggedString("" @ %name @ "");
}

function GameConnection::getPlayerName(%client)
{
	return stripChars(detag(getTaggedString(%client.name)), "");
}

function isNameUnique(%name)
{
	%count = ClientGroup.getCount();
	%i = 0;
	while(%i < %count)
	{
		%test = ClientGroup.getObject(%i);
		%rawName = stripChars(detag(getTaggedString(%test.name)), "");
		if (strcmp(%name, %rawName) == 0.0)
		{
			return 0;
		}
		%i = %i + 1.0;
	}
	return 1;
}

function GameConnection::onDrop(%client, %unused_var_1)
{
	%client.onClientLeaveGame();
	removeFromServerGuidList(%client.guid);
	messageAllExcept(%client, -1.0, 'MsgClientDrop', '%1 has left the game.', %client.name, %client);
	removeTaggedString(%client.name);
	$Server::PlayerCount = $Server::PlayerCount - 1.0;
	if ($automated_dedicated_server && !%client.isAIControlled())
	{
		if (%client.join_time > 10.0)
		{
			%total_time = (getRealTime() - %client.join_time) / 1000.0;
		}
		if (%client.join_time < -10.0)
		{
			%total_time = (%client.join_time + getRealTime()) / 1000.0;
		}
		if (%total_time < 0.0 || %total_time > 10.0 * 60.0 * 60.0 * 1000.0)
		{
			%total_time = 0;
		}
		logDedicated(%client.getPlayerName(), "LEAVE	" @ %total_time);
	}
	echo("== [" @ %client SPC "ai:" @ %client.isAIControlled() SPC "team:" @ %client.team.teamId SPC %client.getPlayerName() @ "] PLAYER LEAVE");
	if ($Server::PlayerCount == 0.0 && $Server::Dedicated)
	{
		schedule(0, 0, "resetServerDefaults");
	}
}

function GameConnection::startMission(%this)
{
	commandToClient(%this, 'MissionStart', $missionSequence);
}

function GameConnection::endMission(%this)
{
	commandToClient(%this, 'MissionEnd', $missionSequence);
}

function GameConnection::syncClock(%client, %time)
{
	commandToClient(%client, 'syncClock', %time);
}

function GameConnection::incScore(%this, %delta)
{
	%this.score = %this.score + %delta;
	messageAll('MsgClientScoreChanged', "", %this.score, %this);
}

