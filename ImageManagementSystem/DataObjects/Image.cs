
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class Image
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public Image() { User = string.Empty; Description = string.Empty; URL = string.Empty; }
        public Image(int Id, string User, string Description, string URL)
        {
            this.Id = Id;
            this.User = User;
            this.Description = Description;
            this.URL = URL;
            this.DateCreated = DateTime.Now;
        }

    }
}
