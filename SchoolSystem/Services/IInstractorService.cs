using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.Services
{
    public interface IInstractorService
    {
        List<Instractor> GetAllInstractorsAndSubjects();
        string RemoveInstractor(int id);
        public string InstractorRegestration(InstractorDto dto);
        string UpdateInstractorData(int id, InstractorDto dto);
    }
}
