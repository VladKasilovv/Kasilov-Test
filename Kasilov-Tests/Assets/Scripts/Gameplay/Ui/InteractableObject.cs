using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

namespace Gameplay.Ui
{
    public class InteractableObject : MonoBehaviour
    {
        private GameObject _interactWidnow;
        private GameObject _interactBtns;
        
        private Button[] _buttons;
        private Animator _modelAnimator;
        private MeshRenderer _modelRenderer;
        
        private const int _animationsCount = 2;
        private const int _actionsCount = 2;
        
        private bool _objectHit = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            if (other.CompareTag("Player"))
            {
                _objectHit = true;
                _interactWidnow.SetActive(true);

                for (int i = 0; i < _buttons.Length; ++i)
                {
                    if (_buttons[i].name.Contains("Animation"))
                    {
                        _buttons[i].onClick.AddListener(RunAnimation);
                    }
                    if (_buttons[i].name.Contains("Color"))
                    {
                        _buttons[i].onClick.AddListener(ChangeColor);
                    }
                    if (_buttons[i].name.Contains("Random"))
                    {
                        _buttons[i].onClick.AddListener(RandomAction);
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                for(var i = 0; i < _buttons.Length; ++i)
                    _buttons[i].onClick.RemoveAllListeners();
                _interactWidnow.SetActive(false);
            }
        }
        
        private void Start()
        {
            var model = transform.parent.Find("Model");
            _modelRenderer = model.GetComponent<MeshRenderer>();
            _modelAnimator = model.GetComponent<Animator>();
            
            var canvasInteract = GameObject.Find("CanvasInteract");
            var canvasBtns = GameObject.Find("CanvasBtns");

            _interactWidnow = canvasInteract.transform.Find("InteractWindow").gameObject;
            _interactBtns = canvasBtns.transform.Find("InteractBtn").gameObject;
            
            _buttons = _interactBtns.GetComponentsInChildren<Button>();
        }

        private void Update()
        {
            if (_objectHit && Input.GetKeyDown(KeyCode.E))
            {
                _objectHit = false;
                
                _interactBtns.SetActive(true);
                _interactWidnow.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                _objectHit = true;
                
                _interactBtns.SetActive(false);
                _interactWidnow.SetActive(true);
            
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
        private void ChangeColor()
        {
            _modelRenderer.material.color = RandomColor();
        }

        private Color RandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }
        
        private void RunAnimation()
        {
            switch(Random.Range(0, _animationsCount))
            {
                case 0: 
                    _modelAnimator.SetTrigger("Jump");
                    break;
                case 1:
                    _modelAnimator.SetTrigger("Rotate");
                    break;
            }
        }

        private void RandomAction()
        {
            switch (Random.Range(0, _actionsCount))
            {
                case 0:
                    RunAnimation();
                    break;
                case 1:
                    ChangeColor();
                    break;
            }
        }
    }
}