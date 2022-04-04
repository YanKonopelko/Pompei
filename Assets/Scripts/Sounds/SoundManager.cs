using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // можно сделать топорно с 1 источником звука, но если будет много звуков одновременно то они будут перебивать друг друга, пока придумал так
    public enum SoundType { DEATH = 0, VOLCANO, JUMP };

    private List<AudioSource> source = new List<AudioSource>();
    public int sourceAmount = 3;

    public AudioClip SecretSound;
    public AudioClip DeathSound;
    public AudioClip JumpSound;
    public AudioClip VolcanoSound;

    public static float volume = 0.4f;

    public static SoundManager instance;

    private KeyCode[] secret = new KeyCode[] { KeyCode.I, KeyCode.O, KeyCode.P };
    private int index = 0;

    private void Start()
    {
        volume = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : volume;

        for (int i = 0; i < sourceAmount; i++)
        {
            source.Add(gameObject.AddComponent<AudioSource>());
        }

        if (instance == null)
            instance = this;

        foreach (AudioSource aso in instance.source)
        {
            aso.volume = volume;
        }
    }

    public static void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        foreach (AudioSource aso in instance.source)
        {
            aso.volume = volume;
        }
    }

    public static void PlaySound(SoundType type)
    {
        switch (type)
        {
            case (SoundType.DEATH):
                {
                    PlayLocal(instance.DeathSound);
                    break;
                }
            case (SoundType.VOLCANO):
                {
                    PlayLocal(instance.SecretSound);
                    break;
                }
            case (SoundType.JUMP):
                {
                    PlayLocal(instance.JumpSound);
                    break;
                }
        }
    }

    public static void PlaySound(AudioClip clip)
    {
        PlayLocal(clip);
    }

    // проверка есть ли пустые источники, если есть играть будет оттуда, если нет, играть будет последний независимо от того играет он или нет
    private static void PlayLocal(AudioClip clip)
    {
        for (int i = 0; i < instance.source.Count; i++)
        {
            if (instance.source[i].isPlaying)
                continue;
            instance.source[i].clip = clip;
            instance.source[i].Play();
            return;
        }

        int rand = Random.Range(0, instance.source.Count);
        instance.source[rand].clip = clip;
        instance.source[rand].Play();
    }

    private void Update()
    {
        if (Input.anyKeyDown) {

            if (Input.GetKeyDown(secret[index])) {
                index++;
            }
            else
            {
                if (index != 0)
                    index = 0;
            }

            if (index == secret.Length)
            {
                PlaySound(SecretSound);
                index = 0;
            }
        }
    }

}
