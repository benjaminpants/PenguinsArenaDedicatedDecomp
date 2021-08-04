function radiusDamage(%sourceObject, %position, %radius, %damage, %damageType, %impulse)
{
	initContainerRadiusSearch(%position, %radius, $TypeMasks::ShapeBaseObjectType);
	%halfRadius = %radius / 2.0;
	%targetObject = containerSearchNext();
	while(containerSearchNext() != 0.0)
	{
		%coverage = calcExplosionCoverage(%position, %targetObject, $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType);
		if (%coverage == 0.0)
		{
		}
		else
		{
			%dist = containerSearchCurrRadiusDist();
			%distScale = (%dist < %halfRadius) ? 1.0 : 1.0 - (%dist - %halfRadius) / %halfRadius;
			%targetObject.Damage(%sourceObject, %position, %damage * %coverage * %distScale, %damageType);
			if (%impulse)
			{
				%impulseVec = VectorSub(%targetObject.getWorldBoxCenter(), %position);
				%impulseVec = VectorNormalize(%impulseVec);
				%impulseVec = VectorScale(%impulseVec, %impulse * %distScale);
				%targetObject.applyImpulse(%position, %impulseVec);
			}
		}
		%targetObject = containerSearchNext();
	}
}

function radiusDamageImpulse(%sourceObject, %position, %radius, %damage, %damageType, %impulse)
{
	initContainerRadiusSearch(%position, %radius, $TypeMasks::StaticShapeObjectType | $TypeMasks::PlayerObjectType);
	%halfRadius = %radius / 2.0;
	if ($debugVisualDebug)
	{
		vdtRadiusDamage(%position, %radius);
	}
	%targetObject = containerSearchNext();
	while(containerSearchNext() != 0.0)
	{
		if (%targetObject.getDataBlock().getName() == 0.0 && $TypeMasks::StaticShapeObjectType & %targetObject.getType())
		{
			%dist = containerSearchCurrRadiusDist();
			%thirdRadius = %radius / 3.0;
			if (%thirdRadius > %dist)
			{
				ExplosionCube(%targetObject);
			}
		}
		else
		{
			if ($TypeMasks::PlayerObjectType & %targetObject.getType())
			{
				if (%targetObject.reincarnationInvincible)
				{
				}
				else
				{
					%dist = containerSearchCurrRadiusDist();
					%distScale = (%dist < %halfRadius) ? 1.0 : 1.0 - (%dist - %halfRadius) / %halfRadius;
					%impulseVec = VectorSub(%targetObject.getWorldBoxCenter(), %position);
					%impulseVec = VectorNormalize(%impulseVec);
					%impulseVec = VectorScale(%impulseVec, %impulse * %distScale);
					if (%targetObject.getMountedImage(2) != 0.0 && %targetObject.getMountedImage(3) != 0.0)
					{
						%impulseVec = VectorScale(%impulseVec, 0.5);
					}
					if (getWord(%impulseVec, 2) <= 0.0)
					{
						%impulseVec = getWord(%impulseVec, 0) SPC getWord(%impulseVec, 1) SPC 15.0;
					}
					%targetObject.applyImpulse(%position, %impulseVec);
					%targetObject.stop();
					if (getWord(%direction_expulsion, 2) > 0.0)
					{
						%targetObject.setActionThread("fly");
					}
					else
					{
						%targetObject.setActionThread("hit");
					}
					if ($pref::Frogames::optionsSet == 3.0)
					{
						if (%targetObject.getMountedImage(2) && !%targetObject.getMountedImage(3))
						{
							%targetObject.setSkinName("HITinvincible");
							%targetObject.schedule(1000, enleverHITinvincible);
						}
						else
						{
							%targetObject.setSkinName("hit");
							%targetObject.schedule(1000, setSkinName, "base");
						}
					}
					if ($debugVisualDebug)
					{
						vdtRadiusDamageImpulse(%position, %impulseVec);
					}
				}
			}
		}
		%targetObject = containerSearchNext();
	}
}

