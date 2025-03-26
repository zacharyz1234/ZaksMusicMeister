//The player class handles audio playback
using NAudio.Wave;

public static class Player
{
    //Implements audio playback from a file location
    public static void PlayAudioFile()
    {
        string file = @"C:\MusicMeister\Panama_Van-Halen.mp3";

        //Load the audio file and select an output device
        using var audioFile = new AudioFileReader(file);
        using var outputDevice = new WaveOutEvent();

        outputDevice.Init(audioFile);
        outputDevice.Play();

        //Sleep until playback is finished
        while(outputDevice.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1000);
        }
    }
}