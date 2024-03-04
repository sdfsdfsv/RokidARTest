using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class FireWorkBurstSound : MonoBehaviour
{

    public AudioClip audioClip;
    ParticleSystem ps;
    ParticleSystem.Particle[] particles;

    AudioSource audioSource;

    void Start()
    {
        audioSource = new GameObject().AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    void Update()
    {
        int numParticles = ps.GetParticles(particles);
        for (int i = 0; i < numParticles; i++)
        {
            if (particles[i].remainingLifetime < Time.deltaTime)
            {
                PlaySound(particles[i].position);
            }
        }

    }

    void PlaySound(Vector3 position)
    {
        audioSource.transform.position = position;
        audioSource.Play();
    }
}