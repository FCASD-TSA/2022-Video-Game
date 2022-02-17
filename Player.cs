using Godot;

namespace TSAVideoGame
{
    public class Player : KinematicBody2D
    {
        [Export] public int Speed;

        public Vector2 ScreenSize;

        public override void _Ready()
        {
            ScreenSize = GetViewportRect().Size;
            GD.Print("Player loaded");
        }

        public override void _Process(float delta)
        {
            Vector2 velocity = Vector2.Zero;

            ZIndex = (int) Position.y;

            if (Input.IsActionPressed("move_right"))
            {
                velocity.x += 1;
            }
            else if (Input.IsActionPressed("move_left"))
            {
                velocity.x -= 1;
            }
            if (Input.IsActionPressed("move_down"))
            {
                velocity.y += 1;
            }
            else if (Input.IsActionPressed("move_up"))
            {
                velocity.y -= 1;
            }

            AnimatedSprite animSprite = GetNode<AnimatedSprite>("AnimatedSprite");

            if (velocity.Length() > 0)
            {
                animSprite.Animation = "walk";
                velocity = velocity.Normalized() * Speed;
            }
            else
            {
                animSprite.Animation = "idle";
            }
            
            animSprite.Play();

            MoveAndCollide(velocity * delta);
            
            // Position = new Vector2(
            //     x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            //     y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
            // );

            if (velocity.x != 0)
            {
                animSprite.FlipV = false;
                animSprite.FlipH = velocity.x < 0;
            }
        }
    }
}