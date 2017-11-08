using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silverzone.Service;
using Silverzone.Entities;
using Silverzone.Web.Areas.Admin.Models;
namespace Silverzone.Web.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public ActionResult SubjectList()
        {
            var subjects = _subjectService.GetAll().ToList();
            var subjectList = subjects.Select(p =>
            {
                var subjectViewModel = new SubjectViewModel();
                subjectViewModel.Id = p.Id;
                subjectViewModel.Name = p.Name;
                subjectViewModel.Status = p.Status;
                return subjectViewModel;
            });
            return View(subjectList);

        }
        // GET: All Subjects
        public JsonResult GetAllSubjects()
        {
            var subjects = _subjectService.GetAll().ToList();
            var subjectList = subjects.Select(p =>
            {
                var subjectViewModel = new SubjectViewModel();
                subjectViewModel.Id = p.Id;
                subjectViewModel.Name = p.Name;
                subjectViewModel.Status = p.Status;
                return subjectViewModel;
            });
            return Json(subjectList, JsonRequestBehavior.AllowGet);

        }
        //GET: Subject by Id
        public JsonResult GetSubjectById(int id)
        {
            var subjectId =id;
            var getSubjectById = _subjectService.GetById(subjectId);
            return Json(getSubjectById, JsonRequestBehavior.AllowGet);

        }
        //Update Subject
        public string UpdateSubject(Subject subject)
        {
            if (subject != null)
            {
                
                int subjectId = subject.Id;
                Subject _subject = _subjectService.GetById(subjectId);
                _subject.Name = subject.Name;
                _subject.Status = subject.Status;
                _subjectService.Update(_subject);
                return "subject record updated successfully";

            }
            else
            {
                return "Invalid subject record";
            }
        }
        // Add Subject
        public string AddSubject(Subject subject)
        {
            if (subject != null)
            {
                _subjectService.Create(subject);
               
                return "Subject record added successfully";

            }
            else
            {
                return "Invalid subject record";
            }
        }
        // Delete subject
        public string DeleteSubject(int subjectId)
        {

            if (subjectId!=null)
            {
                try
                {
                    int _subjectId =subjectId;
                    
                    var _subject =_subjectService.GetById(_subjectId);
                    _subjectService.Delete(_subject);
                   
                    return "Selected subject record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Subject details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}
