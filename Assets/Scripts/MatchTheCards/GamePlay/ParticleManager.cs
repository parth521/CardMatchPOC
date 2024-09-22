using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles=new List<ParticleSystem>();
    [SerializeField] private LevelActions levelActions;

    private void Awake() {
        StopParticle();
    }
    private void OnEnable()
    {
        levelActions.onLevelComplete+=StartParticle;
    }
    private void OnDisable()
    {
          levelActions.onLevelComplete-=StartParticle;
    }
    public void StartParticle()
    {
        foreach(ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }
    public void StopParticle()
    {
        foreach(ParticleSystem particle in particles)
        {
            particle.Stop();
        }
    }
}
