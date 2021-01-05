using UnityEngine;

public class GameManager :MonoBehaviour
{
    [SerializeField] CanvasManager m_CanvasManager;
    [SerializeField] ArmiesManager m_ArmiesManager;

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        m_ArmiesManager.Init();
        ShuffleTeam(ArmySide.Blue);
        ShuffleTeam(ArmySide.Red);
    }

    public void StartGame()
    {
        m_CanvasManager.StartGameUI();
        m_ArmiesManager.Activate();
    }

    public void ShuffleTeam(ArmySide armySide)
    {
        m_ArmiesManager.ReshuffleTeam(armySide);
    }

    //refereneced in the canvas buttons
    public void ShuffleTeamUI(int armySide)
    {
        ShuffleTeam((ArmySide)armySide);
    }

    public void GameOver(ArmySide armySide)
    {
        CanvasManager.DisplayWinner(armySide);
        CleanGame();
        InitGame();
    }

    void CleanGame()
    {
        m_ArmiesManager.CleanUP();
    }

    public CanvasManager CanvasManager { get => m_CanvasManager; set => m_CanvasManager = value; }
    public ArmiesManager ArmiesManager { get => m_ArmiesManager; set => m_ArmiesManager = value; }
}
