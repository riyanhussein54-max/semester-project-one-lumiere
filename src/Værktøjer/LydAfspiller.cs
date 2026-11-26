using System;
using System.IO;
using System.Linq;
using SoundFlow.Abstracts;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Components;
using SoundFlow.Providers;
using SoundFlow.Structs;
using SoundFlow.Abstracts.Devices;

public class LydAfspiller : IDisposable
{
    private readonly MiniAudioEngine _engine;
    private readonly AudioPlaybackDevice _outputDevice;

    private SoundPlayer? _player;
    private StreamDataProvider? _provider;
    private FileStream? _fileStream;

    private string? _aktuelLyd;

    public LydAfspiller()
    {
        _engine = new MiniAudioEngine();

        var defaultDevice = _engine.PlaybackDevices
        .FirstOrDefault(x => x.IsDefault);

        _outputDevice = _engine.InitializePlaybackDevice(
            defaultDevice, AudioFormat.Dvd);

        _outputDevice.Start();
    }
    public void Afspil(string filsti)
    {
        if (!File.Exists(filsti))
            throw new FileNotFoundException("Lydfilen blev ikke fundet.", filsti);

        Stop();

        _fileStream = File.OpenRead(filsti);
        _provider = new StreamDataProvider(_engine, _fileStream);

        _player = new SoundPlayer(_engine, _outputDevice.Format, _provider);
        _player.IsLooping = true;
        _outputDevice.MasterMixer.AddComponent(_player);

        _player.Play();

        _aktuelLyd = filsti;
    }

    public void SkiftLyd(string filsti)
    {
        if (_aktuelLyd == filsti && _player != null)
            return;

        Afspil(filsti);
    }
    public void Stop()
    {
        if (_player != null)
        {
            _player.Stop();
            _outputDevice.MasterMixer.RemoveComponent(_player);
            _player.Dispose();
            _player = null;
        }

        _provider?.Dispose();
        _provider = null;

        _fileStream?.Dispose();
        _fileStream = null;

        _aktuelLyd = null;
    }
    public void Dispose()
    {
        Stop();

        _outputDevice.Stop();
        _outputDevice.Dispose();

        _engine.Dispose();
    }
}
