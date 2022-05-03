using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class BonusDamageSystem : UpdateSystem {
        public override void Update() {
            entities.Each((DamagedEvent damagedTag, Poisoned poisoned) => {
                entities.Each((SelectedTag selectedTag, BonusDamage bonusDamage) => {
                    var bonusDamageValue = damagedTag.value * bonusDamage.valueInPersent / 100;
                    damagedTag.value += bonusDamageValue;
                });    
            });
        }
    }
}