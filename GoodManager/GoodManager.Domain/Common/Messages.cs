namespace GoodManager.Domain.Common;

public static class SuccessMessages
{
    public const string SuccessfullyDone = "با موفقیت انجام شد !";

    public const string AccountSuccessfullyActivated = "حساب کاربری با موفقیت فعال شد";

    public const string SavedChangesSuccessfully = "تغییرات با موفقیت اعمال شد";

    public const string DeleteSuccess = "عملیات حذف با موفقیت انجام شد";

    public const string MessageSentSuccessfully = "پیام شما با موفقیت ثبت شد";

    public const string ConfirmCodeSent = "کد تایید برای شما ارسال شد";

    public const string LoginSuccessfully = "خوش آمدید";

    public const string ReportSendSuccessfully = "گزارش شما با موفقیت ثبت شد";

    #region Roles

    public const string RoleCreatedSuccessfully = "افزودن نقش با موفقیت انجام شد";

    public const string RoleUpdatedSuccessfully = "ویرایش نقش با موفقیت انجام شد";

    #endregion

    #region SmsProviders

    public const string SmsProviderDefaultSuccessfullySet = "سرویس پیامکی پیشفرض با موفقیت تغییر یافت";

    #endregion

    #region ProductAttributes

    public const string ProductAttributeSuccessfullyAdded = "ویژگی محصول با موفقیت اضافه شد";

    public const string ProductAttributeSuccessfullyUpdated = "ویژگی محصول با موفقیت ویرایش شد";

    public const string SetProductAttributeToCategoriesSuccess = "ویژگی محصول با موفقیت به دسته بندی هایی که انتخاب کرده بودید متصل شد";

    public const string AllCategoriesHasBeenUnsetFromProductAttribute = "ویژگی مورد نظر از تمامی دسته بندی های موجود حذف گردید";

    #endregion

    #region ProductGallery

    public const string ProductGalleryImageDeletedSuccessfully = "عکس محصول با موفقیت حذف گردید";

    #endregion

    #region ProductColors

    public const string ProductColorSuccessfullyAdded = "رنگ محصول با موفقیت اضافه شد";

    public const string ProductColorSuccessfullyEdited = "رنگ محصول با موفقیت ویرایش شد";

    public const string ProductColorSuccessfullyDeleted = "رنگ محصول با موفقیت حذف شد ";

    public const string ProductColorSuccessfullyRecovered = "رنگ محصول با موفقیت بازگردانی شد";

    #endregion
}

public static class ErrorMessages
{

    public const string MinRangeError = "{0} باید بزرگتر از {1} باشد";

    public const string MaxRangeError = "{0} باید کوچکتر از {2} باشد";

    public const string RangeError = "{0} باید بین عدد {1} و عدد {2} باشد";

    public const string RangeErrorForPrice = "{0} باید بین {1} ریال و {2} ریال باشد";

    public const string MaxLengthError = "تعداد کاراکتر مجاز {1} عدد می باشد";

    public const string NullValue = "مقادیر نادرست";

    public const string NotFoundError = "موردی یافت نشد";

    public const string SlugExistError = "عنوان در url از قبل موجود است";

    public const string TitleExistError = "عنوان از قبل موجود است";

    public const string OperationFailedError = "عملیات شکست خورد";

    public const string MinLengthError = "کاراکترهای {0} نمیتواند کمتر از {1} باشد";

    public const string RequiredError = "لطفا {0} را وارد کنید";

    public const string CompareError = "{0} با تکرار آن مشابه نیست";

    public const string RegexIncorrectFormat = "{0} را با فرمت درست وارد کنید";

    public const string DuplicatedError = "{0} تکراری است";

    public const string DuplicatedDeletedError = "{0}  در لیست حذف شده ها تکراری است";
    public const string FileSizeError = " مگابایت باشد{0} سایز عکس نمیتواند بیشتر از";

    public const string PasswordRequiredUpperCaseError = "رمز عبور نیازمند حروف بزرگ می باشد";

    public const string PasswordRequiredLowerCaseError = "رمز عبور نیازمند حروف کوچک می باشد";

    public const string BadRequestError = "درخواست شما نامعتر است";

    public const string InvalidConfirmationCode = "کد وارد شده صحیح نمی باشد";

    public const string UserDeletedError = "امکان ثبت نام برای شما وجود ندارد";

    public const string UserBannedError = "حساب کاربری شما مسدود شده است";

    public const string MinOrMaxRatingError = "امتیاز باید عددی بین 1 تا 5 باشد";

    public const string ExpireConfirmCodeError = "کد وارد شده منقضی شده است";

    public const string NullConfirmCode = "کد تایید را وارد کنید";

    public const string AmountNotValidError = "مبلغ وارد شده صحیح نمی باشد";

    public const string NullLocation = "موقعیت مکانی خود را ثبت کنید";

    public const string NotEnoughBalance = "موجودی کیف پول کافی نمی باشد";

    public const string AlreadyExistError = "{0} از قبل موجود است";

    public const string ReCaptchaValidateError = "کپچا تایید نشد";

    public const string BannerInUseError = "این بنر قبلا استفاده شده است";

    public const string AccountIsNotActive = "حساب کاربری فعال نمیباشد";

    #region Roles


    public const string RoleNotFound = "نقش مورد نظر یافت نشد";

    public const string RoleExistError = "نقش از قبل موجود می باشد";

    public const string SavingRolesChangesFailedError = "مشکلی در ذخیره تغییرات در نقش ها پیش آمده است";

    #endregion

    #region Sms

    public const string SmsDidNotSendError = "ارسال پیامک با خطا مواجه شد";

    #endregion

    #region SmsProvider

    public const string SmsProviderNotFound = "مشخصات سرویس پیامکی مورد نظر یافت نشد";

    #endregion

    #region Payment

    public const string PaymentError = "مشکلی در فرایند پرداخت پیش آمده است";

    #endregion

    #region Google Login

    public const string GoogleAuthBadRequestError = "مشکلی در فرایند ورود با حساب کاربری گوگل پیش آمده است";

    #endregion

    #region ProductAttribute

    public const string ProductAttributeNullValueError = "لطفا حداقل یک مقدار را برای ویژگی مورد نظر خود وارد نمایید";

    public const string NoCategoriesSetToProductError =
        "هیچ دسته بندی ای به محصول متصل نشده است. لطفا اول محصول را حداقل به یک دسته بندی متصل نمایید";

    #endregion

    #region Product Tags

    public const string SavingTagsForProductChangesFailedError = "مشکلی در ذخیره تگ های محصول پیش آمده است";

    #endregion

    #region Product Category

    public const string SavingCategoriesForProductChangesFailedError = "مشکلی در ذخیره تغییرات در دسته بندی های محصول پیش آمده است";

    #endregion

    #region Product delivery method

    public const string SavingDeliveryMethodsForProductChangesFailedError = "مشکلی در ذخیره روش های ارسال محصول پیش آمده است";

    #endregion

    #region ProductColor

    public const string ProductColorNameExist = "نام رنگ از قبل در سایت موجود می باشد";

    public const string ProductColorCodeExist = "کد رنگ از قبل در سایت موجود می باشد";

    #endregion

}