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
    public class JsonProjectService
    {
        public JsonProjectService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFileName
        {

            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json"); }

        }
        public IEnumerable<ProjectModel> GetProjects()
        {
            using var json = File.OpenText(JsonFileName);

            //return JsonSerializer.Deserialize<IEnumerable<ProjectModel>>(json.ReadToEnd());
            return JsonSerializer.Deserialize<ProjectModel[]>(json.ReadToEnd());

        }





        public void AddProject(ProjectModel newproject)
        {
            var projects = GetProjects();

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
            IEnumerable<ProjectModel> updatedprojects = temp.ToArray();

            using var json = File.OpenWrite(JsonFileName);


            JsonSerializer.Serialize<IEnumerable<ProjectModel>>
                (
                new Utf8JsonWriter(json, new JsonWriterOptions { Indented = true }), updatedprojects
                );
        }

        public ProjectModel GetProjectById(int id)
        {
            var project = GetProjects();

            ProjectModel query = project.FirstOrDefault(x => x.id == id);
            return query;
        }

        public void UpdateProject(ProjectModel newproject)
        {
            var project = GetProjects();
            ProjectModel query = project.FirstOrDefault(x => x.id == newproject.id);

            if (query != null)
            {
                var temp = project.ToList();
                temp[temp.IndexOf(query)] = newproject;

                IEnumerable<ProjectModel> updatedprojects = temp.ToArray();
                JsonWrite(updatedprojects);
            }


        }
        public void DeleteProject(int id)
        {
            var project = GetProjects();
            ProjectModel query = project.Single(x => x.id == id);

            var temp = project.ToList();
            temp.Remove(query);
            IEnumerable<ProjectModel> updatedprojects = temp.ToArray();
            JsonWrite(updatedprojects);
        }
        public void JsonWrite(IEnumerable<ProjectModel> project)
        {
            using var json = File.Create(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<ProjectModel>>
                (
                new Utf8JsonWriter(json, new JsonWriterOptions { Indented = true }), project
                );
        }

    }
}

