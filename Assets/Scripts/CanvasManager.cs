using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Sprite m_BlueTeamSprite;
    [SerializeField] Sprite m_RedTeamSprite;
    [SerializeField] Image m_WinnerImage;
    [SerializeField] GameObject m_StartButton;
    [SerializeField] GameObject m_ShuffleButtonBlue;
    [SerializeField] GameObject m_ShuffleButtonRed;

    public void StartGameUI()
    {
        ShowUIEelements(false);
    }

    public void DisplayWinner(ArmySide armySide)
    {
        if (armySide == ArmySide.Blue)
        {
            WinnerImage.sprite = BlueTeamSprite;
        }
        else
        {
            WinnerImage.sprite = RedTeamSprite;
        }
        ShowUIEelements(true);
    }

    void ShowUIEelements(bool x)
    {
        WinnerImage.gameObject.SetActive(x);
        StartButton.SetActive(x);
        ShuffleButtonBlue.SetActive(x);
        ShuffleButtonRed.SetActive(x);
    }

    public Sprite BlueTeamSprite { get => m_BlueTeamSprite; set => m_BlueTeamSprite = value; }
    public Sprite RedTeamSprite { get => m_RedTeamSprite; set => m_RedTeamSprite = value; }
    public Image WinnerImage { get => m_WinnerImage; set => m_WinnerImage = value; }
    public GameObject StartButton { get => m_StartButton; set => m_StartButton = value; }
    public GameObject ShuffleButtonBlue { get => m_ShuffleButtonBlue; set => m_ShuffleButtonBlue = value; }
    public GameObject ShuffleButtonRed { get => m_ShuffleButtonRed; set => m_ShuffleButtonRed = value; }
}
