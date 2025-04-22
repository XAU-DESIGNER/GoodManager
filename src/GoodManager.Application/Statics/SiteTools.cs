namespace GoodManager.Application.Statics;

public class SiteTools
{
    #region Common

    public static string? SiteName { get; set; }
    public static string? DefaultImageName { get; set; }
    public static string? UploadImage { get; set; }
    public static string? SiteAddress { get; set; }

    #endregion

    #region File Sizes

    public static int MaxImageSize { get; set; }
    public static int MaxVideoSize { get; set; }

    #endregion

    #region Article

    public static string ArticleImagePath { get; set; }
    public static string ArticleImageThumbPath { get; set; }

    #endregion

    #region User

    public static string UserImagePath { get; set; }
    public static string UserImageThumbPath { get; set; }
    public static string UserDefaultPath { get; set; }

    #endregion
}