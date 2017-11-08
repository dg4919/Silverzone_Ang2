using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace Silverzone.Entities
{
    //public class SilverzoneContext : IdentityDbContext<ApplicationUser>

    public class SilverzoneContext : DbContext
    {
        public SilverzoneContext() :
            base("SilverzoneContext")
        {
            Database.SetInitializer<SilverzoneContext>(null);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookContent> Contents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GenericOTP> GenericOTP { get; set; }
        public DbSet<UserShippingAddress> UserShippingAddress { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<classSubject> classSubject { get; set; }
        public DbSet<ForgetPassword> ForgetPassword { get; set; }
        public DbSet<ErrorLogs> ErrorLogs { get; set; }
        public DbSet<Dispatch> Dispatch { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Olympiads> Olympiads { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<QuickLink> QuickLinks { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<TeacherEvent> TeacherEvents { get; set; }

        public DbSet<UserLogs> UserLogs { get; set; }

        public DbSet<BookBundle> BookBundles { get; set; }
        public DbSet<BookBundleDetails> BundlesDetails { get; set; }

        public DbSet<EventCodeImagePath> EventCodeImagePaths { get; set; }
        public DbSet<MasterAcademicYear> MasterAcademicYears { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }

        public DbSet<BookDispatch> BookDispatches { get; set; }
        public DbSet<Query> Queries { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizQuestionOptions> QuizQuestionOptions { get; set; }
        public DbSet<UserQuizPoints> UserQuizPoints { get; set; }
        public DbSet<QPDispatch> QPDispatch { get; set; }

        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<Freelance> Freelance { get; set; }
        public DbSet<MetaTag> MetaTags { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<UpdateSection> UpdateSection { get; set; }

        public DbSet<MedalImage> MedalImages { get; set; }
        public DbSet<OlympiadList> OlympiadLists { get; set; }

        public DbSet<Courier> Courier { get; set; }
        public DbSet<CourierMode> CourierMode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOptional(x => x.BookDetails)
                .WithRequired(y => y.Book);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = "Divya";
                    //string identityName = Thread.CurrentPrincipal.Identity.Name;

                    //DateTime now = DateTime.UtcNow;
                    DateTime now = DateTime.Now;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreationDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreationDate).IsModified = false;
                    }
                    entity.UpdatedBy = identityName;
                    entity.UpdationDate = now;
                }
            }

            try                // error handling while save changes/record
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbEx.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbEx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, dbEx.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                //todo log the error in saving;
                throw ex;
            }
        }

    }
}
