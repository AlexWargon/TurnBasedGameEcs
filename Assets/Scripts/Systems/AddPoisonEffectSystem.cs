using Wargon.ezs;

namespace TaskGame.Systems {
    public class AddPoisonEffectSystem : UpdateSystem {
        public override void Update() {
            entities.Without<Poisoned>().Each((Entity entity, ClickedEvent clickedTag) => {
                entities.Each((SelectedTag selectedTag, PoisonAbility poisonAbility) => {
                    entity.Get<Poisoned>().damage = poisonAbility.damage;
                });    
            });
        }
    }

    public class PoisonDamageSystem : UpdateSystem {
        public override void Update() {
            entities.Each((in PoisonDamageTick tick) => {
                entities.Each((Entity entity, Poisoned poisoned) => {
                    entity.Get<PoisonDamageEvent>().value = poisoned.damage;
                });
            });
        }
    }
}