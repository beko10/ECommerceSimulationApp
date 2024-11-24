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

    public static class CustomerMessages
    {
        // Success Messages
        public const string CustomerCreated = "Müşteri başarıyla oluşturuldu";
        public const string CustomerUpdated = "Müşteri başarıyla güncellendi";
        public const string CustomerDeleted = "Müşteri başarıyla silindi";
        public const string CustomersListed = "Müşteriler başarıyla listelendi";
        public const string CustomerFound = "Müşteri başarıyla bulundu";

        // Error Messages
        public const string CustomerNotFound = "Müşteri bulunamadı";
        public const string CustomersNotFound = "Hiç müşteri bulunamadı";
        public const string CustomerCreateError = "Müşteri oluşturulurken bir hata oluştu";
        public const string CustomerUpdateError = "Müşteri güncellenirken bir hata oluştu";
        public const string CustomerDeleteError = "Müşteri silinirken bir hata oluştu";
        public const string CustomerAlreadyExists = "Bu müşteri zaten mevcut";

        // Validation Messages
        public const string CustomerNameRequired = "Müşteri adı zorunludur.";
        public const string CustomerNameLength = "Müşteri adı 2-50 karakter arasında olmalıdır.";
        public const string CustomerNameRegex = "Müşteri adı sadece harfler ve boşluklardan oluşmalıdır.";

        public const string CountryRequired = "Ülke adı zorunludur.";
        public const string CountryLength = "Ülke adı 2-50 karakter arasında olmalıdır.";
        public const string CountryRegex = "Ülke adı sadece harfler ve boşluklardan oluşmalıdır.";

        public const string CityRequired = "Şehir adı zorunludur.";
        public const string CityLength = "Şehir adı 2-50 karakter arasında olmalıdır.";
        public const string CityRegex = "Şehir adı sadece harfler ve boşluklardan oluşmalıdır.";

        public const string PhoneRequired = "Telefon numarası zorunludur.";
        public const string PhoneRegex = "Telefon numarası geçersiz.";
        public const string PhoneMaxLength = "Telefon numarası 15 karakterden uzun olamaz.";

        //Bussines Rule Error Messages
        public const string CustomerBusinessRuleError = "Müşteri iş kuralı hatası";
        public const string CustomerBusinessRulePhoneNumberError = "Bu numarayla kayıtlı müşteri bulunmaktadır";

        //Business Rule Success Messages
        public const string CustomerBusinessRuleSuccess = "Müşteri iş kuralı doğrulama başarılı ";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu";
        public const string TransactionError = "İşlem sırasında bir hata oluştu";
        public const string InvalidOperation = "Geçersiz işlem";
    }
    public static class EmployeeMessages
    {
        // Success Messages
        public const string EmployeeCreated = "Çalışan başarıyla oluşturuldu.";
        public const string EmployeeUpdated = "Çalışan başarıyla güncellendi.";
        public const string EmployeeDeleted = "Çalışan başarıyla silindi.";
        public const string EmployeesListed = "Çalışanlar başarıyla listelendi.";
        public const string EmployeeFound = "Çalışan başarıyla bulundu.";

        // Error Messages
        public const string EmployeeNotFound = "Çalışan bulunamadı.";
        public const string EmployeesNotFound = "Hiç çalışan bulunamadı.";
        public const string EmployeeCreateError = "Çalışan oluşturulurken bir hata oluştu.";
        public const string EmployeeUpdateError = "Çalışan güncellenirken bir hata oluştu.";
        public const string EmployeeDeleteError = "Çalışan silinirken bir hata oluştu.";

        // Validation Messages
        public const string NameRequired = "İsim alanı zorunludur.";
        public const string NameLength = "İsim 2-50 karakter arasında olmalıdır.";
        public const string NameRegex = "İsim sadece harfler ve boşluklardan oluşmalıdır.";

        public const string SurNameRequired = "Soyisim alanı zorunludur.";
        public const string SurNameLength = "Soyisim 2-50 karakter arasında olmalıdır.";
        public const string SurNameRegex = "Soyisim sadece harfler ve boşluklardan oluşmalıdır.";

        public const string CountryRequired = "Ülke alanı zorunludur.";
        public const string CountryLength = "Ülke 2-50 karakter arasında olmalıdır.";
        public const string CountryRegex = "Ülke sadece harfler ve boşluklardan oluşmalıdır.";

        public const string CityRequired = "Şehir alanı zorunludur.";
        public const string CityLength = "Şehir 2-50 karakter arasında olmalıdır.";
        public const string CityRegex = "Şehir sadece harfler ve boşluklardan oluşmalıdır.";

        public const string PhoneRequired = "Telefon alanı zorunludur.";
        public const string PhoneLength = "Telefon numarası 10-15 karakter arasında olmalıdır.";
        public const string PhoneRegex = "Telefon numarası geçersiz formatta.";

        // Business Rule Messages
        public const string EmployeeBusinessRuleError = "Çalışan iş kuralı hatası.";
        public const string EmployeePhoneAlreadyExists = "Bu telefon numarası başka bir çalışan tarafından kullanılıyor.";
        public const string EmployeeBusinessRuleSuccess = "Çalışan iş kuralı doğrulama başarılı";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu";
        public const string TransactionError = "İşlem sırasında bir hata oluştu";
        public const string InvalidOperation = "Geçersiz işlem";
    }
    public static class OrderMessages
    {
        // Success Messages
        public const string OrderCreated = "Sipariş başarıyla oluşturuldu.";
        public const string OrderUpdated = "Sipariş başarıyla güncellendi.";
        public const string OrderDeleted = "Sipariş başarıyla silindi.";
        public const string OrdersListed = "Siparişler başarıyla listelendi.";
        public const string OrderFound = "Sipariş başarıyla bulundu.";

        // Error Messages
        public const string OrderNotFound = "Sipariş bulunamadı.";
        public const string OrdersNotFound = "Hiç sipariş bulunamadı.";
        public const string OrderCreateError = "Sipariş oluşturulurken bir hata oluştu.";
        public const string OrderUpdateError = "Sipariş güncellenirken bir hata oluştu.";
        public const string OrderDeleteError = "Sipariş silinirken bir hata oluştu.";

        // Validation Messages
        public const string OrderDateTooEarly = "Sipariş tarihi bugünden daha erken olamaz.";
        public const string OrderDateTooLate = "Sipariş tarihi 1 yıldan daha ileri bir tarih olamaz.";
        public const string ShipAddressRequired = "Teslimat adresi zorunludur.";
        public const string ShipAddressLength = "Teslimat adresi 5-250 karakter arasında olmalıdır.";
        public const string ShipCityRequired = "Şehir adı zorunludur.";
        public const string ShipCityLength = "Şehir adı 2-50 karakter arasında olmalıdır.";
        public const string ShipCityInvalid = "Şehir adı yalnızca harfler ve boşluklardan oluşmalıdır.";
        public const string ShipCountryRequired = "Ülke adı zorunludur.";
        public const string ShipCountryLength = "Ülke adı 2-50 karakter arasında olmalıdır.";
        public const string ShipCountryInvalid = "Ülke adı yalnızca harfler ve boşluklardan oluşmalıdır.";
        public const string OrderDetailsRequired = "Sipariş en az bir detay içermelidir.";

        // Business Rule Messages
        public const string OrderBusinessRuleError = "Sipariş iş kuralı hatası.";
        public const string OrderCannotBeModified = "Sevkiyat başlamış bir sipariş değiştirilemez.";
        public const string OrderTotalAmountInvalid = "Sipariş toplam tutarı geçerli değil.";
        public const string OrderValidationSuccess = "Sipariş doğrulama başarılı.";
        public const string OrderShipmentStarted = "Sipariş sevkiyatı başlamış durumda.";
        public const string OrderPaymentRequired = "Sipariş için ödeme gerekli.";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu.";
        public const string TransactionError = "İşlem sırasında bir hata oluştu.";
        public const string InvalidOperation = "Geçersiz işlem.";
    }

    public static class OrderDetailMessages
    {
        // Success Messages
        public const string OrderDetailCreated = "Sipariş detayı başarıyla oluşturuldu.";
        public const string OrderDetailUpdated = "Sipariş detayı başarıyla güncellendi.";
        public const string OrderDetailDeleted = "Sipariş detayı başarıyla silindi.";
        public const string OrderDetailsListed = "Sipariş detayları başarıyla listelendi.";
        public const string OrderDetailFound = "Sipariş detayı başarıyla bulundu.";

        // Error Messages
        public const string OrderDetailNotFound = "Sipariş detayı bulunamadı.";
        public const string OrderDetailsNotFound = "Hiç sipariş detayı bulunamadı.";
        public const string OrderDetailCreateError = "Sipariş detayı oluşturulurken bir hata oluştu.";
        public const string OrderDetailUpdateError = "Sipariş detayı güncellenirken bir hata oluştu.";
        public const string OrderDetailDeleteError = "Sipariş detayı silinirken bir hata oluştu.";

        // Validation Messages
        public const string QuantityMustBeGreaterThanZero = "Miktar 0'dan büyük olmalıdır.";
        public const string UnitPriceMustBeGreaterThanZero = "Birim fiyat 0'dan büyük olmalıdır.";
        public const string UnitPriceTooHigh = "Birim fiyat 10.000'den fazla olamaz.";


        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu.";
        public const string TransactionError = "İşlem sırasında bir hata oluştu.";
        public const string InvalidOperation = "Geçersiz işlem.";
    }

    public static class ProductMessages
    {
        // Success Messages
        public const string ProductCreated = "Ürün başarıyla oluşturuldu.";
        public const string ProductUpdated = "Ürün başarıyla güncellendi.";
        public const string ProductDeleted = "Ürün başarıyla silindi.";
        public const string ProductsListed = "Ürünler başarıyla listelendi.";
        public const string ProductFound = "Ürün başarıyla bulundu.";

        // Error Messages
        public const string ProductNotFound = "Ürün bulunamadı.";
        public const string ProductsNotFound = "Hiç ürün bulunamadı.";
        public const string ProductCreateError = "Ürün oluşturulurken bir hata oluştu.";
        public const string ProductUpdateError = "Ürün güncellenirken bir hata oluştu.";
        public const string ProductDeleteError = "Ürün silinirken bir hata oluştu.";
        public const string CategoryNotFound = "Kategori bulunamadı.";
        public const string SupplierNotFound = "Tedarikçi bulunamadı.";

        // Validation Messages
        public const string ProductNameRequired = "Ürün adı zorunludur.";
        public const string ProductNameLength = "Ürün adı 2-100 karakter arasında olmalıdır.";
        public const string UnitPriceGreaterThanZero = "Ürün fiyatı sıfırdan büyük olmalıdır.";
        public const string UnitPriceTooHigh = "Ürün fiyatı 10.000'den büyük olamaz.";
        public const string UnitsInStockMustBePositive = "Stoktaki ürün adedi negatif olamaz.";
        public const string CategoryNameRequired = "Kategori adı zorunludur.";
        public const string CategoryNameLength = "Kategori adı 2-50 karakter arasında olmalıdır.";
        public const string SupplierNameRequired = "Tedarikçi adı zorunludur.";
        public const string SupplierNameLength = "Tedarikçi adı 2-50 karakter arasında olmalıdır.";

        // Business Rule Messages
        public const string ProductBusinessRuleError = "Ürün iş kuralı hatası.";
        public const string ProductOutOfStock = "Ürün stokta mevcut değil.";
        public const string ProductDiscontinued = "Bu ürün kullanımdan kaldırılmıştır.";
        public const string ProductBusinessRuleSuccess = "Ürün iş kuralı doğrulama başarılı.";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu.";
        public const string TransactionError = "İşlem sırasında bir hata oluştu.";
        public const string InvalidOperation = "Geçersiz işlem.";
    }

    public static class SupplierMessages
    {
        // Validation Messages
        public const string CompanyNameRequired = "Şirket adı zorunludur.";
        public const string CompanyNameLength = "Şirket adı 2-100 karakter arasında olmalıdır.";
        public const string ContactTitleRequired = "İlgili kişi unvanı zorunludur.";
        public const string ContactTitleLength = "İlgili kişi unvanı 2-50 karakter arasında olmalıdır.";
        public const string CountryRequired = "Ülke bilgisi zorunludur.";
        public const string CityRequired = "Şehir bilgisi zorunludur.";
        public const string PhoneRequired = "Telefon numarası zorunludur.";
        public const string PhoneInvalid = "Geçerli bir telefon numarası girilmelidir.";
        public const string ValidationError = "Doğrulama Hatası";

        // Success Messages
        public const string SupplierCreated = "Tedarikçi başarıyla oluşturuldu.";
        public const string SupplierUpdated = "Tedarikçi başarıyla güncellendi.";
        public const string SupplierDeleted = "Tedarikçi başarıyla silindi.";
        public const string SuppliersListed = "Tedarikçiler başarıyla listelendi.";
        public const string SupplierFound = "Tedarikçi başarıyla bulundu.";

        // Error Messages
        public const string SupplierNotFound = "Tedarikçi bulunamadı.";
        public const string SuppliersNotFound = "Hiç tedarikçi bulunamadı.";
        public const string SupplierCreateError = "Tedarikçi oluşturulurken bir hata oluştu.";
        public const string SupplierUpdateError = "Tedarikçi güncellenirken bir hata oluştu.";
        public const string SupplierDeleteError = "Tedarikçi silinirken bir hata oluştu.";

        // Business Rule Messages
        public const string SupplierBusinessRuleError = "Tedarikçi iş kuralı hatası.";
        public const string SupplierHasPendingOrders = "Tedarikçinin tamamlanmamış siparişleri mevcut.";
        public const string SupplierDeactivated = "Bu tedarikçi devre dışı bırakılmıştır.";
        public const string SupplierBusinessRuleSuccess = "Tedarikçi iş kuralı doğrulama başarılı.";

        // Generic Messages
        public const string UnexpectedError = "Beklenmeyen bir hata oluştu.";
        public const string TransactionError = "İşlem sırasında bir hata oluştu.";
        public const string InvalidOperation = "Geçersiz işlem.";
        public const string OperationSuccessful = "İşlem başarıyla tamamlandı.";
    }
}