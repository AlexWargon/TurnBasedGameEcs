using Wargon.ezs;

namespace TaskGame.Systems {
    public class DestroyUnitSystem : UpdateSystem {
        public override void Update() {
            entities.Each((in UnitsDeathTick turnEnd) => {
                entities.Each((Entity entity, Health health) => {
                    if (health.value <= 0) {
                        entity.Set<DestroyUnitEvent>();
                    }
                });
            });
        }
    }
}