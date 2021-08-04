new StaticShapeData(AnimatedIceCube)
{
	category = "";
	shapeFile = "~/data/shapes/decors/animatedcube.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function AnimatedIceCube::onAdd(%unused_var_0, %obj)
{
	%obj.touche = 1;
}

new StaticShapeData(AnimatedIceCube2)
{
	category = "";
	shapeFile = "~/data/shapes/decors/animatedcube2.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function AnimatedIceCube2::onAdd(%unused_var_0, %obj)
{
	%obj.touche = 1;
}

new StaticShapeData(AnimatedIceCube3)
{
	category = "";
	shapeFile = "~/data/shapes/decors/animatedcube3.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
}
function AnimatedIceCube3::onAdd(%unused_var_0, %obj)
{
	%obj.touche = 1;
}

function ExplosionCube(%obj)
{
	if (%obj.touche == 1.0)
	{
		%obj.touche = 2;
		%obj.playThread(0, "hit");
	}
	else
	{
		if (%obj.touche == 2.0)
		{
			%obj.playThread(0, "fall");
			%obj.schedule(3000, "delete");
		}
	}
}

