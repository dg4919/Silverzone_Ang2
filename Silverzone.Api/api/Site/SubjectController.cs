﻿using Silverzone.Data;
using System.Linq;
using System.Web.Http;

namespace Silverzone.Api.api.Site
{
    public class SubjectController : ApiController
    {
        ISubjectRepository subjectRepository;
        IclassRepository classRepository;
        IclassSubjectRepository classSubjectRepository;

        public IHttpActionResult Get_allSubjects()
        {
            // subjects is anonymous type
            var subjects = subjectRepository.GetByStatus(true).Select(x => new
            {                     // get all subjects which is curently Active
                subjectId = x.Id,
                subjectName = x.Name
            });

            return Ok(new { result = subjects });
        }

        public IHttpActionResult Get_subjects_ByclassId(int classId)
        {
            // subjects is anonymous type
            var subjects = (from a in classSubjectRepository.Get_subjects_ByClassId(classId)
                            join b in subjectRepository.GetAll()
                            on a.SubjectId equals b.Id
                            select new
                            {
                                subjectId = b.Id,
                                subjectName = b.Name
                            });

            return Ok(new { result = subjects });
        }

        public IHttpActionResult Get_class_BysubjectId(int subjectId)
        {
            var subjects = (from a in classSubjectRepository.FindBy(x => x.SubjectId == subjectId)
                            join b in classRepository.GetAll()
                            on a.ClassId equals b.Id
                            select new
                            {
                                Id = b.Id,
                                className = b.className
                            });

            return Ok(new { result = subjects });
        }


        // *****************  Constructors  ********************************

        public SubjectController(
            ISubjectRepository _subjectRepository,
            IclassSubjectRepository _classSubjectRepository,
            IclassRepository _classRepository)
        {
            subjectRepository = _subjectRepository;
            classSubjectRepository = _classSubjectRepository;
            classRepository = _classRepository;
        }

    }
}
