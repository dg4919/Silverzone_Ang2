﻿using Silverzone.Data;
using Silverzone.Entities;
using Silverzone.Api.ViewModel.Site;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Web;

namespace Silverzone.Api.api.User
{
    [Authorize]
    public class UserProfileController : ApiController
    {
        private readonly IAccountRepository accountRepository;            // 1st way > readonly field
        internal IOrderRepository orderRepository { get; private set; }   // 2nd way > readonly property

        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserShippingAddressRepository userShippingAddressRepository;

        public IUserQuizPointsRepository userQuizPointsRepository { get; private set; }
        public IQuizQuestionRepository quizQuestionRepository { get; private set; }
        public IForgetPasswordRepository forgetPasswordRepository { get; private set; }

        #region ***************  Code for user profile update  ************

        //[HttpPost]
        //public IHttpActionResult uploaduserImage()
        //{
        //    string path = string.Format(image_urlResolver.profilePic_temp, User.Identity.Name);
        //    var save_Imagespath = accountRepository.upload_profile_Image_toTemp(path);
        //    return Ok(new { result = save_Imagespath });
        //}

        [HttpPost, AllowAnonymous]
        public IHttpActionResult uploaduserImage()
        {
            var aa = HttpContext.Current.Request.Files;
            string path = string.Format(image_urlResolver.profilePic_temp, 1);
            var save_Imagespath = accountRepository.upload_profile_Image_toTemp(path);
            return Ok(new { result = save_Imagespath });
        }


        [HttpPost]
        public IHttpActionResult saveProfile(UserProfileViewModel model)
        {
            var _model = accountRepository.GetById(Convert.ToInt32(User.Identity.Name));
            string file_pathTo_save = string.Format(image_urlResolver.profilePic_main, User.Identity.Name);

            if (_model != null)
            {
                _model.UserName = model.UserName;
                _model.ClassId = model.Class;
                _model.DOB = model.DOB;
                _model.EmailID = model.EmailID;
                _model.MobileNumber = model.MobileNumber;
                _model.GenderType = model.Gender;

                if (model.ProfilePic != null)
                {
                    _model.ProfilePic = file_pathTo_save + "profilePic.jpg";

                    accountRepository.save_Image_fromTemp(new string[] { model.ProfilePic },  // convert string to array/List
                    string.Format(image_urlResolver.profilePic_temp, User.Identity.Name),
                    file_pathTo_save);
                }

                accountRepository.Update(_model);

                return Ok(new { result = "success", user = UserProfileViewModel.Parse(_model) });
            }

            return Ok(new { result = "error" });
        }

        [HttpPost]
        public IHttpActionResult chaange_userPassword(string oldPassword, string newPassword)
        {
            var _user = accountRepository.GetById(Convert.ToInt32(User.Identity.Name));

            if (_user != null)
            {
                if (accountRepository.VerifyPassword(oldPassword, _user.Password))
                {
                    _user.Password = accountRepository.GetPasswordHash(newPassword);

                    accountRepository.Update(_user);
                    return Ok(new { result = "success" });
                }
            }

            return Ok(new { result = "error" });
        }

        #endregion

        #region ***************  Code for user order Info  ************
        [HttpGet]
        public IHttpActionResult getAll_userOrders()
        {
            // User.Identity.Name will not contain value if we run this method from postman,fidler
            // bcoz identity cookie will not be available there
            // anonymous Type properties
            var _result = orderRepository.GetByuserId(Convert.ToInt32(User.Identity.Name))
                            .Select(x => new
                            {
                                Id = x.Id,
                                OrderNumber = x.OrderNumber,
                                Quiz_Points_Deduction = x.Quiz_Points_Deduction,
                                orderAmount = x.Total_Shipping_Amount + x.Total_Shipping_Charges,
                                OrderDate = x.OrderDate,
                                Order_Deliver_Status = x.Order_Deliver_StatusType.ToString(),   // x.Order_Deliver_Status > return its value
                                Payment_Mode = x.Payment_ModeType.ToString()
                            });

            return Ok(new { result = _result });
        }

        [HttpGet]
        public IHttpActionResult get_orerInfo(int orderId)
        {
            var orders = orderDetailViewModel.Parse(
                orderRepository.GetByuser_andOrderId(orderId, Convert.ToInt32(User.Identity.Name))
                );

            return Ok(new { result = orders });
        }

        #endregion

        #region ***************  Code to change user Email/mobile  ************

        [HttpPost]
        public IHttpActionResult change_EmailMobile(passwordRecoveryViewModel model)
        {
            model.userId = Convert.ToInt32(User.Identity.Name);
            model.OTP_code = accountRepository.get_smsCode();
            model.verficationType = verficationType.change;

            if (accountRepository.check_User(model.userName, model.verificationMode) != null)
            {
                return Ok(new { result = "exist" });
            }

            using (var ctrl = new Site.AccountController(accountRepository, forgetPasswordRepository))
            {
                return Ok(new { result = ctrl.sendSms_forgetPassword(model) });       // shared method for comon fxnality
            }
        }

        [HttpPost]
        public IHttpActionResult validate_OTP(passwordRecoveryViewModel model)
        {  // By default enum is set to 0th value ('verficationType') if we did not pass any value of it :)

            model.userId = Convert.ToInt32(User.Identity.Name);
            using (var ctrl = new Site.AccountController(accountRepository, forgetPasswordRepository))
            {
                return Ok(new { result = ctrl.verify_newPasswordOTP(model) });       // shared method for comon fxnality
            }
        }

        [HttpPost]
        public IHttpActionResult update_EmailMobile(string EmailID, string MobileNumber)
        {
            var _model = accountRepository.GetById(Convert.ToInt32(User.Identity.Name));

            if (_model != null)
            {
                _model.EmailID = EmailID;
                _model.MobileNumber = MobileNumber;

                accountRepository.Update(_model);
                return Ok(new { result = "success" });
            }

            return Ok(new { result = "notfound" });
        }

        #endregion

        #region ***************  Code for user Quiz  ************

        [HttpGet]
        public IHttpActionResult get_userToday_quiz()
        {
            var sysDate = DateTime.Now;

            // check either user already given answer of quiz of current date or not 
            var entity = userQuizPointsRepository // to get date part only of datetime Type :)
                                                .FindBy(x => DbFunctions.TruncateTime(x.Submit_Date) == sysDate.Date)
                                                .SingleOrDefault();
            if (entity != null)
                return Ok(new { Is_showQuiz = false });

            var quiz = quizQuestionRepository
                                            .FindBy(x => x.Active_Date == sysDate.Date && x.is_Active == true)
                                            .SingleOrDefault();

            if (quiz == null)   // quiz qes not found
                return Ok(new { Is_showQuiz = false });

            var quizInfo = new
            {
                quiz.Id,
                quiz.Question,
                quiz.ImageUrl,
                options = quiz.QuizOptions.Select(x => new
                {
                    x.Id,
                    x.Option,
                    x.ImageUrl
                })
            };

            return Ok(new { result = quizInfo, Is_showQuiz = true });
        }

        [HttpGet]
        public IHttpActionResult get_userMega_quiz()
        {
            int userId = Convert.ToInt32(User.Identity.Name);
            var user = accountRepository.FindById(userId);

            if(user.TotalPoint <=  100)
                return Ok(new { Is_showQuiz = false, reason = "notallow" });

            var sysDate = DateTime.Now;
            var quiz = quizQuestionRepository
                                            .FindBy(x => x.Active_Date <= sysDate.Date
                                                      && x.End_Date >= sysDate.Date
                                                      && x.is_Active == true)
                                            .SingleOrDefault();

            if (quiz == null)   // quiz qes not found
                return Ok(new { Is_showQuiz = false, reason = "notfound" });

            // check either user already given answer of quiz or not
            var entity = userQuizPointsRepository // to get date part only of datetime Type :)
                                               .FindBy(x => x.QuizId == quiz.Id)
                                               .SingleOrDefault();

            if (entity != null)
                return Ok(new { Is_showQuiz = false, reason = "exist" });

            var quizInfo = new
            {
                quiz.Id,
                quiz.Question,
                quiz.ImageUrl,
                quiz.Prize,
                quiz.PrizeImage,                
                options = quiz.QuizOptions.Select(x => new
                {
                    x.Id,
                    x.Option,
                    x.ImageUrl
                })
            };

            return Ok(new { result = quizInfo, Is_showQuiz = true });
        }


        [HttpPost]
        public IHttpActionResult save_userQuiz(int quizId, int answerId)
        {
            var quiz = quizQuestionRepository.FindById(quizId);
            int userId = Convert.ToInt32(User.Identity.Name);

            userQuizPointsRepository.Create(new UserQuizPoints()
            {
                UserId = userId,
                QuizId = quizId,
                Answerid = answerId,
                Submit_Date = DateTime.Now
            });

            if (quiz.AnswerId == answerId)
            {
                var user = accountRepository.FindById(userId);
                user.TotalPoint += quiz.Points;

                accountRepository.Update(user);
                return Ok(new { result = "ok", earnPoint = quiz.Points });
            }
            else
                return Ok(new { result = "wrong" });        // anser is not matched
        }

        [HttpGet]
        public IHttpActionResult get_userQuiz_history()
        {
            int userid = Convert.ToInt32(User.Identity.Name);
            var entity = userQuizPointsRepository
                                                 .FindBy(x => x.UserId == userid)
                                                 .Select(x => new
                                                 {
                                                     UserAnswer = x.Answerid,
                                                     Question = x.quiz.Question,
                                                     ImageUrl = x.quiz.ImageUrl,
                                                     QuizAnswer = x.quiz.AnswerId,
                                                     QuizOptions = x.quiz.QuizOptions.Select(y => new
                                                     {
                                                         y.Id,
                                                         y.Option,
                                                         y.ImageUrl,
                                                     })
                                                 });

            if (entity == null)
                return Ok(new { result = entity });

            var points = accountRepository.GetById(userid).TotalPoint;
            return Ok(new { result = entity, quizPoints = points });

        }


        #endregion

        // *****************  Constructors  ********************************

        public UserProfileController(
           IAccountRepository _accountRepository,
           IOrderRepository _orderRepository,
           IOrderDetailRepository _orderDetailRepository,
           IBookRepository _bookRepository,
           IUserShippingAddressRepository _userShippingAddressRepository,
           IForgetPasswordRepository _forgetPasswordRepository,
           IQuizQuestionRepository _quizQuestionRepository,
           IUserQuizPointsRepository _userQuizPointsRepository
           )
        {                                      // values r initialising using DI
            accountRepository = _accountRepository;
            orderRepository = _orderRepository;
            orderDetailRepository = _orderDetailRepository;
            bookRepository = _bookRepository;
            userShippingAddressRepository = _userShippingAddressRepository;
            forgetPasswordRepository = _forgetPasswordRepository;
            quizQuestionRepository = _quizQuestionRepository;
            userQuizPointsRepository = _userQuizPointsRepository;
        }


    }
}
