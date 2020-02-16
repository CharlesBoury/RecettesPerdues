
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Particles : MonoBehaviour
{
    ParticleSystem ps;
    public GameObject gameState;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
    private string parentName;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        parentName = transform.parent.name;
        //ps.trigger.SetCollider(0, gameState.GetComponent<gameState>().getCollider());
    }

    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        gameState.GetComponent<gameState>().ImpactParticle(parentName, numEnter);

        // re-assign the modified particles back into the particle system
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}
