using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class ApplyPoisonDamageSystem : UpdateSystem {

        public override void Update() {
            entities.Each((in PoisonDamageTick tick) => {
                entities.Each((Entity e, Health health, PoisonDamageEvent damaged, View view, HealthBar healthBar) => {
                    health.value -= damaged.value;

                    var prefabs = Service<PrefabsService>.Get();
                    var damagePopup = Pools.ReuseEntity(prefabs.DamagePopup, view.value.transform.position + Vector3.up*2,
                        Constans.DAMAGE_POPUP_ROTATION);

                    damagePopup.Get<DamagePopup>().value.text = damaged.value.ToString();
                    damagePopup.Get<DamagePopup>().value.color = Color.green;
                
                    health.value = Mathf.Clamp(health.value, 0, health.max);
                
                    healthBar.slider.maxValue = health.max;
                    healthBar.slider.value = health.value;
                    healthBar.text.text = $"{health.value}/{health.max}";
                    e.Remove<PoisonDamageEvent>();
                });
            });

        }
    }
}