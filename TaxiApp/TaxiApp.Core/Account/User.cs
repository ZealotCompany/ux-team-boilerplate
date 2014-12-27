using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TaxiApp.Account
{
    public abstract class User : Entity<int>
    {
        public enum GenderType
        {
            Male,
            Female
        }
        #region Account Details
        public virtual string EmailAddress { get; set; }
        
        public virtual string UserName { get; set; }
        
        public virtual string Salt { get; set; }
        
        public virtual string HashedPassword { get; set; }
        #endregion

        #region User Details
        public virtual string FirstName { get; set; }
        
        public virtual string LastName { get; set; }
        
        public virtual GenderType Gender { get; set; }
        
        public virtual DateTime BirthDate { get; set; }
        
        public virtual string Phone { get; set; }
        #endregion


    }
}