new StaticShapeData(geyser1)
{
	category = "";
	shapeFile = "~/data/shapes/decors/geyser1.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function geyser1::onAdd(%unused_var_0, %obj)
{
	%obj.playThread(0, "idle");
}

new ParticleEmitterNodeData(DefaultEmitterNode)
{
	timeMultiple = "";
}
new ParticleData(geyserParticles1)
{
	textureName = "";
	dragCoeffiecient = 10;
	gravityCoefficient = 0.5;
	inheritedVelFactor = 0.25;
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
new ParticleEmitterData(geyserEmitter1)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 3;
	thetaMin = 0;
	thetaMax = 90;
	particles = geyserParticles1;
}
new ParticleData(geyserParticles2)
{
	textureName = 0.5;
	dragCoeffiecient = 10;
	gravityCoefficient = 3;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 2000;
	lifetimeVarianceMS = 500;
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
new ParticleEmitterData(geyserEmitter2)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 35;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 5;
	particles = geyserParticles2;
}
new ParticleData(geyserParticles3)
{
	textureName = 0.5;
	dragCoeffiecient = 10;
	gravityCoefficient = 3;
	inheritedVelFactor = 0.25;
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
new ParticleEmitterData(geyserEmitter3)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 20;
	velocityVariance = 0.1;
	thetaMin = 10;
	thetaMax = 20;
	particles = geyserParticles3;
}
new ParticleData(geyserParticles4)
{
	textureName = 0.5;
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0.25;
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
new ParticleEmitterData(geyserEmitter4)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 3;
	thetaMin = 10;
	thetaMax = 20;
	particles = geyserParticles4;
}
return 0.5;
