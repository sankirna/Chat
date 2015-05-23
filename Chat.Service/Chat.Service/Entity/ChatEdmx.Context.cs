﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat.Service.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ChatContext : DbContext
    {
        public ChatContext()
            : base("name=ChatContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Advertisement_Cat> Advertisement_Cat { get; set; }
        public DbSet<ChatTab> ChatTabs { get; set; }
        public DbSet<Country_State_city> Country_State_city { get; set; }
        public DbSet<Department_Master> Department_Master { get; set; }
        public DbSet<Friend_Coonnect_Tab> Friend_Coonnect_Tab { get; set; }
        public DbSet<G_CompanyMaster> G_CompanyMaster { get; set; }
        public DbSet<Group_Master> Group_Master { get; set; }
        public DbSet<Group_Member> Group_Member { get; set; }
        public DbSet<Group_Message> Group_Message { get; set; }
        public DbSet<Invite_User> Invite_User { get; set; }
        public DbSet<Meeting_Master> Meeting_Master { get; set; }
        public DbSet<Meeting_User> Meeting_User { get; set; }
        public DbSet<Notification_Tab> Notification_Tab { get; set; }
        public DbSet<Opinion_Metting_Master> Opinion_Metting_Master { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<SplashAdvMaster_1> SplashAdvMaster_1 { get; set; }
        public DbSet<SplashAdvMaster_2> SplashAdvMaster_2 { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User_Category> User_Category { get; set; }
        public DbSet<User_Master> User_Master { get; set; }
        public DbSet<Vendor_Master> Vendor_Master { get; set; }
    
        public virtual ObjectResult<Advertisement_Result> Advertisement(Nullable<int> ad_Cat_Id, string ad_Cat_Name, string ad_Cat_Reason, Nullable<System.DateTime> dttm, Nullable<int> oP)
        {
            var ad_Cat_IdParameter = ad_Cat_Id.HasValue ?
                new ObjectParameter("Ad_Cat_Id", ad_Cat_Id) :
                new ObjectParameter("Ad_Cat_Id", typeof(int));
    
            var ad_Cat_NameParameter = ad_Cat_Name != null ?
                new ObjectParameter("Ad_Cat_Name", ad_Cat_Name) :
                new ObjectParameter("Ad_Cat_Name", typeof(string));
    
            var ad_Cat_ReasonParameter = ad_Cat_Reason != null ?
                new ObjectParameter("Ad_Cat_Reason", ad_Cat_Reason) :
                new ObjectParameter("Ad_Cat_Reason", typeof(string));
    
            var dttmParameter = dttm.HasValue ?
                new ObjectParameter("Dttm", dttm) :
                new ObjectParameter("Dttm", typeof(System.DateTime));
    
            var oPParameter = oP.HasValue ?
                new ObjectParameter("OP", oP) :
                new ObjectParameter("OP", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Advertisement_Result>("Advertisement", ad_Cat_IdParameter, ad_Cat_NameParameter, ad_Cat_ReasonParameter, dttmParameter, oPParameter);
        }
    
        public virtual ObjectResult<Depatment_Result> Depatment(Nullable<int> deptId, string department, Nullable<int> createdBy, Nullable<System.DateTime> dateCreated, Nullable<int> modifyBy, Nullable<System.DateTime> datemodify, Nullable<int> isDeleted, Nullable<int> op)
        {
            var deptIdParameter = deptId.HasValue ?
                new ObjectParameter("DeptId", deptId) :
                new ObjectParameter("DeptId", typeof(int));
    
            var departmentParameter = department != null ?
                new ObjectParameter("Department", department) :
                new ObjectParameter("Department", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            var dateCreatedParameter = dateCreated.HasValue ?
                new ObjectParameter("DateCreated", dateCreated) :
                new ObjectParameter("DateCreated", typeof(System.DateTime));
    
            var modifyByParameter = modifyBy.HasValue ?
                new ObjectParameter("ModifyBy", modifyBy) :
                new ObjectParameter("ModifyBy", typeof(int));
    
            var datemodifyParameter = datemodify.HasValue ?
                new ObjectParameter("Datemodify", datemodify) :
                new ObjectParameter("Datemodify", typeof(System.DateTime));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("IsDeleted", isDeleted) :
                new ObjectParameter("IsDeleted", typeof(int));
    
            var opParameter = op.HasValue ?
                new ObjectParameter("op", op) :
                new ObjectParameter("op", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Depatment_Result>("Depatment", deptIdParameter, departmentParameter, createdByParameter, dateCreatedParameter, modifyByParameter, datemodifyParameter, isDeletedParameter, opParameter);
        }
    
        public virtual ObjectResult<sp_A_UserCatergory1_Result> sp_A_UserCatergory1(Nullable<int> coId, Nullable<int> uCatID, string uCatName, string remarks, string status, Nullable<System.DateTime> dttm, string chkSum, Nullable<int> usID, Nullable<int> coFinID, string operation)
        {
            var coIdParameter = coId.HasValue ?
                new ObjectParameter("CoId", coId) :
                new ObjectParameter("CoId", typeof(int));
    
            var uCatIDParameter = uCatID.HasValue ?
                new ObjectParameter("UCatID", uCatID) :
                new ObjectParameter("UCatID", typeof(int));
    
            var uCatNameParameter = uCatName != null ?
                new ObjectParameter("UCatName", uCatName) :
                new ObjectParameter("UCatName", typeof(string));
    
            var remarksParameter = remarks != null ?
                new ObjectParameter("Remarks", remarks) :
                new ObjectParameter("Remarks", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var dttmParameter = dttm.HasValue ?
                new ObjectParameter("Dttm", dttm) :
                new ObjectParameter("Dttm", typeof(System.DateTime));
    
            var chkSumParameter = chkSum != null ?
                new ObjectParameter("ChkSum", chkSum) :
                new ObjectParameter("ChkSum", typeof(string));
    
            var usIDParameter = usID.HasValue ?
                new ObjectParameter("UsID", usID) :
                new ObjectParameter("UsID", typeof(int));
    
            var coFinIDParameter = coFinID.HasValue ?
                new ObjectParameter("CoFinID", coFinID) :
                new ObjectParameter("CoFinID", typeof(int));
    
            var operationParameter = operation != null ?
                new ObjectParameter("operation", operation) :
                new ObjectParameter("operation", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_A_UserCatergory1_Result>("sp_A_UserCatergory1", coIdParameter, uCatIDParameter, uCatNameParameter, remarksParameter, statusParameter, dttmParameter, chkSumParameter, usIDParameter, coFinIDParameter, operationParameter);
        }
    
        public virtual ObjectResult<Sp_AdminUserMaster_Result> Sp_AdminUserMaster(string operation, Nullable<int> coID, Nullable<int> userID, string userName, string password, Nullable<int> catID, string email, string mobileNo, Nullable<int> empID, string userMode, string status, Nullable<System.DateTime> dttm, string chkSum, Nullable<int> usID, Nullable<int> lic_ID)
        {
            var operationParameter = operation != null ?
                new ObjectParameter("operation", operation) :
                new ObjectParameter("operation", typeof(string));
    
            var coIDParameter = coID.HasValue ?
                new ObjectParameter("CoID", coID) :
                new ObjectParameter("CoID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var catIDParameter = catID.HasValue ?
                new ObjectParameter("CatID", catID) :
                new ObjectParameter("CatID", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileNoParameter = mobileNo != null ?
                new ObjectParameter("MobileNo", mobileNo) :
                new ObjectParameter("MobileNo", typeof(string));
    
            var empIDParameter = empID.HasValue ?
                new ObjectParameter("EmpID", empID) :
                new ObjectParameter("EmpID", typeof(int));
    
            var userModeParameter = userMode != null ?
                new ObjectParameter("UserMode", userMode) :
                new ObjectParameter("UserMode", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var dttmParameter = dttm.HasValue ?
                new ObjectParameter("Dttm", dttm) :
                new ObjectParameter("Dttm", typeof(System.DateTime));
    
            var chkSumParameter = chkSum != null ?
                new ObjectParameter("ChkSum", chkSum) :
                new ObjectParameter("ChkSum", typeof(string));
    
            var usIDParameter = usID.HasValue ?
                new ObjectParameter("UsID", usID) :
                new ObjectParameter("UsID", typeof(int));
    
            var lic_IDParameter = lic_ID.HasValue ?
                new ObjectParameter("Lic_ID", lic_ID) :
                new ObjectParameter("Lic_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sp_AdminUserMaster_Result>("Sp_AdminUserMaster", operationParameter, coIDParameter, userIDParameter, userNameParameter, passwordParameter, catIDParameter, emailParameter, mobileNoParameter, empIDParameter, userModeParameter, statusParameter, dttmParameter, chkSumParameter, usIDParameter, lic_IDParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<UserMaster_Result> UserMaster(Nullable<int> userID, string userName, string password, Nullable<int> catId, string email, string mobileNo, string userMode, string status, Nullable<System.DateTime> dttm, Nullable<int> usID, Nullable<int> oP)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var catIdParameter = catId.HasValue ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileNoParameter = mobileNo != null ?
                new ObjectParameter("MobileNo", mobileNo) :
                new ObjectParameter("MobileNo", typeof(string));
    
            var userModeParameter = userMode != null ?
                new ObjectParameter("UserMode", userMode) :
                new ObjectParameter("UserMode", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var dttmParameter = dttm.HasValue ?
                new ObjectParameter("Dttm", dttm) :
                new ObjectParameter("Dttm", typeof(System.DateTime));
    
            var usIDParameter = usID.HasValue ?
                new ObjectParameter("UsID", usID) :
                new ObjectParameter("UsID", typeof(int));
    
            var oPParameter = oP.HasValue ?
                new ObjectParameter("OP", oP) :
                new ObjectParameter("OP", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserMaster_Result>("UserMaster", userIDParameter, userNameParameter, passwordParameter, catIdParameter, emailParameter, mobileNoParameter, userModeParameter, statusParameter, dttmParameter, usIDParameter, oPParameter);
        }
    }
}
