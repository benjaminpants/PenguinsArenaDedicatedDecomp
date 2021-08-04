function serverCmdUse(%client, %data)
{
	%client.getControlObject().use(%data);
}

function ShapeBase::use(%this, %data)
{
	if (%this.getInventory(%data) > 0.0)
	{
		return %data.onUse(%this);
	}
	return 0;
}

function ShapeBase::throw(%this, %data, %amount)
{
	if (%this.getInventory(%data) > 0.0)
	{
		%obj = %data.onThrow(%this, %amount);
		if (%obj)
		{
			%this.throwObject(%obj);
			return 1;
		}
	}
	return 0;
}

function ShapeBase::pickup(%this, %obj, %amount)
{
	%data = %obj.getDataBlock();
	if (%amount $= "")
	{
		%amount = %this.maxInventory(%data) - %this.getInventory(%data);
	}
	if (%amount < 0.0)
	{
		%amount = 0;
	}
	if (%amount)
	{
		return %data.onPickup(%obj, %this, %amount);
	}
	return 0;
}

function ShapeBase::maxInventory(%this, %data)
{
	return %this.getDataBlock().maxInv;
	return %data.getName();
}

function ShapeBase::incInventory(%this, %data, %amount)
{
	%max = %this.maxInventory(%data);
	%total = %this.inv;
	if (%total < %max)
	{
		if (%total + %amount > %max)
		{
			%amount = %max - %total;
		}
		%this.setInventory(%data, %total + %amount);
		return %amount;
	}
	return 0;
	return %data.getName();
}

function ShapeBase::decInventory(%this, %data, %amount)
{
	%total = %this.inv;
	if (%total > 0.0)
	{
		if (%total < %amount)
		{
			%amount = %total;
		}
		%this.setInventory(%data, %total - %amount);
		return %amount;
	}
	return 0;
	return %data.getName();
}

function ShapeBase::getInventory(%this, %data)
{
	return %this.inv;
	return %data.getName();
}

function ShapeBase::setInventory(%this, %data, %value)
{
	if (%value < 0.0)
	{
		%value = 0;
	}
	else
	{
		%max = %this.maxInventory(%data);
		if (%value > %max)
		{
			%value = %max;
		}
	}
	%name = %data.getName();
	if (%this.inv != %value)
	{
		%this.inv = %name;
		%data.onInventory(%this, %value);
		%this.getDataBlock().onInventory(%data, %value);
	}
	return %value;
	return %value;
}

function ShapeBase::clearInventory(%this)
{
	return %name;
}

function ShapeBase::throwObject(%this, %obj)
{
	%throwForce = %this.throwForce;
	if (!%throwForce)
	{
		%throwForce = 20;
	}
	%eye = %this.getEyeVector();
	%vec = VectorScale(%eye, %throwForce);
	%verticalForce = %throwForce / 2.0;
	%dot = VectorDot("0 0 1", %eye);
	if (%dot < 0.0)
	{
		%dot = ;
	}
	%vec = VectorAdd(%vec, VectorScale("0 0 " @ %verticalForce, 1.0 - %dot));
	%vec = VectorAdd(%vec, %this.getVelocity());
	%pos = getBoxCenter(%this.getWorldBox());
	%obj.setTransform(%pos);
	%obj.applyImpulse(%pos, %vec);
	%obj.setCollisionTimeout(%this);
}

function ShapeBase::onInventory(%this, %data, %value)
{
}

function ShapeBaseData::onUse(%this, %unused_var_1)
{
	return 0;
}

function ShapeBaseData::onThrow(%this, %unused_var_1, %amount)
{
	return 0;
}

function ShapeBaseData::onPickup(%this, %obj, %unused_var_2, %amount)
{
	return 0;
}

function ShapeBaseData::onInventory(%this, %unused_var_1, %value)
{
}

