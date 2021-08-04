function array_echo(%array)
{
	echo("-- array_echo --");
	%i = 0;
	while(%i < %array.count)
	{
		echo("array_echo" SPC %array[%i]);
		%i = %i + 1.0;
	}
}

function array_tozero(%array)
{
	%i = 0;
	while(%i < %array.count)
	{
		%array[%i] = 0;
		%i = %i + 1.0;
	}
}

function array_shift(%array)
{
	%i = 0;
	while(%i < %array.count - 1.0)
	{
		%array[%i] = %array[%i + 1.0];
		%i = %i + 1.0;
	}
	%array[%array.count - 1.0] = 0;
	return %array;
}

