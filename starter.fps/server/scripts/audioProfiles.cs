new AudioDescription(AudioLoud3d)
{
	volume = "";
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 40;
	maxDistance = 200;
	type = $SimAudioType;
}
new AudioDescription(AudioDefault3d)
{
	volume = "";
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 20;
	maxDistance = 100;
	type = $SimAudioType;
}
new AudioDescription(AudioClose3d)
{
	volume = "";
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 10;
	maxDistance = 60;
	type = $SimAudioType;
}
new AudioDescription(AudioClosest3d)
{
	volume = "";
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 5;
	maxDistance = 30;
	type = $SimAudioType;
}
new AudioDescription(AudioDefaultLooping3d)
{
	volume = "";
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 20;
	maxDistance = 100;
	type = $SimAudioType;
}
new AudioDescription(AudioCloseLooping3d)
{
	volume = "";
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 10;
	maxDistance = 50;
	type = $SimAudioType;
}
new AudioDescription(AudioClosestLooping3d)
{
	volume = "";
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 5;
	maxDistance = 30;
	type = $SimAudioType;
}
new AudioDescription(Audio2D)
{
	volume = "";
	isLooping = 0;
	is3D = 0;
	type = $SimAudioType;
}
new AudioDescription(AudioLooping2D)
{
	volume = "";
	isLooping = 1;
	is3D = 0;
	type = $SimAudioType;
}
new AudioProfile(takeme)
{
	fileName = "";
	description = "AudioDefaultLooping3d";
	preload = 0;
}
