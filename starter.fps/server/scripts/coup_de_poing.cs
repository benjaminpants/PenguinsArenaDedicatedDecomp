new AudioProfile(ImpactCCSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
}
new AudioProfile(NoImpactCCSound)
{
	fileName = "";
	description = AudioDefault3d;
	preload = 1;
}
new ItemData(coup_de_poing)
{
	category = "";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/coupdepoing/weapon.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "coup de poing";
	image = coup_de_poingImage;
}
new ParticleData(coup_de_poingParticle)
{
	textureName = "";
	dragCoefficient = 2;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 300;
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
}
new ParticleEmitterData(coup_de_poingEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = "coup_de_poingParticle";
}
new ParticleData(coup_de_poingSmoke)
{
	textureName = 0.3;
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
}
new ParticleEmitterData(coup_de_poingSmokeEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "coup_de_poingSmoke";
}
new ExplosionData(coup_de_poingExplosion)
{
	lifetimeMS = 0.3;
	particleEmitter = coup_de_poingEmitter;
	particleDensity = 1;
	particleRadius = 0.1;
	emitter = 0;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "0.7 0.7 0.7";
	camShakeDuration = 1.5;
	camShakeRadius = 5;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0.5 0.5 0";
	lightEndColor = "0 0 0";
}
new ShapeBaseImageData(coup_de_poingImage)
{
	shapeFile = coup_de_poingSmokeEmitter;
	emap = 1;
	MountPoint = 1;
	eyeOffset = "0.1 0.4 -0.8";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = coup_de_poing;
	ammo = CrossbowAmmo;
	Projectile = CrossbowProjectile;
	projectileType = Projectile;
	stateName = 0;
	stateTransitionOnLoaded = 0;
	stateName = 1;
	stateTransitionOnTimeout = 1;
	stateTimeoutValue = 1;
	stateSequence = 1;
	stateName = 2;
	stateTransitionOnTriggerDown = 2;
	stateName = 3;
	stateTransitionOnTimeout = 3;
	stateTimeoutValue = 3;
	stateFire = 3;
	stateRecoil = 3;
	stateAllowImageChange = 3;
	stateSequence = 3;
	stateScript = 3;
	stateName = 4;
	stateTransitionOnTimeout = 4;
	stateTimeoutValue = 4;
	stateAllowImageChange = 4;
	stateEjectShell = 4;
}
function coup_de_poingImage::onFire(%unused_var_0, %obj, %unused_var_2)
{
	if ($debugVisualDebug)
	{
		vdtVector(%obj.getEyeTransform(), %obj.getEyeVector(), 4.5, 6000, "0.0 1.0 1.0 1.0", 1);
	}
	%startvec = %obj.getEyeTransform();
	%endvec = VectorAdd(%obj.getEyeTransform(), VectorScale(%obj.getEyeVector(), 4.5));
	%searchResult = containerRayCast(%startvec, %endvec, $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::PlayerObjectType, %obj);
	%foundObject = getWord(%searchResult, 0);
	if (%foundObject && $TypeMasks::PlayerObjectType & %foundObject.getType())
	{
		if (%foundObject.reincarnationInvincible)
		{
			%foundObject.playAudio(2, EffetInvincibleSound);
		}
		else
		{
			%direction = VectorSub(%foundObject.getWorldBoxCenter(), %obj.getPosition());
			%direction = VectorNormalize(%direction);
			%velocity = VectorNormalize(%obj.getVelocity());
			%directionImpulse2 = VectorAdd(VectorScale(%velocity, 100.0 * VectorLen(%obj.getVelocity())), VectorScale(%direction, 900));
			%foundObject.applyImpulse(%foundObject.getPosition(), %directionImpulse2);
			%foundObject.setActionThread("hit");
			if ($pref::Frogames::optionsSet == 3.0)
			{
				if (%foundObject.getMountedImage(2) && !%foundObject.getMountedImage(3))
				{
					%foundObject.setSkinName("HITinvincible");
					%foundObject.schedule(1000, enleverHITinvincible);
				}
				else
				{
					%foundObject.setSkinName("hit");
					%foundObject.schedule(1000, setSkinName, "base");
				}
			}
			spawnExplosion(%foundObject.getWorldBoxCenter(), "0 0 1", 0, "coup_de_poingExplosion");
			%foundObject.playAudio(2, ImpactCCSound);
			if (%foundObject.client)
			{
				commandToClient(%foundObject.client, 'CaChit');
			}
			if (%obj.client)
			{
				commandToClient(%obj.client, 'CaCtouche', 180);
			}
		}
	}
	else
	{
		%obj.playAudio(2, NoImpactCCSound);
	}
	return 1;
}

return 0;
