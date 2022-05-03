using Wargon.ezs;

namespace TaskGame.Systems {
    public class InitHealthBarSystem : OnAdd<HealthBar> {
        public override void Execute(in Entity entity) {
            var health = entity.Get<Health>();
            entity.Get<HealthBar>().text.text = $"{health.value}/{health.max}";
        }
    }
}