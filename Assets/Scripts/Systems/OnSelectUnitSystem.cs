using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class OnSelectUnitSystem : OnAdd<SelectedTag> {
        public override void Execute(in Entity entity) {
            entity.Get<View>().value.transform.localScale = Vector3.one * 1.3f;
        }
    }
}