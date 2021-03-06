using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperSimple.Auth.Api.Repository
{
    
    public class User : IUser
	{
        [BsonId]
        public Guid Id                  { get; set; }
        [BsonElement]
        public Guid DomainId            { get; set; }
        [BsonElement]
        public string UserName          { get; set; }
        [BsonElement]
        public string Email             { get; set;}
        [BsonElement]
        public string Secret            { get; set; }
        [BsonElement]
        public string Key               { get; set; }
        [BsonElement]
        public Guid AuthToken           { get; set; }
        [BsonElement]
        public bool Enabled             { get; set; }
        [BsonElement]
        public List<Role> Roles         { get; set; }
        [BsonElement]
        public List<string> Claims      { get; set; }
        [BsonElement]
        public string CurrentIp         { get; set; }
        [BsonElement]
        public DateTime ?CurrentLogon   { get; set; }
        [BsonElement]
        public string LastIp            { get; set; }
        [BsonElement]
        public DateTime ?LastLogon      { get; set; }
        [BsonElement]
        public DateTime ?LastRequest    { get; set; }
        [BsonElement]
        public int LogonCount           { get; set; }
        [BsonElement]
        public DateTime CreatedAt       { get; set; }
        [BsonElement]
        public DateTime ModifiedAt      { get; set; }

        public User()
        {
            Roles = new List<Role>();
            Claims = new List<string>();
        }

        public string[] GetRoles()
        {
            var roles = new List<string> ();

            if (this.Roles != null) 
            {
                foreach (Role role in this.Roles) 
                {
                    roles.Add (role.Name);
                }
            }

            return roles.ToArray ();
        }


        public void AddRole(Role role)
        {
            if(Roles == null)
            {
                Roles = new List<Role> ();
            }

            Roles.Add (role);
        }

        public void RemoveRole(Role role)
        {
            Roles.Remove (Roles.Find (x => x.Name == role.Name));
        }

        public string[] GetClaims()
        {
            var claims = new List<string> ();

            if (Claims != null) 
            {
                claims = Claims;
            }

            if (Roles != null) 
            {
                foreach (Role role in this.Roles) 
                {
                    if (role.Claims != null) 
                    {
                        claims.AddRange (role.Claims);
                    }
                }
            }

            return claims.ToArray();
        }

        public bool InRole(string role)
        {
            if (Roles == null || Roles.Count == 0) 
            {
                return false;
            }

            foreach(Role r in Roles)
            {
                if (r.Name == role) 
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasClaim(string claim)
        {
            var claims = GetClaims ();

            if (claims == null) 
            {
                return false;
            }

            foreach(string c in claims)
            {
                if (c == claim)
                {
                    return true;
                }
            }

            return false;
        }
	}
}

