namespace GDNET.WebInfrastructure.Models.System
{
    public enum UserDetailsMode
    {
        /// <summary>
        /// Display in other pages
        /// </summary>
        Default = 0,
        /// <summary>
        /// Display in search page (/Search/Index)
        /// </summary>
        Search,
        /// <summary>
        /// Display in account page (/Account/Watch)
        /// </summary>
        AccountWatch,
    }
}
