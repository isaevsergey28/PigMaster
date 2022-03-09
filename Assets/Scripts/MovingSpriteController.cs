using UnityEngine;

public enum SpriteDirection
{
    Left,
    Right,
    Up,
    Down
}

public class MovingSpriteController : MonoBehaviour
{
    // создать скриптабл с 8 спрайтами 4 чистые 4 в грязи и менять в зависимости от игры
    [SerializeField] private Sprite _rightMove;
    [SerializeField] private Sprite _leftMove;
    [SerializeField] private Sprite _upMove;
    [SerializeField] private Sprite _downMove;
    [SerializeField] private BoxCollider2D _boxCollider;

    private Vector2 _horizontalColliderSize;
    private Vector2 _verticalColliderSize;
    private SpriteRenderer _currentSprite;
    
    private void Start()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
        _horizontalColliderSize = new Vector2(5, 3);
        _verticalColliderSize = new Vector2(3, 5);
    }

    public bool IsLeftSpriteActive()
    {
        return _currentSprite.sprite == _leftMove;
    }
    
    public bool IsRightSpriteActive()
    {
        return _currentSprite.sprite == _rightMove;
    }
    
    public bool IsUpSpriteActive()
    {
        return _currentSprite.sprite == _upMove;
    }
    
    public bool IsDownSpriteActive()
    {
        return _currentSprite.sprite == _downMove;
    }
    
    public void ChangeSprite(SpriteDirection spriteDirection)
    {
        switch (spriteDirection)
        {
            case SpriteDirection.Left:
                _currentSprite.sprite = _leftMove;
                _boxCollider.size = _horizontalColliderSize;
                break;
            case SpriteDirection.Right:
                _currentSprite.sprite = _rightMove;
                _boxCollider.size = _horizontalColliderSize;
                break;
            case SpriteDirection.Down:
                _currentSprite.sprite = _downMove;
                _boxCollider.size = _verticalColliderSize;
                break;
            case SpriteDirection.Up:
                _currentSprite.sprite = _upMove;
                _boxCollider.size = _verticalColliderSize;
                break;
        }
    }
}