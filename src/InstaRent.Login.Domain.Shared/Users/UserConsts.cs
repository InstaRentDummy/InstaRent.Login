namespace InstaRent.Login.Users
{
    public static class UserConsts
    {
        private const string DefaultSorting = "{0}Email asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "User." : string.Empty);
        }

        public const int EmailMaxLength = 128;
        public const int PasswordMaxLength = 128;
    }
}
