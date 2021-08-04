new AudioProfile(ImpactGeante)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
};
new ItemData(BdNgeante)
{
	category = "";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNgeante/BdNgeante.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige geante";
};
function BdNgeante::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function BdNgeante::onPickup(%this, %obj, %user, %unused_var_3)
{
	%user.setInventory(rafaleAmmo, 0);
	%user.setInventory(BdNexplosive, 0);
	%user.setInventory(BdNexplosiveW, 0);
	%user.mountImage(geanteImage, 0);
	%user.setInventory(BdNgeanteW, 1);
	%user.setInventory(BdNgeante, 1);
	if (%user.client)
	{
		commandToClient(%user.client, 'GotBonus', "BdNgeante");
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

new ItemData(BdNgeanteW)
{
	category = "";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNgeante/BdNgeante.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a geante";
	image = geanteImage;
}
new ParticleData(Mineparticles3)
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
}
new ParticleEmitterData(Mineemitter3)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = Mineparticles3;
}
new DebrisData(GeanteExplosionDebris)
{
	shapeFile = 0.2;
	elasticity = 0.8;
	friction = 0.5;
	numBounces = 1;
	bounceVariance = 0;
	explodeOnMaxBounce = 0;
	staticOnMaxBounce = 0;
	snapOnMaxBounce = 0;
	minSpinSpeed = 0;
	maxSpinSpeed = 180;
	render2D = 0;
	lifetime = 3;
	lifetimeVariance = 0.4;
	velocity = 20;
	velocityVariance = 0.5;
	fade = 1;
	useRadiusMass = 0;
	baseRadius = 2;
	gravModifier = 1;
	terminalVelocity = 20;
	ignoreWater = 1;
}
new ExplosionData(MineExplosion)
{
	lifetimeMS = 0;
	particleDensity = 5;
	particleRadius = 1;
	emitter = 2;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
	Debris = GeanteExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 2;
	debrisNumVariance = 1;
	debrisVelocity = 15;
	debrisVelocityVariance = 2;
}
new ProjectileData(BdNgeanteProjectile)
{
	projectileShapeName = Mineemitter3;
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 3.9;
	areaImpulse = 1400;
	Explosion = MineExplosion;
	particleEmitter = snowballemitter2;
	particleWaterEmitter = CrossbowBoltBubbleEmitter;
	Splash = CrossbowSplash;
	muzzleVelocity = 45;
	velInheritFactor = 0.3;
	armingDelay = 0;
	lifetime = 3000;
	fadeDelay = 3000;
	bounceElasticity = 0;
	bounceFriction = 0;
	isBallistic = 0;
	gravityMod = 0.3;
	hasLight = 0;
	hasWaterLight = 0;
}
function BdNgeanteProjectile::onCollision(%this, %obj, %col, %unused_var_3, %pos, %unused_var_5)
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
				%col.playAudio(2, ImpactGeante);
				%kickBack = 8000;
				if (%col.getMountedImage(2) != 0.0 && %col.getMountedImage(3) != 0.0)
				{
					%kickBack = %kickBack - 4000.0;
				}
				%direction_expulsion = VectorSub(%obj.getoldPosition(), %pos);
				%direction_expulsion = VectorNormalize(%direction_expulsion);
				%direction_expulsion = VectorScale(%direction_expulsion, %unused_var_1);
				%col.applyImpulse(%obj.getoldPosition(), %direction_expulsion);
				if ($debugVisualDebug)
				{
					vdtVector(%obj.getoldPosition(), %direction_expulsion, VectorLen(%direction_expulsion) / 1000.0, 6000, "0.3 0.3 0.7 1.0", 0);
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
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
	return 15;
}

new ShapeBaseImageData(geanteImage)
{
	shapeFile = 10;
	emap = 1;
	MountPoint = 0;
	offset = "0 0 1";
	eyeOffset = "0.2 0.5 0.1";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = BdNgeanteW;
	Ammo = BdNgeante;
	Projectile = BdNgeanteProjectile;
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
function geanteImage::onFire(%this, %obj, %slot)
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
	if (%obj.getInventory(BdNgeante) <= 0.0)
	{
		%obj.setInventory(Crossbow, 1);
		%obj.setInventory(CrossbowAmmo, 500);
		%obj.mountImage(CrossbowImage, 0);
	}
	return %p;
	return rafaleFireEmptySound;
}

return "NoAmmo";
