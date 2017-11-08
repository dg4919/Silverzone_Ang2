namespace Silverzone.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        Caption = c.String(),
                        Link = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookBundle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        bundle_totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        books_totalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        is_Active = c.Boolean(nullable: false),
                        ClassId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: false)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.BookBundleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BundleId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: false)
                .ForeignKey("dbo.BookBundle", t => t.BundleId, cascadeDelete: false)
                .Index(t => t.BundleId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        BookImage = c.String(),
                        ISBN = c.String(maxLength: 100),
                        Publisher = c.String(maxLength: 100),
                        Edition = c.String(maxLength: 100),
                        Pages = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                        in_Stock = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: false)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: false)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.BookContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Status = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: false)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.BookDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BookDescription = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BookReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Review = c.String(maxLength: 300),
                        Rating = c.String(),
                        BookId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: false)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(),
                        CouponId = c.Int(),
                        is_Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coupon", t => t.CouponId)
                .Index(t => t.CouponId);
            
            CreateTable(
                "dbo.Coupon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coupon_name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 140),
                        Coupon_amount = c.Int(nullable: false),
                        DiscountType = c.Int(nullable: false),
                        Start_time = c.DateTime(nullable: false),
                        End_time = c.DateTime(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                        is_Deleted = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        className = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.classSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: false)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: false)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookDispatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacketID = c.String(maxLength: 50),
                        ItemDescription = c.String(maxLength: 150),
                        DispatchDate = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DispatchMode = c.String(maxLength: 50),
                        CourierName = c.String(maxLength: 50),
                        ConsignmentNumber = c.String(maxLength: 50),
                        Remarks = c.String(maxLength: 200),
                        EventCode = c.String(maxLength: 15),
                        SchCode = c.String(maxLength: 15),
                        DeliveryStatus = c.String(maxLength: 50),
                        StatusDate = c.DateTime(nullable: false),
                        ReceivedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Courier_name = c.String(nullable: false),
                        Courier_Link = c.String(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourierMode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Courier_Mode = c.String(nullable: false),
                        CourierId = c.Int(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courier", t => t.CourierId, cascadeDelete: false)
                .Index(t => t.CourierId);
            
            CreateTable(
                "dbo.Dispatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Packet_Id = c.String(),
                        Invoice_No = c.String(),
                        OrderId = c.Int(nullable: false),
                        Packet_Wheight = c.Decimal(precision: 18, scale: 2),
                        Packet_Consignment = c.String(),
                        print_reason = c.String(),
                        Dispatch_Date = c.DateTime(),
                        Recieved_By = c.String(),
                        Recieved_Date = c.DateTime(),
                        CourierModeId = c.Int(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourierMode", t => t.CourierModeId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.CourierModeId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        Total_Shipping_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total_Shipping_Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Payment_ModeType = c.Int(nullable: false),
                        Payment_Status = c.Boolean(),
                        Order_Deliver_StatusType = c.Int(),
                        orderSourceType = c.Int(),
                        Shipping_addressId = c.Int(nullable: false),
                        Quiz_Points_Deduction = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserShippingAddress", t => t.Shipping_addressId, cascadeDelete: false)
                .Index(t => t.Shipping_addressId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        BookId = c.Int(),
                        BundleId = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bookType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId)
                .ForeignKey("dbo.BookBundle", t => t.BundleId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.BookId)
                .Index(t => t.BundleId);
            
            CreateTable(
                "dbo.UserShippingAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Address = c.String(),
                        PinCode = c.String(),
                        CountryType = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                        UserId = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        create_date = c.DateTime(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 100),
                        Password = c.String(maxLength: 200),
                        ProfilePic = c.String(maxLength: 200),
                        GenderType = c.Int(),
                        DOB = c.DateTime(storeType: "date"),
                        ClassId = c.Int(),
                        EmailID = c.String(maxLength: 100),
                        MobileNumber = c.String(),
                        IPAddress = c.String(),
                        Browser = c.String(),
                        OperatingSystem = c.String(),
                        Location = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdationDate = c.DateTime(nullable: false),
                        TotalPoint = c.Int(nullable: false),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ClassId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserQuizPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                        Answerid = c.Int(nullable: false),
                        Submit_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestion", t => t.QuizId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.QuizQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        AnswerId = c.Int(),
                        ImageUrl = c.String(),
                        Points = c.Int(nullable: false),
                        Active_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(),
                        QuizType = c.Int(nullable: false),
                        Prize = c.String(),
                        PrizeImage = c.String(),
                        is_Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestionOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        QuizId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        isAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestion", t => t.QuizId, cascadeDelete: false)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        is_Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdationDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enquiry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 12),
                        Subject = c.String(maxLength: 30),
                        Description = c.String(maxLength: 120),
                        QueryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ErrorCode = c.Int(nullable: false),
                        ErrorDate = c.DateTime(nullable: false),
                        ErrorModule = c.String(),
                        ErrorURL = c.String(),
                        ErrorSource = c.String(),
                        ErrorMessage = c.String(),
                        ErrorStackTrace = c.String(),
                        ErrorInnerException = c.String(),
                        ErrorIP = c.String(),
                        ErrorBrowser = c.String(),
                        ErrorBrowserVersion = c.String(),
                        ErrorOperatingSystem = c.String(),
                        ErrorLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventCodeImagePath",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        EventImagePath = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventCode = c.String(nullable: false, maxLength: 20),
                        EventName = c.String(nullable: false, maxLength: 20),
                        is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Class = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(maxLength: 50),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Forget_Password",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        verificationMode = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        sms_code = c.Int(nullable: false),
                        max_attempt = c.Int(nullable: false),
                        valid_time = c.DateTime(nullable: false),
                        max_attempt_unlock_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Freelance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YourName = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 12),
                        Phone = c.String(maxLength: 12),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        PinCode = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        EduQualification = c.String(maxLength: 50),
                        OthQualification = c.String(maxLength: 50),
                        Profession = c.String(maxLength: 50),
                        HowDid = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenericOTP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        mobileNo = c.String(),
                        sms_code = c.Int(nullable: false),
                        max_attempt = c.Int(nullable: false),
                        valid_time = c.DateTime(nullable: false),
                        max_attempt_unlock_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasterAcademicYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentAcademicYear = c.String(maxLength: 7),
                        LastAcademicYear = c.String(maxLength: 7),
                        CurrentEventCodes = c.String(maxLength: 80),
                        LastEventCodes = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedalImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MetaTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Link = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                        Keyword = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OlympiadList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OlympiadName = c.String(maxLength: 50),
                        FirstDate = c.String(),
                        SecondDate = c.String(),
                        LastDateOfRegistration = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Olympiads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        ImageName = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileName = c.String(nullable: false, maxLength: 50),
                        is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QPDispatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacketID = c.String(maxLength: 50),
                        ItemDescription = c.String(maxLength: 150),
                        DispatchDate = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DispatchMode = c.String(maxLength: 50),
                        CourierName = c.String(maxLength: 50),
                        ConsignmentNumber = c.String(maxLength: 50),
                        Remarks = c.String(maxLength: 200),
                        EventCode = c.String(maxLength: 15),
                        SchCode = c.String(maxLength: 15),
                        DeliveryStatus = c.String(maxLength: 50),
                        StatusDate = c.DateTime(nullable: false),
                        ReceivedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Query",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 50),
                        QueryDetail = c.String(maxLength: 200),
                        OldRef = c.Int(nullable: false),
                        QueryDate = c.DateTime(nullable: false),
                        QueryStatus = c.String(maxLength: 20),
                        CloseDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuickLink",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchCode = c.String(maxLength: 15),
                        RollNo = c.String(maxLength: 2),
                        Class = c.String(maxLength: 4),
                        Sections = c.String(maxLength: 1),
                        TotMarks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassRank = c.Int(nullable: false),
                        StateRank = c.Int(nullable: false),
                        AllIndiaRank = c.Int(nullable: false),
                        NIORollNo = c.String(maxLength: 12),
                        StudName = c.String(maxLength: 100),
                        RawScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondLevelEligible = c.Boolean(nullable: false),
                        Medal = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventYear = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: false)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.SchoolEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchCode = c.String(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventYear = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentRegistration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventCode = c.String(maxLength: 40),
                        SchCode = c.String(maxLength: 40),
                        RegSrlNo = c.Int(nullable: false),
                        ExamDateOpted = c.Int(nullable: false),
                        Class1E = c.Int(nullable: false),
                        Class2E = c.Int(nullable: false),
                        Class3E = c.Int(nullable: false),
                        Class4E = c.Int(nullable: false),
                        Class5E = c.Int(nullable: false),
                        Class6E = c.Int(nullable: false),
                        Class7E = c.Int(nullable: false),
                        Class8E = c.Int(nullable: false),
                        Class9E = c.Int(nullable: false),
                        Class10E = c.Int(nullable: false),
                        Class11EN = c.Int(nullable: false),
                        Class12EN = c.Int(nullable: false),
                        TotalE = c.Int(nullable: false),
                        Book1 = c.Int(nullable: false),
                        Book2 = c.Int(nullable: false),
                        Book3 = c.Int(nullable: false),
                        Book4 = c.Int(nullable: false),
                        Book5 = c.Int(nullable: false),
                        Book6 = c.Int(nullable: false),
                        Book7 = c.Int(nullable: false),
                        Book8 = c.Int(nullable: false),
                        Book9 = c.Int(nullable: false),
                        Book10 = c.Int(nullable: false),
                        Book11 = c.Int(nullable: false),
                        Book12 = c.Int(nullable: false),
                        BookTot = c.Int(nullable: false),
                        PreYearQP1 = c.Int(nullable: false),
                        PreYearQP2 = c.Int(nullable: false),
                        PreYearQP3 = c.Int(nullable: false),
                        PreYearQP4 = c.Int(nullable: false),
                        PreYearQP5 = c.Int(nullable: false),
                        PreYearQP6 = c.Int(nullable: false),
                        PreYearQP7 = c.Int(nullable: false),
                        PreYearQP8 = c.Int(nullable: false),
                        PreYearQP9 = c.Int(nullable: false),
                        PreYearQP10 = c.Int(nullable: false),
                        PreYearQP11 = c.Int(nullable: false),
                        PreYearQP12 = c.Int(nullable: false),
                        PreYearQPTot = c.Int(nullable: false),
                        GenXBook1 = c.Int(nullable: false),
                        GenXBook2 = c.Int(nullable: false),
                        GenXBook3 = c.Int(nullable: false),
                        GenXBook4 = c.Int(nullable: false),
                        GenXBook5 = c.Int(nullable: false),
                        GenXBook6 = c.Int(nullable: false),
                        GenXBook7 = c.Int(nullable: false),
                        GenXBook8 = c.Int(nullable: false),
                        GenXBook9 = c.Int(nullable: false),
                        GenXBook10 = c.Int(nullable: false),
                        GenXBook11 = c.Int(nullable: false),
                        GenXBook12 = c.Int(nullable: false),
                        GenXBookTot = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SchoolName = c.String(nullable: false),
                        SchoolCode = c.String(),
                        SchoolAddress = c.String(maxLength: 200),
                        PinCode = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.TeacherEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.UpdateSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(maxLength: 20),
                        UpdateLine = c.String(maxLength: 150),
                        LinkText = c.String(maxLength: 30),
                        LinkUrl = c.String(maxLength: 30),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Login_DateTime = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                        Browser = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogs", "UserId", "dbo.User");
            DropForeignKey("dbo.TeacherEvent", "UserId", "dbo.User");
            DropForeignKey("dbo.TeacherEvent", "EventId", "dbo.Event");
            DropForeignKey("dbo.TeacherDetail", "Id", "dbo.User");
            DropForeignKey("dbo.TeacherDetail", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Result", "EventId", "dbo.Event");
            DropForeignKey("dbo.Query", "UserId", "dbo.User");
            DropForeignKey("dbo.Forget_Password", "UserId", "dbo.User");
            DropForeignKey("dbo.Dispatch", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "Shipping_addressId", "dbo.UserShippingAddress");
            DropForeignKey("dbo.UserShippingAddress", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserQuizPoints", "UserId", "dbo.User");
            DropForeignKey("dbo.UserQuizPoints", "QuizId", "dbo.QuizQuestion");
            DropForeignKey("dbo.QuizQuestionOptions", "QuizId", "dbo.QuizQuestion");
            DropForeignKey("dbo.User", "ClassId", "dbo.Class");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "BundleId", "dbo.BookBundle");
            DropForeignKey("dbo.OrderDetail", "BookId", "dbo.Book");
            DropForeignKey("dbo.Dispatch", "CourierModeId", "dbo.CourierMode");
            DropForeignKey("dbo.CourierMode", "CourierId", "dbo.Courier");
            DropForeignKey("dbo.BookBundle", "ClassId", "dbo.Class");
            DropForeignKey("dbo.BookBundleDetails", "BundleId", "dbo.BookBundle");
            DropForeignKey("dbo.BookBundleDetails", "BookId", "dbo.Book");
            DropForeignKey("dbo.classSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Book", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.classSubject", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Book", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Category", "CouponId", "dbo.Coupon");
            DropForeignKey("dbo.Book", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.BookReview", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookDetail", "Id", "dbo.Book");
            DropForeignKey("dbo.BookContent", "BookId", "dbo.Book");
            DropIndex("dbo.UserLogs", new[] { "UserId" });
            DropIndex("dbo.TeacherEvent", new[] { "EventId" });
            DropIndex("dbo.TeacherEvent", new[] { "UserId" });
            DropIndex("dbo.TeacherDetail", new[] { "ProfileId" });
            DropIndex("dbo.TeacherDetail", new[] { "Id" });
            DropIndex("dbo.Result", new[] { "EventId" });
            DropIndex("dbo.Query", new[] { "UserId" });
            DropIndex("dbo.Forget_Password", new[] { "UserId" });
            DropIndex("dbo.QuizQuestionOptions", new[] { "QuizId" });
            DropIndex("dbo.UserQuizPoints", new[] { "QuizId" });
            DropIndex("dbo.UserQuizPoints", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.User", new[] { "ClassId" });
            DropIndex("dbo.UserShippingAddress", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "BundleId" });
            DropIndex("dbo.OrderDetail", new[] { "BookId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "Shipping_addressId" });
            DropIndex("dbo.Dispatch", new[] { "CourierModeId" });
            DropIndex("dbo.Dispatch", new[] { "OrderId" });
            DropIndex("dbo.CourierMode", new[] { "CourierId" });
            DropIndex("dbo.classSubject", new[] { "SubjectId" });
            DropIndex("dbo.classSubject", new[] { "ClassId" });
            DropIndex("dbo.Category", new[] { "CouponId" });
            DropIndex("dbo.BookReview", new[] { "BookId" });
            DropIndex("dbo.BookDetail", new[] { "Id" });
            DropIndex("dbo.BookContent", new[] { "BookId" });
            DropIndex("dbo.Book", new[] { "CategoryId" });
            DropIndex("dbo.Book", new[] { "SubjectId" });
            DropIndex("dbo.Book", new[] { "ClassId" });
            DropIndex("dbo.BookBundleDetails", new[] { "BookId" });
            DropIndex("dbo.BookBundleDetails", new[] { "BundleId" });
            DropIndex("dbo.BookBundle", new[] { "ClassId" });
            DropTable("dbo.UserLogs");
            DropTable("dbo.UpdateSection");
            DropTable("dbo.TeacherEvent");
            DropTable("dbo.TeacherDetail");
            DropTable("dbo.StudentRegistration");
            DropTable("dbo.SchoolEvent");
            DropTable("dbo.Result");
            DropTable("dbo.QuickLink");
            DropTable("dbo.Query");
            DropTable("dbo.QPDispatch");
            DropTable("dbo.Profile");
            DropTable("dbo.Olympiads");
            DropTable("dbo.OlympiadList");
            DropTable("dbo.MetaTag");
            DropTable("dbo.MedalImage");
            DropTable("dbo.MasterAcademicYear");
            DropTable("dbo.GenericOTP");
            DropTable("dbo.Freelance");
            DropTable("dbo.Forget_Password");
            DropTable("dbo.FeedBack");
            DropTable("dbo.Event");
            DropTable("dbo.EventCodeImagePath");
            DropTable("dbo.ErrorLogs");
            DropTable("dbo.Enquiry");
            DropTable("dbo.Role");
            DropTable("dbo.QuizQuestionOptions");
            DropTable("dbo.QuizQuestion");
            DropTable("dbo.UserQuizPoints");
            DropTable("dbo.User");
            DropTable("dbo.UserShippingAddress");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.Dispatch");
            DropTable("dbo.CourierMode");
            DropTable("dbo.Courier");
            DropTable("dbo.BookDispatch");
            DropTable("dbo.Subject");
            DropTable("dbo.classSubject");
            DropTable("dbo.Class");
            DropTable("dbo.Coupon");
            DropTable("dbo.Category");
            DropTable("dbo.BookReview");
            DropTable("dbo.BookDetail");
            DropTable("dbo.BookContent");
            DropTable("dbo.Book");
            DropTable("dbo.BookBundleDetails");
            DropTable("dbo.BookBundle");
            DropTable("dbo.Banner");
        }
    }
}
