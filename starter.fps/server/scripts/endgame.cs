function endgame_check()
{
	if (!$Game::Sessionfinished)
	{
		%i = 1;
		while(%i <= $nb_teams)
		{
			if ($Team[%i].numPlayers >= 1.0)
			{
				%compte_equipes_vivantes = %compte_equipes_vivantes + 1.0;
			}
			%i = %i + 1.0;
		}
		if (%compte_equipes_vivantes < 2.0)
		{
			%i = 1;
			while(%i <= $nb_teams)
			{
				if ($Team[%i].numPlayers)
				{
					endgame_ok(%i, $Team[%i].numPlayers);
					$Game::WiningTeam = %i;
				}
				else
				{
					%i = %i + 1.0;
				}
			}
		}
		else
		{
			if ($Team[1].numPlayers + $Team[2].numPlayers + $Team[3].numPlayers + $Team[4].numPlayers == 2.0)
			{
				messageAll('MsgDuel');
				$achivement_temp_duel = 1;
			}
		}
	}
	else
	{
		endgame_cameras($Game::WiningTeam, 1);
	}
}

function endgame_ok(%equipe_gagnante, %nb_gagnants)
{
	if (!$Game::Sessionfinished)
	{
		$Game::Sessionfinished = 1;
		endgame_danser(%equipe_gagnante);
		endgame_cameras(%equipe_gagnante, 0);
		endgame_scores(%equipe_gagnante, %nb_gagnants);
		schedule(3000, 0, endgame_screenscores1, %equipe_gagnante, %nb_gagnants);
		schedule(6000, 0, endgame_screenscores2, %equipe_gagnante);
		cycleGame();
	}
}

function endgame_danser(%equipe_gagnante)
{
	%current_player_ID = 1;
	while(%current_player_ID <= $nb_joueurs_par_team)
	{
		if ($Team[%equipe_gagnante].Player)
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%equipe_gagnante].Player;
				$Team[%equipe_gagnante].Player.schedule(2000, setSkinName, "base");
			}
			$Team[%equipe_gagnante].Player.setImageTrigger(0, 0);
			$Team[%equipe_gagnante].Player.setImageTrigger(1, 0);
			cancel($Team[%equipe_gagnante].Player.ailoop);
			$Team[%equipe_gagnante].Player.stop();
			$Team[%equipe_gagnante].Player.setSkinName("happy");
			$Team[%equipe_gagnante].Player.setActionThread("danse");
		}
		%current_player_ID = %current_player_ID + 1.0;
	}
	return %current_player_ID;
}

function endgame_cameras(%equipe_gagnante, %alreadyPlaying)
{
	%current_player_ID = 1;
	while(%current_player_ID <= $nb_joueurs_par_team)
	{
		if ($Team[%equipe_gagnante].Player)
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%equipe_gagnante].Player;
			}
		}
		else
		{
			%current_player_ID = %current_player_ID + 1.0;
		}
	}
	if (%first_winning_player)
	{
		%first_winning_player.unmountImage(2);
		%first_winning_player.unmountImage(3);
	}
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		if (isObject(%cl.Camera) && %first_winning_player)
		{
			%cl.Camera.setMode("Corpse", %first_winning_player);
			%cl.setControlObject(%cl.Camera);
			if (!%alreadyPlaying)
			{
				commandToClient(%cl, 'GameEndScores0');
			}
		}
		else
		{
			if (!%cl.isAIControlled())
			{
				echo("CAMERA - oups... endgameNoCamera");
				%cl.endgameNoCamera();
			}
		}
		%clientIndex = %clientIndex + 1.0;
	}
	return %current_player_ID;
}

function endgame_scores(%equipe_gagnante, %nb_vivants)
{
	%score_current_partie = 2.0 + %nb_vivants;
	$Team[%equipe_gagnante].score = $Team[%equipe_gagnante].score + %score_current_partie;
	messageAll('MsgTeamScoreChanged', "", %equipe_gagnante, $Team[%equipe_gagnante].score);
	%team = 1;
	while(%team <= $nb_teams)
	{
		%i = 1;
		while(%i <= 9.0)
		{
			$Team[%team].scoreLTG = %i;
			%i = %i + 1.0;
		}
		if (%team == %equipe_gagnante)
		{
			$Team[%team].scoreLTG = 10;
		}
		else
		{
			$Team[%team].scoreLTG = 10;
		}
		$Team[%team].scoreLTGtotal = 0;
		%i = 1;
		while(%i <= 10.0)
		{
			$Team[%team].scoreLTGtotal = $Team[%team].scoreLTGtotal + $Team[%team].scoreLTG;
			%i = %i + 1.0;
		}
		messageAll('MsgTeamScoreLTGChanged', "", %team, $Team[%team].scoreLTGtotal);
		%team = %team + 1.0;
	}
	return %i;
}

function endgame_screenscores1(%equipe_gagnante, %nb_gagnants)
{
	if (%equipe_gagnante == 1.0)
	{
		%nom_equipe_gagnante = $Txt_Scores01;
	}
	else
	{
		if (%equipe_gagnante == 2.0)
		{
			%nom_equipe_gagnante = $Txt_Scores02;
		}
		else
		{
			if (%equipe_gagnante == 3.0)
			{
				%nom_equipe_gagnante = $Txt_Scores03;
			}
			else
			{
				if (%equipe_gagnante == 4.0)
				{
					%nom_equipe_gagnante = $Txt_Scores04;
				}
			}
		}
	}
	echo("STEAM & ACH - endgame_screenscores1");
	%full_team = 0;
	if ($Team[%equipe_gagnante].numPlayers == $nb_joueurs_par_team)
	{
		%full_team = 1;
	}
	echo("STEAM & ACH - %full_team = " @ %full_team);
	%duel = 0;
	if ($achivement_temp_duel == 1.0)
	{
		%duel = 1;
	}
	echo("STEAM & ACH - %duel = " @ %duel);
	%not_touched = 0;
	if ($Team[%equipe_gagnante].achivement_temp_not_touched == 1.0)
	{
		%not_touched = 1;
	}
	echo("STEAM & ACH - %not_touched = " @ %not_touched);
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores1', %equipe_gagnante, %nom_equipe_gagnante, %nb_gagnants);
		if ($pref::Server::AI_level >= 5.0)
		{
			if (%cl.team_id == %equipe_gagnante)
			{
				commandToClient(%cl, 'AchievementNewGamePlayed', 1, %duel, %full_team, %not_touched);
			}
			else
			{
				commandToClient(%cl, 'AchievementNewGamePlayed', 0, %duel, %full_team, %not_touched);
			}
		}
		%clientIndex = %clientIndex + 1.0;
	}
	return 0;
}

function endgame_screenscores2(%equipe_gagnante)
{
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores2', $nb_teams, %equipe_gagnante, $Team[1].playerName, $Team[2].playerName, $Team[3].playerName, $Team[4].playerName);
		%clientIndex = %clientIndex + 1.0;
	}
	return %score_current_partie;
}

return $Team[%team].scoreLTG;
