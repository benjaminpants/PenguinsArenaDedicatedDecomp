$MissionLoadPause = 5000;
function loadMission(%missionName, %isFirstMission)
{
	endMission();
	echo("*** LOADING MISSION: " @ %missionName);
	echo("*** Stage 1 load");
	clearCenterPrintAll();
	clearBottomPrintAll();
	$missionSequence = $missionSequence + 1.0;
	$missionRunning = 0;
	$Server::MissionFile = %missionName;
	buildLoadInfo(%missionName);
	%count = ClientGroup.getCount();
	%cl = 0;
	while(%cl < %count)
	{
		%client = ClientGroup.getObject(%cl);
		if (!%client.isAIControlled())
		{
			sendLoadInfoToClient(%client);
		}
		%cl = %cl + 1.0;
	}
	if (%isFirstMission || $Server::ServerType $= "SinglePlayer")
	{
		loadMissionStage2();
	}
	else
	{
		schedule($MissionLoadPause, ServerGroup, loadMissionStage2);
	}
}

function loadMissionStage2()
{
	echo("*** Stage 2 load");
	$instantGroup = ServerGroup;
	%file = $Server::MissionFile;
	if (!isFile(%file))
	{
		error("Could not find mission " @ %file);
		return;
	}
	$missionCRC = getFileCRC(%file);
	exec(%file);
	if (!isObject(MissionGroup))
	{
		error("No 'MissionGroup' found in mission \"" @ $missionName @ "\".");
		schedule(3000, ServerGroup, CycleMissions);
		return;
	}
	new SimGroup(MissionCleanup)
	$instantGroup = MissionCleanup;
	pathOnMissionLoadDone();
	echo("*** Mission loaded");
	$missionRunning = 1;
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		ClientGroup.getObject(%clientIndex).loadMission();
		%clientIndex = %clientIndex + 1.0;
	}
	onMissionLoaded();
	purgeResources();
}

function endMission()
{
	if (!isObject(MissionGroup))
	{
		return;
	}
	echo("*** ENDING MISSION");
	onMissionEnded();
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		%cl.endMission();
		%cl.resetGhosting();
		%cl.clearPaths();
		%clientIndex = %clientIndex + 1.0;
	}
	MissionGroup.delete();
	MissionCleanup.delete();
	$ServerGroup.delete();
	$ServerGroup = new SimGroup(ServerGroup);
}

function resetMission()
{
	echo("*** MISSION RESET");
	MissionCleanup.delete();
	$instantGroup = ServerGroup;
	new SimGroup(MissionCleanup)
	$instantGroup = MissionCleanup;
	onMissionReset();
}

