new StaticShapeData(plateform)
{
	category = "";
	shapeFile = "~/data/shapes/decors/plateform.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
}
function plateform::onAdd(%unused_var_0, %unused_var_1)
{
}

new ParticleData(plateformParticles)
{
	textureName = "";
	gravityCoefficient = -0.25;
	lifetimeMS = 10000;
	lifetimeVarianceMS = 1000;
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
}
new ParticleEmitterData(plateformEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 1;
	thetaMin = 10;
	thetaMax = 20;
	particles = plateformParticles;
}
return 0.5;
