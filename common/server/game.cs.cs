function onServerCreated()
{
	$Server::GameType = "Test App";
	$Server::MissionType = "Deathmatch";
	createGame();
}

function onServerDestroyed()
{
	destroyGame();
}

function onMissionLoaded()
{
	startGame();
}

function onMissionEnded()
{
	endGame();
}

function onMissionReset()
{
}

function GameConnection::onClientEnterGame(%this)
{
}

function GameConnection::onClientLeaveGame(%this)
{
}

function createGame()
{
}

function destroyGame()
{
}

function startGame()
{
}

function endGame()
{
}

