using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NeedHelp : MonoBehaviour
{

    public HelpVisuals Help;
    public GameObject _particle;
    public static NeedHelp Instance;
    GameObject canvas, hurtChar,helper;
    HelpVisuals instance;
    bool canSave;
    public bool saving;
    float timeToSave = 2f,timeTry = 0f;
    public float alturaPersonagens;
    Animator anim;

	public GameObject Texto;

    void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        Instance = this;
        _particle.SetActive(false);
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
		if (InputManager.players == 2) {
			if (helper.tag == "Player2") {
				if ((Input.GetKeyDown (KeyCode.Joystick2Button3) || Input.GetKeyDown (KeyCode.Keypad8)) && canSave)
					saving = true;
				if ((Input.GetKeyUp (KeyCode.Joystick2Button3) || Input.GetKeyUp (KeyCode.Keypad8)) || !canSave)
					saving = false;
			}
		} else {
			if ((Input.GetKeyDown(KeyCode.Joystick1Button3)  || Input.GetKeyDown (KeyCode.I)) && canSave)
				saving = true;
			if ((Input.GetKeyUp (KeyCode.Joystick1Button3) || Input.GetKeyUp (KeyCode.I)) || !canSave)
				saving = false;
		}
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
        Vector3 positionHurted = new Vector3(_hurted.transform.position.x, _hurted.transform.position.y + alturaPersonagens, _hurted.transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(positionHurted);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        _particle.SetActive(true);
        //KeepButtonsOnHurtedChar();
        if (hurtChar != null)
        {
			StartCoroutine (CallGameOver ());
        }
        else
        {
            hurtChar = _hurted;
            anim = hurtChar.GetComponent<Animator>();
            anim.SetBool("Hurt", true);
			if (hurtChar.tag == "Player1")
				hurtChar.GetComponent<FSM_Camponesa> ().enabled = false;
			else if (hurtChar.tag == "Player2")
				hurtChar.GetComponent<FSM_Turnip> ().enabled = false;
        }
        defineHurtedAndHelper();
    }
    void KeepButtonsOnHurtedChar()
    {
        Vector3 positionHurted = new Vector3(hurtChar.transform.position.x, hurtChar.transform.position.y + alturaPersonagens, hurtChar.transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(positionHurted);
        instance.transform.position = screenPosition;
        _particle.transform.position = positionHurted;
    }
    void defineHurtedAndHelper()
    {
        if (hurtChar.CompareTag("Player1")) helper = GameObject.Find("PlayerTurnip");
        else helper = GameObject.Find("PlayerCamponesa");
    }
    void checkDistanceBetweenPlayers()
    {
		if (Vector3.Distance (helper.transform.position, hurtChar.transform.position) <= 1.5f) {
			canSave = true;
			Texto.SetActive (true);
		} else {
			canSave = false;
			Texto.SetActive (false);
		}
    }
    void savingHurtedChar()
    {
        if(canSave && saving) timeTry += Time.deltaTime;
        else timeTry = 0;
        instance.Bar.fillAmount = ((timeTry * 5f) / (timeToSave * 5f));
    }
    public void CharSaved()
    {
        hurtChar.GetComponent<PlayersDamangeHandler>().HP = 50;
        anim.SetBool("Hurt", false);
        _particle.SetActive(false);
		Texto.SetActive (false);
        hurtChar = null;
        helper = null;
        timeTry = 0;
    }

	IEnumerator CallGameOver(){

		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (9);

	}
}
