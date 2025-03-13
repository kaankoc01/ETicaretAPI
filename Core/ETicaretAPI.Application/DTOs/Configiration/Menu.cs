namespace ETicaretAPI.Application.DTOs.Configiration
{
    public class Menu
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
