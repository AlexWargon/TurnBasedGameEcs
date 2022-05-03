using Wargon.ezs;

namespace TaskGame.Systems {
    public class PlayerParticleOnPoolSystem : UpdateSystem {
        public override void Update() {
            entities.Each((Particle particle, ref PooledEvent pooledEvent) => {
                particle.value.Play();
            });
        }
    }
}