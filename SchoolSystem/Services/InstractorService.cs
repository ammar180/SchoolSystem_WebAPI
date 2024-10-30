using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.Services
{
    public class InstractorService : IInstractorService
    {
        private IInstractorRepository InstractorRepo;
        private ISubjectRepository subjectRepo;
        private Validation validation = new Validation();


        public InstractorService(IInstractorRepository _InstractorRepo, ISubjectRepository _subjectRepo)
        {
            InstractorRepo = _InstractorRepo;
            subjectRepo = _subjectRepo;
        }

        public string RemoveInstractor(int id)
        {
            var Instractor = InstractorRepo.GetById(id);
            if(Instractor != null)
            {
                InstractorRepo.Delete(Instractor);
                return "Instractor deleted Successfully";
            }
            return "Not Found!";
        }

        public string InstractorRegestration(InstractorDto dto)
        {
            try
            {

                Instractor inst = new Instractor()
                {
                    Name = dto.Name,
                    Salary = dto.Salary,
                    SubjectId = subjectRepo.GetIdByName(dto.SubjectName),
                };

                InstractorRepo.Add(inst);
                return $"Instractor Regester Successfully with, {inst.Subject.Name ?? "No Subject"}";
            }
            catch
            {
                throw new InvalidOperationException("Subject Name Not found!!");
            }
        }

        public string UpdateInstractorData(int id, InstractorDto dto)
        {
            try
            {
                var inst = InstractorRepo.GetById(id);
                if (inst == null)
                    return "Instractor Not Found";

                inst.Name = dto.Name;
                inst.Salary = dto.Salary;
                inst.SubjectId = subjectRepo.GetIdByName( dto.SubjectName);
                
                InstractorRepo.Update(inst);

                return $"Instractor Name Updated Successfully";

            }
            catch (InvalidDataException probs)
            {
                return probs.Message;
            }
        }

        public List<Instractor> GetAllInstractorsAndSubjects()
        {
            return InstractorRepo.GetAll();
        }
    }
}
