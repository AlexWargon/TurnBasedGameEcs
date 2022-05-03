using Wargon.ezs;

public class UnselectUnitSystem : UpdateSystem {
    public override void Update() {
        entities.Each((in PoisonDamageTick tick) => {
            entities.Each((Entity e, in SelectedTag tag)=>{ e.Remove<SelectedTag>();});
        });
    }
}