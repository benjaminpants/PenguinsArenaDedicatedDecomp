new ParticleData(ChimneyFire1)
{
	textureName = "";
	dragCoefficient = 0;
	gravityCoefficient = -0.10000000149;
	inheritedVelFactor = 0;
	lifetimeMS = 2000;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -20.0;
	spinRandomMax = 20;
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
new ParticleEmitterData(ChimneyFireEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 10;
	ejectionVelocity = 0.15;
	velocityVariance = 0.05;
	thetaMin = 3;
	thetaMax = 90;
	particles = "ChimneyFire1";
}
new ParticleEmitterNodeData(ChimneyFireEmitterNode)
{
	timeMultiple = 0.2;
}
return 0;
