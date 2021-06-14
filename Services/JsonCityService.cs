using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WorldTravel.Models;

namespace WorldTravel.Services
{
    public class JsonCityService
    {
        public JsonCityService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Serverdeki Json dosyasının ismini ve yolunu alır
        public string JsonFileName
        {

            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "sehirVeri.json"); }

        }

        // GetCity() fonksiyonu bize json dosyasındaki verileri okunabilir halde döndürür.
        public IEnumerable<CityModel> GetCity()
        {
            using var json = File.OpenText(JsonFileName);

            //return JsonSerializer.Deserialize<IEnumerable<CityModel>>(json.ReadToEnd());
            return JsonSerializer.Deserialize<CityModel[]>(json.ReadToEnd());

        }




        // Şehir ekleme fonksiyonu için kullanılır. Tüm şehirleri alıp şehir id'si linq yapısı ile son eklenen şehrin id'sinin bir fazlası olarak atanır.
        // Yeni proje listeye ekleniyor ve serialize edilir
        public void AddCity(CityModel newproject)
        {
            var projects = GetCity();

            if (projects != null)
            {
                newproject.id = projects.Max(x => x.id) + 1;

            }
            else
            {
                newproject.id = 1;
            }

            var temp = projects.ToList();
            temp.Add(newproject);
            IEnumerable<CityModel> updatedprojects = temp.ToArray();

            using var json = File.OpenWrite(JsonFileName);


            JsonSerializer.Serialize<IEnumerable<CityModel>>
                (
                new Utf8JsonWriter(json, new JsonWriterOptions { Indented = true }), updatedprojects
                );
        }

        // Şuanlık ID'ye göre değil Name değişkenine göre arama yaptırıyoruz.
        public CityModel GetCityById(int id)
        {
            var project = GetCity();

            CityModel query = project.FirstOrDefault(x => x.id == id);
            return query;
        }
       
        // Şehir adına göre arama yapılarak aranan şehir linq yapısı ile bu query döndürülüyor.
        public CityModel GetCityByName(string name)
        {
            var project = GetCity();

            CityModel query = project.FirstOrDefault(x => x.name.Equals(name));
            return query;
        }

        // Şehir güncelleme fonksiyonu. Aranan şehir adına göre ekleme veya silme işlemleri yapılarak dosyaya yazılıyor.
        public void UpdateCity(CityModel newproject)
        {
            var project = GetCity();
            CityModel query = project.FirstOrDefault(x => x.name == newproject.name);

            if (query != null)
            {
                var temp = project.ToList();
                temp[temp.IndexOf(query)] = newproject;

                IEnumerable<CityModel> updatedprojects = temp.ToArray();
                JsonWrite(updatedprojects);
            }


        }
        public void DeleteProject(int id)
        {
            var project = GetCity();
            CityModel query = project.Single(x => x.id == id);

            var temp = project.ToList();
            temp.Remove(query);
            IEnumerable<CityModel> updatedprojects = temp.ToArray();
            JsonWrite(updatedprojects);
        }
        public void JsonWrite(IEnumerable<CityModel> project)
        {
            using var json = File.Create(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<CityModel>>
                (
                new Utf8JsonWriter(json, new JsonWriterOptions { Indented = true }), project
                );
        }
    }
}



