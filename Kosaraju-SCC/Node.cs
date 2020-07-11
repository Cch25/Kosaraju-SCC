namespace Kosaraju_SCC
{
    public class Node
    {
        public enum Colors
        {
            Black, White, Gray
        }

        public Colors Color { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Node(int id, string name)
        {
            Id = id;
            Name = name;
            Color = Colors.White;
        }
    }
}
