function serverCmdSAD(%client, %password)
{
	if (%password !$= "" && %password $= $Pref::Server::AdminPassword)
	{
		%client.isAdmin = 1;
		%client.isSuperAdmin = 1;
		%name = getTaggedString(%client.name);
		messageAll('MsgAdminForce', "" @ %name @ " has become Admin by force.", %client);
	}
}

function serverCmdSADSetPassword(%client, %password)
{
	if (%client.isSuperAdmin)
	{
		$Pref::Server::AdminPassword = %password;
	}
}

function serverCmdTeamMessageSent(%client, %text)
{
	if (strlen(%text) >= $Pref::Server::MaxChatLen)
	{
		%text = getSubStr(%text, 0, $Pref::Server::MaxChatLen);
	}
	chatMessageTeam(%client, %client.team, '%1: %2', %client.name, %text);
}

function serverCmdMessageSent(%client, %text)
{
	if (strlen(%text) >= $Pref::Server::MaxChatLen)
	{
		%text = getSubStr(%text, 0, $Pref::Server::MaxChatLen);
	}
	chatMessageAll(%client, '%1: %2', %client.name, %text);
	if ($automated_dedicated_server)
	{
		logDedicated(%client.getPlayerName(), "CHAT	" @ %client.getAddress() @ "	" @ %text);
	}
}

