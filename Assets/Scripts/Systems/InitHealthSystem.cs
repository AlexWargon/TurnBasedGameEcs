using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class InitHealthSystem : OnAdd<Health> {
        private StaticDataService _staticDataService;
        public override void OnInit() {
            _staticDataService = Service<StaticDataService>.Get();
        }

        public override void Execute(in Entity entity) {
            var health = entity.Get<Health>();
            var healthValue = Random.Range(_staticDataService.MinHealth, _staticDataService.MaxHealth);
            health.value = healthValue;
            health.max = healthValue;
        }
    }
}