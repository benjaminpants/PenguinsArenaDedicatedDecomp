new AudioProfile(OrqueSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
}
new StaticShapeData(orque)
{
	category = "";
	shapeFile = "~/data/shapes/orque/orque.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function orque::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "attaque");
	%obj.playAudio(2, OrqueSound);
}

function orqueEclaboussures(%loc)
{
	spawnExplosion(%loc, "0 0 1", 0, "OrqueExplosion");
}

new StaticShapeData(aileron)
{
	category = "";
	shapeFile = "~/data/shapes/orque/aileron.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function aileron::onAdd(%unused_var_0, %obj)
{
	%aleat = getRandom(1000);
	%obj.schedule(%aleat, playThread, 0, "idle");
}

new ParticleData(Orqueparticles)
{
	textureName = "";
	dragCoeffiecient = 1;
	gravityCoefficient = 5;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors = 0;
	colors = 1;
	sizes = 0;
	sizes = 1;
	times = 0;
	times = 1;
}
new ParticleEmitterData(Orqueemitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 2;
	thetaMin = 20;
	thetaMax = 60;
	lifetimeMS = 300;
	particles = Orqueparticles;
}
new ExplosionData(OrqueExplosion)
{
	lifetimeMS = 0;
	particleDensity = 1000;
	particleRadius = 10;
	emitter = 0;
	emitter = 1;
	emitter = 2;
}
new StaticShapeData(DeadPenguin)
{
	category = Orqueemitter;
	shapeFile = "~/data/shapes/deadPlayer/deadpenguin.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function DeadPenguin::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "idle");
	return PlayerSplashMistEmitter;
}

new StaticShapeData(SacPoubelle)
{
	category = PlayerSplashEmitter;
	shapeFile = "~/data/shapes/decors/decharge_sacanime.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function SacPoubelle::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "idle");
	return 0.5;
}

new StaticShapeData(auroreA)
{
	category = 0.5;
	shapeFile = "~/data/shapes/decors/aurore1.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function auroreA::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "idle");
	return "1 1 1 0";
}

new StaticShapeData(auroreB)
{
	category = "1 1 1 0.5";
	shapeFile = "~/data/shapes/decors/aurore2.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function auroreB::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "idle");
}

