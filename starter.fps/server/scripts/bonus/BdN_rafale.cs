new AudioProfile(rafaleReloadSound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
};
new AudioProfile(rafaleFireSound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
};
new AudioProfile(rafaleFireEmptySound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
};
new AudioProfile(rafaleExplosionSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
};
new ParticleData(rafaleSplashMist)
{
	dragCoefficient = "";
	gravityCoefficient = -0.0500000007451;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 400;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	spinRandomMin = -90.0;
	spinRandomMax = 500;
	textureName = "~/data/shapes/crossbow/splash";
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
new ParticleEmitterData(rafaleSplashMistEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 2;
	ejectionOffset = 0;
	thetaMin = 85;
	thetaMax = 85;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	lifetimeMS = 250;
	particles = "rafaleSplashMist";
};
new ParticleData(rafaleSplashParticle)
{
	dragCoefficient = 0.5;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = -0.0;
	lifetimeMS = 600;
	lifetimeVarianceMS = 0;
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
new ParticleEmitterData(rafaleSplashEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 60;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	orientParticles = 1;
	lifetimeMS = 100;
	particles = "rafaleSplashParticle";
};
new SplashData(rafaleSplash)
{
	numSegments = 0.5;
	ejectionFreq = 15;
	ejectionAngle = 40;
	ringLifetime = 0.5;
	lifetimeMS = 300;
	velocity = 4;
	startRadius = 0;
	acceleration = -3.0;
	texWrap = 5;
	Texture = "~/data/shapes/crossbow/splash";
	emitter = 0;
	emitter = 1;
	colors = 0;
	colors = 1;
	colors = 2;
	colors = 3;
	times = 0;
	times = 1;
	times = 2;
	times = 3;
};
new ParticleData(rafaleBoltParticle)
{
	textureName = 1;
	dragCoefficient = 0;
	gravityCoefficient = -0.10000000149;
	inheritedVelFactor = 0;
	lifetimeMS = 150;
	lifetimeVarianceMS = 10;
	useInvAlpha = 0;
	spinRandomMin = -30.0;
	spinRandomMax = 30;
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
new ParticleData(rafaleBubbleParticle)
{
	textureName = 1;
	dragCoefficient = 0;
	gravityCoefficient = -0.25;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -100.0;
	spinRandomMax = 100;
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
new ParticleEmitterData(rafaleBoltEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0.1;
	thetaMin = 0;
	thetaMax = 90;
	particles = rafaleBoltParticle;
};
new ParticleEmitterData(rafaleBoltBubbleEmitter)
{
	ejectionPeriodMS = 0.5;
	periodVarianceMS = 0;
	ejectionVelocity = 1;
	ejectionOffset = 0.1;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = rafaleBubbleParticle;
};
new ParticleData(rafaleDebrisSpark)
{
	textureName = 0;
	dragCoefficient = 0;
	gravityCoefficient = 0;
	windCoefficient = 0;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 50;
	spinRandomMin = -90.0;
	spinRandomMax = 90;
	useInvAlpha = 0;
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
new ParticleEmitterData(rafaleDebrisSparkEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0.5;
	velocityVariance = 0.25;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 90;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 0;
	lifetimeMS = 300;
	particles = "rafaleDebrisSpark";
};
new ExplosionData(rafaleDebrisExplosion)
{
	emitter = 0;
	shakeCamera = 0;
	impulseRadius = 0;
	lightStartRadius = 0;
	lightEndRadius = 0;
};
new ParticleData(rafaleDebrisTrail)
{
	textureName = 0.5;
	dragCoefficient = 1;
	gravityCoefficient = 0;
	inheritedVelFactor = 0;
	windCoefficient = 0;
	constantAcceleration = 0;
	lifetimeMS = 800;
	lifetimeVarianceMS = 100;
	spinSpeed = 0;
	spinRandomMin = -90.0;
	spinRandomMax = 90;
	useInvAlpha = 1;
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
new ParticleEmitterData(rafaleDebrisTrailEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	ejectionOffset = 0;
	thetaMin = 170;
	thetaMax = 180;
	phiReferenceVel = 0;
	phiVariance = 360;
	lifetimeMS = 5000;
	particles = "rafaleDebrisTrail";
};
new DebrisData(rafaleExplosionDebris)
{
	shapeFile = 0.2;
	elasticity = 0.6;
	friction = 0.5;
	numBounces = 0;
	bounceVariance = 0;
	explodeOnMaxBounce = 0;
	staticOnMaxBounce = 0;
	snapOnMaxBounce = 0;
	minSpinSpeed = 0;
	maxSpinSpeed = 700;
	render2D = 0;
	lifetime = 2;
	lifetimeVariance = 0.4;
	velocity = 5;
	velocityVariance = 0.5;
	fade = 1;
	useRadiusMass = 1;
	baseRadius = 0.3;
	gravModifier = 0.7;
	terminalVelocity = 6;
	ignoreWater = 1;
};
new ParticleData(rafaleExplosionSmoke)
{
	textureName = 0.1;
	dragCoefficient = 2;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 0;
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
new ParticleData(rafaleExplosionBubble)
{
	textureName = 1;
	dragCoeffiecient = 0;
	gravityCoefficient = -0.25;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -100.0;
	spinRandomMax = 100;
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
new ParticleEmitterData(rafaleExplosionSmokeEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "rafaleExplosionSmoke";
};
new ParticleEmitterData(rafaleExplosionBubbleEmitter)
{
	ejectionPeriodMS = 0.5;
	periodVarianceMS = 0;
	ejectionVelocity = 1;
	ejectionOffset = 0.1;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = "rafaleExplosionBubble";
};
new ParticleData(rafaleExplosionFire)
{
	textureName = 0;
	dragCoeffiecient = 100;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 1200;
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
};
new ParticleEmitterData(rafaleExplosionFireEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0.8;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "rafaleExplosionFire";
};
new ParticleData(rafaleExplosionSparks)
{
	textureName = 0.5;
	dragCoefficient = 1;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 350;
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
new ParticleData(rafaleExplosionWaterSparks)
{
	textureName = 1;
	dragCoefficient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 350;
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
new ParticleEmitterData(rafaleExplosionSparkEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 180;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 1;
	lifetimeMS = 100;
	particles = "rafaleExplosionSparks";
};
new ParticleEmitterData(rafaleExplosionWaterSparkEmitter)
{
	ejectionPeriodMS = 0.5;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 4;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 1;
	lifetimeMS = 200;
	particles = "rafaleExplosionWaterSparks";
};
new ExplosionData(rafaleSubExplosion1)
{
	offset = 0;
	emitter = 0;
	emitter = 1;
};
new ExplosionData(rafaleSubExplosion2)
{
	offset = rafaleExplosionSparkEmitter;
	emitter = 0;
	emitter = 1;
};
new ExplosionData(rafaleSubWaterExplosion1)
{
	delayMS = rafaleExplosionSparkEmitter;
	offset = 1.2;
	playSpeed = 1.5;
	emitter = 0;
	emitter = 1;
	sizes = 0;
	sizes = 1;
	sizes = 2;
	times = 0;
	times = 1;
	times = 2;
};
new ExplosionData(rafaleSubWaterExplosion2)
{
	delayMS = 1;
	offset = 1.2;
	playSpeed = 0.75;
	emitter = 0;
	emitter = 1;
	sizes = 0;
	sizes = 1;
	sizes = 2;
	times = 0;
	times = 1;
	times = 2;
};
new ExplosionData(rafaleExplosion)
{
	lifetimeMS = 1;
	emitter = 0;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
	Debris = rafaleExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 1;
	debrisNumVariance = 0;
	debrisVelocity = 1;
	debrisVelocityVariance = 0.5;
};
new ExplosionData(rafaleWaterExplosion)
{
	particleEmitter = rafaleExplosionSmokeEmitter;
	particleDensity = 375;
	particleRadius = 2;
	emitter = 0;
	emitter = 1;
	subExplosion = 0;
	subExplosion = 1;
	shakeCamera = 1;
	camShakeFreq = "8.0 9.0 7.0";
	camShakeAmp = "3.0 3.0 3.0";
	camShakeDuration = 1.3;
	camShakeRadius = 20;
	Debris = rafaleExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 6;
	debrisNumVariance = 2;
	debrisVelocity = 0.5;
	debrisVelocityVariance = 0.2;
	impulseRadius = 10;
	impulseForce = 15;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0 0.5 0.5";
	lightEndColor = "0 0 0";
};
new ProjectileData(rafaleProjectile)
{
	projectileShapeName = rafaleSubWaterExplosion2;
	directDamage = 20;
	radiusDamage = 20;
	damageRadius = 1.5;
	Explosion = rafaleExplosion;
	particleWaterEmitter = rafaleBoltBubbleEmitter;
	Splash = rafaleSplash;
	muzzleVelocity = 80;
	velInheritFactor = 0.02;
	armingDelay = 0;
	lifetime = 3000;
	fadeDelay = 3000;
	bounceElasticity = 0;
	bounceFriction = 0;
	isBallistic = 0;
	gravityMod = 0.8;
	hasLight = 0;
	hasWaterLight = 0;
};
function rafaleProjectile::onCollision(%this, %obj, %col, %unused_var_3, %pos, %unused_var_5)
{
	if ($TypeMasks::PlayerObjectType & %col.getType())
	{
		if (!%col.isObserver)
		{
			if (%col.getMountedImage(2) && !%col.getMountedImage(3) || %col.reincarnationInvincible)
			{
				%col.playAudio(2, EffetInvincibleSound);
			}
			else
			{
				%col.playAudio(2, rafaleExplosionSound);
				%kickBack = 3400;
				if (%col.getMountedImage(2) != 0.0 && %col.getMountedImage(3) != 0.0)
				{
					%kickBack = %kickBack - 2200.0;
				}
				%direction_expulsion = VectorSub(%obj.getoldPosition(), %pos);
				%direction_expulsion = VectorNormalize(%direction_expulsion);
				%direction_expulsion = VectorScale(%direction_expulsion, %unused_var_1);
				%col.applyImpulse(%obj.getoldPosition(), %direction_expulsion);
				if ($debugVisualDebug)
				{
					vdtVector(%obj.getoldPosition(), %direction_expulsion, VectorLen(%direction_expulsion) / 1000.0, 6000, "1.0 0.0 1.0 1.0", 0);
				}
				%col.stop();
				if (getWord(%direction_expulsion, 2) > 0.0)
				{
					%col.setActionThread("fly");
				}
				else
				{
					if (getRandom(1, 2) == 1.0)
					{
						%col.setActionThread("hit");
					}
					else
					{
						%col.setActionThread("turn");
					}
				}
				if ($pref::Frogames::optionsSet == 3.0)
				{
					%col.setSkinName("hit");
					%col.schedule(1000, setSkinName, "base");
				}
			}
		}
	}
	return rafaleSubWaterExplosion1;
}

new ItemData(rafaleAmmo)
{
	category = rafaleExplosionWaterSparkEmitter;
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNrafale/BdNrafale.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "rafale bolts";
	maxInventory = 25;
};
function rafaleAmmo::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
	return rafaleExplosionBubbleEmitter;
}

function rafaleAmmo::onPickup(%this, %obj, %user, %unused_var_3)
{
	%user.setInventory(BdNexplosive, 0);
	%user.setInventory(BdNexplosiveW, 0);
	%user.setInventory(BdNgeanteW, 0);
	%user.setInventory(BdNgeante, 0);
	%user.mountImage(rafaleImage, 0);
	%user.setInventory(rafaleAmmo, 25);
	if (%user.client)
	{
		commandToClient(%user.client, 'GotBonus', "BdNrafale");
	}
	if (%obj.isStatic())
	{
		%obj.respawn();
	}
	else
	{
		%obj.delete();
	}
	return 1;
	return 0.5;
}

new ItemData(rafale)
{
	category = 0;
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNrafale/BdNrafale.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a rafale";
	image = rafaleImage;
};
new ShapeBaseImageData(rafaleImage)
{
	shapeFile = "1.0 1.0 1.0";
	emap = 1;
	MountPoint = 0;
	offset = "0 0 1";
	eyeOffset = "0.7 1.5 -0.4";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = rafale;
	Ammo = rafaleAmmo;
	Projectile = rafaleProjectile;
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
	stateName = 6;
	stateTimeoutValue = 6;
	stateTransitionOnTimeout = 6;
	stateSound = 6;
};
function rafaleImage::onFire(%this, %obj, %slot)
{
	%obj.stop();
	%obj.setActionThread("fire");
	%projectile = %this.Projectile;
	if ($Server::MissionType !$= "Unlimited")
	{
		%obj.decInventory(%this.Ammo, 1);
	}
	%muzzleVector = %obj.getMuzzleVector(%slot);
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
	if (%obj.getInventory("rafaleAmmo") <= 0.0)
	{
		%obj.setInventory(Crossbow, 1);
		%obj.setInventory(CrossbowAmmo, 500);
		%obj.mountImage(CrossbowImage, 0);
	}
	return %p;
	return rafaleFireEmptySound;
}

return "NoAmmo";
