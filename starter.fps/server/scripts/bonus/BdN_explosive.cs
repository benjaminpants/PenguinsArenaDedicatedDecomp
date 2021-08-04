new AudioProfile(ExplosionBDN)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
};
new ItemData(BdNexplosive)
{
	category = "";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige explosive";
	maxInventory = 1;
	computeCRC = 0;
};
new ItemData(BdNexplosiveW)
{
	category = "";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a grenade";
	image = grenadeImage;
};
function BdNexplosive::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function BdNexplosive::onPickup(%this, %obj, %user, %unused_var_3)
{
	%user.setInventory(rafaleAmmo, 0);
	%user.setInventory(BdNgeanteW, 0);
	%user.setInventory(BdNgeante, 0);
	%user.mountImage(grenadeImage, 0);
	%user.setInventory(BdNexplosive, 1);
	%user.setInventory(BdNexplosiveW, 1);
	if (%user.client)
	{
		commandToClient(%user.client, 'GotBonus', "BdNexplosive");
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
}

new ParticleData(BdNexplosiveparticles1)
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
}
new ParticleData(BdNexplosiveparticles2)
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
}
new ParticleData(BdNexplosiveparticles3)
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
}
new ParticleEmitterData(BdNexplosiveemitter1)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 250;
	particles = BdNexplosiveparticles1;
}
new ParticleEmitterData(BdNexplosiveemitter2)
{
	ejectionPeriodMS = 0.2;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 150;
	particles = BdNexplosiveparticles2;
}
new ParticleEmitterData(BdNexplosiveemitter3)
{
	ejectionPeriodMS = 0;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = BdNexplosiveparticles3;
}
new ExplosionData(BdNexplosiveExplosion)
{
	soundProfile = 40;
	lifetimeMS = 200;
	particleDensity = 5;
	particleRadius = 1;
	emitter = 0;
	emitter = 1;
	emitter = 2;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
}
new ProjectileData(BdNexplosiveProjectile)
{
	projectileShapeName = BdNexplosiveemitter3;
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 26;
	areaImpulse = 4000;
	Explosion = BdNexplosiveExplosion;
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
	lightRadius = 3;
	lightColor = "0.3 0.8 0.3";
	hasWaterLight = 0;
}
function BdNexplosiveProjectile::onCollision(%this, %obj, %unused_var_2, %unused_var_3, %pos, %unused_var_5)
{
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
	return BdNexplosiveemitter2;
}

new ShapeBaseImageData(grenadeImage)
{
	shapeFile = BdNexplosiveemitter1;
	emap = 1;
	MountPoint = 0;
	eyeOffset = "0.3 0.5 -1";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = BdNexplosiveW;
	Ammo = BdNexplosive;
	Projectile = BdNexplosiveProjectile;
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
}
function grenadeImage::onFire(%this, %obj, %slot)
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
	if (%obj.getInventory(BdNexplosive) <= 0.0)
	{
		%obj.setInventory(Crossbow, 1);
		%obj.setInventory(CrossbowAmmo, 250);
		%obj.mountImage(CrossbowImage, 0);
	}
	return %p;
	return rafaleFireEmptySound;
}

return "NoAmmo";
