exec("~/data/shapes/player/player.cs");
$CorpseTimeoutValue = 2.0 * 1000.0;
$DamageLava = 0.00999999977648;
$DamageHotLava = 0.00999999977648;
$DamageCrustyLava = 0.00999999977648;
$PlayerDeathAnim::TorsoFrontFallForward = 1;
$PlayerDeathAnim::TorsoFrontFallBack = 2;
$PlayerDeathAnim::TorsoBackFallForward = 3;
$PlayerDeathAnim::TorsoLeftSpinDeath = 4;
$PlayerDeathAnim::TorsoRightSpinDeath = 5;
$PlayerDeathAnim::LegsLeftGimp = 6;
$PlayerDeathAnim::LegsRightGimp = 7;
$PlayerDeathAnim::TorsoBackFallForward = 8;
$PlayerDeathAnim::HeadFrontDirect = 9;
$PlayerDeathAnim::HeadBackFallForward = 10;
$PlayerDeathAnim::ExplosionBlowBack = 11;
new AudioProfile(DeathCrySound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
}
new AudioProfile(PainCrySound)
{
	fileName = "";
	description = AudioClose3d;
	preload = 1;
}
new AudioProfile(ReincarnationSound)
{
	fileName = "";
	description = AudioLoud3d;
	preload = 1;
}
new ParticleData(PlayerSplashMist)
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
	textureName = "~/data/shapes/player/splash";
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
new ParticleEmitterData(PlayerSplashMistEmitter)
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
	particles = "PlayerSplashMist";
}
new ParticleData(PlayerBubbleParticle)
{
	dragCoefficient = 0.5;
	gravityCoefficient = -0.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 400;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	textureName = "~/data/shapes/player/splash";
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
new ParticleEmitterData(PlayerBubbleEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	ejectionOffset = 0.5;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	particles = "PlayerBubbleParticle";
}
new ParticleData(PlayerFoamParticle)
{
	dragCoefficient = 0.5;
	gravityCoefficient = -0.0500000007451;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 400;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	spinRandomMin = -90.0;
	spinRandomMax = 500;
	textureName = "~/data/shapes/player/splash";
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
new ParticleEmitterData(PlayerFoamEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 85;
	thetaMax = 85;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	particles = "PlayerFoamParticle";
}
new ParticleData(PlayerFoamDropletsParticle)
{
	dragCoefficient = 0.5;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = -0.0;
	lifetimeMS = 600;
	lifetimeVarianceMS = 0;
	textureName = "~/data/shapes/player/splash";
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
new ParticleEmitterData(PlayerFoamDropletsEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 60;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	orientParticles = 1;
	particles = "PlayerFoamDropletsParticle";
}
new ParticleData(PlayerSplashParticle)
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
}
new ParticleEmitterData(PlayerSplashEmitter)
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
	particles = "PlayerSplashParticle";
}
new SplashData(PlayerSplash)
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
	Texture = "~/data/shapes/player/splash";
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
}
new ParticleData(snowballparticles3)
{
	textureName = 1;
	dragCoeffiecient = 100;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 500;
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
new ParticleEmitterData(snowballemitter3)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "snowballparticles2";
}
new ParticleData(LightPuff)
{
	dragCoefficient = 0.5;
	gravityCoefficient = -0.00999999977648;
	inheritedVelFactor = 0.6;
	constantAcceleration = 0;
	lifetimeMS = 800;
	lifetimeVarianceMS = 100;
	useInvAlpha = 1;
	spinRandomMin = -35.0;
	spinRandomMax = 35;
	colors = 0;
	colors = 1;
	sizes = 0;
	sizes = 1;
	times = 0;
	times = 1;
}
new ParticleEmitterData(LightPuffEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 10;
	ejectionVelocity = 0.2;
	velocityVariance = 0.1;
	ejectionOffset = 0;
	thetaMin = 20;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	useEmitterColors = 1;
	particles = "LightPuff";
}
new ParticleData(LiftoffDust)
{
	dragCoefficient = 0.3;
	gravityCoefficient = -0.00999999977648;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 100;
	useInvAlpha = 1;
	spinRandomMin = -90.0;
	spinRandomMax = 500;
	colors = 0;
	sizes = 0;
	times = 0;
}
new ParticleEmitterData(LiftoffDustEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 0;
	ejectionOffset = 0;
	thetaMin = 90;
	thetaMax = 90;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	useEmitterColors = 1;
	particles = "LiftoffDust";
}
new DecalData(PlayerFootprint)
{
	sizeX = 1;
	sizeY = 0.25;
	textureName = "~/data/shapes/player/footprint";
}
new DebrisData(PlayerDebris)
{
	explodeOnMaxBounce = "1.0 1.0 1.0 1.0";
	elasticity = 0.15;
	friction = 0.5;
	lifetime = 4;
	lifetimeVariance = 0;
	minSpinSpeed = 40;
	maxSpinSpeed = 600;
	numBounces = 5;
	bounceVariance = 0;
	staticOnMaxBounce = 1;
	gravModifier = 1;
	useRadiusMass = 1;
	baseRadius = 1;
	velocity = 20;
	velocityVariance = 12;
}
new PlayerData(PlayerBody)
{
	renderFirstPerson = 0.8;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	aiAvoidThis = 1;
	minLookAngle = -1.39999997616;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48.0 * 90.0;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90.0;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 2;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	footPuffEmitter = snowballemitter3;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter = 0;
	splashEmitter = 1;
	splashEmitter = 2;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 40;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv = Crossbow;
	maxInv = CrossbowAmmo;
	maxInv = BdNgeanteW;
	maxInv = BdNgeante;
	maxInv = BdNexplosiveW;
	maxInv = BdNexplosive;
	maxInv = rafale;
	maxInv = rafaleAmmo;
	maxInv = griffes;
	maxInv = InvincibleB;
}
new PlayerData(PlayerBody2)
{
	renderFirstPerson = 1;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player2/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player2/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.39999997616;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48.0 * 90.0;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90.0;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter = 0;
	splashEmitter = 1;
	splashEmitter = 2;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv = Crossbow;
	maxInv = CrossbowAmmo;
	maxInv = BdNgeante;
	maxInv = BdNexplosive;
	maxInv = rafale;
	maxInv = rafaleAmmo;
	maxInv = griffes;
	maxInv = InvincibleB;
}
new PlayerData(PlayerBody3)
{
	renderFirstPerson = 1;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player3/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player3/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.39999997616;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48.0 * 90.0;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90.0;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter = 0;
	splashEmitter = 1;
	splashEmitter = 2;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv = Crossbow;
	maxInv = CrossbowAmmo;
	maxInv = BdNgeante;
	maxInv = BdNexplosive;
	maxInv = rafale;
	maxInv = rafaleAmmo;
	maxInv = griffes;
	maxInv = InvincibleB;
}
new PlayerData(PlayerBody4)
{
	renderFirstPerson = 1;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player4/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player4/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.39999997616;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48.0 * 90.0;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90.0;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter = 0;
	splashEmitter = 1;
	splashEmitter = 2;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv = Crossbow;
	maxInv = CrossbowAmmo;
	maxInv = BdNgeante;
	maxInv = BdNexplosive;
	maxInv = rafale;
	maxInv = rafaleAmmo;
	maxInv = griffes;
	maxInv = InvincibleB;
}
new PlayerData(PlayerBodyObserver)
{
	renderFirstPerson = 1;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/deadPlayer/fantome.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player4/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.39999997616;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 1e-07;
	drag = 31;
	maxDrag = 31;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.756;
	runForce = 48.0 * 90.0;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 8.30000019073 * 90.0;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 15;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.2 1.2 2.3";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter = 0;
	splashEmitter = 1;
	splashEmitter = 2;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv = observAmmo;
	maxInv = observ;
}
function armor::onAdd(%this, %obj)
{
	%obj.mountVehicle = 1;
	%obj.setRechargeRate(%this.rechargeRate);
	%obj.setRepairRate(0);
	return 1;
}

function armor::onRemove(%this, %obj)
{
	if (%obj.client.Player == %obj)
	{
		%obj.client.Player = 0;
	}
	return 100;
}

function armor::onNewDataBlock(%this, %obj)
{
	return PlayerBubbleEmitter;
}

function armor::onMount(%this, %obj, %vehicle, %node)
{
	if (%node == 0.0)
	{
		%obj.setTransform("0 0 0 0 0 1 0");
		%obj.setActionThread(%vehicle.getDataBlock().mountPose, 1, 1);
		%obj.lastWeapon = %obj.getMountedImage($WeaponSlot);
		%obj.unmountImage($WeaponSlot);
		%obj.setControlObject(%vehicle);
		%obj.client.setObjectActiveImage(%vehicle, 2);
	}
	return %node;
}

function armor::onUnmount(%this, %obj, %vehicle, %node)
{
	if (%node == 0.0)
	{
		%obj.mountImage(%obj.lastWeapon, $WeaponSlot);
	}
	return PlayerFoamEmitter;
}

function armor::doDismount(%this, %obj, %forced)
{
	if (!%obj.isMounted())
	{
		return PlayerFoamDropletsEmitter;
	}
	%pos = getWords(%obj.getTransform(), 0, 2);
	%oldPos = %pos;
	%vec[0] = " 0  0  1";
	%vec[1] = " 0  0  1";
	%vec[2] = " 0  0 -1";
	%vec[3] = " 1  0  0";
	%vec[4] = "-1  0  0";
	%impulseVec = "0 0 0";
	%vec[0] = MatrixMulVector(%obj.getTransform(), %vec[0]);
	%pos = "0 0 0";
	%numAttempts = 5;
	%success = -1.0;
	%i = 0;
	while(%i < %numAttempts)
	{
		%pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
		if (%obj.checkDismountPoint(%oldPos, %pos))
		{
			%success = %i;
			%impulseVec = %vec[%i];
		}
		else
		{
			%i = %i + 1.0;
		}
	}
	if (%forced && %success == -1.0)
	{
		%pos = %oldPos;
	}
	%obj.mountVehicle = 0;
	%obj.schedule(4000, "mountVehicles", 1);
	%obj.setTransform(%pos);
	%obj.applyImpulse(%pos, VectorScale(%impulseVec, %obj.getDataBlock().mass));
	%obj.setPilot(0);
	%obj.vehicleTurret = "";
	return 1;
}

function armor::onCollision(%this, %obj, %col)
{
	if (%obj.getState() $= "Dead")
	{
		return 20;
	}
	if (%col.getClassName() $= "Item")
	{
		%obj.pickup(%col);
	}
	if (%col.getClassName() $= "AIPlayer" && %obj.lastCollisionPlayer != %col)
	{
		%vec = %obj.getVelocityFromPlayerColl();
		if (%vec != 0.0)
		{
			%col.applyImpulse(getWords(%col.getTransform(), 0, 2), VectorScale(%vec, 1.3));
			%obj.lastCollisionPlayer = %col;
			%obj.schedule(250, removeLastCollisionPlayer, %obj);
		}
	}
	return 1;
}

function Player::removeLastCollisionPlayer(%this, %obj)
{
	%obj.lastCollisionPlayer = "";
	return 1;
}

function armor::onImpact(%this, %obj, %unused_var_2, %vec, %vecLen)
{
	%obj.Damage(0, VectorAdd(%obj.getPosition(), %vec), %vecLen * %this.speedDamageScale, "Impact");
	return 1;
}

function Player::enleverHITinvincible(%this)
{
	if (%this.getSkinName() $= "HITinvincible")
	{
		%this.setSkinName("invincible");
	}
	return 1000;
}

function armor::Damage(%this, %obj, %sourceObject, %unused_var_3, %damage, %damageType)
{
	if (%obj.getState() $= "Dead")
	{
		return 1;
	}
	%obj.applyDamage(%damage);
	%location = "Body";
	%client = %obj.client;
	if (%sourceObject)
	{
	}
	else
	{
	}
	%sourceClient = 0;
	if (%obj.getState() $= "Dead")
	{
		if (%obj.getControllingClient())
		{
			%obj.getControllingClient().onDeath(%sourceObject, %sourceClient, %damageType, %location);
		}
		else
		{
			if (%client && %client.isAIControlled())
			{
				%client.onDeath(%sourceObject, %sourceClient, %damageType, %location);
			}
			else
			{
				%obj.onDeath();
			}
		}
	}
	return %sourceObject.client;
}

function armor::onDamage(%this, %obj, %unused_var_2)
{
	return PlayerBubbleEmitter;
}

function armor::onDisabled(%this, %obj, %unused_var_2)
{
	%obj.playDeathCry();
	%obj.setImageTrigger(0, 0);
	%obj.schedule($CorpseTimeoutValue - 1000.0, "startFade", 1000, 0, 1);
	return PlayerFoamEmitter;
}

function armor::onLeaveMissionArea(%this, %obj)
{
	%obj.client.onLeaveMissionArea();
	return PlayerFoamDropletsEmitter;
}

function armor::onEnterMissionArea(%this, %obj)
{
	%obj.client.onEnterMissionArea();
	return 1;
}

function armor::onEnterLiquid(%this, %obj, %unused_var_2, %type)
{
	if (%type == 0.0)
	{
	}
	else
	{
		if (%type == 1.0)
		{
		}
		else
		{
			if (%type == 2.0)
			{
			}
			else
			{
				if (%type == 3.0)
				{
				}
				else
				{
					if (%type == 4.0)
					{
					}
					else
					{
						if (%type == 5.0)
						{
						}
						else
						{
							if (%type == 6.0)
							{
							}
							else
							{
							}
						}
					}
				}
			}
		}
	}
	return 20;
}

function armor::onLeaveLiquid(%this, %obj, %type)
{
	%obj.clearDamageDt();
	return 1;
}

function armor::onTrigger(%this, %obj, %unused_var_2, %unused_var_3)
{
	return 1;
}

function Player::kill(%this, %damageType)
{
	%this.Damage(0, %this.getPosition(), 10000, %damageType);
	return 1;
}

function Player::playDeathAnimation(%this)
{
	return 1000;
}

function Player::playCelAnimation(%this, %unused_var_1)
{
	return 1;
}

function Player::playDeathCry(%this)
{
	%this.playAudio(2, DeathCrySound);
	return PlayerBubbleEmitter;
}

function Player::playPain(%this)
{
	%this.playAudio(2, PainCrySound);
	return PlayerFoamEmitter;
}

function Player::playReincarnationSound(%this)
{
	%this.playAudio(3, ReincarnationSound);
	return PlayerFoamDropletsEmitter;
}

function Player::playReincarnation(%this)
{
	if (%this.getMountedImage(2))
	{
		%this.unmountImage(ReincarnationImage, 2);
	}
	if (%this.getMountedImage(3))
	{
		%this.unmountImage(ReincarnationImage, 3);
	}
	%this.mountImage(ReincarnationImage, 3);
	%this.schedule(800, "unmountImage", 3);
	%this.reincarnationInvincible = 1;
	%this.schedule(1300, "unReincarnationInvincible");
	if (%this.client && %this.client.isAIControlled())
	{
		spawnExplosion(%this.getTransform(), "0 0 1", 0, "ReincarnationExplosionAI");
	}
	else
	{
		spawnExplosion(%this.getTransform(), "0 0 1", 0, "ReincarnationExplosion");
	}
	if (%this.client)
	{
		if (%this.client.isAIControlled())
		{
			%this.mountImage(PlayerTagAIImage, 7);
		}
		else
		{
			%this.mountImage(PlayerTagImage, 7);
		}
	}
	%this.setActionThread("reincarnation");
	%this.playReincarnationSound();
	return 1;
}

new ParticleData(ReincarnationParticleAI)
{
	textureName = 20;
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 1;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 0;
	useInvAlpha = 1;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors = 0;
	colors = 1;
	sizes = 0;
	sizes = 1;
	times = 0;
	times = 1;
}
new ParticleData(ReincarnationParticle)
{
	textureName = 1;
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 1;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 0;
	useInvAlpha = 1;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors = 0;
	colors = 1;
	sizes = 0;
	sizes = 1;
	times = 0;
	times = 1;
}
new ParticleEmitterData(ReincarnationEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = ReincarnationParticle;
}
new ParticleEmitterData(ReincarnationEmitterAI)
{
	ejectionPeriodMS = 0;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = ReincarnationParticleAI;
}
new ExplosionData(ReincarnationExplosion)
{
	lifetimeMS = 1;
	particleEmitter = ReincarnationEmitter;
	particleDensity = 30;
	particleRadius = 1;
}
new ExplosionData(ReincarnationExplosionAI)
{
	lifetimeMS = 0.3;
	particleEmitter = ReincarnationEmitterAI;
	particleDensity = 30;
	particleRadius = 1;
}
new ShapeBaseImageData(ReincarnationImage)
{
	shapeFile = "1 1 1 0";
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
}
new ShapeBaseImageData(PlayerTagImage)
{
	shapeFile = "1 1 1 1";
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
}
new ShapeBaseImageData(PlayerTagAIImage)
{
	shapeFile = 0;
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
}
new ShapeBaseImageData(CrownImage)
{
	shapeFile = 1;
	firstPerson = 0;
	emap = 1;
	MountPoint = 6;
}
function Player::unReincarnationInvincible(%this)
{
	%this.reincarnationInvincible = 0;
	return 0.3;
}

return "1 1 1 0";
