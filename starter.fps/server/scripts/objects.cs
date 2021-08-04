new ShapeBaseImageData(TopObjectData1)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData2)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData3)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData4)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData5)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData6)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData7)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData8)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData9)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData10)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData11)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData12)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(TopObjectData13)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
}
new ShapeBaseImageData(BottomObjectData1)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
new ShapeBaseImageData(BottomObjectData2)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
new ShapeBaseImageData(BottomObjectData3)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
new ShapeBaseImageData(BottomObjectData4)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
new ShapeBaseImageData(BottomObjectData5)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
new ShapeBaseImageData(BottomObjectData6)
{
	shapeFile = "";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
}
function serverCmdMountDecoObjects(%client, %place, %numeroObjet)
{
	if (%client.Player)
	{
		if (%place $= "top")
		{
			eval("%client.player.mountImage(TopObjectData" @ %numeroObjet @ ",4);");
		}
		else
		{
			if (%place $= "bottom")
			{
				eval("%client.player.mountImage(BottomObjectData" @ %numeroObjet @ ",5);");
			}
		}
	}
}

