using Bogus;

namespace SharedDll
{
    public static class ProfileSeed
    {
        public static Faker<ProfileSearch> GetProfileSearch(string Id = null)
        {
            return new Faker<ProfileSearch>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(Id ?? s.Random.Guid().ToString());
                    p.NickName = s.Name.FirstName();
                    p.BirthDate = s.Date.Past(18).Date;
                    p.UpdatePhoto(GetProfilePhoto());
                    p.ActivityStatus = s.PickRandom<ActivityStatus>();
                    p.Distance = s.Random.Number(500, 10000);
                });
        }

        public static Faker<ProfilePhoto> GetProfilePhoto()
        {
            return new Faker<ProfilePhoto>("pt_BR")
                .Rules((s, p) =>
                {
                    p.UpdateMainPhoto(s.Internet.Avatar());
                    p.UpdatePhotoGallery(new[] { s.Image.PicsumUrl() });
                });
        }
    }
}