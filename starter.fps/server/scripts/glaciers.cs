new ParticleData(glacierParticles1)
{
	textureName = "";
	dragCoeffiecient = 5;
	gravityCoefficient = 0.4;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0.1;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80.0;
	spinRandomMax = 80;
	colors = 0;
	colors = 1;
	colors = 2;
	sizes = 0;
	sizes = 1;
	sizes = 2;
	times = 0;
	times = 1;
	times = 2;
}
new ParticleEmitterData(glacierEmitter1)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 10;
	ejectionVelocity = 15;
	velocityVariance = 10;
	thetaMin = 0;
	thetaMax = 90;
	particles = glacierParticles1;
}
new ExplosionData(glacierExplosion)
{
	lifetimeMS = 0.5;
	particleDensity = 1000;
	particleRadius = 10;
	emitter = 0;
}
new StaticShapeData(glacierLoin)
{
	category = glacierEmitter1;
	shapeFile = "~/data/shapes/decors/glaciera.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function glacierLoin::onAdd(%unused_var_0, %obj)
{
	schedule(10000.0 + getRandom(15000), 0, AnimationFonteGlaces, %obj);
	return 0;
}

new StaticShapeData(glaciera)
{
	category = 40;
	shapeFile = "~/data/shapes/decors/glaciera.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function glaciera::onAdd(%unused_var_0, %obj)
{
	schedule(35000.0 + getRandom(15000), 0, AnimationFonteGlaces, %obj);
	return 20;
}

new StaticShapeData(glacierb)
{
	category = 10;
	shapeFile = "~/data/shapes/decors/glacierb.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function glacierb::onAdd(%unused_var_0, %obj)
{
	schedule(25000.0 + getRandom(9000), 0, AnimationFonteGlaces, %obj);
	return "1 1 1 0";
}

new StaticShapeData(glacierc)
{
	category = "1 1 1 0.5";
	shapeFile = "~/data/shapes/decors/glacierc.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function glacierc::onAdd(%unused_var_0, %obj)
{
	schedule(20000.0 + getRandom(6000), 0, AnimationFonteGlaces, %obj);
	return "1 1 1 0";
}

new StaticShapeData(glacierd)
{
	category = "";
	shapeFile = "~/data/shapes/decors/glacierd.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.001;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function glacierd::onAdd(%unused_var_0, %obj)
{
	schedule(15000.0 + getRandom(3000), 0, AnimationFonteGlaces, %obj);
}

new StaticShapeData(glaciere)
{
	category = "";
	shapeFile = "~/data/shapes/decors/glaciere.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.001;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function glaciere::onAdd(%unused_var_0, %obj)
{
	schedule(30000.0 + getRandom(12000), 0, AnimationFonteGlaces, %obj);
}

new AudioProfile(GlacierSound)
{
	fileName = "";
	description = AudioLoud3d;
	preload = 1;
}
function AnimationFonteGlaces(%obj)
{
	%loc = getWord(%obj.getTransform(), 0) SPC getWord(%obj.getTransform(), 1) SPC 205;
	spawnExplosion(%loc, "0 0 1", 0, "glacierExplosion");
	%obj.playThread(0, "idle");
	%obj.playAudio(2, GlacierSound);
	%obj.schedule(8000, "delete");
}

