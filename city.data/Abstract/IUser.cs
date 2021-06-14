using city.entity;

namespace city.data.Abstract
{
    // User interfacesi kullanýlan metotlarýn arayüzü
    public interface IUser
    {

        // Kullanýcý ekleme metodunun arayüzü.
         void addUser(User user);

        // Kullanýcý giriþ ekranýnda kayýtlý kullanýcý sorgusu için fonksiyon
        User findUser(string email, string password);
    }
}