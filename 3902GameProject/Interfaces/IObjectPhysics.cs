namespace _3902GameProject.Interfaces
{
    public interface IObjectPhysics
    {
        float XPosition { get; set; }
        float YPosition { get; set; }
        float XVelocity { get; set; }
        float YVelocity { get; set; }
        float Gravity { get; set; }
        float MaxXSpeed { get; set; }
        float MaxYSpeed { get; set; }

        void Update();
        void DampenSpeed(float x, float y);
    }
}
