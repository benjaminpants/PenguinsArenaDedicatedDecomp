new AudioProfile(EffetInvincibleSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
};
new ShapeBaseImageData(InvincibleImage)
{
	shapeFile = "";
	firstPerson = 0;
	Item = InvincibleB;
	MountPoint = 5;
	emap = 1;
};
new ItemData(InvincibleB)
{
	category = "";
	className = "Bonus";
	shapeFile = "~/data/shapes/bonus/invincible/invincibleBonus.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Invincible";
	computeCRC = 0;
};
function InvincibleB::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function InvincibleB::onunmountbonus(%this, %player)
{
	%player.unmountImage(2);
	%player.setSkinName("base");
}

function InvincibleB::onPickup(%this, %obj, %player, %unused_var_3)
{
	spawnExplosion(%obj.getTransform(), "0 0 1", 0, "InvincibleEffectExplosion");
	%player.unmountImage(2);
	%player.unmountImage(3);
	%player.mountImage(InvincibleImage, 2);
	%player.setSkinName("invincible");
	%this.schedule(10.0 * 1000.0, "onunmountbonus", %player);
	if (%player.client)
	{
		commandToClient(%player.client, 'GotBonus', "invincibilite", 10.0 * 1000.0);
	}
	%obj.respawn();
	return 1;
}

new ParticleData(InvincibleEffectparticles)
{
	textureName = "";
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.1;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 0;
	useInvAlpha = 0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors = 0;
	colors = 1;
	colors = 2;
	sizes = 0;
	sizes = 1;
	sizes = 2;
	times = 0;
	times = 1;
	times = 2;
};
new ParticleEmitterData(InvincibleEffectemitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = InvincibleEffectparticles;
};
new ExplosionData(InvincibleEffectExplosion)
{
	lifetimeMS = 0.2;
	particleDensity = 5;
	particleRadius = 1;
	emitter = 0;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0.5 0.5 0";
	lightEndColor = "0 0 0";
};
return InvincibleEffectemitter;
