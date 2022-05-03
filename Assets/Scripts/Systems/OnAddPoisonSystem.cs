using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class OnAddPoisonSystem : OnAdd<Poisoned> {
        public override void Execute(in Entity entity) {
            var transform = entity.Get<View>().value.transform;
            Object.Instantiate(Service<PrefabsService>.Get().PoisonEffect, transform.position, Quaternion.identity,
                transform);
        }
    }
}