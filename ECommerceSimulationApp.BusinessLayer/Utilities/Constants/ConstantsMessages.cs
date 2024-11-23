namespace ECommerceSimulationApp.BusinessLayer.Utilities.Constants;

public static class ConstantsMessages
{
    public static class CategoryMessages
    {
        // Success Messages
        public const string CategoryCreated = "Kategori başarıyla oluşturuldu";
        public const string CategoryUpdated = "Kategori başarıyla güncellendi";
        public const string CategoryDeleted = "Kategori başarıyla silindi";
        public const string CategoriesListed = "Kategoriler başarıyla listelendi";
        public const string CategoryFound = "Kategori başarıyla bulundu";

        // Error Messages
        public const string CategoryNotFound = "Kategori bulunamadı";
        public const string CategoriesNotFound = "Hiç kategori bulunamadı";
        public const string CategoryNameExists = "Bu kategori adı zaten kullanılıyor";
        public const string CategoryHasProducts = "Bu kategoriye ait ürünler bulunduğu için silinemez";
        public const string CategoryCreateError = "Kategori oluşturulurken bir hata oluştu";
        public const string CategoryUpdateError = "Kategori güncellenirken bir hata oluştu";
        public const string CategoryDeleteError = "Kategori silinirken bir hata oluştu";

        // Validation Messages
        public const string CategoryNameRequired = "Kategori adı zorunludur";
        public const string CategoryNameLength = "Kategori adı 3-50 karakter arasında olmalıdır";
        public const string CategoryDescriptionRequired = "Kategori açıklaması zorunludur";
        public const string CategoryDescriptionLength = "Kategori açıklaması 5-200 karakter arasında olmalıdır";
        public const string CategoryIdRequired = "Kategori ID'si zorunludur";

        // Business Rule Messages
        public const string CategoryValidationError = "Kategori doğrulama hatası";
        public const string CategoryBusinessRuleError = "Kategori iş kuralı hatası";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu";
        public const string TransactionError = "İşlem sırasında bir hata oluştu";
        public const string InvalidOperation = "Geçersiz işlem";
    }
}