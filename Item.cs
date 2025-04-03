namespace IndividualProjectTodo_List
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        protected Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void EditItem(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
