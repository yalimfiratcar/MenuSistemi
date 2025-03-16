namespace MenuSistemi.Models
{
    public class MenuAndCategory
    {
        public List<Category> Category { get; set; }

        public List<MenuLeftJoinCategory> MenuLeftJoin { get; set; }

        public List<MenuCategoryCount> MenuCount { get; set; }
    }
}
