using DG.Tweening;
using UnityEngine;

public static class AudioSourceExtensions
{
    public static AudioSource FadeSoundOut(this AudioSource aSource, float delay, float duration, float to = 0f)
    {
        DOTween.To(() => aSource.volume, x => aSource.volume = x, to, duration).SetDelay(delay);
        return aSource;
    }

    public static AudioSource FadeSoundIn(this AudioSource aSource, float delay, float duration, float from = 0f)
    {
        DOTween.To(() => aSource.volume, x => aSource.volume = x, from, duration).From().SetDelay(delay);
        return aSource;
    }

    //public static void FadeMusicOut(this EventInstance instance, float duration)
    //{
    //    DOTween.To(() => { float ret; instance.getVolume(out ret); return ret; }, x => instance.setVolume(x), 0f, duration).OnComplete(() =>
    //    {
    //        instance.stop(STOP_MODE.ALLOWFADEOUT);
    //    });
    //}

    //public static void FadeMusicIn(this EventInstance instance, float duration)
    //{
    //    instance.setVolume(0f);
    //    instance.start();
    //    DOTween.To(() => { float ret; instance.getVolume(out ret); return ret; }, x => instance.setVolume(x), 1f, duration);
    //}

    public static AudioSource Skip(this AudioSource aSource, float seconds)
    {
        aSource.time = seconds;
        //aSource.timeSamples += (int)seconds * 100000;
        return aSource;
    }

    public static AudioSource SetVolume(this AudioSource aSource, float volume)
    {
        aSource.volume = volume;
        return aSource;
    }

    public static AudioSource RandomizePitch(this AudioSource aSource, float low = 0.6f, float high = 1.5f)
    {
        aSource.pitch = Random.Range(low, high);
        return aSource;
    }

    public static AudioSource SetPitch(this AudioSource aSource, float pitch = 1f)
    {
        aSource.pitch = pitch;
        return aSource;
    }
}
