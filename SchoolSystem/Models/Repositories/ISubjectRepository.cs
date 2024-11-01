﻿using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories.RepositoriesHelpers;

namespace SchoolSystem.Models.Repositories
{
    public interface ISubjectRepository : IEntityReader<Subject>, IEntityWriter<Subject>
    {
        int GetIdByName(string subjectName);
        List<Subject>? GetSubjectsStudents();
        bool IsExist(int id);
    }
}
