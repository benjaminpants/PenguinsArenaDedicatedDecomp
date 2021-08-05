function messageClient(%client, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
	commandToClient(%client, 'ServerMessage', %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
}

function messageTeam(%team, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%recipient = ClientGroup.getObject(%cl);
		if (%recipient.team == %team)
		{
			messageClient(%recipient, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
		}
		%cl = %cl + 1.0;
	}
}

function messageTeamExcept(%client, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
	%team = %client.team;
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%recipient = ClientGroup.getObject(%cl);
		if (%recipient.team == %team && %recipient != %client)
		{
			messageClient(%recipient, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
		}
		%cl = %cl + 1.0;
	}
}

function messageAll(%msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%client = ClientGroup.getObject(%cl);
		messageClient(%client, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
		%cl = %cl + 1.0;
	}
}

function messageAllExcept(%client, %team, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%recipient = ClientGroup.getObject(%cl);
		if (%recipient != %client && %recipient.team != %team)
		{
			messageClient(%recipient, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
		}
		%cl = %cl + 1.0;
	}
}

$SPAM_PROTECTION_PERIOD = 10000;
$SPAM_MESSAGE_THRESHOLD = 4;
$SPAM_PENALTY_PERIOD = 10000;
$SPAM_MESSAGE = 'FLOOD PROTECTION: You must wait another %1 seconds.';
function GameConnection::spamMessageTimeout(%this)
{
	if (%this.spamMessageCount > 0.0)
	{
		%this.spamMessageCount = %this.spamMessageCount - 1.0;
	}
}

function GameConnection::spamReset(%this)
{
	%this.isSpamming = 0;
}

function spamAlert(%client)
{
	if ($Pref::Server::FloodProtectionEnabled != 1.0)
	{
		return 0;
	}
	if (!%client.isSpamming && %client.spamMessageCount >= $SPAM_MESSAGE_THRESHOLD)
	{
		%client.spamProtectStart = getSimTime();
		%client.isSpamming = 1;
		%client.schedule($SPAM_PENALTY_PERIOD, spamReset);
	}
	if (%client.isSpamming)
	{
		%wait = mFloor(($SPAM_PENALTY_PERIOD - getSimTime() - %client.spamProtectStart) / 1000.0);
		messageClient(%client, "", $SPAM_MESSAGE, %wait);
		return 1;
	}
	%client.spamMessageCount = %client.spamMessageCount + 1.0;
	%client.schedule($SPAM_PROTECTION_PERIOD, spamMessageTimeout);
	return 0;
}

function chatMessageClient(%client, %sender, %voiceTag, %voicePitch, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10)
{
	if (!%client.muted)
	{
		commandToClient(%client, 'ChatMessage', %sender, %voiceTag, %voicePitch, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10);
	}
	return %sender;
}

function chatMessageTeam(%sender, %team, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10)
{
	if (%msgString $= "" || spamAlert(%sender))
	{
		return;
	}
	%count = ClientGroup.getCount();
	%i = 0;
	while(%i < %count)
	{
		%obj = ClientGroup.getObject(%i);
		if (%obj.team == %sender.team)
		{
			chatMessageClient(%obj, %sender, %sender.voiceTag, %sender.voicePitch, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10);
		}
		%i = %i + 1.0;
	}
}

function chatMessageAll(%sender, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10)
{
	if (%msgString $= "" || spamAlert(%sender))
	{
		return;
	}
	%count = ClientGroup.getCount();
	%i = 0;
	while(%i < %count)
	{
		%obj = ClientGroup.getObject(%i);
		if (%sender.team != 0.0)
		{
			chatMessageClient(%obj, %sender, %sender.voiceTag, %sender.voicePitch, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10);
		}
		else
		{
			if (%obj.team == %sender.team)
			{
				chatMessageClient(%obj, %sender, %sender.voiceTag, %sender.voicePitch, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10);
			}
		}
		%i = %i + 1.0;
	}
}

