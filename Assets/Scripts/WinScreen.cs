using TaskGame.Systems;
using TMPro;
using UnityEngine;

public class WinScreen : UIElement {
    [SerializeField] private TextMeshProUGUI contextText;

    public WinScreen SetContext(GameResultType gameResultType) {
        contextText.text = gameResultType switch {
            GameResultType.PlayerWin => "YOU WIN",
            GameResultType.PlayerLose => "YOU LOSE",
            GameResultType.Tie => "TIE",
            _ => contextText.text
        };
        return this;
    }
}
