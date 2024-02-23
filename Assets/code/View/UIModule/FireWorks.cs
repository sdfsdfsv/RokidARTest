using UnityEngine;

public class FireWorks : MonoBehaviour
{
    public ParticleSystem particle;
    
    void Start()
    {
        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
        }
    }

    public float probablity = 0.5f;

    public float minEmissionInterval = 0.2f;

    private float lastEmissionTime = 0f;
    void Update() {
        
        
        float interval = Time.time-lastEmissionTime;
        if(interval<minEmissionInterval)return;

        if (Random.Range(0.0f, 1.0f)<probablity){
            this.transform.localPosition = new Vector3(Random.Range(-300f,300f),Random.Range(-200f,200f),0f);
            BurstParticles();
            lastEmissionTime = Time.time;    
        }    
        
    }
    
    void BurstParticles()
    {
        var burstCount = Random.Range(10, 100); // Random number of particles
        var particleBurst = particle.emission.GetBurst(0);
        // Finally, start the particle system
        particle.Play();
    }
}