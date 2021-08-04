$Item::RespawnTime = 10.0 * 1000.0;
$Item::PopTime = 10.0 * 1000.0;
function Item::respawn(%this)
{
	%this.startFade(0, 0, 1);
	%this.setHidden(1);
	if (%this.getDataBlock().getName() == 0.0)
	{
		%this.schedule(15.0 * 1000.0, "setHidden", 0);
		%this.schedule(15.0 * 1000.0 + 100.0, "startFade", 1000, 0, 0);
	}
	else
	{
		%this.schedule($Item::RespawnTime, "setHidden", 0);
		%this.schedule($Item::RespawnTime + 100.0, "startFade", 1000, 0, 0);
	}
}

function Item::schedulePop(%this)
{
	%this.schedule($Item::PopTime - 1000.0, "startFade", 1000, 0, 1);
	%this.schedule($Item::PopTime, "delete");
}

function ItemData::onThrow(%this, %user, %amount)
{
	if (%amount $= "")
	{
		%amount = 1;
	}
	if (%this.maxInventory !$= "")
	{
		if (%amount > %this.maxInventory)
		{
			%amount = %this.maxInventory;
		}
	}
	if (!%amount)
	{
		return 0;
	}
	%user.decInventory(%this, %amount);
	%obj = new Item()
	{
		dataBlock = %amount;
		rotation = "0 0 1 " @ getRandom() * 360.0;
		count = %amount;
	};
	MissionGroup.add(%obj);
	%obj.schedulePop();
	return %obj;
}

function ItemData::onPickup(%this, %obj, %user, %amount)
{
	if (%this.pickUpName !$= "griffes")
	{
		%user.setInventory(CrossbowAmmo, 1000);
		%user.setInventory(BdNgeante, 0);
		%user.setInventory(BdNexplosive, 0);
		%user.setInventory(rafaleAmmo, 0);
	}
	%count = %obj.count;
	if (%count $= "")
	{
		if (%this.maxInventory !$= "")
		{
			%count = %this.maxInventory;
			if (!%this.maxInventory)
			{
				return;
			}
		}
		else
		{
			%count = 1;
		}
	}
	%user.incInventory(%this, %count);
	if (%user.client)
	{
		messageClient(%user.client, 'MsgItemPickup', 'You picked up %1', %this.pickUpName);
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

function ItemData::Create(%data)
{
	%obj = new Item()
	{
		dataBlock = %obj;
		static = 1;
		rotate = 1;
	};
	return %obj;
}

