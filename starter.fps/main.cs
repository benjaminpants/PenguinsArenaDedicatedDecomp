loadDir("common");
$FrogamesOptionsLow = 1001;
$FrogamesOptionsMedium = 1501;
echo("
--------- Loading prefs ---------");
exec("./client/defaults.cs");
if (!$ProcessorMhz || $ProcessorMhz < 100.0)
{
	echo("default : medium (can't detect processor frequency) ->" @ $ProcessorMhz);
	exec("./client/defaults_medium.cs");
	$pref::Video::resolution = "1024 768 32";
	$pref::Video::windowedRes = "1024 768";
}
else
{
	if ($ProcessorMhz < $FrogamesOptionsLow)
	{
		echo("default : low -> " @ $ProcessorMhz @ " Mhz < " @ $FrogamesOptionsLow @ " Mhz");
		exec("./client/defaults_low.cs");
		$pref::Video::resolution = "800 600 32";
		$pref::Video::windowedRes = "800 600";
	}
	else
	{
		if ($ProcessorMhz < $FrogamesOptionsMedium)
		{
			echo("default : medium -> " @ $ProcessorMhz @ " Mhz < " @ $FrogamesOptionsMedium @ " Mhz");
			exec("./client/defaults_medium.cs");
			$pref::Video::resolution = "1024 768 32";
			$pref::Video::windowedRes = "1024 768";
		}
		else
		{
			echo("default : heavy -> " @ $ProcessorMhz @ " Mhz > " @ $FrogamesOptionsMedium @ " Mhz");
			exec("./client/defaults_heavy.cs");
			$pref::Video::resolution = "1280 800 32";
			$pref::Video::windowedRes = "1280 800";
		}
	}
}
echo("This prefs will be overwrited by your previously selected options.");
exec("./dev_tools.cs");
exec("./server/defaults.cs");
exec("./client/prefs.cs");
exec("./server/prefs.cs");
$pref::Master[1] = "2:192.30.35.187:28002";
%localization = $pref::Localization;
if (%localization $= "")
{
	%localization = "en";
}
exec("./localization_" @ %localization @ ".cs");
function displayHelp()
{
	Parent::displayHelp();
	error("FPS Mod options:" @ "  -dedicated             Start as dedicated server" @ "  -connect <address>     For non-dedicated: Connect to a game at <address>" @ "  -mission <filename>    For dedicated: Load the mission" @ "  -gametype <type>       For dedicated: Type of game (Classic/Duels/Unlimited)");
}

function parseArgs()
{
	Parent::parseArgs();
	%i = 1;
	while(%i < $Game::argc)
	{
		%arg = $Game::argv[%i];
		%nextArg = $Game::argv[%i + 1.0];
		%hasNextArg = $Game::argc - %i > 1.0;
		if (%arg $= "-dedicated")
		{
			$Server::Dedicated = 1;
			enableWinConsole(1);
			$argUsed[%i] = $argUsed[%i] + 1.0;
		}
		else
		{
			if (%arg $= "-mission")
			{
				$argUsed[%i] = $argUsed[%i] + 1.0;
				if (%hasNextArg)
				{
					$missionArg = %nextArg;
					$argUsed[%i + 1.0] = $argUsed[%i + 1.0] + 1.0;
					%i = %i + 1.0;
				}
				else
				{
					error("Error: Missing Command Line argument. Usage: -mission <filename>");
				}
			}
			else
			{
				if (%arg $= "-gametype")
				{
					$argUsed[%i] = $argUsed[%i] + 1.0;
					if (%hasNextArg)
					{
						$Server::MissionType = %nextArg;
						$argUsed[%i + 1.0] = $argUsed[%i + 1.0] + 1.0;
						%i = %i + 1.0;
					}
					else
					{
						error("Error: Missing Command Line argument. Usage: -gametype <type>");
					}
				}
				else
				{
					if (%arg $= "-connect")
					{
						$argUsed[%i] = $argUsed[%i] + 1.0;
						if (%hasNextArg)
						{
							$JoinGameAddress = %nextArg;
							$argUsed[%i + 1.0] = $argUsed[%i + 1.0] + 1.0;
							%i = %i + 1.0;
						}
						else
						{
							error("Error: Missing Command Line argument. Usage: -connect <ip_address>");
						}
					}
				}
			}
		}
		%i = %i + 1.0;
	}
}

function onStart()
{
	Parent::onStart();
	echo("
--------- Initializing MOD: FPS Starter Kit ---------");
	exec("./client/init.cs");
	exec("./server/init.cs");
	exec("./data/init.cs");
	initServer();
	if ($Server::Dedicated)
	{
		initDedicated();
	}
	else
	{
		initClient();
	}
}

function onExit()
{
	echo("Exporting client prefs");
	export("$pref::*", "./client/prefs.cs", False);
	echo("Exporting client config");
	if (isObject(moveMap))
	{
		moveMap.save("./client/config.cs", 0);
	}
	echo("Exporting server prefs");
	export("$Pref::Server::*", "./server/prefs.cs", False);
	BanList::export("./server/banlist.cs");
	Parent::onExit();
}

activatePackage(FpsStarterKit);
