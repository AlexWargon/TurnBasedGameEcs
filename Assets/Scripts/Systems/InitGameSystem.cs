using Wargon.ezs;

namespace TaskGame.Systems { 
    public sealed class InitGameSystem : InitSystem {
    public override void Execute() {
        Service<GameRunTimeData>.Get().CurentSide = SideTurn.Player;
        world.CreateEntity().Add(new CurrentGameTick());
    }
}}

