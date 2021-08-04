function debugTeams()
{
	%current_team_ID = 1;
	while(%current_team_ID <= $nb_teams)
	{
		if (%current_team_ID == 1.0)
		{
			%current_team_name = "Blue";
		}
		else
		{
			if (%current_team_ID == 2.0)
			{
				%current_team_name = "Red";
			}
			else
			{
				if (%current_team_ID == 3.0)
				{
					%current_team_name = "Yellow";
				}
				else
				{
					if (%current_team_ID == 4.0)
					{
						%current_team_name = "Green";
					}
				}
			}
		}
		%current_player_ID = 1;
		while(%current_player_ID <= $nb_joueurs_par_team)
		{
			echo(%current_player_ID @ $Team[%current_team_ID].Player);
			%current_player_ID = %current_player_ID + 1.0;
		}
		%current_team_ID = %current_team_ID + 1.0;
	}
	return " " @ %current_team_name SPC "->" ;
}

function debugPause()
{
	if (!$debugPauseAI)
	{
		$debugPauseAI = 1;
	}
	else
	{
		$debugPauseAI = 0;
	}
}

function debugPauseTires()
{
	if (!$debugPauseAITires)
	{
		$debugPauseAITires = 1;
	}
	else
	{
		$debugPauseAITires = 0;
	}
}

$debugPauseAITires = 0;
function visualDebug()
{
	if (!$debugVisualDebug)
	{
		$debugVisualDebug = 1;
	}
	else
	{
		$debugVisualDebug = 0;
	}
}

if ($dev_build == 1.0)
{
	$debugVisualDebug = 1;
}
else
{
	$debugVisualDebug = 0;
}
function serverCmdDebugPause()
{
	echo("xxxxxxxxxxxx debugPause xxxxxxxxxxxx");
	debugPause();
}

function serverCmdDebugPauseTires()
{
	echo("xxxxxxxxxxxx debugPause Tires xxxxxxxxxxxx");
	debugPauseTires();
}

function serverCmdDebugTeams()
{
	echo("xxxxxxxxxxxx DebugTeams xxxxxxxxxxxx");
	debugTeams();
	echo("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
}

function serverCmdVisualDebug()
{
	echo("xxxxxxxxxxxx Visual Debug xxxxxxxxxxxx");
	visualDebug();
}

