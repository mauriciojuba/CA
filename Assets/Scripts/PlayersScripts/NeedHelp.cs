using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeedHelp : MonoBehaviour
{

    public HelpVisuals Help;
    public static NeedHelp Instance;
    GameObject canvas, hurtChar,helper;
    HelpVisuals instance;
    bool canSave, saving;
    float timeToSave = 2f,timeTry = 0f;
    public float alturaPersonagens;



    void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        Instance = this;
    }
    void Start()
    {
        Initialize();
    }
    void Update()
    {
        if (hurtChar != null)
        {
            KeepButtonsOnHurtedChar();
            savingHurtedChar();
        }
        if (Input.GetKeyDown(KeyCode.I) && canSave) saving = true;
        if (Input.GetKeyUp(KeyCode.I) || !canSave) saving = false;

    }
    void FixedUpdate()
    {
        if (hurtChar != null)
        {
            checkDistanceBetweenPlayers();
        }
    }
    public void CreateHelpSign(GameObject _hurted)
    {
        instance = Instantiate(Help);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(new Vector3(_hurted.transform.position.x, _hurted.transform.position.y+alturaPersonagens, _hurted.transform.position.z));
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition; 
        //KeepButtonsOnHurtedChar();
        if (hurtChar != null)
        {
            //gameover
        }
        else
        {
            hurtChar = _hurted;
            //PAROLI ===>  hurtChar tem que perder o controle(não conseguir se mexer)
        }
        defineHurtedAndHelper();
    }
    void KeepButtonsOnHurtedChar()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(new Vector3(hurtChar.transform.position.x, hurtChar.transform.position.y+alturaPersonagens, hurtChar.transform.position.z));
        instance.transform.position = screenPosition;
    }
    void defineHurtedAndHelper()
    {
        if (hurtChar.CompareTag("Player1")) helper = GameObject.Find("PlayerTurnip");
        else helper = GameObject.Find("PlayerCamponesa");
    }
    void checkDistanceBetweenPlayers()
    {
        if (Vector3.Distance(helper.transform.position, hurtChar.transform.position) <= 1.5f)
        {
            canSave = true;
        }
        else canSave = false;
    }
    void savingHurtedChar()
    {
        Debug.Log(timeTry);
        if(canSave && saving) timeTry += Time.deltaTime;
        else timeTry = 0;
        instance.Bar.fillAmount = ((timeTry * 5f) / (timeToSave * 5f));
    }
    public void CharSaved()
    {
        hurtChar = null;
        helper = null;
        timeTry = 0;
    }
}
