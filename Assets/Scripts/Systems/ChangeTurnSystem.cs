using Wargon.ezs;

namespace TaskGame.Systems {
    public class ChangeTurnSystem : OnAdd<TurnChangeTick> {
        public override void Execute(in Entity _) {
            var runTime = Service<GameRunTimeData>.Get();
            entities.Each((CurrentGameTick tick) => {
                switch (runTime.CurentSide) {
                    case SideTurn.Player:
                        runTime.CurentSide = SideTurn.Bot;
                        world.CreateEntity().Add(new BotTurn());
                        break;
                    case SideTurn.Bot:
                        runTime.CurentSide = SideTurn.Player;
                        entities.Each((Entity entity,in BotTurn botTurn)=> entity.Remove<BotTurn>());
                        break;
                }
                entities.Each((Entity entity, ref SelectedTag selectedTag) => entity.Remove<SelectedTag>());
            });

        }
    }

}