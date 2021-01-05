using System;

namespace SharedDll
{
    public class ProfileSearch
    {
        public string Id { get; set; }

        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public ProfilePhoto Photo { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }

        public void SetIds(string IdLoggedUser)
        {
            Id = IdLoggedUser;
        }

        public void UpdatePhoto(ProfilePhoto obj)
        {
            Photo = obj;
        }
    }

    public class ProfilePhoto
    {
        public string Main { get; set; }
        public string Validation { get; set; }
        public string[] Gallery { get; set; } = Array.Empty<string>();

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }

        public string GetMainPhoto()
        {
            if (string.IsNullOrEmpty(Main))
                return "/img/nouser.jpg";
            else
                return Main;
        }
    }

    public enum ActivityStatus
    {
        Today = 1,
        Week = 2,
        Month = 3,
        Disabled = 4
    }
}