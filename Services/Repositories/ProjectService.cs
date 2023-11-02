using Portfolio.Models;
using Portfolio.Services.Interfaces;

namespace Portfolio.Services.Repositories
{
    public class ProjectService : IProjectService
    {
        public List<ProyectDTO> GetProyects()
        {
            return new List<ProyectDTO>() { new ProyectDTO {
                Description = "A graphql api about books",
                ImageUrl = "/images/graphqlstest.png",
                RepositoryUrl = "https://github.com/MiguelBrav/GraphQLTest",
                Title = "GraphqlTest"
                },new ProyectDTO {
                Description = "Survey small project with asp .net MVC",
                ImageUrl = "/images/survey.png",
                RepositoryUrl = "https://github.com/MiguelBrav/SurveyProject",
                Title = "Survey"
                },new ProyectDTO {
                Description = "YGO Wiki using grpc",
                ImageUrl = "/images/ygogrpc.png",
                RepositoryUrl = "https://github.com/MiguelBrav/YGOWiki",
                Title = "Yugioh project"
                },new ProyectDTO {
                Description = "To do list using .net",
                ImageUrl = "/images/heisenhower.png",
                RepositoryUrl = "https://github.com/MiguelBrav/ToDoList",
                Title = "To do list"
                },
            };
        }
    }
}
