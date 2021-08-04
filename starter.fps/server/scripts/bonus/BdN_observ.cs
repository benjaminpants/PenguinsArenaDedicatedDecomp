new AudioProfile(observExplosionSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
};
new AudioProfile(observReloadSound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
};
new AudioProfile(observFireSound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
};
new ItemData(observAmmo)
{
	category = "";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige explosive";
	maxInventory = 100;
	computeCRC = 0;
};
new ItemData(observ)
{
	category = "";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a observ weapon";
	image = observImage;
};
new ParticleData(observParticles1)
{
	textureName = "";
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinSpeed = 1;
	spinRandomMin = -90.0;
	spinRandomMax = 90;
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
new ParticleData(observParticles2)
{
	textureName = 1;
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinSpeed = 1;
	spinRandomMin = -90.0;
	spinRandomMax = 90;
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
new ParticleData(observParticles3)
{
	textureName = 1;
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
new ParticleEmitterData(observEmitter1)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 250;
	particles = observParticles1;
};
new ParticleEmitterData(observEmitter2)
{
	ejectionPeriodMS = 0.2;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 150;
	particles = observParticles2;
};
new ParticleEmitterData(observEmitter3)
{
	ejectionPeriodMS = 0;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = observParticles3;
};
new ExplosionData(observExplosion)
{
	soundProfile = 32;
	lifetimeMS = 200;
	particleDensity = 5;
	particleRadius = 1;
	emitter = 0;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
};
new ProjectileData(observProjectile)
{
	projectileShapeName = observEmitter3;
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 15;
	areaImpulse = 3000;
	Explosion = observExplosion;
	particleWaterEmitter = CrossbowBoltBubbleEmitter;
	Splash = CrossbowSplash;
	muzzleVelocity = 30;
	velInheritFactor = 0.4;
	armingDelay = 2000;
	lifetime = 5000;
	fadeDelay = 5000;
	bounceElasticity = 0.3;
	bounceFriction = 0.6;
	isBallistic = 1;
	gravityMod = 1;
	hasLight = 1;
	lightRadius = 2.5;
	lightColor = "0.8 0.3 0.8";
	hasWaterLight = 0;
};
function observProjectile::onCollision(%this, %obj, %unused_var_2, %unused_var_3, %pos, %unused_var_5)
{
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
	return 22;
}

new ShapeBaseImageData(observImage)
{
	shapeFile = 1;
	emap = 1;
	MountPoint = 2;
	offset = "0 0 0";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = observ;
	Ammo = observAmmo;
	Projectile = observProjectile;
	projectileType = Projectile;
	stateName = 0;
	stateTransitionOnLoaded = 0;
	stateTransitionOnNoAmmo = 0;
	stateName = 1;
	stateTransitionOnTimeout = 1;
	stateTimeoutValue = 1;
	stateSequence = 1;
	stateName = 2;
	stateTransitionOnNoAmmo = 2;
	stateTransitionOnTriggerDown = 2;
	stateName = 3;
	stateTransitionOnTimeout = 3;
	stateTimeoutValue = 3;
	stateFire = 3;
	stateRecoil = 3;
	stateAllowImageChange = 3;
	stateSequence = 3;
	stateScript = 3;
	stateSound = 3;
	stateName = 4;
	stateTransitionOnNoAmmo = 4;
	stateTransitionOnTimeout = 4;
	stateTimeoutValue = 4;
	stateAllowImageChange = 4;
	stateSequence = 4;
	stateEjectShell = 4;
	stateSound = 4;
	stateName = 5;
	stateTransitionOnAmmo = 5;
	stateSequence = 5;
	stateTransitionOnTriggerDown = 5;
	stateScript = 5;
	stateName = 6;
	stateTimeoutValue = 6;
	stateTransitionOnTimeout = 6;
	stateSound = 6;
};
function observImage::onFire(%this, %obj, %slot)
{
	%obj.setActionThread("fire");
	%projectile = %this.Projectile;
	%obj.decInventory(%this.Ammo, 1);
	%muzzleVector = %obj.client.Player.getEyeVector();
	%objectVelocity = %obj.getVelocity();
	%muzzleVelocity = VectorAdd(VectorScale(%muzzleVector, %projectile.muzzleVelocity), VectorScale(%objectVelocity, %projectile.velInheritFactor));
	%p = new %this.projectileType()
	{
		dataBlock = %this;
		initialVelocity = %muzzleVelocity;
		initialPosition = %obj.getMuzzlePoint(%slot);
		sourceObject = %obj;
		sourceSlot = %slot;
		client = %obj.client;
	};
	MissionCleanup.add(%p);
	return %p;
	return observFireEmptySound;
}

function observImage::onNoAmmo(%this, %obj, %slot)
{
	commandToClient(%obj.client, 'FullGameOnlyFantome');
	return "NoAmmo";
}

return 1;
